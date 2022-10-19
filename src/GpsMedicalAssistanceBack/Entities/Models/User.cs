using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string Identification { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [StringLength(300)]
        public string? ImagePath { get; set; }

        public ICollection<Family> Families { get; set; }
        public ICollection<FavoritePlace> FavoritePlaces { get; set; }
        public ICollection<AlertUser> AlertUsers { get; set; }
    }
}
