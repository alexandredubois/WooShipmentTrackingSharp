namespace WooShipmentTrackingSharp.Models.Request
{
    public class SupportedShipmentTracking : ShipmentTracking
    {
        /// <summary>
        /// Shipment tracking for a natively supported provider
        /// </summary>
        /// <param name="provider">Name of the provider (see woocommerce plugin documentation</param>
        /// <param name="trackingNumber">Parcel tracking number</param>
        public SupportedShipmentTracking(string provider, string trackingNumber)
        {
            TrackingProvider = provider;
            TrackingNumber = trackingNumber;
        }
    }
}
