using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pozisyon",
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
                    table.PrimaryKey("PK_pozisyon", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
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
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ulke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ulke", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sehir",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UlkeId = table.Column<int>(type: "int", nullable: true),
                    UlkeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehir", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sehir_ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sehir_ulke_UlkeId1",
                        column: x => x.UlkeId1,
                        principalTable: "ulke",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "firma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adres = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SehirId = table.Column<int>(type: "int", nullable: true),
                    UlkeId = table.Column<int>(type: "int", nullable: true),
                    VergiDairesi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoFirmaId = table.Column<int>(type: "int", nullable: true),
                    LogoCariKod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VergiNo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefon = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Faks = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostaKodu = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SehirId1 = table.Column<int>(type: "int", nullable: true),
                    UlkeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_firma_sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_firma_sehir_SehirId1",
                        column: x => x.SehirId1,
                        principalTable: "sehir",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_firma_ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_firma_ulke_UlkeId1",
                        column: x => x.UlkeId1,
                        principalTable: "ulke",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sifre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salt = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonelId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    IsSifreDegisti = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: true),
                    CreatedByComputer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedByUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedByComputer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kullanici_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_kullanici_rol_RolId1",
                        column: x => x.RolId1,
                        principalTable: "rol",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kod = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonelAd = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonelSoyad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefon = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PozisyonId = table.Column<int>(type: "int", nullable: true),
                    FirmaId = table.Column<int>(type: "int", nullable: true),
                    PersonelResimId = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "varchar(91)", maxLength: 91, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YoneticiPersonelId = table.Column<int>(type: "int", nullable: true),
                    FirmaId1 = table.Column<int>(type: "int", nullable: true),
                    PozisyonId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personel_firma_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "firma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personel_firma_FirmaId1",
                        column: x => x.FirmaId1,
                        principalTable: "firma",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_personel_personel_YoneticiPersonelId",
                        column: x => x.YoneticiPersonelId,
                        principalTable: "personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personel_pozisyon_PozisyonId",
                        column: x => x.PozisyonId,
                        principalTable: "pozisyon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personel_pozisyon_PozisyonId1",
                        column: x => x.PozisyonId1,
                        principalTable: "pozisyon",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personelresim",
                columns: table => new
                {
                    PersonelResimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    ResimData = table.Column<byte[]>(type: "longblob", nullable: true),
                    ImageFormat = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personelresim", x => x.PersonelResimId);
                    table.ForeignKey(
                        name: "FK_personelresim_personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_firma_SehirId",
                table: "firma",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_firma_SehirId1",
                table: "firma",
                column: "SehirId1");

            migrationBuilder.CreateIndex(
                name: "IX_firma_UlkeId",
                table: "firma",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_firma_UlkeId1",
                table: "firma",
                column: "UlkeId1");

            migrationBuilder.CreateIndex(
                name: "IX_kullanici_PersonelId",
                table: "kullanici",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_kullanici_RolId",
                table: "kullanici",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_kullanici_RolId1",
                table: "kullanici",
                column: "RolId1");

            migrationBuilder.CreateIndex(
                name: "IX_personel_FirmaId",
                table: "personel",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_personel_FirmaId1",
                table: "personel",
                column: "FirmaId1");

            migrationBuilder.CreateIndex(
                name: "IX_personel_PersonelResimId",
                table: "personel",
                column: "PersonelResimId");

            migrationBuilder.CreateIndex(
                name: "IX_personel_PozisyonId",
                table: "personel",
                column: "PozisyonId");

            migrationBuilder.CreateIndex(
                name: "IX_personel_PozisyonId1",
                table: "personel",
                column: "PozisyonId1");

            migrationBuilder.CreateIndex(
                name: "IX_personel_YoneticiPersonelId",
                table: "personel",
                column: "YoneticiPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_personelresim_PersonelId",
                table: "personelresim",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_sehir_UlkeId",
                table: "sehir",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_sehir_UlkeId1",
                table: "sehir",
                column: "UlkeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_kullanici_personel_PersonelId",
                table: "kullanici",
                column: "PersonelId",
                principalTable: "personel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personel_personelresim_PersonelResimId",
                table: "personel",
                column: "PersonelResimId",
                principalTable: "personelresim",
                principalColumn: "PersonelResimId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_firma_sehir_SehirId",
                table: "firma");

            migrationBuilder.DropForeignKey(
                name: "FK_firma_sehir_SehirId1",
                table: "firma");

            migrationBuilder.DropForeignKey(
                name: "FK_firma_ulke_UlkeId",
                table: "firma");

            migrationBuilder.DropForeignKey(
                name: "FK_firma_ulke_UlkeId1",
                table: "firma");

            migrationBuilder.DropForeignKey(
                name: "FK_personelresim_personel_PersonelId",
                table: "personelresim");

            migrationBuilder.DropTable(
                name: "kullanici");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "sehir");

            migrationBuilder.DropTable(
                name: "ulke");

            migrationBuilder.DropTable(
                name: "personel");

            migrationBuilder.DropTable(
                name: "firma");

            migrationBuilder.DropTable(
                name: "personelresim");

            migrationBuilder.DropTable(
                name: "pozisyon");
        }
    }
}
