using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevTrail.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_AccountId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_AccountId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Transacoes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_AccountId",
                table: "Transacoes",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_AccountId",
                table: "Transacoes",
                column: "AccountId",
                principalTable: "Contas",
                principalColumn: "Id");
        }
    }
}
