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

                // G�nderilecek veri (kullan�c�dan al�nan)
                string postData = "{\"message\": \"" + message + "\"}";

                // JSON verisini StringContent olarak ayarla
                StringContent content = new StringContent(postData, System.Text.Encoding.UTF8, "application/json");

                // HttpClient olu�tur
                using (HttpClient client = new HttpClient())
                {
                    // POST iste�i g�nder
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Yan�t kontrol�
                    if (response.IsSuccessStatusCode)
                    {
                        // Yan�t ba�ar�l� ise veriyi al
                        string responseData = await response.Content.ReadAsStringAsync();
                        return Json(new { success = true, data = responseData });
                    }
                    else
                    {
                        return Json(new { success = false, message = "API iste�i ba�ar�s�z. Status Code: " + response.StatusCode });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata olu�tu: " + ex.Message });
            }
        }
    }
}
