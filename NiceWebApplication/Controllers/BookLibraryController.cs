using Microsoft.AspNetCore.Mvc;
using NiceWebApplication.Models;
using NiceWebApplication.Core;


namespace NiceWebApplication.Controllers
{
    public class BookLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View(LoadBooks());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Check()
        {
            return View("Index");
        }
        private List<Book> LoadBooks() => DB.GetList<Book>("SELECT * FROM books");
    }
}
