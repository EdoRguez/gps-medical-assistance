namespace Entities.RequestFeatures
{
    public class IncludesGeneral
    {
        public string Name { get; set; }
        public List<IncludesGeneral> Children { get; set; } = new List<IncludesGeneral>();
    }
}
