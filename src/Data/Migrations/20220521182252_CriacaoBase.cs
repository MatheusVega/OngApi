using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AM.Amil.PeNaAreia.Data.Migrations
{
    public partial class CriacaoBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROJETO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(200)", nullable: true),
                    ESTADO = table.Column<string>(type: "varchar(120)", nullable: true),
                    CIDADE = table.Column<string>(type: "varchar(120)", nullable: true),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJETO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: true),
                    NOME = table.Column<string>(type: "varchar(120)", nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(80)", nullable: true),
                    SENHA = table.Column<string>(type: "varchar(120)", nullable: true),
                    DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOACAO_PROJETO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    VALOR = table.Column<decimal>(type: "decimal", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(200)", nullable: true),
                    ID_PROJETO = table.Column<int>(type: "int", nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOACAO_PROJETO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOACAO_PROJETO_PROJETO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "PROJETO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_PROJETO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: true),
                    ID_PROJETO = table.Column<int>(type: "int", nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_PROJETO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_PROJETO_PROJETO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "PROJETO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_PROJETO_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOACAO_PROJETO_UsuarioId",
                table: "DOACAO_PROJETO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PROJETO_ID_USUARIO",
                table: "USUARIO_PROJETO",
                column: "ID_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOACAO_PROJETO");

            migrationBuilder.DropTable(
                name: "USUARIO_PROJETO");

            migrationBuilder.DropTable(
                name: "PROJETO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
