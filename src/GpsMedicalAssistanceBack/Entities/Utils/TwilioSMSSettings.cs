namespace Entities.Utils
{
    public class TwilioSMSSettings
    {
        public const string SectionName = "TwilioSMSSettings";
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
    }
}