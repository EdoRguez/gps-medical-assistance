using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects.User;

namespace Entities.DataTransferObjects.FavoritePlace
{
    public class FavoritePlaceDto
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public UserDto User { get; set; }
    }
}
