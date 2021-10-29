using classificados.Dominio.Handlers;
using classificados.Dominio.Handlers.Autenticacao;
using classificados.Dominio.Handlers.Produtos;
using classificados.Dominio.Repositorios;
using classificados.Infra.Data.Contexts;
using classificados.Infra.Data.Repositórios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.WebApi
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

            services.AddControllers();
              // contexto do banco
            services.AddDbContext<classificadosContext>(c => c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection") ) );


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "classificados.WebApi", Version = "v1" });
            });


            // JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "classificados",
                        ValidAudience = "classificados",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaClassificadosSenai132"))

                    };
                });


            //Adiciona o CORS ao projeto
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:5001", "http://localhost:5000")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });


            //declarando as injeções de dependencia
            // fazer pra cada handle e reposositorio *CRIAR UMA REGION PRA CADA SITUACAO
            #region Usuario
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<CriarContaHandler, CriarContaHandler>();
            services.AddTransient<LogarHandler, LogarHandler>();
            #endregion

            #region Injeções de dependencia de Produto
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddTransient<CadastrarProdutoHandle, CadastrarProdutoHandle>();
            services.AddTransient<ListarProdutoHandle, ListarProdutoHandle>();
            services.AddTransient<AlterarProdutoHandle, AlterarProdutoHandle>();
            services.AddTransient<ExcluirProdutoHandle, ExcluirProdutoHandle>();
            services.AddTransient<ListarMeusProdutosHandle, ListarMeusProdutosHandle>();
            services.AddTransient<BuscarPorNomeHandle, BuscarPorNomeHandle>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "classificados.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
