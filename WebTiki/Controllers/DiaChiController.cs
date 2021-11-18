using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiki.Models;

namespace WebTiki.Controllers
{
    public class DiaChiController : Controller
    {
        // GET: DiaChi
        SQLSanPhamEntities db = new SQLSanPhamEntities();
        public ActionResult Index()
        {
            List<DiaChiKH> lst = db.DiaChiKH.ToList();


            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DiaChiKH sp)
        {


            db.DiaChiKH.Add(sp);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            DiaChiKH sp = db.DiaChiKH.FirstOrDefault(x => x.MaDC == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(DiaChiKH sp)
        {
            DiaChiKH usp = db.DiaChiKH.FirstOrDefault(x => x.MaDC == sp.MaDC);
            usp.TenKH = sp.TenKH;
            usp.DT = sp.DT;
            usp.TinhTP = sp.TinhTP;
            usp.QuanHuyen = sp.QuanHuyen;
            usp.PhuongXa = sp.PhuongXa;
            usp.DiaChi = sp.DiaChi;
            usp.LoaiDC = sp.LoaiDC;



            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DiaChiKH sp = db.DiaChiKH.FirstOrDefault(x => x.MaDC == id);
            db.DiaChiKH.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}