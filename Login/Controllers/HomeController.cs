using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                // API adresi
                string apiUrl = "https://aigency.dev/api/v1/my-chats?access_token=a08e0786df6f4e8f";

                // Gönderilecek veri (kullanýcýdan alýnan)
                string postData = "{\"message\": \"" + message + "\"}";

                // JSON verisini StringContent olarak ayarla
                StringContent content = new StringContent(postData, System.Text.Encoding.UTF8, "application/json");

                // HttpClient oluþtur
                using (HttpClient client = new HttpClient())
                {
                    // POST isteði gönder
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Yanýt kontrolü
                    if (response.IsSuccessStatusCode)
                    {
                        // Yanýt baþarýlý ise veriyi al
                        string responseData = await response.Content.ReadAsStringAsync();
                        return Json(new { success = true, data = responseData });
                    }
                    else
                    {
                        return Json(new { success = false, message = "API isteði baþarýsýz. Status Code: " + response.StatusCode });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata oluþtu: " + ex.Message });
            }
        }
    }
}
