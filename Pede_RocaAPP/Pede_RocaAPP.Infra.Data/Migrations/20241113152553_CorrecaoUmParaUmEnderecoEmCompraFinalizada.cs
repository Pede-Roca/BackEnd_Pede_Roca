using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class CorrecaoUmParaUmEnderecoEmCompraFinalizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComprasFinalizadas_IdCarrinhoCompra",
                table: "ComprasFinalizadas");

            migrationBuilder.DropIndex(
                name: "IX_ComprasFinalizadas_IdEndereco",
                table: "ComprasFinalizadas");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasFinalizadas_IdCarrinhoCompra",
                table: "ComprasFinalizadas",
                column: "IdCarrinhoCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasFinalizadas_IdEndereco",
                table: "ComprasFinalizadas",
                column: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComprasFinalizadas_IdCarrinhoCompra",
                table: "ComprasFinalizadas");

            migrationBuilder.DropIndex(
                name: "IX_ComprasFinalizadas_IdEndereco",
                table: "ComprasFinalizadas");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasFinalizadas_IdCarrinhoCompra",
                table: "ComprasFinalizadas",
                column: "IdCarrinhoCompra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComprasFinalizadas_IdEndereco",
                table: "ComprasFinalizadas",
                column: "IdEndereco",
                unique: true);
        }
    }
}
