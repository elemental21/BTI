using BuffaloTungsten.Domain.Abstract;
using BuffaloTungsten.Models;
using BuffaloTungsten.Domain.Entities;
using Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace BuffaloTungsten.Controllers
{
    public class InventoryController : Controller
    {
        private ICategoryRepository _categoryRepo;

        public InventoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Upload()
        {
            return View(uploadModelCreation(new UploadViewModel()));
        }

        [HttpPost]
        public ViewResult Upload(UploadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(uploadModelCreation(model));
            }
            var file = model.ExcelFile;
            //FileStream stream = System.IO.File.Open(@"c:\W_LotInv.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
            string data;
            List<Inventory> items = new List<Inventory>();
            List<string> header = new List<string>();
            for (var x = 0; excelReader.Read(); x++)
            {
                for (var y = 0; y < excelReader.FieldCount; y++)
                {
                    // Header, determins columns
                    if (x == 0)
                    { header.Add(excelReader.GetString(y)); }
                }
            }
            excelReader.Close();

            return View(uploadModelCreation(model));
        }

        private UploadViewModel uploadModelCreation(UploadViewModel viewModel)
        {
            // need to cache
            var categories = _categoryRepo.Categories.Where(x => x.Parent_Id != null).ToList();
            Mapper.CreateMap<Category, ProductCategory>();
            //List<DepartmentVM> depts = Mapper.Map<List<DepartmentVM>>(departments);
            viewModel.ProductCategories = Mapper.Map<List<ProductCategory>>(categories);
            return viewModel;
        }

    }
}