using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StokKartTablolar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hammadde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hammadde", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "malzemestandart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StandartAdi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malzemestandart", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "olcubirim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tanim = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_olcubirim", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stokgrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stokgrup", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stoktip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stoktip", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "malzemegrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StokGrupId = table.Column<int>(type: "int", nullable: true),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PdfVar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DxfVar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StepVar = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malzemegrup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_malzemegrup_stokgrup_StokGrupId",
                        column: x => x.StokGrupId,
                        principalTable: "stokgrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "malzemealtgrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MalzemeGrupId = table.Column<int>(type: "int", nullable: true),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PdfVar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DxfVar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StepVar = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malzemealtgrup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_malzemealtgrup_malzemegrup_MalzemeGrupId",
                        column: x => x.MalzemeGrupId,
                        principalTable: "malzemegrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "malzemealtgrup2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MalzemeAltGrupId = table.Column<int>(type: "int", nullable: true),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsUretim = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PdfVar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DxfVar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StepVar = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malzemealtgrup2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_malzemealtgrup2_malzemealtgrup_MalzemeAltGrupId",
                        column: x => x.MalzemeAltGrupId,
                        principalTable: "malzemealtgrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stokkart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParcaKod = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParcaAdi = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Boyut = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Malzeme = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aciklama = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Agirlik = table.Column<double>(type: "double", nullable: true),
                    Boy = table.Column<double>(type: "double", nullable: true),
                    En = table.Column<double>(type: "double", nullable: true),
                    Yukseklik = table.Column<double>(type: "double", nullable: true),
                    Uzunluk = table.Column<double>(type: "double", nullable: true),
                    Cap = table.Column<double>(type: "double", nullable: true),
                    EtKalınligi = table.Column<double>(type: "double", nullable: true),
                    StokGrupId = table.Column<int>(type: "int", nullable: true),
                    StokTipId = table.Column<int>(type: "int", nullable: true),
                    MalzemeGrupId = table.Column<int>(type: "int", nullable: true),
                    MalzemeAltGrupId = table.Column<int>(type: "int", nullable: true),
                    MalzemeAltGrup2Id = table.Column<int>(type: "int", nullable: true),
                    OlcuBirimId = table.Column<int>(type: "int", nullable: true),
                    MalzemeStandartId = table.Column<int>(type: "int", nullable: true),
                    HammaddeId = table.Column<int>(type: "int", nullable: true),
                    IsFromExcel = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: true),
                    CreatedByComputer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedByUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedByComputer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stokkart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stokkart_hammadde_HammaddeId",
                        column: x => x.HammaddeId,
                        principalTable: "hammadde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_malzemealtgrup2_MalzemeAltGrup2Id",
                        column: x => x.MalzemeAltGrup2Id,
                        principalTable: "malzemealtgrup2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_malzemealtgrup_MalzemeAltGrupId",
                        column: x => x.MalzemeAltGrupId,
                        principalTable: "malzemealtgrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_malzemegrup_MalzemeGrupId",
                        column: x => x.MalzemeGrupId,
                        principalTable: "malzemegrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_malzemestandart_MalzemeStandartId",
                        column: x => x.MalzemeStandartId,
                        principalTable: "malzemestandart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_olcubirim_OlcuBirimId",
                        column: x => x.OlcuBirimId,
                        principalTable: "olcubirim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_stokgrup_StokGrupId",
                        column: x => x.StokGrupId,
                        principalTable: "stokgrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stokkart_stoktip_StokTipId",
                        column: x => x.StokTipId,
                        principalTable: "stoktip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_malzemealtgrup_MalzemeGrupId",
                table: "malzemealtgrup",
                column: "MalzemeGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_malzemealtgrup2_MalzemeAltGrupId",
                table: "malzemealtgrup2",
                column: "MalzemeAltGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_malzemegrup_StokGrupId",
                table: "malzemegrup",
                column: "StokGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_HammaddeId",
                table: "stokkart",
                column: "HammaddeId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_MalzemeAltGrup2Id",
                table: "stokkart",
                column: "MalzemeAltGrup2Id");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_MalzemeAltGrupId",
                table: "stokkart",
                column: "MalzemeAltGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_MalzemeGrupId",
                table: "stokkart",
                column: "MalzemeGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_MalzemeStandartId",
                table: "stokkart",
                column: "MalzemeStandartId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_OlcuBirimId",
                table: "stokkart",
                column: "OlcuBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_StokGrupId",
                table: "stokkart",
                column: "StokGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_stokkart_StokTipId",
                table: "stokkart",
                column: "StokTipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stokkart");

            migrationBuilder.DropTable(
                name: "hammadde");

            migrationBuilder.DropTable(
                name: "malzemealtgrup2");

            migrationBuilder.DropTable(
                name: "malzemestandart");

            migrationBuilder.DropTable(
                name: "olcubirim");

            migrationBuilder.DropTable(
                name: "stoktip");

            migrationBuilder.DropTable(
                name: "malzemealtgrup");

            migrationBuilder.DropTable(
                name: "malzemegrup");

            migrationBuilder.DropTable(
                name: "stokgrup");
        }
    }
}
