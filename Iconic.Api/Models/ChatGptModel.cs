using System.Collections.Generic;

namespace Iconic.Api.Models
{
    public class ChatGptModel
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public int Created { get; set; }
        public string Model { get; set; }
        public List<ChatGptContent> Choices { get; set; }
    }
}