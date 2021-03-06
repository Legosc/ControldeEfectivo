﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace MascoticasTienda.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            userIdentity.AddClaim(new Claim(ClaimTypes.Email, this.Email));
            return userIdentity;
        }
    }
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("Mascotica", throwIfV1Schema: false)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Efectivo> Efectivos { get; set; }
        public virtual DbSet<Destino> Destinos { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public virtual DbSet<MovimientoEfectivo> MovimientoEfectivos { get; set; }
        public virtual DbSet<MovimientoDetalle> MovimientoDetalles { get; set; }
    }
}