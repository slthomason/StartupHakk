using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _09_Razor_Page_EF_Core_P7.Migrations
{
    public partial class ColumnFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Secret",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Student",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Student",
                newName: "FirstMidName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstMidName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Secret",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
