using System.Text.Json.Serialization;

namespace Demo.App.Models
{
    public class Receiver
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("NameSurname")]
        public string NameSurname { get; set; }

        [JsonPropertyName("Number")]
        public int Number { get; set; }

    }
}
