using Newtonsoft.Json;

namespace WooShipmentTrackingSharp.Models.Response
{
    public class Link
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
