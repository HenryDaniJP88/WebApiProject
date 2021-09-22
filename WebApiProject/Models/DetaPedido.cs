using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class DetaPedido
    {
        //public string Nombre { get; set; }
        //[ForeignKey("Pais")]
        //public int PaisId { get; set; }
        //[JsonIgnore]
        //public Pais Pais { get; set; }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        [ForeignKey("Pedido")]
        public int CodPedido { get; set; }
        public int CodArticulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        [JsonIgnore]
        public Pedido Pedido { get; set; }
    }
}
