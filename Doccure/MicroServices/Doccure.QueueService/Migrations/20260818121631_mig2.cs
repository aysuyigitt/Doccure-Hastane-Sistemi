using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doccure.QueueService.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentTime",
                table: "PaitentQueues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "PaitentQueues",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "PaitentQueues");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "PaitentQueues");
        }
    }
}
