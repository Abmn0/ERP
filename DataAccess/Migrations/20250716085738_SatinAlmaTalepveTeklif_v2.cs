using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlmaTalepveTeklif_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "satinalmatalepbaslik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_satinalmatalepbaslik_FirmaId",
                table: "satinalmatalepbaslik",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_satinalmatalepbaslik_firma_FirmaId",
                table: "satinalmatalepbaslik",
                column: "FirmaId",
                principalTable: "firma",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_satinalmatalepbaslik_firma_FirmaId",
                table: "satinalmatalepbaslik");

            migrationBuilder.DropIndex(
                name: "IX_satinalmatalepbaslik_FirmaId",
                table: "satinalmatalepbaslik");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "satinalmatalepbaslik");
        }
    }
}
