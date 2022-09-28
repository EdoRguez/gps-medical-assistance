using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Family
{
    public class FamilyCreateDto
    {
        [Required]
        public int Id_FamilyType { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string LastName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 2)]
        public string Identification { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 11)]
        public string Phone { get; set; }
    }
}
