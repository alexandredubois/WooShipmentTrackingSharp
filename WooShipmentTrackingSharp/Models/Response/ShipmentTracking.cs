using Newtonsoft.Json;

namespace WooShipmentTrackingSharp.Models.Response
{
    public class ShipmentTracking
    {
        [JsonProperty("tracking_id")]
        public string TrackingId { get; set; }

        [JsonProperty("tracking_provider")]
        public string TrackingProvider { get; set; }

        [JsonProperty("tracking_link")]
        public string TrackingLink { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("date_shipped")]
        public string DateShipped { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
