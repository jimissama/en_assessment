namespace Server.Models
{
    public class BingMapBusinessAutoResponse
    {
        public List<BingMapAutoSuggestresourceSet> resourceSets { get; set; } = default!;
    }

    public class BingMapAutoSuggestresourceSet
    {
        public List<BingMapAutoSuggestResource> resources { get; set; }= default!;
    }

    public class BingMapAutoSuggestResource
    {
        public List<BingMapAutoSuggestValue> value { get; set; }= default!;
    }

    public class BingMapAutoSuggestValue
    {
        public BingMapAutoSuggestAddress address { get; set; }= default!;
    }

    public class BingMapAutoSuggestAddress
    {   public string countryRegion { get; set; }= default!;
        public string locality { get; set; }= default!;
        public string adminDistrict { get; set; }= default!;
        public string countryRegionIso2 { get; set; }= default!;
        public string postalCode { get; set; }= default!;
        public string addressLine { get; set; }= default!;
        public string formattedAddress { get; set; }= default!;
    }
}