namespace EN.Client.Models
{
    public interface IBusinessAddress
    {
        string CountryRegion { get; set; }
        string Locality { get; set; }
        string AdminDistrict { get; set; }
        string CountryRegionIso2 { get; set; }
        string PostalCode { get; set; }
        string AddressLine { get; set; }
        string FormattedAddress { get; set; }
    }
}