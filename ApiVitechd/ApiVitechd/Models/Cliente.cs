namespace ApiVitechd.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public long tipo_identificacion { get; set; }
        public long numero_identificacion { get; set; }
    }
}