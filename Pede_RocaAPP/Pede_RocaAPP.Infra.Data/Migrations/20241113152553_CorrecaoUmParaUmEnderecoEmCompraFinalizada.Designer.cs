﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pede_RocaAPP.Infra.Data.Context;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241113152553_CorrecaoUmParaUmEnderecoEmCompraFinalizada")]
    partial class CorrecaoUmParaUmEnderecoEmCompraFinalizada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("IdCarrinhoCompra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Nota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("IdCarrinhoCompra");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.CarrinhoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("CarrinhoCompras");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.CarrinhoComprasProdutosPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCarrinhoCompra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProdutosPedido")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdCarrinhoCompra");

                    b.HasIndex("IdProdutosPedido");

                    b.ToTable("CarrinhoComprasProdutosPedidos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ComprasFinalizadas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCarrinhoCompra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TipoEntrega")
                        .HasColumnType("int");

                    b.Property<int>("TipoPagamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCarrinhoCompra");

                    b.HasIndex("IdEndereco");

                    b.ToTable("ComprasFinalizadas");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Mensagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("UidAnexo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Mensagems");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.PlanoAssinatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("planoAssinaturas");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Estoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("FatorPromocao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdCategoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUnidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UidFoto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdUnidade");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ProdutoFavorito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("produtosFavoritos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ProdutosPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("ProdutosPedidos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.UnidadeMedida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeUnidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SiglaUnidade")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("UnidadeMedidas");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreateUserDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NivelAcesso")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UidFotoPerfil")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.CarrinhoCompra", "CarrinhoCompra")
                        .WithMany()
                        .HasForeignKey("IdCarrinhoCompra")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pede_RocaAPP.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CarrinhoCompra");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.CarrinhoCompra", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.CarrinhoComprasProdutosPedido", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.CarrinhoCompra", "CarrinhoCompra")
                        .WithMany("CarrinhoComprasProdutosPedido")
                        .HasForeignKey("IdCarrinhoCompra")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pede_RocaAPP.Domain.Entities.ProdutosPedido", "ProdutosPedido")
                        .WithMany("CarrinhoComprasProdutosPedido")
                        .HasForeignKey("IdProdutosPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CarrinhoCompra");

                    b.Navigation("ProdutosPedido");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ComprasFinalizadas", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.CarrinhoCompra", "CarrinhoCompra")
                        .WithMany()
                        .HasForeignKey("IdCarrinhoCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pede_RocaAPP.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrinhoCompra");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Mensagem", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.PlanoAssinatura", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pede_RocaAPP.Domain.Entities.UnidadeMedida", "UnidadeMedida")
                        .WithMany("Produtos")
                        .HasForeignKey("IdUnidade")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("UnidadeMedida");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ProdutoFavorito", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutosFavoritos")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pede_RocaAPP.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ProdutosPedido", b =>
                {
                    b.HasOne("Pede_RocaAPP.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutosPedidos")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.CarrinhoCompra", b =>
                {
                    b.Navigation("CarrinhoComprasProdutosPedido");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ProdutosFavoritos");

                    b.Navigation("ProdutosPedidos");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.ProdutosPedido", b =>
                {
                    b.Navigation("CarrinhoComprasProdutosPedido");
                });

            modelBuilder.Entity("Pede_RocaAPP.Domain.Entities.UnidadeMedida", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
