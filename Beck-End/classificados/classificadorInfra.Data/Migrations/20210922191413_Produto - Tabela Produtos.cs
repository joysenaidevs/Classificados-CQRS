using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace classificados.Infra.Data.Migrations
{
    public partial class ProdutoTabelaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar (40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar (60)", maxLength: 60, nullable: true),
                    Senha = table.Column<string>(type: "varchar (200)", maxLength: 200, nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Isvalid = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar (100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar (100)", maxLength: 100, nullable: false),
                    Imagem = table.Column<string>(type: "varchar (100)", maxLength: 100, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "varchar (100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioId",
                table: "Produto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
