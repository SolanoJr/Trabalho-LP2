using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Atividade2EFCoreClassLibrary.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BancoId = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencias_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgenciaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Juros = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgenciaId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteSolicitacoes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    SolicitacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteSolicitacoes", x => new { x.ClienteId, x.SolicitacaoId });
                    table.ForeignKey(
                        name: "FK_ClienteSolicitacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteSolicitacoes_Solicitacoes_SolicitacaoId",
                        column: x => x.SolicitacaoId,
                        principalTable: "Solicitacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_BancoId",
                table: "Agencias",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContaId",
                table: "Clientes",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteSolicitacoes_SolicitacaoId",
                table: "ClienteSolicitacoes",
                column: "SolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_AgenciaId",
                table: "Contas",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_AgenciaId",
                table: "Solicitacoes",
                column: "AgenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteSolicitacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
