using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Library;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly Library.AppContext db = new Library.AppContext();

        public ActionResult Index()
        {
            var users = DbActions.Select();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            DbActions.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            try
            {
                DbActions.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
