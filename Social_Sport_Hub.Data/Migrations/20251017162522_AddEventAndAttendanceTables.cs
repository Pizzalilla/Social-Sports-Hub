using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_Sport_Hub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEventAndAttendanceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SportEventId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SportEventId",
                table: "Users",
                column: "SportEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_SportEventId",
                table: "AttendanceRecords",
                column: "SportEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_UserId",
                table: "AttendanceRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_SportEvents_SportEventId",
                table: "AttendanceRecords",
                column: "SportEventId",
                principalTable: "SportEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_Users_UserId",
                table: "AttendanceRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SportEvents_SportEventId",
                table: "Users",
                column: "SportEventId",
                principalTable: "SportEvents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_SportEvents_SportEventId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_Users_UserId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SportEvents_SportEventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SportEventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceRecords_SportEventId",
                table: "AttendanceRecords");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceRecords_UserId",
                table: "AttendanceRecords");

            migrationBuilder.DropColumn(
                name: "SportEventId",
                table: "Users");
        }
    }
}
