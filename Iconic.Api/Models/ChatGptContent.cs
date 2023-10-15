using Newtonsoft.Json;

namespace Iconic.Api.Models
{
    public class ChatGptContent
    {
        public string Text { get; set; }
        public string Index { get; set; }
        public string Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}