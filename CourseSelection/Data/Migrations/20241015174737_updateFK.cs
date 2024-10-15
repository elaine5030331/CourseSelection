using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSelection.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_StudentDepartments",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_teachers_TeacherDepartments",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_teachers_departmentId",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_students_DepartmentId",
                table: "students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_teachers_departmentId",
                table: "teachers",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_students_DepartmentId",
                table: "students",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_StudentDepartments",
                table: "students",
                column: "DepartmentId",
                principalTable: "StudentDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_TeacherDepartments",
                table: "teachers",
                column: "departmentId",
                principalTable: "TeacherDepartments",
                principalColumn: "Id");
        }
    }
}
