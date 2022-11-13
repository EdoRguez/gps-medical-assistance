using System;
namespace Entities.RequestFeatures
{
    public class AlertParameters
    {
        public int? OrderBy { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Identification { get; set; }
        public string? IdentificationType { get; set; }
        public uint? Age { get; set; }
        public DateTime? InitDate { get; set; }
        public DateTime? EndDate { get; set; }
        public uint AlertUserTypeId { get; set; }

        public List<IncludesGeneral> Includes { get; set; } = new List<IncludesGeneral>();
    }

    public enum OrderBy
    {
        CreationDate = 1
    }
}