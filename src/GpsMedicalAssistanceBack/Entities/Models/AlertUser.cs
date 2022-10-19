using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AlertUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Alert { get; set; }

        [Required]
        public int Id_User { get; set; }

        [Required]
        public int Id_AlertUserType { get; set; }


        [ForeignKey(nameof(Id_Alert))]
        public Alert Alert { get; set; }

        [ForeignKey(nameof(Id_User))]
        public User User { get; set; }

        [ForeignKey(nameof(Id_AlertUserType))]
        public AlertUserType AlertUserType { get; set; }
    }
}
