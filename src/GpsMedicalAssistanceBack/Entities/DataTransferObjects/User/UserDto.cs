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
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
        public ICollection<FamilyDto> Families { get; set; }
        public ICollection<FavoritePlaceDto> FavoritePlaces { get; set; }
    }
}
