using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class TruyenController : Controller
    {
        // GET: Truyen
        WebTruyenDataContext data = new WebTruyenDataContext();

        // ---------------------- List ---------------------- //

        public ActionResult ListTruyen()
        {
            var all_truyen = from tt in data.Truyens select tt;
            return View(all_truyen);
        }

        // ---------------------- Detail ---------------------- //

        public ActionResult Detail(int id)
        {
            var D_sach = data.Truyens.Where(m => m.matruyen == id).First();
            return View(D_sach);
        }

        // ---------------------- Create ---------------------- //

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, Truyen s)
        {
            var E_tensach = collection["tentruyen"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tentruyen = E_tensach.ToString();
                s.hinh = E_hinh.ToString();
                s.giaban = E_giaban;
                s.ngaycapnhat = E_ngaycapnhat;
                s.soluongton = E_soluongton;
                data.Truyens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListTruyen");
            }
            return this.Create();
        }

        // ---------------------- Edit ---------------------- //

        public ActionResult Edit(int id)
        {
            var E_sach = data.Truyens.First(m => m.matruyen == id);
            return View(E_sach);
        }
        [HttpPost]

        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = data.Truyens.First(m => m.matruyen == id);
            var E_tensach = collection["tentruyen"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_sach.matruyen = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sach.tentruyen = E_tensach;
                E_sach.hinh = E_hinh;
                E_sach.giaban = E_giaban;
                E_sach.ngaycapnhat = E_ngaycapnhat;
                E_sach.soluongton = E_soluongton;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("ListTruyen");
            }
            return this.Edit(id);
        }

        // ---------------------- Delete ---------------------- //

        public ActionResult Delete(int id)
        {
            var D_sach = data.Truyens.First(m => m.matruyen == id);
            return View(D_sach);
        }
        [HttpPost]

        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.Truyens.Where(m => m.matruyen == id).First();
            data.Truyens.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("ListTruyen");
        }

        // ---------------------- Up Picture ---------------------- //

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Hinh/" + file.FileName));
            return "/Content/Hinh/" + file.FileName;
        }

    }
}

