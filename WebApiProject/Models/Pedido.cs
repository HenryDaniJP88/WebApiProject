using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class Pedido
    {

        public Pedido()
        {
            DetaPedidos = new List<DetaPedido>();
        }

        //public int Id { get; set; }
        //[StringLength(30)]
        //public string Nombre { get; set; }
        //public List<Provincia> Provincias { get; set; }

        [Key]
        public int Id { get; set; }
        public int CodCliente { get; set; }
        [StringLength(30)]
        public string NombreCliente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime FechaPedido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime FechaEntrega { get; set; }
        public string Vendedor { get; set; }
        public string Moneda { get; set; }
        public double Total { get; set; }
        public List<DetaPedido> DetaPedidos { get; set; }
    }
}
