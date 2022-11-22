using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.Alert;
using Entities.DataTransferObjects.UserAnonymous;

namespace Entities.DataTransferObjects.AlertUser
{
    public class AlertUserDto
    {
        public int Id_Alert { get; set; }
        public int? Id_User { get; set; }
        public int? Id_UserAnonymous { get; set; }
        public int Id_AlertUserType { get; set; }


        [ForeignKey(nameof(Id_Alert))]
        public AlertDto Alert { get; set; }

        [ForeignKey(nameof(Id_User))]
        public UserDto? User { get; set; }

        [ForeignKey(nameof(Id_UserAnonymous))]
        public UserAnonymousDto? UserAnonymous { get; set; }

        [ForeignKey(nameof(Id_AlertUserType))]
        public AlertUserType AlertUserType { get; set; }
    }
}
