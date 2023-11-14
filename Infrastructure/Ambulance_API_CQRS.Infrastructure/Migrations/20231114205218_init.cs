using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambulance_API_CQRS.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Callings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCAllAmbulance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCall = table.Column<DateTime>(type: "date", nullable: false),
                    TimeCall = table.Column<TimeSpan>(type: "time", nullable: false),
                    CauseCall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedirectCall = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Callings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameLocality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberAccident_AssistantSquad = table.Column<int>(type: "int", nullable: false),
                    DateDepart = table.Column<DateTime>(type: "date", nullable: false),
                    TimeDepart = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartPatient = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTimePatient = table.Column<TimeSpan>(type: "time", nullable: false),
                    NameHospital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallingAmbulanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departs_Callings_CallingAmbulanceId",
                        column: x => x.CallingAmbulanceId,
                        principalTable: "Callings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberEntranceOfHouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberFlat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthYear = table.Column<DateTime>(type: "date", nullable: false),
                    CallingAmbulanceId = table.Column<int>(type: "int", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: true),
                    LocalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Callings_CallingAmbulanceId",
                        column: x => x.CallingAmbulanceId,
                        principalTable: "Callings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Callings_DateCall",
                table: "Callings",
                column: "DateCall");

            migrationBuilder.CreateIndex(
                name: "IX_Departs_CallingAmbulanceId",
                table: "Departs",
                column: "CallingAmbulanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departs_DateDepart",
                table: "Departs",
                column: "DateDepart");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CallingAmbulanceId",
                table: "Patients",
                column: "CallingAmbulanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LocalityId",
                table: "Patients",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Name_FamilyName_Patronymic",
                table: "Patients",
                columns: new[] { "Name", "FamilyName", "Patronymic" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StreetId",
                table: "Patients",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_LocalityId",
                table: "Streets",
                column: "LocalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Callings");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Localities");
        }
    }
}
