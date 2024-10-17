using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class AdicaoMediadoraCarrinhoCompraProdutoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "CarrinhoCompras",
                type: "bit",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "CarrinhoComprasProdutosPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCarrinhoCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProdutosPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoComprasProdutosPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoComprasProdutosPedidos_CarrinhoCompras_IdCarrinhoCompra",
                        column: x => x.IdCarrinhoCompra,
                        principalTable: "CarrinhoCompras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarrinhoComprasProdutosPedidos_ProdutosPedidos_IdProdutosPedido",
                        column: x => x.IdProdutosPedido,
                        principalTable: "ProdutosPedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoComprasProdutosPedidos_IdCarrinhoCompra",
                table: "CarrinhoComprasProdutosPedidos",
                column: "IdCarrinhoCompra");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoComprasProdutosPedidos_IdProdutosPedido",
                table: "CarrinhoComprasProdutosPedidos",
                column: "IdProdutosPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoComprasProdutosPedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "CarrinhoCompras",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 50);

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
    }
}
