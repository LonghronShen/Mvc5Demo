using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{

    public class HomeController
        : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult PostName(FormModel model)
        {
            if (this.HttpContext.Request.Files.Count == 1)
            {
                var file = this.HttpContext.Request.Files[0];
                using (var fs = file.InputStream)
                {
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Flush();
                        model.FileContent = ms.ToArray();
                    }
                }
            }
            return this.Json(model);
        }

    }

}