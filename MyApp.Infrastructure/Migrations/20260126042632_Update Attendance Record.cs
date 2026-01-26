using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttendanceRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "AttendanceRecords");

            migrationBuilder.AddColumn<string>(
                name: "QrNumber",
                table: "AttendanceRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrNumber",
                table: "AttendanceRecords");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "AttendanceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
