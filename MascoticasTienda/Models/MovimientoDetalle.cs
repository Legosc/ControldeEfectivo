using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MascoticasTienda.Models
{
    public class MovimientoDetalle
    {

        public int Id { get; set; }
        [ForeignKey("Moneda")]
        public int MoendaId { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("Movimiento")]
        public int MovimientoId { get; set; }
        public MovimientoEfectivo Movimiento { get; set; }
        public Moneda Moneda { get; set; }

    }
}