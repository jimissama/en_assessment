namespace EN.Client.Models
{
    public class BingMapAutoSuggestValue
    {
        public string __type { get; set; }= default!;
        public BingMapAutoSuggestAddress Address { get; set; } = default!;
        public string Name { get; set; }= default!;
    }
}