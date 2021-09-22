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
    [Route("api/Pedido")]
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext context;

        public PedidoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            return context.Pedidos.ToList();
        }

        [HttpGet("{id}", Name = "pedidoCreado")]
        public IActionResult GetById(int id)
        {
            var pedido = context.Pedidos.Include(x => x.DetaPedidos).FirstOrDefault(x => x.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        //Insertamos el Pedido
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                context.Pedidos.Add(pedido);
                context.SaveChanges();
                return new CreatedAtRouteResult("pedidoCreado", new { id = pedido.Id}, pedido);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pedido pedido, int id)
        {
            if (pedido.Id != id)
            {
                return BadRequest();
            }

            context.Entry(pedido).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pais = context.Pedidos.FirstOrDefault(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            context.Pedidos.Remove(pais);
            context.SaveChanges();
            return Ok(pais);
        }
    }
}
