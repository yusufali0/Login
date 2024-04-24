using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Genius()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> SendMessage(string message)
        {
            try
            {
                // API URL
                var loginApiUrl = "https://aigency.dev/api/v1/login/";

                // Login form data
                var loginFormData = new FormUrlEncodedContent(new[]
                {
                 new KeyValuePair<string, string>("email", "yusuf2979@gmail.com"),
                new KeyValuePair<string, string>("password", "63634488yY")
                });

                using (var httpClient = new HttpClient())
                {
                    // Login isteði
                    var loginResponse = await httpClient.PostAsync(loginApiUrl, loginFormData);

                    if (!loginResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Login Error: {loginResponse.StatusCode}");
                        return Content($"Login Error: {loginResponse.StatusCode}");
                    }

                    var loginContent = await loginResponse.Content.ReadAsStringAsync();
                    

                    var loginJson = JObject.Parse(loginContent);

                    var accessToken = loginJson["access_token"]?.ToString();

                    if (string.IsNullOrEmpty(accessToken))
                    {
                        Console.WriteLine("Error parsing access_token.");
                        return Content("Error parsing access_token.");
                    }

                    // SendMessage API URL
                    var sendMessageApiUrl = "https://aigency.dev/api/v1/sendMessage";

                    // SendMessage form data
                    var sendMessageFormData = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("access_token", "a08e0786df6f4e8f"),  
                    new KeyValuePair<string, string>("chat_id", "thread_66108518b8e5a1.18914117"),
                    new KeyValuePair<string, string>("message", message) 
                    });

                    // SendMessage isteði
                    var sendMessageResponse = await httpClient.PostAsync(sendMessageApiUrl, sendMessageFormData);

                    if (sendMessageResponse.IsSuccessStatusCode)
                    {
                        var sendMessageContent = await sendMessageResponse.Content.ReadAsStringAsync();
                        return Content(sendMessageContent);
                    }
                    else
                    {
                        Console.WriteLine($"SendMessage Error: {sendMessageResponse.StatusCode}");
                        return Content($"SendMessage Error: {sendMessageResponse.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Content($"Error: {ex.Message}");
            }


        }
    }
}

