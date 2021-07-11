using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WooShipmentTrackingSharp
{
    public class WooSite
    {
        private string _url;

        private string _key;

        private string _secret;

        const string apiUrlTemplate = "{0}/wp-json/wc-shipment-tracking/v3/orders/{1}/shipment-trackings";

        private HttpClient _client;

        public WooSite(string url, string key, string secret)
        {
            _url = url;
            _key = key;
            _secret = secret;

            _client = new HttpClient();
            var authenticationBytes = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", key, secret));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationBytes));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public Models.Response.ShipmentTracking CreateShipmentTracking(int orderId, Models.Request.ShipmentTracking shipmentTracking)
        {
            var request_json = JsonConvert.SerializeObject(shipmentTracking);
            var content = new StringContent(request_json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync(string.Format(apiUrlTemplate, _url, orderId), content);
            Debug.WriteLine(string.Format(apiUrlTemplate, _url, orderId));
            _client.PostAsync("https://webhook.site/8a2fe5ba-25af-474c-8dcc-caef11846dd6", content);

            var stringResult = response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Models.Response.ShipmentTracking>(stringResult.Result);
            return result;
        }

        public Models.Response.ShipmentTracking RetrieveShipmentTracking(int orderId, string trackingId)
        {
            var response = _client.GetAsync(string.Format(apiUrlTemplate + "/" + trackingId, _url, orderId));
            var stringResult = response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Models.Response.ShipmentTracking>(stringResult.Result);
            return result;
        }

        public List<Models.Response.ShipmentTracking> RetrieveAllShipmentTrackings(int orderId)
        {
            var response = _client.GetAsync(string.Format(apiUrlTemplate + "/", _url, orderId));
            var stringResult = response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Models.Response.ShipmentTracking>>(stringResult.Result);
            return result;
        }

        public void DeleteShipmentTracking(int orderId, string trackingId)
        {
            _client.DeleteAsync(string.Format(apiUrlTemplate + "/" + trackingId, _url, orderId));
        }

    }
}
