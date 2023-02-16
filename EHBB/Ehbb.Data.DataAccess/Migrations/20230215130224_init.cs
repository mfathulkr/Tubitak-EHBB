using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ehbb.Data.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emitters",
                columns: table => new
                {
                    EmitterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Notation = table.Column<string>(type: "text", nullable: true),
                    EmitterName = table.Column<string>(type: "text", nullable: false),
                    SpotNo = table.Column<string>(type: "text", nullable: false),
                    EmitterFunction = table.Column<string>(type: "text", nullable: false),
                    EmitterDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emitters", x => x.EmitterID);
                });

            migrationBuilder.CreateTable(
                name: "Lasers",
                columns: table => new
                {
                    LaserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LaserName = table.Column<string>(type: "text", nullable: false),
                    SpotNumber = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double precision", maxLength: 1000, nullable: true),
                    OperatingTemperature = table.Column<double>(type: "double precision", maxLength: 100, nullable: true),
                    StorageTemperature = table.Column<double>(type: "double precision", maxLength: 100, nullable: true),
                    Power = table.Column<double>(type: "double precision", maxLength: 100000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lasers", x => x.LaserID);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlatformName = table.Column<string>(type: "text", nullable: false),
                    PlatformType = table.Column<int>(type: "integer", nullable: false),
                    PlatformCategory = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    MaxSpeed = table.Column<double>(type: "double precision", nullable: false),
                    MinSpeed = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformID);
                });

            migrationBuilder.CreateTable(
                name: "EmitterModes",
                columns: table => new
                {
                    EmitterModeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmitterModeName = table.Column<string>(type: "text", nullable: false),
                    RFlimits = table.Column<double>(type: "double precision", maxLength: 100000, nullable: false),
                    PRIlimits = table.Column<double>(type: "double precision", maxLength: 100000, nullable: false),
                    PDlimits = table.Column<double>(type: "double precision", maxLength: 100000, nullable: false),
                    ScanLimits = table.Column<double>(type: "double precision", maxLength: 10000, nullable: false),
                    EmitterID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmitterModes", x => x.EmitterModeID);
                    table.ForeignKey(
                        name: "FK_EmitterModes_Emitters_EmitterID",
                        column: x => x.EmitterID,
                        principalTable: "Emitters",
                        principalColumn: "EmitterID");
                });

            migrationBuilder.CreateTable(
                name: "LaserModes",
                columns: table => new
                {
                    LaserModeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LaserModeCode = table.Column<string>(type: "text", nullable: false),
                    LaserModeInfo = table.Column<string>(type: "text", nullable: true),
                    LaserModePRI = table.Column<double>(type: "double precision", maxLength: 1000000, nullable: true),
                    LaserModePulseDuration = table.Column<double>(type: "double precision", maxLength: 1000000, nullable: true),
                    ScanPeriod = table.Column<double>(type: "double precision", maxLength: 1000000, nullable: true),
                    LaserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaserModes", x => x.LaserModeID);
                    table.ForeignKey(
                        name: "FK_LaserModes_Lasers_LaserID",
                        column: x => x.LaserID,
                        principalTable: "Lasers",
                        principalColumn: "LaserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformEmitter",
                columns: table => new
                {
                    PlatformEmitterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlatformID = table.Column<int>(type: "integer", nullable: false),
                    EmitterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformEmitter", x => x.PlatformEmitterID);
                    table.ForeignKey(
                        name: "FK_PlatformEmitter_Emitters_EmitterID",
                        column: x => x.EmitterID,
                        principalTable: "Emitters",
                        principalColumn: "EmitterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformEmitter_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "PlatformID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformLaser",
                columns: table => new
                {
                    PlatformLaserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlatformID = table.Column<int>(type: "integer", nullable: false),
                    LaserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformLaser", x => x.PlatformLaserID);
                    table.ForeignKey(
                        name: "FK_PlatformLaser_Lasers_LaserID",
                        column: x => x.LaserID,
                        principalTable: "Lasers",
                        principalColumn: "LaserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformLaser_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "PlatformID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmitterModes_EmitterID",
                table: "EmitterModes",
                column: "EmitterID");

            migrationBuilder.CreateIndex(
                name: "IX_LaserModes_LaserID",
                table: "LaserModes",
                column: "LaserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformEmitter_EmitterID",
                table: "PlatformEmitter",
                column: "EmitterID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformEmitter_PlatformID",
                table: "PlatformEmitter",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformLaser_LaserID",
                table: "PlatformLaser",
                column: "LaserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformLaser_PlatformID",
                table: "PlatformLaser",
                column: "PlatformID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmitterModes");

            migrationBuilder.DropTable(
                name: "LaserModes");

            migrationBuilder.DropTable(
                name: "PlatformEmitter");

            migrationBuilder.DropTable(
                name: "PlatformLaser");

            migrationBuilder.DropTable(
                name: "Emitters");

            migrationBuilder.DropTable(
                name: "Lasers");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
