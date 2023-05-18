using System.Text.Json.Serialization;

namespace TaskBoard.APITests
{
    internal class Taskss
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }


    }
}