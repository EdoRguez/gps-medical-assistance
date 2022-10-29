using AutoMapper;
using Entities.DataTransferObjects.Alert;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
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

        [HttpPost("Filter")]
        public async Task<IActionResult> GetAll([FromBody] AlertParameters parameters)
        {
            var alerts = await _repo.Alert.GetAll(parameters.Includes, false);

            var dto = _mapper.Map<IEnumerable<AlertDto>>(alerts);

            return Ok(dto);
        }

        [HttpGet("{id}", Name = "GetAlert")]
        public async Task<IActionResult> GetAlert(int id)
        {
            List<IncludesGeneral> includes = new()
            {
                new IncludesGeneral()
                {
                    Name = "AlertUsers",
                    Children =  new List<IncludesGeneral>()
                    {
                        new IncludesGeneral() { Name = "User" }
                    }
                }
            };

            var alert = await _repo.Alert.Get(id, includes, false);

            var dto = _mapper.Map<AlertDto>(alert);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlertCreateDto dto)
        {
            var model = _mapper.Map<Alert>(dto);

            _repo.Alert.CreateAlert(model);
            await _repo.SaveAsync();

            var returnAlert = _mapper.Map<AlertDto>(model);

            return CreatedAtRoute(nameof(GetAlert), new { id = returnAlert.Id }, returnAlert);
        }
    }
}
