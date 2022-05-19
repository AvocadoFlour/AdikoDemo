using Demo.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Demo.App.Controllers
{
    public class HomeController : Controller
    {

        // Demo.APi url http://localhost:5081
        string baseUrl = "http://localhost:5081";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            List<Receiver> receiversInfo = new List<Receiver>();
            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define rquest data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Receivers");
                if (res.IsSuccessStatusCode)
                {
                    // Storing the response
                    var recResponse = res.Content.ReadAsStringAsync().Result;
                    // Deserializing the response
                    receiversInfo = JsonConvert.DeserializeObject <List<Receiver>>(recResponse);
                }
            }
            ViewBag.Receivers = receiversInfo;
            return View(receiversInfo);
        }

        public async Task<ActionResult> SendMessage(List<int> recipients, string messageContent)
        {
            foreach(int recipient in recipients)
            {

            }
            return View("SuccesS");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}