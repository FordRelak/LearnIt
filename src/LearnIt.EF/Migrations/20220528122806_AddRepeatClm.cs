using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnIt.EF.Migrations
{
    public partial class AddRepeatClm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRepeat",
                table: "UserWord",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRepeat",
                table: "UserWord");
        }
    }
}
