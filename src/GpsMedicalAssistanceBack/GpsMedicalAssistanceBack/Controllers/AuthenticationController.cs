using AutoMapper;
using Entities.DataTransferObjects.Authentication;
using Entities.DataTransferObjects.User;
using Entities.Models;
using GpsMedicalAssistanceBack.Utils.Authentication;
using GpsMedicalAssistanceBack.Utils.General;
using Interfaces.Core;
using Microsoft.AspNetCore.Mvc;

namespace GpsMedicalAssistanceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public AuthenticationController(IRepositoryManager repo, IMapper mapper, IWebHostEnvironment env)
        {
            _repo = repo;
            _mapper = mapper;
            _env = env;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationLoginDto dto)
        {
            var user = await _repo.Authentication.Login(dto.Email, dto.Password);

            if (user == null)
                return Unauthorized();

            var dtoUser = _mapper.Map<UserDto>(user);

            return Ok(dtoUser);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationRegisterDto dto)
        {
            dto.User.Email = dto.User.Email.ToLower().Trim();

            if (await _repo.Authentication.UserExists(dto.User.Email))
            {
                ModelState.AddModelError(AuthenticationSettings.FieldEmail, AuthenticationSettings.ErrorMessageUserAlreadyExists);
                return BadRequest(ModelState);
            }

            var familyTypeIds = dto.User.Families.Select(x => x.Id_FamilyType).ToList();
            if(!(await _repo.FamilyType.AreIdsValid(familyTypeIds)))
            {
                ModelState.AddModelError(AuthenticationSettings.FieldFamilies, AuthenticationSettings.ErrorMessageFamiliesIdFamilyType);
                return BadRequest(ModelState);
            }

            string? imagePath = ImageManager.Base64ToImagePath(dto.User.ImagePath, string.Format("{0}-User", Guid.NewGuid()), "UserFaceImage", _env);

            if(string.IsNullOrEmpty(imagePath))
            {
                ModelState.AddModelError(AuthenticationSettings.FieldImagePath, AuthenticationSettings.ErrorMessageImagePath);
                return BadRequest(ModelState);
            }

            dto.User.ImagePath = imagePath;

            User userToCreate = _mapper.Map<User>(dto.User);
            var createdUser = await _repo.Authentication.Register(userToCreate, dto.Password);
            await _repo.SaveAsync();

            var dtoUser = _mapper.Map<UserDto>(createdUser);

            return Ok(dtoUser);
        }
    }
}
