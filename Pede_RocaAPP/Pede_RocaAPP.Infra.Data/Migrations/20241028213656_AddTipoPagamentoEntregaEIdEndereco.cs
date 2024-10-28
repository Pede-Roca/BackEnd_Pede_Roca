using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class AddTipoPagamentoEntregaEIdEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdEndereco",
                table: "ComprasFinalizadas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TipoEntrega",
                table: "ComprasFinalizadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagamento",
                table: "ComprasFinalizadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComprasFinalizadas_IdEndereco",
                table: "ComprasFinalizadas",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasFinalizadas_Enderecos_IdEndereco",
                table: "ComprasFinalizadas",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasFinalizadas_Enderecos_IdEndereco",
                table: "ComprasFinalizadas");

            migrationBuilder.DropIndex(
                name: "IX_ComprasFinalizadas_IdEndereco",
                table: "ComprasFinalizadas");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "ComprasFinalizadas");

            migrationBuilder.DropColumn(
                name: "TipoEntrega",
                table: "ComprasFinalizadas");

            migrationBuilder.DropColumn(
                name: "TipoPagamento",
                table: "ComprasFinalizadas");
        }
    }
}
