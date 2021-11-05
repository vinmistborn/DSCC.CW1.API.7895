using Microsoft.EntityFrameworkCore.Migrations;

namespace DSCC.CW1.DAL._7895.Migrations
{
    public partial class DeleteTeacherColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teachers_TeacherId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teachers_TeacherId",
                table: "Course",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teachers_TeacherId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teachers_TeacherId",
                table: "Course",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
