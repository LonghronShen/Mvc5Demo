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

        public ActionResult ShowImgs()
        {
            return this.View();
        }

        public ActionResult GetItems(int startIndex, int count)
        {
            var list = Enumerable.Range(0, 100)
                .Skip(startIndex).Take(count)
                .Select(x => new ItemModel()
                {
                    Id = x,
                    ImgUrl = $"/Content/img/a-(x).jpg"
                });
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult PostName(FormModel model)
        {
            this.ValidateModel(model);
            var fileContent = default(byte[]);
            if (this.HttpContext.Request.Files.Count > 0)
            {
                using (var fs = this.HttpContext.Request.Files[0].InputStream)
                {
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Flush();
                        fileContent = ms.ToArray();
                    }
                }
            }
            return this.Json(new
            {
                model.Id,
                model.Name,
                Content = System.Text.Encoding.UTF8.GetString(fileContent)
            });
        }

    }

}