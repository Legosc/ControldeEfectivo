using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MascoticasTienda.Models
{
    public class MovimientoEfectivo
    {
        
        public int ID { get; set; }
        [ForeignKey("Destino")]
        public int DestinoId { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
        public Destino Destino { get; set; }
    }
}