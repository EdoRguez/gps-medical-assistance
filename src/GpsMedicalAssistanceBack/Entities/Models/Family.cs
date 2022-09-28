using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Family
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_User { get; set; }

        [Required]
        public int Id_FamilyType { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(11)]
        public string Identification { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }


        [ForeignKey(nameof(Id_User))]
        public User User { get; set; }

        [ForeignKey(nameof(Id_FamilyType))]
        public FamilyType FamilyType { get; set; }
    }
}
