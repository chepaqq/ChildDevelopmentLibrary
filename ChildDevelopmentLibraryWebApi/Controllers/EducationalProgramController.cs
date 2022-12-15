using AutoMapper;
using ChildDevelopmentLibrary.BLL.Repository;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildDevelopmentLibraryWebApi.Controllers
{
    [Route("api/EducationalProgram")]
    [ApiController]
    public class EducationalProgramController : ControllerBase
    {
        private readonly IEducationalWebsiteRepository _repository;
        private readonly IMapper _mapper;

        public EducationalProgramController(IEducationalWebsiteRepository repository,
            IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("SubscribeToProgram/child/{childId}/program/{programId}")]
        public async Task<ActionResult> SubscribeToProgram(int childId, int programId)
        {
            await _repository.SubscribeToProgram(childId, programId);
            
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("StartStudying/child/{childId}/program/{programId}")]
        public async Task<ActionResult> StartStudying(int childId, int programId)
        {
            await _repository.StartStudying(childId, programId);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("CompleteStudying/child/{childId}/program/{programId}")]
        public async Task<ActionResult> CompleteStudying(int childId, int programId)
        {
            await _repository.CompleteStudying(childId, programId);

            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
