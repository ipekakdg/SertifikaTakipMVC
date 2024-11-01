using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SertifikaKontrol.Migrations
{
    /// <inheritdoc />
    public partial class newmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozisyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IseGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerID);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    NotificationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.NotificationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    SertifikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    SertifikaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SertifikaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SertifikaSaglayici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.SertifikaID);
                    table.ForeignKey(
                        name: "FK_Certificates_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationPreferences",
                columns: table => new
                {
                    NotificationPreferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    EpostaBildirim = table.Column<bool>(type: "bit", nullable: false),
                    SMSBildirim = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationPreferences", x => x.NotificationPreferenceID);
                    table.ForeignKey(
                        name: "FK_NotificationPreferences_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Applies",
                columns: table => new
                {
                    ApplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    CertificateID = table.Column<int>(type: "int", nullable: true),
                    BasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Belgeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnayDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OnayTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnaylayanYoneticiID = table.Column<int>(type: "int", nullable: true),
                    ReddedenYoneticiID = table.Column<int>(type: "int", nullable: true),
                    RedSebebi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applies", x => x.ApplyID);
                    table.ForeignKey(
                        name: "FK_Applies_Certificates_CertificateID",
                        column: x => x.CertificateID,
                        principalTable: "Certificates",
                        principalColumn: "SertifikaID");
                    table.ForeignKey(
                        name: "FK_Applies_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "ESignatureCertificates",
                columns: table => new
                {
                    EimzaSertifikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateID = table.Column<int>(type: "int", nullable: true),
                    SertifikaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SertifikaSahibi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EimzaDosyaYolu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESignatureCertificates", x => x.EimzaSertifikaID);
                    table.ForeignKey(
                        name: "FK_ESignatureCertificates_Certificates_CertificateID",
                        column: x => x.CertificateID,
                        principalTable: "Certificates",
                        principalColumn: "SertifikaID");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplyID = table.Column<int>(type: "int", nullable: true),
                    CertificateID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    BasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Belgeler = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_Applies_ApplyID",
                        column: x => x.ApplyID,
                        principalTable: "Applies",
                        principalColumn: "ApplyID");
                    table.ForeignKey(
                        name: "FK_Applications_Certificates_CertificateID",
                        column: x => x.CertificateID,
                        principalTable: "Certificates",
                        principalColumn: "SertifikaID");
                    table.ForeignKey(
                        name: "FK_Applications_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    ApplyID = table.Column<int>(type: "int", nullable: true),
                    ApplicationID = table.Column<int>(type: "int", nullable: true),
                    BildirimMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_Notifications_Applies_ApplyID",
                        column: x => x.ApplyID,
                        principalTable: "Applies",
                        principalColumn: "ApplyID");
                    table.ForeignKey(
                        name: "FK_Notifications_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationRecords",
                columns: table => new
                {
                    NotificationRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationID = table.Column<int>(type: "int", nullable: true),
                    NotificationTypeID = table.Column<int>(type: "int", nullable: true),
                    GonderilenTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRecords", x => x.NotificationRecordID);
                    table.ForeignKey(
                        name: "FK_NotificationRecords_NotificationTypes_NotificationTypeID",
                        column: x => x.NotificationTypeID,
                        principalTable: "NotificationTypes",
                        principalColumn: "NotificationTypeID");
                    table.ForeignKey(
                        name: "FK_NotificationRecords_Notifications_NotificationID",
                        column: x => x.NotificationID,
                        principalTable: "Notifications",
                        principalColumn: "NotificationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplyID",
                table: "Applications",
                column: "ApplyID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CertificateID",
                table: "Applications",
                column: "CertificateID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_EmployeeID",
                table: "Applications",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Applies_CertificateID",
                table: "Applies",
                column: "CertificateID");

            migrationBuilder.CreateIndex(
                name: "IX_Applies_EmployeeID",
                table: "Applies",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_EmployeeID",
                table: "Certificates",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ESignatureCertificates_CertificateID",
                table: "ESignatureCertificates",
                column: "CertificateID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPreferences_EmployeeID",
                table: "NotificationPreferences",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecords_NotificationID",
                table: "NotificationRecords",
                column: "NotificationID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecords_NotificationTypeID",
                table: "NotificationRecords",
                column: "NotificationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ApplicationID",
                table: "Notifications",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ApplyID",
                table: "Notifications",
                column: "ApplyID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EmployeeID",
                table: "Notifications",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESignatureCertificates");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "NotificationPreferences");

            migrationBuilder.DropTable(
                name: "NotificationRecords");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Applies");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
