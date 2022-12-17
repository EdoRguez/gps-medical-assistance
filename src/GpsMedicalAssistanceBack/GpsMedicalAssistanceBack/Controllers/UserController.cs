using AutoMapper;
using Entities.DataTransferObjects.FaceRecognition;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.Utils;
using GpsMedicalAssistanceBack.Utils.General;
using Interfaces.Core;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GpsMedicalAssistanceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly IFaceRecognitionServiceRepository _faceRecognitionSvcRepo;

        public UserController(IRepositoryManager repo, IMapper mapper, IFaceRecognitionServiceRepository faceRecognitionSvcRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _faceRecognitionSvcRepo = faceRecognitionSvcRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repo.User.GetAllUsers(false);
            var dto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(dto);
        }

        [HttpPost("Filter")]
        public async Task<IActionResult> GetAll([FromBody] UserParameters userParameters)
        {
            var users = await _repo.User.GetAllUsers(userParameters, false);
            var dto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(dto);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            List<IncludesGeneral> includes = new List<IncludesGeneral>()
            {
                new IncludesGeneral(){ Name = "Families" },
                new IncludesGeneral(){ Name = "FavoritePlaces" }
            };

            var user = await _repo.User.GetUser(id, includes, false);

            var dto = _mapper.Map<UserDto>(user);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto dto)
        {
            var model = _mapper.Map<User>(dto);

            _repo.User.CreateUser(model);
            await _repo.SaveAsync();

            var returnUser = _mapper.Map<UserDto>(model);

            return CreatedAtRoute("GetUser", new { id = returnUser.Id }, returnUser);
        }

        [HttpPost("GetByFace")]
        public async Task<IActionResult> GetByFace([FromBody] FaceRecognitionDto dto)
        {
            IFormFile imageFile = ImageManager.Base64ToFormFile(dto.ImagePath, string.Empty);
            FaceRecognitionResult result = await _faceRecognitionSvcRepo.CheckFace(imageFile);

            if (!result.isSuccess)
                return NotFound();

            List<IncludesGeneral> includes = new List<IncludesGeneral>();
            var user = await _repo.User.GetUser((int)result.Id_User, includes, false);

            var returnUser = _mapper.Map<UserDto>(user);

            return Ok(returnUser);
        }
    }
}
