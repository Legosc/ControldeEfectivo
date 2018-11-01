using MascoticasTienda.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MascoticasTienda.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Roles
        public ActionResult Index(RoleMessageId? message)
        {
            ViewBag.StatusMessage =
                message == RoleMessageId.CreateSuccess ? "Su contraseña se ha cambiado."
                : message == RoleMessageId.EditSuccess ? "Su contraseña se ha establecido."
                : message == RoleMessageId.DeleteSuccess ? "Su proveedor de autenticación de dos factores se ha establecido."
                : message == RoleMessageId.Error ? "Se ha producido un error."
                : "";
            return View();
        }

        public ActionResult Roles(RoleMessageId? message)
        {
            ViewBag.StatusMessage =
                message == RoleMessageId.CreateSuccess ? "Role Creado."
                : message == RoleMessageId.EditSuccess ? "Role Modificado."
                : message == RoleMessageId.DeleteSuccess ? "Role eliminado."
                : message == RoleMessageId.Error ? "Se ha producido un error."
                : "";
            IEnumerable<IdentityRole> roles = db.Roles.ToList();
            return View(roles);
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(string name)
        {
            RoleMessageId? message;
            try
            {
                var  roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                if (!roleManager.RoleExists(name))
                {
                    var role1 = new IdentityRole();
                    role1.Name = name;
                    roleManager.Create(role1);
                    
                }

            }
            catch (Exception)
            {
                message = RoleMessageId.Error;
            }
            message = RoleMessageId.CreateSuccess;
            return RedirectToAction("Index", new { Message = message });
        }
        public ActionResult DeleteRole(string id)
        {
            IdentityRole model;
            try
            {
                model = db.Roles.Where(d => d.Id == id).Single();
                
            }
            catch (Exception)
            {
                throw;
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRole(IdentityRole role)
        {
            RoleMessageId? message;
            db.Entry(role).State = EntityState.Deleted;
            db.Roles.Remove(role);
            message = RoleMessageId.DeleteSuccess;
            db.SaveChangesAsync();
            return RedirectToAction("Index", new { Message = message });
        }
        public enum RoleMessageId
        {
            CreateSuccess,
            EditSuccess,
            DeleteSuccess,
            Error
        }
        //END Roles
        //Moneadas
        public ActionResult Monedas(MonedaMessageId? message)
        {
            ViewBag.StatusMessage =
                message == MonedaMessageId.CreateSuccess ? "Moneda creada."
                : message == MonedaMessageId.EditSuccess ? "Moneda Actualizada."
                : message == MonedaMessageId.DeleteSuccess ? "Moneda Eliminada"
                : message == MonedaMessageId.Error ? "Se ha producido un error."
                : "";
            IEnumerable<Moneda> monedas = db.Monedas.ToList();
            return View(monedas);
        }
        public ActionResult CreateMoneda()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMoneda(Moneda moneda)
        {
            MonedaMessageId? message;
            if (!ModelState.IsValid)
            {
                return View(moneda);
            }
            db.Monedas.Add(moneda);

            message = MonedaMessageId.CreateSuccess;
            db.SaveChanges();
            return RedirectToAction("Index", new { Message = message });
        }
        public ActionResult DeleteMoneda(Int32 Id)
        {
            Moneda model;
            model = db.Monedas.Where(d => d.ID == Id).Single();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMoneda(Moneda model)
        {
            MonedaMessageId? message;
            db.Entry(model).State = EntityState.Deleted;
            db.Monedas.Remove(model);
            message = MonedaMessageId.DeleteSuccess;
            db.SaveChanges();
            return RedirectToAction("Index", new { Message = message });
        }
        public enum MonedaMessageId
        {
            CreateSuccess,
            EditSuccess,
            DeleteSuccess,
            Error
        }
        //END Monedas
        //EFECTIVO
        public ActionResult AjusteEfectivo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjusteEfectivo(MovimientoEfectivo movimiento, IEnumerable<Moneda> monedas)
        {
            MonedaMessageId? message;
            message = MonedaMessageId.DeleteSuccess;

            return RedirectToAction("Index", new { Message = message });
        }
    }
}