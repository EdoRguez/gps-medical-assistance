using Entities.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Authentication
{
    public class AuthenticationRegisterDto
    {
        [Required]
        public UserCreateDto User { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
