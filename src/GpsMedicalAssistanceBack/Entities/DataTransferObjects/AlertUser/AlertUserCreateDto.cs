using Entities.DataTransferObjects.Alert;
using Entities.DataTransferObjects.User;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects.UserAnonymous;

namespace Entities.DataTransferObjects.AlertUser
{
    public class AlertUserCreateDto
    {
        public int? Id_User { get; set; }
        public UserAnonymousCreateDto? UserAnonymous { get; set; }

        [Required]
        public int Id_AlertUserType { get; set; }
    }
}
