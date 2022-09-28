using AutoMapper;
using Entities.DataTransferObjects.FamilyType;
using Interfaces.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GpsMedicalAssistanceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public FamilyTypeController(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var familyTypes = await _repo.FamilyType.GetAllFamilyTypes(false);
            var dto = _mapper.Map<IEnumerable<FamilyTypeDto>>(familyTypes);

            return Ok(dto);
        }
    }
}
