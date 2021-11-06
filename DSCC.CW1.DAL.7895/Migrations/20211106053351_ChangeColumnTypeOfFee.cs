using Microsoft.EntityFrameworkCore.Migrations;

namespace DSCC.CW1.DAL._7895.Migrations
{
    public partial class ChangeColumnTypeOfFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Fee",
                table: "Course",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Fee",
                table: "Course",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
