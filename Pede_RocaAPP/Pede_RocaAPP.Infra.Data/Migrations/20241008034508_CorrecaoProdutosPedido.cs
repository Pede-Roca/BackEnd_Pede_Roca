using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class CorrecaoProdutosPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosPedidos_CarrinhoCompras_IdCarrinhoCompra",
                table: "ProdutosPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosPedidos_IdCarrinhoCompra",
                table: "ProdutosPedidos");

            migrationBuilder.DropColumn(
                name: "IdCarrinhoCompra",
                table: "ProdutosPedidos");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProdutosPedido",
                table: "CarrinhoCompras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompras_IdProdutosPedido",
                table: "CarrinhoCompras",
                column: "IdProdutosPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompras_ProdutosPedidos_IdProdutosPedido",
                table: "CarrinhoCompras",
                column: "IdProdutosPedido",
                principalTable: "ProdutosPedidos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompras_ProdutosPedidos_IdProdutosPedido",
                table: "CarrinhoCompras");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompras_IdProdutosPedido",
                table: "CarrinhoCompras");

            migrationBuilder.DropColumn(
                name: "IdProdutosPedido",
                table: "CarrinhoCompras");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCarrinhoCompra",
                table: "ProdutosPedidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosPedidos_IdCarrinhoCompra",
                table: "ProdutosPedidos",
                column: "IdCarrinhoCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosPedidos_CarrinhoCompras_IdCarrinhoCompra",
                table: "ProdutosPedidos",
                column: "IdCarrinhoCompra",
                principalTable: "CarrinhoCompras",
                principalColumn: "Id");
        }
    }
}
