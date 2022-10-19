using AutoMapper;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces.Core;
using Microsoft.AspNetCore.Mvc;

namespace GpsMedicalAssistanceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public UserController(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserParameters userParameters)
        {
            var users = await _repo.User.GetAllUsers(userParameters, false);
            var dto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(dto);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            List<string> includes = new List<string>
            {
                "Families",
                "FavoritePlaces"
            };

            var user = await _repo.User.GetUser(id, includes, false);

            var dto = _mapper.Map<UserDto>(user);

            return Ok(dto);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto dto)
        {
            var model = _mapper.Map<User>(dto);
            
            _repo.User.CreateUser(model);
            await _repo.SaveAsync();

            var returnUser = _mapper.Map<UserDto>(model);

            return CreatedAtRoute("GetUser", new { id = returnUser.Id }, returnUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
