using Newtonsoft.Json;

namespace RestClient.Core.Models
{
    public class GeoIpData
    {
        [JsonProperty("ip")] 
        public string Ip;

        [JsonProperty("country_code")]
        public string CountryCode;
    }
}