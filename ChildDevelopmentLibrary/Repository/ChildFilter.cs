using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ChildDevelopmentLibrary.BLL.Repository
{
    public class ChildFilter
    {
        //public static List<ChildDto> FilterByStatus(IEnumerable<ChildDto> children, Status period) =>
        //    children.Where(m => m.Status == period).ToList();

        public static async Task<IEnumerable<Child>> FilterByStatus(DbSet<Child> children, Status period) =>
            await children.Where(m => m.Status == period).ToArrayAsync();
    }
}
