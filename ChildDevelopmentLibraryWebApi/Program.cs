using ChildDevelopmentLibrary.BLL.Repository;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.DBContext;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.DAL.Interfaces;
using ChildDevelopmentLibraryWebApi.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBWebsite>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<DataSeeder>();

builder.Services.AddScoped<IEducationalWebsiteRepository, EducationalWebsiteRepository>();
builder.Services.AddScoped<IDBWebsite, DBWebsite>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//Seeder
var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var service = scope.ServiceProvider.GetService<DataSeeder>();
    service.Initial();
}


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DBWebsite>();
    db.Database.Migrate();
}
app.Run();