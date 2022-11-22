namespace Entities.RequestFeatures
{
    public class IncludesGeneral
    {
        public string Name { get; set; } = null!;
        public List<IncludesGeneral> Children { get; set; } = new List<IncludesGeneral>();
    }
}
