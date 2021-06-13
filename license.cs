using System;
using System.Text.Json.Serialization;

namespace WebApiClient 
{
    public class License 
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

    }
}