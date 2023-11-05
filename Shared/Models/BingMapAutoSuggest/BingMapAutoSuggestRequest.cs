namespace EN.Shared
{
    public class BingMapAutoSuggestRequest :IBingMapAutoSuggestRequest
    {
        public string query { get; set; }= string.Empty;
        public string userLocation { get; set; }= string.Empty;
        public string userCircularMapView { get; set; }= string.Empty;
        public string userMapView { get; set; }= string.Empty;
        public string maxResults { get; set; }= string.Empty;
        public string includeEntityTypes { get; set; }= string.Empty;
        public string culture { get; set; }= string.Empty;
        public string userRegion { get; set; }= string.Empty;
        public string countryFilter { get; set; }= string.Empty;
        public string output { get; set; }= string.Empty;
        public string key { get; set; }= string.Empty;
    }
}