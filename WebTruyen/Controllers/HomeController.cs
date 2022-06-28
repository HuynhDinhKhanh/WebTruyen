using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using PagedList;

namespace WebTruyen.Controllers
{
    public class HomeController : Controller
    {
        WebTruyenDataContext data = new WebTruyenDataContext();

        public ActionResult Index(int ? page)
        {
            if (page == null) page = 1;
            var all_truyen = (from t in data.Truyens select t).OrderBy(m => m.matruyen);
            int pageSize = 6;
            int pageNum = page ?? 1;

            return View(all_truyen.ToPagedList(pageNum, pageSize));
        }

    }
}