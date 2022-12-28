using AutoMapper;
using Entities.DataTransferObjects.Alert;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.Utils;
using GpsMedicalAssistanceBack.Utils.TwilioSMS;
using Interfaces.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GpsMedicalAssistanceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly TwilioSMSSettings _twilioSMSSettings;

        public AlertController(IRepositoryManager repo, IMapper mapper, IOptions<TwilioSMSSettings> twilioSMSSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _twilioSMSSettings = twilioSMSSettings.Value;
        }

        [HttpPost("Filter")]
        public async Task<IActionResult> GetAll([FromBody] AlertParameters parameters)
        {
            var alerts = await _repo.Alert.GetAll(parameters, false);

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
                        new IncludesGeneral() { Name = "User" },
                        new IncludesGeneral() { Name = "UserAnonymous"}
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

            var alertUser = dto.AlertUsers.FirstOrDefault(x => x.Id_AlertUserType == 2 && x.Id_User != null);
            if(alertUser != null)
            {
                List<IncludesGeneral> includes = new List<IncludesGeneral>()
                {
                    new IncludesGeneral() { Name = "Families" }
                };

                var user = await _repo.User.GetUser((int)alertUser.Id_User, includes, false);

                if(user != null && user.Families != null)
                {
                    string smsMessage = $"ALERTA - Gps Medical Assistance \n\n {user.Name} sufrió un accidente \n\n Para más detalles visita http://localhost:4200/alerts/{model.Id}";

                    List<string> familyPhoneNumbers = user.Families.Select(x => x.Phone.Replace("-", string.Empty)).ToList();

                    TwilioSMS twilio = new TwilioSMS(_twilioSMSSettings);
                    twilio.SendMultipleSMS(familyPhoneNumbers, smsMessage);
                }
            }

            var returnAlert = _mapper.Map<AlertDto>(model);

            return CreatedAtRoute(nameof(GetAlert), new { id = returnAlert.Id }, returnAlert);
        }
    }
}
