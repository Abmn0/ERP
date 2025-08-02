using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProjeTablolar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kod = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marka", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projesurectanim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projesurectanim", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projetip",
                columns: table => new
                {
                    ProjeTipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjeTipAd = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projetip", x => x.ProjeTipId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "satissiparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SiparisNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SiparisTutari = table.Column<double>(type: "double", nullable: true),
                    OngoruMaliyeti = table.Column<double>(type: "double", nullable: true),
                    Kdv = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satissiparis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "markaaltgrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kod = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markaaltgrup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_markaaltgrup_marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "markaaltgrupkategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MarkaAltGrupId = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kod = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markaaltgrupkategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_markaaltgrupkategori_markaaltgrup_MarkaAltGrupId",
                        column: x => x.MarkaAltGrupId,
                        principalTable: "markaaltgrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjeTipId = table.Column<int>(type: "int", nullable: true),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    ProjeNo = table.Column<int>(type: "int", nullable: true),
                    AltGrupId = table.Column<int>(type: "int", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilePaths = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SatisSiparisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proje_marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proje_markaaltgrup_AltGrupId",
                        column: x => x.AltGrupId,
                        principalTable: "markaaltgrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proje_markaaltgrupkategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "markaaltgrupkategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proje_projetip_ProjeTipId",
                        column: x => x.ProjeTipId,
                        principalTable: "projetip",
                        principalColumn: "ProjeTipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proje_satissiparis_SatisSiparisId",
                        column: x => x.SatisSiparisId,
                        principalTable: "satissiparis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projesorumlu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(type: "int", nullable: true),
                    PersonelId = table.Column<int>(type: "int", nullable: true),
                    Gorev = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projesorumlu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projesorumlu_personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projesorumlu_proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projestokkart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(type: "int", nullable: true),
                    StokKartId = table.Column<int>(type: "int", nullable: true),
                    Miktar = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projestokkart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projestokkart_proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projestokkart_stokkart_StokKartId",
                        column: x => x.StokKartId,
                        principalTable: "stokkart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projetakvim",
                columns: table => new
                {
                    ProjeTakvimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(type: "int", nullable: true),
                    ProjeSurecId = table.Column<int>(type: "int", nullable: true),
                    PlanlananBaslangicTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlanlananBitisTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GerceklesenBaslangicTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GerceklesenBitisTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projetakvim", x => x.ProjeTakvimId);
                    table.ForeignKey(
                        name: "FK_projetakvim_proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projetakvim_projesurectanim_ProjeSurecId",
                        column: x => x.ProjeSurecId,
                        principalTable: "projesurectanim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_markaaltgrup_MarkaId",
                table: "markaaltgrup",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_markaaltgrupkategori_MarkaAltGrupId",
                table: "markaaltgrupkategori",
                column: "MarkaAltGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_proje_AltGrupId",
                table: "proje",
                column: "AltGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_proje_KategoriId",
                table: "proje",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_proje_MarkaId",
                table: "proje",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_proje_ProjeTipId",
                table: "proje",
                column: "ProjeTipId");

            migrationBuilder.CreateIndex(
                name: "IX_proje_SatisSiparisId",
                table: "proje",
                column: "SatisSiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_projesorumlu_PersonelId",
                table: "projesorumlu",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_projesorumlu_ProjeId",
                table: "projesorumlu",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_projestokkart_ProjeId",
                table: "projestokkart",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_projestokkart_StokKartId",
                table: "projestokkart",
                column: "StokKartId");

            migrationBuilder.CreateIndex(
                name: "IX_projetakvim_ProjeId",
                table: "projetakvim",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_projetakvim_ProjeSurecId",
                table: "projetakvim",
                column: "ProjeSurecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projesorumlu");

            migrationBuilder.DropTable(
                name: "projestokkart");

            migrationBuilder.DropTable(
                name: "projetakvim");

            migrationBuilder.DropTable(
                name: "proje");

            migrationBuilder.DropTable(
                name: "projesurectanim");

            migrationBuilder.DropTable(
                name: "markaaltgrupkategori");

            migrationBuilder.DropTable(
                name: "projetip");

            migrationBuilder.DropTable(
                name: "satissiparis");

            migrationBuilder.DropTable(
                name: "markaaltgrup");

            migrationBuilder.DropTable(
                name: "marka");
        }
    }
}
