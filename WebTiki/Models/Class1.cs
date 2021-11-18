using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTIKI.Models;
namespace WebTIKI.Models
{
    public class Class1
    {
        SQLSanPhamEntities db = new SQLSanPhamEntities();
        public IEnumerable<SANPHAM> layds()
        {
            return db.SANPHAM.ToList();
        }
        public SANPHAM lays(string id)
        {
            return db.SANPHAM.First(m => m.MaSP.CompareTo(id) == 0);
        }
        public void Them(SANPHAM n)
        {
            db.SANPHAM.Add(n);
            db.SaveChanges();
        }
        public void Sua(SANPHAM n)
        {
            SANPHAM x = lays(n.MaSP);
            x.TenSP = n.TenSP;
            x.GiaCu = n.GiaCu;
            x.GiaMoi = n.GiaMoi;
            x.TomTat = n.TomTat;
            x.BaiViec = n.BaiViec;
            x.Img = n.Img;
            db.SaveChanges();
        }
        public void Xoa(String id)
        {
            SANPHAM n = lays(id);
            db.SANPHAM.Remove(n);
            db.SaveChanges();
        }
    }
}