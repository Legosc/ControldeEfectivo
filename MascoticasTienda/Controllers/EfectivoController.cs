using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascoticasTienda.Controllers
{
    public class EfectivoController : Controller
    {
        // GET: Efectivo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult Cierre()
        {
            return View();
        }
        public ActionResult Movimientos()
        {
            return View();
        }
    }
}