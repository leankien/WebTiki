using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiki.Models;
namespace WebTiki.Controllers
{
    public class HomeControllerAdmin : Controller
    {
        // GET: HomeControllerAdmin
        SQLSanPhamEntities db = new SQLSanPhamEntities();

        public ActionResult Index()
        {

            return View();
        }
    }
}