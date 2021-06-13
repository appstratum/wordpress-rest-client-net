using System.Text.Json.Serialization;

namespace WebApiClient 
{
    public class RenderedAttribute 
    {
        [JsonPropertyName("rendered")]
        public string Rendered { get; set; }
    }
}