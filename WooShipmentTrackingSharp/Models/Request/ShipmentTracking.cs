using Newtonsoft.Json;

namespace WooShipmentTrackingSharp.Models.Request
{
    public abstract class ShipmentTracking
    {
        /// <summary>
        /// Tracking provider. See the woocommerce plugin doc for the complete list. 
        /// </summary>
        [JsonProperty("tracking_provider")]
        public string TrackingProvider { get; protected set; }

        /// <summary>
        /// Tracking number
        /// </summary>
        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }
    }
}
