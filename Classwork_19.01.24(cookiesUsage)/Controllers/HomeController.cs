using Classwork_19._01._24_cookiesUsage_.Interfaces;
using Classwork_19._01._24_cookiesUsage_.Models;
using Classwork_19._01._24_cookiesUsage_.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Classwork_19._01._24_cookiesUsage_.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsRepository newsRepository;
        private readonly UserRepository userRepository;

        public HomeController(NewsRepository newsRepository, UserRepository userRepository)
        {
            this.newsRepository = newsRepository;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("userid"))
            {
                var allUsers = userRepository.GetAllUsers();
                return View("Index", allUsers);
            }
            else
            {
                return RedirectToAction("Main");
            }
        }

        public IActionResult SetUser(int id)
        {
            HttpContext.Response.Cookies.Append("userid", id.ToString());
            return RedirectToAction("Main");
        }

         //1 Without @inject directive
        /*public IActionResult Main()
        {
            string backgroundColor = "";

            if (HttpContext.Request.Cookies.ContainsKey("background"))
            {
                var cookieData = JsonSerializer.Deserialize<CookieData>(HttpContext.Request.Cookies["background"]);
                backgroundColor = cookieData.Color;
            }

            ViewBag.Color = backgroundColor;
            var allNews = newsRepository.GetAllNews();
            return View("News", allNews);

        }

        [HttpGet]
        public IActionResult ReaderColor()
        {
            string backgroundColor = "";

            if (HttpContext.Request.Cookies.ContainsKey("background"))
            {
                var cookieData = JsonSerializer.Deserialize<CookieData>(HttpContext.Request.Cookies["background"]);
                backgroundColor = cookieData.Color;
            }

            ViewBag.Color = backgroundColor;

            return View("Background");
        }

        [HttpPost]
        public IActionResult ReaderColor(string color)
        {

            var userId = HttpContext.Request.Cookies["userid"];

            if (HttpContext.Request.Cookies.ContainsKey("background"))
            {
                var cookieData = JsonSerializer.Deserialize<CookieData>(HttpContext.Request.Cookies["background"]);

                cookieData.Color = color;

                var updatedCookieData = JsonSerializer.Serialize<CookieData>(cookieData);

                HttpContext.Response.Cookies.Append("background", updatedCookieData);
            }
            else
            {
                
                CookieData data = new CookieData { Id = userId, Color = color };

                var cookieData = JsonSerializer.Serialize<CookieData>(data);

                HttpContext.Response.Cookies.Append("background", cookieData);
            }
            return RedirectToAction("Main");
        }
        */

        //2 With @inject directive

        public IActionResult Main()
        {
            var allNews = newsRepository.GetAllNews();
            return View("News", allNews);
        }

        [HttpGet]
        public IActionResult ReaderColor()
        {
            return View("Background");
        }

        [HttpPost]
        public IActionResult ReaderColor(string color, [FromServices] IUserPreferences userPreferences)
        {
            userPreferences.SetUserPreferences("setcolor", HttpContext, new Preference
            {
                BackGroundColor = color,
            });
            return RedirectToAction("Main");
        }
    }
}