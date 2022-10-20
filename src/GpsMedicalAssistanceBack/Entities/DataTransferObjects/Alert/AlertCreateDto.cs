using Entities.DataTransferObjects.AlertUser;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Alert
{
    public class AlertCreateDto
    { 
        [Required]
        public decimal CurrentLocationLatitude { get; set; }

        [Required]
        public decimal CurrentLocationLongitude { get; set; }

        [Required]
        public decimal DestinationLocationLatitude { get; set; }

        [Required]
        public decimal DestinationLocationLongitude { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public ICollection<AlertUserCreateDto> AlertUsers { get; set; }
    }
}
