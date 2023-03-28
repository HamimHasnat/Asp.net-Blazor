using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Av : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<string>(name: "Appointment_ID", type: "nvarchar(450)", nullable: false),
                    AppointmentName = table.Column<string>(name: "Appointment_Name", type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<string>(name: "Service_ID", type: "nvarchar(450)", nullable: false),
                    ServiceName = table.Column<string>(name: "Service_Name", type: "nvarchar(max)", nullable: false),
                    AppointmentID = table.Column<string>(name: "Appointment_ID", type: "nvarchar(450)", nullable: false),
                    ServiceFee = table.Column<string>(name: "Service_Fee", type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_Appointment_Appointment_ID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "Appointment_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_Appointment_ID",
                table: "Service",
                column: "Appointment_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
