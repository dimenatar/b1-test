using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Task2.Models;
using Task2.Scripts;

namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {
        private IWebHostEnvironment _env;
        private List<string> _fileNames;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
            _fileNames = new List<string>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ExcelPresentation()
        {
            ViewData["ExcelFile"] = null;
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(IFormFile file)
        {
            if (file == null) return View();
            try
            {
                if (file.Length > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(_env.ContentRootPath, ("UploadedFiles"), _FileName);
                    using (Stream fileStream = new FileStream(_path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    _fileNames.Add(_FileName);

                    ExcelParser.SendExcelToDB(ExcelParser.Parse(_path, _FileName));
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                ViewData["Files"] = _fileNames;
                TempData["Files"] = _fileNames;
                return View(_fileNames);
            }
            catch (Exception ex) 
            {
                ViewBag.Message = $"File upload failed!! \n {ex.Message}";
                return View();
            }
        }
    }
}