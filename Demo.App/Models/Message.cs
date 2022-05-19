using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace Demo.App.Models
{
    public class Message
    {
        [JsonPropertyName("SentTime")]
        public DateTime SentTime { get; set; }

        [JsonPropertyName("Receiver")]
        public string Receiver { get; set; }

        [JsonPropertyName("PhoneNumber")]
        public int PhoneNumber { get; set; }

        [JsonPropertyName("FileName")]
        public string FileName { get; set; }

    }
}
