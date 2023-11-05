using System.Collections.Specialized;
using EN.Shared;

namespace Server.Helpers
{
    public static class UriBingMapAutosuggestHelper
    {
        const string _uri = "http://dev.virtualearth.net/REST/v1/Autosuggest";
        public static string CreateQueryUri(IBingMapAutoSuggestRequest bingMapAutoSuggestRequest)
        {
            var properties = bingMapAutoSuggestRequest.GetType().GetProperties();

            NameValueCollection queryString = new NameValueCollection();

            foreach(var prop in properties)
            {
                if(prop.GetValue(bingMapAutoSuggestRequest) != null && !string.IsNullOrEmpty(prop.GetValue(bingMapAutoSuggestRequest)?.ToString()))
                    queryString.Add(prop.Name, prop.GetValue(bingMapAutoSuggestRequest).ToString());
            }
            
            var parameterString = UriQueryHelper.ToQueryString(queryString);
            return $"{_uri}{parameterString}";
        }

    }
}