using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildDevelopmentLibrary.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ASP.NET Core 7" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "PHP" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Java" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "FirstName", "LastName", "ProgramId", "Status" },
                values: new object[,]
                {
                    { 1, "Igor", "Radchuk", 1, 2 },
                    { 2, "Petro", "Ostapchuk", 1, 2 },
                    { 3, "Ivan", "Chug", 1, 2 },
                    { 4, "Andriy", "Oshuta", 1, 2 },
                    { 5, "Nazar", "Melnyk", 1, 2 },
                    { 6, "Dmitro", "Honchar", 1, 2 },
                    { 7, "Stepan", "Bandera", 1, 2 },
                    { 8, "Taras", "Shevchenko", 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_ProgramId",
                table: "Children",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
