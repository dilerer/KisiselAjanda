using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisiselAjandaWeb.Migrations
{
    /// <inheritdoc />
    public partial class IlkTablolariKur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RenkKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "TakvimGunleri",
                columns: table => new
                {
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GununOzeti = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DurumRengi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GununNotu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakvimGunleri", x => x.Tarih);
                });

            migrationBuilder.CreateTable(
                name: "BagimsizNotlar",
                columns: table => new
                {
                    NotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagimsizNotlar", x => x.NotID);
                    table.ForeignKey(
                        name: "FK_BagimsizNotlar_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PanoObjeleri",
                columns: table => new
                {
                    ObjelD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjeTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KonumX = table.Column<int>(type: "int", nullable: false),
                    KonumY = table.Column<int>(type: "int", nullable: false),
                    Genislik = table.Column<int>(type: "int", nullable: false),
                    Yukseklik = table.Column<int>(type: "int", nullable: false),
                    ArkaPlanRengi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanoObjeleri", x => x.ObjelD);
                    table.ForeignKey(
                        name: "FK_PanoObjeleri_TakvimGunleri_Tarih",
                        column: x => x.Tarih,
                        principalTable: "TakvimGunleri",
                        principalColumn: "Tarih",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PomodoroKayitlari",
                columns: table => new
                {
                    KayitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    DersEtiketi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroKayitlari", x => x.KayitID);
                    table.ForeignKey(
                        name: "FK_PomodoroKayitlari_TakvimGunleri_Tarih",
                        column: x => x.Tarih,
                        principalTable: "TakvimGunleri",
                        principalColumn: "Tarih",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yapilacaklar",
                columns: table => new
                {
                    GorevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GorevMetni = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TamamlandiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yapilacaklar", x => x.GorevID);
                    table.ForeignKey(
                        name: "FK_Yapilacaklar_TakvimGunleri_Tarih",
                        column: x => x.Tarih,
                        principalTable: "TakvimGunleri",
                        principalColumn: "Tarih",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BagimsizNotlar_KategoriID",
                table: "BagimsizNotlar",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_PanoObjeleri_Tarih",
                table: "PanoObjeleri",
                column: "Tarih");

            migrationBuilder.CreateIndex(
                name: "IX_PomodoroKayitlari_Tarih",
                table: "PomodoroKayitlari",
                column: "Tarih");

            migrationBuilder.CreateIndex(
                name: "IX_Yapilacaklar_Tarih",
                table: "Yapilacaklar",
                column: "Tarih");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagimsizNotlar");

            migrationBuilder.DropTable(
                name: "PanoObjeleri");

            migrationBuilder.DropTable(
                name: "PomodoroKayitlari");

            migrationBuilder.DropTable(
                name: "Yapilacaklar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "TakvimGunleri");
        }
    }
}
