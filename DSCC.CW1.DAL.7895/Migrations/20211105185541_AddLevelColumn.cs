using Microsoft.EntityFrameworkCore.Migrations;

namespace DSCC.CW1.DAL._7895.Migrations
{
    public partial class AddLevelColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Course",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Course");
        }
    }
}
