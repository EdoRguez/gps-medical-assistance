using Entities.DataTransferObjects.Family;
using Entities.DataTransferObjects.FavoritePlace;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public abstract class UserManipulationDto
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 2)]
        public string Identification { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 11)]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [MinLength(2)]
        public ICollection<FamilyCreateDto> Families { get; set; }

        [Required]
        [MinLength(1)]
        public ICollection<FavoritePlaceCreateDto> FavoritePlaces { get; set; }
    }
}
