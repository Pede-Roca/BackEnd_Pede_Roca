using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class AddImagesProductsTableRefInProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ImagensProdutos_ImagensProdutoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ImagensProdutoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ImagensProdutoId",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdImagensProdutos",
                table: "Produtos",
                column: "IdImagensProdutos");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ImagensProdutos_IdImagensProdutos",
                table: "Produtos",
                column: "IdImagensProdutos",
                principalTable: "ImagensProdutos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ImagensProdutos_IdImagensProdutos",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdImagensProdutos",
                table: "Produtos");

            migrationBuilder.AddColumn<Guid>(
                name: "ImagensProdutoId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ImagensProdutoId",
                table: "Produtos",
                column: "ImagensProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ImagensProdutos_ImagensProdutoId",
                table: "Produtos",
                column: "ImagensProdutoId",
                principalTable: "ImagensProdutos",
                principalColumn: "Id");
        }
    }
}
