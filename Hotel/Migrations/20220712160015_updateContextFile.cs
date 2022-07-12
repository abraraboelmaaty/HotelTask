using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    public partial class updateContextFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Rooms_Status_Enum",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "available",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rooms_Status_Enum",
                table: "Rooms",
                sql: "[Status] IN (N'available', N'booked')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Rooms_Status_Enum",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "available");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rooms_Status_Enum",
                table: "Rooms",
                sql: "[Status] IN (0, 1)");
        }
    }
}
