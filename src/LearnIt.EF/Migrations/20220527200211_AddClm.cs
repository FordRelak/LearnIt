using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnIt.EF.Migrations
{
    public partial class AddClm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfWords",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfWords",
                table: "User");
        }
    }
}
