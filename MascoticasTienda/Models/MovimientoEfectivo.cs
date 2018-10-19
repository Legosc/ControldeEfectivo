using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MascoticasTienda.Models
{
    public class MovimientoEfectivo
    {
        public class Detail
        {
            [ForeignKey("Moneda")]
            public int MoendaId { get; set; }
            public int Cantidad { get; set; }
        }
        public int ID { get; set; }
        public IEnumerable<Detail> Details { get; set; }
        public int Destino { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
        public Moneda Moneda { get; set; }
    }
}