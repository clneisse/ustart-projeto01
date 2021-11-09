using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UStart.Infrastructure.Migrations
{
    public partial class obra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "grupo_produtos");

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    codigo_externo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "obras",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    grupo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    projetos = table.Column<string>(type: "text", nullable: true),
                    serviços = table.Column<string>(type: "text", nullable: true),
                    codigo_externo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obras", x => x.id);
                    table.ForeignKey(
                        name: "fk_obras_grupos_grupo_id",
                        column: x => x.grupo_id,
                        principalTable: "grupos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_obras_grupo_id",
                table: "obras",
                column: "grupo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "obras");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.CreateTable(
                name: "grupo_produtos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupo_produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    grupo_produto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    preco = table.Column<decimal>(type: "numeric", nullable: false),
                    url_imagem = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produtos", x => x.id);
                    table.ForeignKey(
                        name: "fk_produtos_grupo_produtos_grupo_produto_id",
                        column: x => x.grupo_produto_id,
                        principalTable: "grupo_produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_produtos_grupo_produto_id",
                table: "produtos",
                column: "grupo_produto_id");
        }
    }
}
