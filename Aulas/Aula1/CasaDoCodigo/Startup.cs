using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Application.Interfaces;
using CasaDoCodigo.Application.Services;
using CasaDoCodigo.Domain.Interfaces.Repositories;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using CasaDoCodigo.Domain.Services;
using CasaDoCodigo.Domain.Services.Interfaces;
using CasaDoCodigo.Infra.Data;
using CasaDoCodigo.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CasaDoCodigo
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
            services.AddMvc();
            //session e cache 
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("CasaDoCodigo"))
            );

            services.AddTransient<IDataService, DataService>();
            
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
            
            services.AddTransient<IProdutoApp, ProdutoApp>();
            services.AddTransient<IProdutoService, ProdutoService>();
            
            services.AddTransient<IPedidoApp, PedidoApp>();
            services.AddTransient<IPedidoService, PedidoService>();

            services.AddTransient<IItemPedidoApp, ItemPedidoApp>();
            services.AddTransient<IItemPedidoService, ItemPedidoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{codigo?}");
            });

            serviceProvider.GetService<IDataService>().InicializaDB();
        }
    }
}
