using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
   [Produces("application/json")]
    [Route("api/Pedido/{PedidoId}/DetaPedido")]
    public class DetaPedidoController : Controller
    {
        private readonly ApplicationDbContext context;

        public DetaPedidoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<DetaPedido> GetAll(int CodPedido)
        {
            return context.DetaPedidos.Where(x => x.CodPedido == CodPedido).ToList();
        }

        [HttpGet("{id}", Name = "detaPedidoById")]
        public IActionResult GetById(int id)
        {
            var pedido = context.DetaPedidos.FirstOrDefault(x => x.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return new ObjectResult(pedido);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DetaPedido detaPedido, int PedidoId)
        {
            detaPedido.CodPedido = PedidoId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.DetaPedidos.Add(detaPedido);
            context.SaveChanges();

            return new CreatedAtRouteResult("detaPedidoById", new { id = detaPedido.Id }, detaPedido);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] DetaPedido detaPedido, int id)
        {
            if (detaPedido.Id != id)
            {
                return BadRequest();
            }

            context.Entry(detaPedido).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var detaPedido = context.DetaPedidos.FirstOrDefault(x => x.Id == id);

            if (detaPedido == null)
            {
                return NotFound();
            }

            context.DetaPedidos.Remove(detaPedido);
            context.SaveChanges();
            return Ok(detaPedido);
        }
    }
}
