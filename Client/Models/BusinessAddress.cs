namespace EN.Client.Models
{
    public class BusinessAddress
    {
        public string CountryRegion { get; set; } = default!;
        public string Locality { get; set; }= default!;
        public string AdminDistrict { get; set; }= default!;
        public string CountryRegionIso2 { get; set; }= default!;
        public string PostalCode { get; set; }= default!;
        public string AddressLine { get; set; }= default!;
        public string FormattedAddress { get; set; }= default!;
    }
}