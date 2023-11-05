namespace EN.Shared
{
    public interface IBingMapAutoSuggestRequest
    {
        
        string query { get; set; }
        string userLocation { get; set; }
        string userCircularMapView { get; set; }
        string userMapView { get; set; }
        string maxResults { get; set; }
        string includeEntityTypes { get; set; }
        string culture { get; set; }
        string userRegion { get; set; }
        string countryFilter { get; set; }
        string output { get; set; }
        string key { get; set; }
    }
}