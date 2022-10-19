using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal CurrentLocationLatitude { get; set; }

        [Required]
        public decimal CurrentLocationLongitude { get; set; }

        [Required]
        public decimal DestinationLocationLatitude { get; set; }

        [Required]
        public decimal DestinationLocationLongitude { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public ICollection<AlertUser> AlertUsers { get; set; }
    }
}
