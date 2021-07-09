using Newtonsoft.Json;

namespace WooShipmentTrackingSharp.Models.Request
{
    /// <summary>
    /// If our shipment tracking provider is not natively supported by the plugin, you can add a custom
    /// shipment tracking, posting the number AND the tracking link
    /// </summary>
    public class CustomShipmentTracking : ShipmentTracking
    {
        [JsonProperty("custom_tracking_link")]
        public string CustomTrackingLink { get; private set; }

        /// <summary>
        /// Shipment tracking entry for a non supported tracking provider
        /// </summary>
        /// <param name="trackingNumber">Tracking number</param>
        /// <param name="trackingLink">Tracking link with %1$s placeholder for the tracking number</param>
        public CustomShipmentTracking(string trackingNumber, string trackingLink)
        {
            TrackingProvider = "Custom";
            TrackingNumber = trackingNumber;
            CustomTrackingLink = trackingLink;
        }
    }
}
