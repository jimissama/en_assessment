namespace EN.Client.Models
{
    public class BingMapAutoSuggestAddress
    {
        public string CountryRegion { get; set; } = default!;
        public string Locality { get; set; } = default!;
        public string AdminDistrict { get; set; } = default!;
        public string AdminDistrict2 { get; set; } = default!;
        public string CountryRegionIso2 { get; set; } = default!;
        public string Neighborhood { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string AddressLine { get; set; } = default!;
        public string FormattedAddress { get; set; } = default!;
        public string HouseNumber { get; set; } = default!;
        public string StreetName { get; set; } = default!;
    }
}