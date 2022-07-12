using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    public partial class updateRoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBookingmore",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CoustomerCount",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBookingmore",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CoustomerCount",
                table: "Rooms");
        }
    }
}
