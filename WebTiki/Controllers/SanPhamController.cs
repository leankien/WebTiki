using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiki.Models;
using System.IO;


namespace WebTiki.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        SQLSanPhamEntities db = new SQLSanPhamEntities();
        public ActionResult Index()
        {
            List<SANPHAM> lst = db.SANPHAM.ToList();
          

            return View(lst);
        }


        public ActionResult kqTimKiem(String key)
        {
            var lstSp = db.SANPHAM.Where(n => n.TenSP.Contains(key));
            return View(lstSp.OrderBy(n => n.TenSP));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SANPHAM sp, HttpPostedFileBase uploadhinh)
        {


            db.SANPHAM.Add(sp);

            db.SaveChanges();

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.SANPHAM.ToList().Last().MaSP.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "sp" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/ImgSP"), _FileName);
                uploadhinh.SaveAs(_path);

                SANPHAM usp = db.SANPHAM.FirstOrDefault(x => x.MaSP == id);
                usp.Img = _FileName;
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            SANPHAM sp = db.SANPHAM.FirstOrDefault(x => x.MaSP == id);
            return View(sp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SANPHAM sp, HttpPostedFileBase uploadhinh)
        {
            SANPHAM usp = db.SANPHAM.FirstOrDefault(x => x.MaSP == sp.MaSP);
            usp.TenSP = sp.TenSP;
            usp.GiaCu = sp.GiaCu;
            usp.GiaMoi = sp.GiaMoi;
            usp.BaiViet = sp.BaiViet;
            usp.TomTat = sp.TomTat;
            usp.DanhMucID = sp.DanhMucID;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = sp.MaSP;

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "sp" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/ImgSp"), _FileName);
                uploadhinh.SaveAs(_path);
                usp.Img = _FileName;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            SANPHAM sp = db.SANPHAM.FirstOrDefault(x => x.MaSP == id);
            db.SANPHAM.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(string name)
        {
            // Đưa từ khóa vào viewbag
            @ViewBag.key = name;

            // truy vấn các sản phẩm có tên chứa từ khóa name
            List<SANPHAM> pList = db.SANPHAM.Where(x => x.TenSP.Contains(name)).ToList();
            return View(pList);
        }
        public ActionResult ChiTietSP(int MaSP)
        {
            var product = db.SANPHAM.Where(x => x.MaSP == MaSP).FirstOrDefault();
            return View(product);
        }




        }
}