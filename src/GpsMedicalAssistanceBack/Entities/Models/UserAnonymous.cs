using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class UserAnonymous
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(11)]
        public string Identification { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [Range(0, short.MaxValue)]
        public short? Age { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }

        [Range(0, float.MaxValue)]
        public float? Height { get; set; }

        public AlertUser AlertUser { get; set; }
    }
}