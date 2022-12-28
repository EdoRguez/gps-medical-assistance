using Entities.Utils;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace GpsMedicalAssistanceBack.Utils.TwilioSMS
{
    public class TwilioSMS
    {
        private readonly TwilioSMSSettings _settings;

        public TwilioSMS(TwilioSMSSettings settings)
        {
            _settings = settings;
        }

        public void SendMultipleSMS(List<string> phoneNumbers, string message)
        {
            try
            {
                TwilioClient.Init(_settings.AccountSID, _settings.AuthToken);

                foreach (var number in phoneNumbers)
                {
                    MessageResource.Create(
                        body: message,
                        from: new Twilio.Types.PhoneNumber(_settings.PhoneNumber),
                        to: new Twilio.Types.PhoneNumber($"+58{number}")
                    );
                }
            }
            catch (Exception) { }
        }
    }
}