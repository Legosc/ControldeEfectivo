using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MascoticasTienda.Models
{
    public class Destino
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public int Total { get; set; }
    }
}