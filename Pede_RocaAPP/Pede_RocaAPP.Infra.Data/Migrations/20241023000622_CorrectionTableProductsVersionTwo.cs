using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class CorrectionTableProductsVersionTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove a chave estrangeira existente (se necessário)
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ImagensProdutos_IdImagensProdutos",
                table: "Produtos");

            // Adicionar novamente a chave estrangeira com ON DELETE CASCADE
            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ImagensProdutos_IdImagensProdutos",
                table: "Produtos",
                column: "IdImagensProdutos",
                principalTable: "ImagensProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover a chave estrangeira com a regra ON DELETE CASCADE
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ImagensProdutos_IdImagensProdutos",
                table: "Produtos");

            // Adicionar novamente a chave estrangeira original (sem a regra ON DELETE CASCADE)
            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ImagensProdutos_IdImagensProdutos",
                table: "Produtos",
                column: "IdImagensProdutos",
                principalTable: "ImagensProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
