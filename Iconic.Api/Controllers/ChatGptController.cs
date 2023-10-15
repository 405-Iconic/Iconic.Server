using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Iconic.Api.Models;

namespace Iconic.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class ChatGptController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Responce(string query)
        {
            // Your OpenAI API key
            string apiKey = "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";

            // The API endpoint for the ChatGPT API
            string apiUrl = "https://api.openai.com/v1/chat/completions";

            // Create a request object
            var request = new
            {
                messages = new[]
                {
                new
                {
                    role = "system",
                    content = "You are a helpful assistant."
                },
                new
                {
                    role = "user",
                    content = query
                }
            }
            };

            // Serialize the request object to JSON
            string requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(request);

            using (var httpClient = new HttpClient())
            {
                // Set the API key in the request headers
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Send a POST request to the ChatGPT API
                var response = await httpClient.PostAsync(apiUrl, new StringContent(requestBody, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Error";
                }
            }
        }

    }
}
