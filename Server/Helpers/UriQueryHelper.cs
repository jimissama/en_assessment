using System.Collections.Specialized;
using System.Web;

namespace Server.Helpers
{
    public static class UriQueryHelper
    {

        /// <summary>
        /// Creates uri query string
        /// </summary>
        /// <param name="valueCollection">query parametes' collection</param>
        /// <returns>parameters' query string</returns>
        public static string ToQueryString(NameValueCollection valueCollection)
        {
            var array = (
                from key in valueCollection.AllKeys
                from value in valueCollection.GetValues(key)
                select string.Format(
            "{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
                ).ToArray();
            return "?" + string.Join("&", array);
        }

    }
}