using Microsoft.AspNetCore.Mvc;
using Task2.Models;
using Task2.Scripts;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Task2.Controllers
{
    public class ExcelPresentationController : Controller
    {
        private ExcelPresentationModel _model = new ExcelPresentationModel();

        public IActionResult ExcelPresentation()
        {
            var a = TempData["Files"] as IEnumerable<string>;
            if (a != null)
            {
                _model.Files = a.ToList();
            }
            return View(_model);
        }

        public IActionResult Index()
        {
            var a =TempData["Files"] as IEnumerable<string>;
            if (a != null)
            {
                _model.Files = a.ToList();
            }
            return View(_model);
        }

        [HttpPost]
        public async Task<IActionResult> ExcelPresentation([FromBody] FileName fileName)
        {
            var result = await ExcelParser.GetDataFromDB(fileName.name);

            ViewData["ExcelFile"] = result;
            ViewBag.ExcelFile = result;
            _model.ExcelFile = result;
            return View(new ExcelPresentationModel { ExcelFile = result });
        }

        public IActionResult FileChosen(string fileName)
        {
            return View();
        }
    }
}
