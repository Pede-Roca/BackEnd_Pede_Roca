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

            // Injeção de dependência para os repositórios
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            
            // Injeção de dependência para os serviços
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // Configuração do MediatR
            var myHandlers = AppDomain.CurrentDomain.Load("Pede_RocaAPP.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
