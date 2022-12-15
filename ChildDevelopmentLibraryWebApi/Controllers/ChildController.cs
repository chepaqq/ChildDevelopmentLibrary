using AutoMapper;
using ChildDevelopmentLibrary.BLL.Services.Interfaces;
using ChildDevelopmentLibrary.DAL.Entities;
using ChildDevelopmentLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildDevelopmentLibraryWebApi.Controllers
{
    [Route("api/Child")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IEducationalWebsiteRepository _repository;
        private readonly IMapper _mapper;

        public ChildController(IEducationalWebsiteRepository repository,
            IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{status}")]
        public async Task<ActionResult<IEnumerable<Child>>> GetChild(Status status)
        {            
            var cityEntities = await _repository.GetChildrenByStatus(status);
            return Ok(cityEntities);
        }
    }
}
