using Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuffaloTungsten.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Upload()
        {
            return View();
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