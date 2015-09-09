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
            var viewModel = new UploadViewModel();
            var categories = _categoryRepo.Categories.Where(x => x.Parent_Id != null).ToList();
            Mapper.CreateMap<Category, ProductCategory>();
            //List<DepartmentVM> depts = Mapper.Map<List<DepartmentVM>>(departments);
            viewModel.ProductCategories = Mapper.Map<List<ProductCategory>>(categories);
            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Upload(HttpPostedFileBase file)
        {
            //FileStream stream = System.IO.File.Open(@"c:\W_LotInv.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
            string data;
            while (excelReader.Read())
            {
                data = excelReader.GetString(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            return View();
        }

    }
}