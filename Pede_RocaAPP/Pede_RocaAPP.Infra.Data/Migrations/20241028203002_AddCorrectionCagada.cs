using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class AddCorrectionCagada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Produtos_ImagensProdutoId')" +
                     " CREATE INDEX IX_Produtos_ImagensProdutoId ON Produtos(ImagensProdutoId);");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ImagensProdutos_ImagensProdutoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "ImagensProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ImagensProdutoId",
                table: "Produtos");

            // Verifica a existência da coluna antes de removê-la
            migrationBuilder.Sql("IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS " +
                "WHERE TABLE_NAME = 'Produtos' AND COLUMN_NAME = 'IdImagensProdutos') " +
                "BEGIN " +
                "ALTER TABLE Produtos DROP COLUMN IdImagensProdutos; " +
                "END");

            migrationBuilder.Sql("IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS " +
                "WHERE TABLE_NAME = 'Produtos' AND COLUMN_NAME = 'ImagensProdutoId') " +
                "BEGIN " +
                "ALTER TABLE Produtos DROP COLUMN ImagensProdutoId; " +
                "END");

            migrationBuilder.CreateTable(
                name: "ComprasFinalizadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCarrinhoCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasFinalizadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasFinalizadas_CarrinhoCompras_IdCarrinhoCompra",
                        column: x => x.IdCarrinhoCompra,
                        principalTable: "CarrinhoCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasFinalizadas_IdCarrinhoCompra",
                table: "ComprasFinalizadas",
                column: "IdCarrinhoCompra",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasFinalizadas");

            // Adicione as colunas de volta
            migrationBuilder.AddColumn<Guid>(
                name: "IdImagensProdutos",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.AddColumn<Guid>(
                name: "ImagensProdutoId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImagensProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensProdutos", x => x.Id);
                });

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
