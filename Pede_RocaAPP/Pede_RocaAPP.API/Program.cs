using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Repositories;
using Pede_RocaAPP.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

// Registrar os serviços e repositórios no contêiner de DI
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>(); // Adicionando AvaliacaoService
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();

builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();
builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

builder.Services.AddScoped<IMensagemService, MensagemService>();
builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();

builder.Services.AddScoped<IPlanoAssinaturaService, PlanoAssinaturaService>();
builder.Services.AddScoped<IPlanoAssinaturaRepository, PlanoAssinaturaRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<IProdutoFavoritoService, ProdutoFavoritoService>();
builder.Services.AddScoped<IProdutoFavoritoRepository, ProdutoFavoritoRepository>();

builder.Services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();
builder.Services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();