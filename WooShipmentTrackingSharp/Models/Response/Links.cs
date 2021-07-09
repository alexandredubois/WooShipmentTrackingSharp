using Newtonsoft.Json;
using System.Collections.Generic;

namespace WooShipmentTrackingSharp.Models.Response
{
    public class Links
    {
        [JsonProperty("self")]
        public List<Link> Self { get; set; }

        [JsonProperty("collection")]
        public List<Link> Collection { get; set; }

        [JsonProperty("up")]
        public List<Link> Up { get; set; }
    }
}
