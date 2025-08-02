using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlmaTalepveTeklif_v2_talepdetay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StokKartId1",
                table: "satinalmatalepdetay",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_satinalmatalepdetay_StokKartId1",
                table: "satinalmatalepdetay",
                column: "StokKartId1");

            migrationBuilder.CreateIndex(
                name: "IX_satinalmatalepbaslik_OnayKullaniciId",
                table: "satinalmatalepbaslik",
                column: "OnayKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_satinalmatalepbaslik_TalepEdenKullaniciId",
                table: "satinalmatalepbaslik",
                column: "TalepEdenKullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_satinalmatalepbaslik_kullanici_OnayKullaniciId",
                table: "satinalmatalepbaslik",
                column: "OnayKullaniciId",
                principalTable: "kullanici",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_satinalmatalepbaslik_kullanici_TalepEdenKullaniciId",
                table: "satinalmatalepbaslik",
                column: "TalepEdenKullaniciId",
                principalTable: "kullanici",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_satinalmatalepdetay_stokkart_StokKartId1",
                table: "satinalmatalepdetay",
                column: "StokKartId1",
                principalTable: "stokkart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_satinalmatalepbaslik_kullanici_OnayKullaniciId",
                table: "satinalmatalepbaslik");

            migrationBuilder.DropForeignKey(
                name: "FK_satinalmatalepbaslik_kullanici_TalepEdenKullaniciId",
                table: "satinalmatalepbaslik");

            migrationBuilder.DropForeignKey(
                name: "FK_satinalmatalepdetay_stokkart_StokKartId1",
                table: "satinalmatalepdetay");

            migrationBuilder.DropIndex(
                name: "IX_satinalmatalepdetay_StokKartId1",
                table: "satinalmatalepdetay");

            migrationBuilder.DropIndex(
                name: "IX_satinalmatalepbaslik_OnayKullaniciId",
                table: "satinalmatalepbaslik");

            migrationBuilder.DropIndex(
                name: "IX_satinalmatalepbaslik_TalepEdenKullaniciId",
                table: "satinalmatalepbaslik");

            migrationBuilder.DropColumn(
                name: "StokKartId1",
                table: "satinalmatalepdetay");
        }
    }
}
