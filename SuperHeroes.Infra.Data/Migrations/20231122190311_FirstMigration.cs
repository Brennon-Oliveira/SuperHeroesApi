using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HeroName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroesSuperPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuperHeroesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SuperPowersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroesSuperPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroesSuperPowers_SuperHeroes_SuperHeroesId",
                        column: x => x.SuperHeroesId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperHeroesSuperPowers_SuperPowers_SuperPowersId",
                        column: x => x.SuperPowersId,
                        principalTable: "SuperPowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroesSuperPowers_SuperHeroesId",
                table: "SuperHeroesSuperPowers",
                column: "SuperHeroesId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroesSuperPowers_SuperPowersId",
                table: "SuperHeroesSuperPowers",
                column: "SuperPowersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroesSuperPowers");

            migrationBuilder.DropTable(
                name: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "SuperPowers");
        }
    }
}
