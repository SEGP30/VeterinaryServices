using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace VeterinaryServices.Infrastructure.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Names = table.Column<string>(type: "text", nullable: true),
                    Surnames = table.Column<string>(type: "text", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Names = table.Column<string>(type: "text", nullable: true),
                    Surnames = table.Column<string>(type: "text", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Profile = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AestheticServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    PetId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AestheticServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AestheticServices_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AestheticServices_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Observation = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    PetId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAppointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Observation = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    PetId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAppointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalAppointments_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AestheticServices_DoctorId",
                table: "AestheticServices",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AestheticServices_PetId",
                table: "AestheticServices",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_DoctorId",
                table: "Hospitalizations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_PetId",
                table: "Hospitalizations",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_DoctorId",
                table: "MedicalAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_PetId",
                table: "MedicalAppointments",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AestheticServices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Hospitalizations");

            migrationBuilder.DropTable(
                name: "MedicalAppointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
