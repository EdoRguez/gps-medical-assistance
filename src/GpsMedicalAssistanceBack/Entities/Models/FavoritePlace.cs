using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FavoritePlace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_User { get; set; }

        [Required]
        [StringLength(350)]
        public string Name { get; set; }

        [Required]
        public decimal Latitude { get; set; }
        
        [Required]
        public decimal Longitude { get; set; }

        [ForeignKey(nameof(Id_User))]
        public User User { get; set; }
    }
}
