using System.Text.Json.Serialization;

namespace WebApiClient 
{
    public class SurveyDefAttribute 
    {
        [JsonPropertyName("surveyDef")]
        public string SurveyDef { get; set; }
    }
}