using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;
using Pede_RocaAPP.Infra.Data.Repositories;
using Pede_RocaAPP.Infra.Data.Identity;
using Pede_RocaAPP.Application.Mappings;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Pede_RocaAPP.Domain.Account;

namespace Pede_RocaAPP.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurando o DbContext com o SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Configurando o Identity com ApplicationUser e IdentityRole<Guid>
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Registrar os serviços e repositórios no contêiner de DI
            services.AddScoped<IAvaliacaoService, AvaliacaoService>(); // Adicionando AvaliacaoService
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();

            services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();
            services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<IMensagemService, MensagemService>();
            services.AddScoped<IMensagemRepository, MensagemRepository>();

            services.AddScoped<IPlanoAssinaturaService, PlanoAssinaturaService>();
            services.AddScoped<IPlanoAssinaturaRepository, PlanoAssinaturaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IProdutosPedidoService, ProdutosPedidoService>();
            services.AddScoped<IProdutosPedidoRepository, ProdutosPedidoRepository>();

            services.AddScoped<IProdutoFavoritoService, ProdutoFavoritoService>();
            services.AddScoped<IProdutoFavoritoRepository, ProdutoFavoritoRepository>();

            services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();
            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // Configuração do MediatR
            var myHandlers = AppDomain.CurrentDomain.Load("Pede_RocaAPP.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
