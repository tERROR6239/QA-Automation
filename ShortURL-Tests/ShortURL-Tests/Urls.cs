using System.Text.Json.Serialization;
namespace ShortURL_Tests
{
    public class Urlss
    {
        [JsonPropertyName("url")]
        public string urll { get; set; }

        [JsonPropertyName("shortCode")]
        public string shortCode { get; set; }

        [JsonPropertyName("shortUrl")]
        public string shortUrl { get; set; }

        [JsonPropertyName("dateCreated")]
        public string dateCreated { get; set; }

        [JsonPropertyName("visits")]
        public int visits { get; set; }

 

    }
}