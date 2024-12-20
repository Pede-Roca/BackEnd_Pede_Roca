﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pede_RocaAPP.Infra.Data.Migrations
{
    public partial class AddImagesProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdImagensProdutos",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ImagensProdutos_ImagensProdutoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "ImagensProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ImagensProdutoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdImagensProdutos",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ImagensProdutoId",
                table: "Produtos");
        }
    }
}
