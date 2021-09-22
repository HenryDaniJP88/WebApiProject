using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("pedidoDB"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Si no existen estos pedidos los creamos
            if (!context.Pedidos.Any())
            {
                context.Pedidos.AddRange(new List<Pedido>()
                {
                    new Pedido(){
                                Id = 100,
                                CodCliente = 1,
                                NombreCliente = "Henry Jara",
                                FechaPedido = DateTime.Parse("22/09/2021"),
                                FechaEntrega = DateTime.Parse("25/09/2021"),
                                Vendedor = "Jose Soto",
                                Moneda = "PYG",
                                Total = 12,
                               DetaPedidos = new List<DetaPedido>()
                                {
                                    new DetaPedido()
                                    {
                                        CodArticulo = 1,
                                        Descripcion = "Bufanda",
                                        Cantidad = 2,
                                        PrecioUnitario = 60
                                    }
                                } 
                    
                    },
                    new Pedido(){
                                    Id = 200,
                                CodCliente = 2,
                                NombreCliente = "Daniel Pereira",
                                FechaPedido = DateTime.Parse("20/09/2021"),
                                FechaEntrega = DateTime.Parse("24/09/2021"),
                                Vendedor = "Maria Perez",
                                Moneda = "PYG",
                                Total = 50000,
                                DetaPedidos = new List<DetaPedido>()
                                {
                                     new DetaPedido()
                                    {
                                        CodArticulo = 2,
                                        Descripcion = "Sombrero",
                                        Cantidad = 1,
                                        PrecioUnitario = 30
                                    },
                                    new DetaPedido()
                                    {
                                        CodArticulo = 2,
                                        Descripcion = "Pantalon",
                                        Cantidad = 1,
                                        PrecioUnitario = 20
                                    }
                        } },
                    new Pedido(){
                                Id = 300,
                                CodCliente = 3,
                                NombreCliente = "Juan Perez",
                                FechaPedido = DateTime.Parse("20/09/2021"),
                                FechaEntrega = DateTime.Parse("24/09/2021"),
                                Vendedor = "Jose Gonzalez",
                                Moneda = "PYG",
                                Total = 75,
                                DetaPedidos = new List<DetaPedido>()
                                {
                                     new DetaPedido()
                                    {
                                        CodArticulo = 4,
                                        Descripcion = "Vino",
                                        Cantidad = 1,
                                        PrecioUnitario = 75
                                    }
                        } }
                });

                context.SaveChanges();
            }
        }
    }
}
