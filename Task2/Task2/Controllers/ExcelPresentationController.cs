using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class ExcelPresentationController : Controller
    {
        public IActionResult Index()
        {
            var a =TempData["Files"];

            return View();
        }

        public void TextClick(object sender, EventArgs e)
        {

        }

        public IActionResult FileChosen(string fileName)
        {
            return View();
        }
    }
}
