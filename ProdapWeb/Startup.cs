using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.EfCore;
using Service.Adapters;
using Service.Request;
using Service.TarefaService;
using Service.UsuarioService;
using Service.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdapWeb
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
            services.AddControllersWithViews();

            services.AddDbContext<ProdapDbContext>();


            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            
            services.AddTransient<ITarefaService, TarefaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ITarefaAdapter, TarefaAdapter>();
            services.AddTransient<IUsuarioAdapter, UsuarioAdapter>();

            services.AddTransient<IValidator<CriarTarefaRequest>, CriarTarefaRequestValidator>();
            services.AddTransient<IValidator<AlterarTarefaRequest>, AlterarTarefaRequestValidator>();
            services.AddTransient<IValidator<CriarUsuarioRequest>, CriarUsuarioRequestValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
