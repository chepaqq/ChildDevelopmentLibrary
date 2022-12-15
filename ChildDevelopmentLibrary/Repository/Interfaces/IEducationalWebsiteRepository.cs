using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChildDevelopmentLibrary.BLL.Repository;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChildDevelopmentLibrary.BLL.Services.Interfaces
{
    public interface IEducationalWebsiteRepository
    {
        Task<IEnumerable<Child>> GetChildrenByStatus(Status period);
        Task SubscribeToProgram(int childId, int programId);
        Task StartStudying(int childId, int programId);
        Task CompleteStudying(int childId, int programId);

        Task<Child> GetChild(int cityId);
        Task<EducationalProgram> GetProgram(int programId);
        Task<bool> SaveChangesAsync();
    }
}
