using Microsoft.EntityFrameworkCore.Migrations;

namespace DSCC.CW1.DAL._7895.Migrations
{
    public partial class AddBranchAndStatusColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Branch",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Course",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Course");
        }
    }
}
