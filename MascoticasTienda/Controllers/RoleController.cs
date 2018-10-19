using MascoticasTienda.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MascoticasTienda.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Role
        public ActionResult Index(RoleMessageId? message)
        {
            ViewBag.StatusMessage =
                message == RoleMessageId.CreateSuccess ? "Su contraseña se ha cambiado."
                : message == RoleMessageId.EditSuccess ? "Su contraseña se ha establecido."
                : message == RoleMessageId.DeleteSuccess ? "Su proveedor de autenticación de dos factores se ha establecido."
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
        public ActionResult CreateRole(string role)
        {
            RoleMessageId? message;
            try
            {
                var  roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                if (!roleManager.RoleExists(role))
                {
                    var role1 = new IdentityRole();
                    role1.Name = role;
                    roleManager.Create(role1);
                    
                }
                return View(role);

            }
            catch (Exception)
            {
                message = RoleMessageId.Error;
            }
            message = RoleMessageId.CreateSuccess;
            return RedirectToAction("Index", new { Message = message });
        }
        public enum RoleMessageId
        {
            CreateSuccess,
            EditSuccess,
            DeleteSuccess,
            Error
        }
    }
}