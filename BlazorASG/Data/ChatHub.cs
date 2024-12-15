using Microsoft.AspNetCore.SignalR;
namespace BlazorASG.Data
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
    public class AIService
    {
        private readonly HttpClient _httpClient;

        public AIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAIResponse(string prompt)
        {
            // قم بإرسال الطلب إلى API الذكاء الاصطناعي
            return $"رد الذكاء الاصطناعي على: {prompt}";
        }
    }

}
