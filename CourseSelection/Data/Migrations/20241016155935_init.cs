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
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "教室代碼"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "教室名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "學號"),
                    EnrollmentYear = table.Column<int>(type: "int", nullable: false, comment: "入學年份"),
                    Department = table.Column<int>(type: "int", nullable: false, comment: "所屬系所(心理學系 = 1, 特殊教育學系 = 2, 資訊管理學系 = 3, 資訊工程學系 = 4, 建築學系 = 5, 會計學系 = 6, 國際經營與貿易學系 =7")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false, comment: "所屬部門(理學院 = 1, 人文與教育學院 = 2, 商學院 = 3, 法學院 = 4, 電資學院 = 5, 工學院 = 6, 設計學院 =7)"),
                    Position = table.Column<int>(type: "int", nullable: false, comment: "職稱(助理教授 = 1, 副教授 = 2, 教授 = 3, 講師 = 4)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "課程名稱"),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false, comment: "必選修(必修為1，選修為0)"),
                    Language = table.Column<int>(type: "int", nullable: false, comment: "授課語言(國語 = 0, 英語 = 1)"),
                    Syllabus = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "課程簡介"),
                    AcademicYear = table.Column<short>(type: "smallint", nullable: false, comment: "學年度"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false, comment: "課程為每週幾，星期一 = 1，星期二 = 2，星期三 = 3..., 星期日 = 7"),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false, comment: "上課開始時間"),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false, comment: "上課結束時間"),
                    MaximumEnrollment = table.Column<int>(type: "int", nullable: false, comment: "開課人數上限"),
                    CurrentEnrollment = table.Column<int>(type: "int", nullable: false, comment: "目前選課人數"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, comment: "已刪除為1，未刪除為0"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Classes",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Teachers",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SelectedCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "選課狀態，選課成功 = 0, 已退選 = 1"),
                    SelectedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedCourses_Courese",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedCourses_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Classes_ClassId",
                table: "Classes",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClassId",
                table: "Courses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "UQ_Courses_CourseId",
                table: "Courses",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCourses_CourseId",
                table: "SelectedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCourses_StudentId",
                table: "SelectedCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "UQ_Students_StudentId",
                table: "Students",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Teachers_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
