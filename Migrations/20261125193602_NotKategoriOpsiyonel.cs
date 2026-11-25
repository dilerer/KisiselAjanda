using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisiselAjandaWeb.Migrations
{
    /// <inheritdoc />
    public partial class NotKategoriOpsiyonel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagimsizNotlar_Kategoriler_KategoriID",
                table: "BagimsizNotlar");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "BagimsizNotlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BagimsizNotlar_Kategoriler_KategoriID",
                table: "BagimsizNotlar",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagimsizNotlar_Kategoriler_KategoriID",
                table: "BagimsizNotlar");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "BagimsizNotlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BagimsizNotlar_Kategoriler_KategoriID",
                table: "BagimsizNotlar",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
