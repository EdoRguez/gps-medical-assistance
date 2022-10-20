using AutoMapper;
using Entities.DataTransferObjects.Alert;
using Interfaces.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GpsMedicalAssistanceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public AlertController(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlertCreateDto dto)
        {


            //return CreatedAtRoute("GetAlert", new { id = returnUser.Id }, returnUser);
            return Ok();
        }
    }
}
