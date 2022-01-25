using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceiteDigital.Data.Migrations
{
    public partial class CarregamentoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Signatario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraEvento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    TipoEvento = table.Column<int>(type: "int", nullable: false),
                    DocumentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Evento_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoSignatario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentoId = table.Column<long>(type: "bigint", nullable: false),
                    SignatarioId = table.Column<long>(type: "bigint", nullable: false),
                    TipoSignatario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoSignatario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_DocumentoSignatario_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Signatario_DocumentoSignatario_SignatarioId",
                        column: x => x.SignatarioId,
                        principalTable: "Signatario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assinatura",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentoSignatarioId = table.Column<long>(type: "bigint", nullable: false),
                    Assinado = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assinatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoSignatario_Assinatura_DocumentoSignatarioId",
                        column: x => x.DocumentoSignatarioId,
                        principalTable: "DocumentoSignatario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_DocumentoSignatarioId",
                table: "Assinatura",
                column: "DocumentoSignatarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoSignatario_DocumentoId",
                table: "DocumentoSignatario",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoSignatario_SignatarioId",
                table: "DocumentoSignatario",
                column: "SignatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_DocumentoId",
                table: "Evento",
                column: "DocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assinatura");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "DocumentoSignatario");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Signatario");
        }
    }
}
