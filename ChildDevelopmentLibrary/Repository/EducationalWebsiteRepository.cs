using Couchbase.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildDevelopmentLibrary.Models;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.Interfaces;
using ChildDevelopmentLibrary.DAL.DBContext;
using ChildDevelopmentLibrary.DAL.Entities;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChildDevelopmentLibrary.BLL.Repository
{
    public class EducationalWebsiteRepository : IEducationalWebsiteRepository
    {
        private readonly DBWebsite _context;

        public EducationalWebsiteRepository(DBWebsite context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task SubscribeToProgram(int childId, int programId)
        {
            if (childId > 0)
            {
                try
                {
                    var childEdit = await GetChild(childId);
                    var programEdit = await GetProgram(programId);

                    if (childEdit.Status == Status.CompletedStudies
                        && childEdit != null
                        && programEdit != null)
                    {
                        childEdit.Status = Status.Signed;
                        programEdit.Children.Add(childEdit);
                    }
                }
                catch (Exception e)
                {
                    throw new InvalidArgumentException(e.Message);
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }

        }
        public async Task StartStudying(int childId, int programId)
        {
            if (childId > 0)
            {
                try
                {
                    var programEdit = await GetProgram(programId);
                    var childEdit = await GetChild(childId);

                    if (childEdit.Status == Status.Signed
                        && childEdit != null
                        && programEdit != null)
                    {
                        if (childEdit.ProgramId == programId)
                        {
                            childEdit.Status = Status.IsStudying;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new InvalidArgumentException(e.Message);
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }
        }

        public async Task CompleteStudying(int childId, int programId)
        {
            if (childId > 0)
            {
                try
                {
                    var programEdit = await GetProgram(programId);
                    var childEdit = await GetChild(childId);

                    if (childEdit.Status == Status.IsStudying
                        && childEdit != null
                        && programEdit != null)
                    {
                        if (childEdit.ProgramId == programId)
                        {
                            childEdit.Status = Status.CompletedStudies;
                            programEdit.Children.Remove(childEdit);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new InvalidArgumentException(e.Message);
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }
        }

        public async Task<IEnumerable<Child>> GetChildrenByStatus(Status period)
        {
            try
            {
                return await ChildFilter.FilterByStatus(_context.Children, period);
            }
            catch (Exception e)
            {
                throw new InvalidArgumentException(e.Message);
            }
        }

        public async Task<Child> GetChild(int cityId)
        {
            return await _context.Children
                  .Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<EducationalProgram> GetProgram(int programId)
        {
            return await _context.Programs
                  .Where(c => c.Id == programId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
