﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Qly_Luong_NVien_Model;

namespace Qly_Luong_NVien_MVC.Controllers
{
    public class LichSuNgachController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        // GET: /LichSuNgach/Index/id
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: /LichSuNgach/getLichSuNgach/nhan_vien_id
        public JsonResult getLichSuNgach(int? nhan_vien_id)
        {
            if (nhan_vien_id == null)
            {
                return null;
            }
            ICollection<LichSuNgach> lichsungach = db.lich_su_ngach.Where(l => l.nhan_vien.id == nhan_vien_id).ToList();
            return Json(lichsungach, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
