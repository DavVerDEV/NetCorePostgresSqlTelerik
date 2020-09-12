using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetCorePostgresSqlTelerik.Data.Migrations
{
    public partial class CreazionePrimiModelli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descrizione = table.Column<string>(nullable: true),
                    titolo = table.Column<string>(nullable: true),
                    numMaxPrenotati = table.Column<int>(nullable: false),
                    dIniziale = table.Column<DateTime>(nullable: false),
                    dFinale = table.Column<DateTime>(nullable: false),
                    ore = table.Column<List<int>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data = table.Column<DateTime>(nullable: false),
                    ora = table.Column<int>(nullable: false),
                    idCorso = table.Column<int>(nullable: false),
                    idUtente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "Prenotazioni");
        }
    }
}
