using Entities.DataTransferObjects.AlertUser;

namespace Entities.DataTransferObjects.Alert
{
    public class AlertDto
    {
        public int Id { get; set; }
        public decimal CurrentLocationLatitude { get; set; }
        public decimal CurrentLocationLongitude { get; set; }
        public decimal DestinationLocationLatitude { get; set; }
        public decimal DestinationLocationLongitude { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<AlertUserDto> AlertUsers { get; set; }
    }
}
