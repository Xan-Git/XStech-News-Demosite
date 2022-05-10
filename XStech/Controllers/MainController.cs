using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using XStech.Models;

namespace XStech.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _db;

        public MainController(ILogger<MainController> logger, AppDbContext db, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _db = db;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ReadPost(int id)
        {
            Post post = _db.Posts.Where(p => p.Id == id)
                .Include(p => p.Author)
                .FirstOrDefault();

            return View(post);
        }

        public IActionResult Tips()
        {
            return View();
        }

        public IActionResult Videos()
        {
            return View();
        }

        public IActionResult Reviews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContact(ContactForm submittedForm)
        {
            ContactForm form = submittedForm;
            await Utilities.Contact.ReceiveContactForm(form, _configuration);
            return View("Home");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Advertising()
        {
            return View();
        }

        public IActionResult Legal()
        {
            return View();
        }

        public IActionResult Careers()
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