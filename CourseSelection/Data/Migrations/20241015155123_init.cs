using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSelection.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__classes__3213E83F86AA231D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83FCEAC9358", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enrollmentYear = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__students__3213E83FA4399641", x => x.id);
                    table.ForeignKey(
                        name: "FK__students__userId__46E78A0C",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_students_StudentDepartments",
                        column: x => x.DepartmentId,
                        principalTable: "StudentDepartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false, comment: "所屬部門"),
                    position = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__teachers__3213E83F8F85CF9D", x => x.id);
                    table.ForeignKey(
                        name: "FK__teachers__userId__47DBAE45",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_teachers_TeacherDepartments",
                        column: x => x.departmentId,
                        principalTable: "TeacherDepartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false),
                    required = table.Column<bool>(type: "bit", nullable: false),
                    language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    syllabus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    academicYear = table.Column<short>(type: "smallint", nullable: false),
                    dayOfWeek = table.Column<byte>(type: "tinyint", nullable: false),
                    startTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    endTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    maximumEnrollment = table.Column<int>(type: "int", nullable: false),
                    currentEnrollment = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    teacherId = table.Column<int>(type: "int", nullable: false),
                    classId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__courses__3213E83FB2C69356", x => x.id);
                    table.ForeignKey(
                        name: "FK__courses__teacher__4BAC3F29",
                        column: x => x.teacherId,
                        principalTable: "teachers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_courses_classes",
                        column: x => x.classId,
                        principalTable: "classes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "selectedCourses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    coursesId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    selectedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__selected__3213E83FCE6CC156", x => x.id);
                    table.ForeignKey(
                        name: "FK__selectedC__cours__49C3F6B7",
                        column: x => x.coursesId,
                        principalTable: "courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__selectedC__stude__48CFD27E",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__classes__7577347F0696B23A",
                table: "classes",
                column: "classId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_classId",
                table: "courses",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_teacherId",
                table: "courses",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "UQ__courses__2AA84FD08F807AB6",
                table: "courses",
                column: "courseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_selectedCourses_coursesId",
                table: "selectedCourses",
                column: "coursesId");

            migrationBuilder.CreateIndex(
                name: "IX_selectedCourses_studentId",
                table: "selectedCourses",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_students_DepartmentId",
                table: "students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UQ__students__CB9A1CFE2CB55CC4",
                table: "students",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_departmentId",
                table: "teachers",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "UQ__teachers__CB9A1CFE171CCC77",
                table: "teachers",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "selectedCourses");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "StudentDepartments");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "TeacherDepartments");
        }
    }
}
