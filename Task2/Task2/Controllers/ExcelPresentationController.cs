using Microsoft.AspNetCore.Mvc;
using Task2.Models;
using Task2.Scripts;
namespace Task2.Controllers
{
    public class ExcelPresentationController : Controller
    {
        public IActionResult Index()
        {
            var a =TempData["Files"];

            return View();
        }

        [HttpPost]
        public IActionResult GetFile([FromBody] FileName fileName)
        {
            var t = fileName.GetType();
            return View(new ExcelPresentationModel { ExcelFile = ExcelParser.GetDataFromDB(fileName.name.ToString()) });
        }

        public IActionResult FileChosen(string fileName)
        {
            return View();
        }
    }
}
