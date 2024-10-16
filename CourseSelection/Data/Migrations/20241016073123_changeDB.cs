using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSelection.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__courses__teacher__4BAC3F29",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_courses_classes",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK__selectedC__cours__49C3F6B7",
                table: "selectedCourses");

            migrationBuilder.DropForeignKey(
                name: "FK__selectedC__stude__48CFD27E",
                table: "selectedCourses");

            migrationBuilder.DropForeignKey(
                name: "FK__students__userId__46E78A0C",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK__teachers__userId__47DBAE45",
                table: "teachers");

            migrationBuilder.DropTable(
                name: "StudentDepartments");

            migrationBuilder.DropTable(
                name: "TeacherDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__users__3213E83FCEAC9358",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__teachers__3213E83F8F85CF9D",
                table: "teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__students__3213E83FA4399641",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK__selected__3213E83FCE6CC156",
                table: "selectedCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__courses__3213E83FB2C69356",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__classes__3213E83F86AA231D",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "positionId",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "students");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "teachers",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "selectedCourses",
                newName: "SelectedCourses");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "classes",
                newName: "Classes");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Teachers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Teachers",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "UQ__teachers__CB9A1CFE171CCC77",
                table: "Teachers",
                newName: "UQ_Teachers_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Students",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "enrollmentYear",
                table: "Students",
                newName: "EnrollmentYear");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "UQ__students__CB9A1CFE2CB55CC4",
                table: "Students",
                newName: "UQ_Students_UserId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "SelectedCourses",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "selectedAt",
                table: "SelectedCourses",
                newName: "SelectedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SelectedCourses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "coursesId",
                table: "SelectedCourses",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_selectedCourses_studentId",
                table: "SelectedCourses",
                newName: "IX_SelectedCourses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_selectedCourses_coursesId",
                table: "SelectedCourses",
                newName: "IX_SelectedCourses_CourseId");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "syllabus",
                table: "Courses",
                newName: "Syllabus");

            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "Courses",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "required",
                table: "Courses",
                newName: "Required");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "maximumEnrollment",
                table: "Courses",
                newName: "MaximumEnrollment");

            migrationBuilder.RenameColumn(
                name: "language",
                table: "Courses",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "Courses",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "Courses",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "dayOfWeek",
                table: "Courses",
                newName: "DayOfWeek");

            migrationBuilder.RenameColumn(
                name: "currentEnrollment",
                table: "Courses",
                newName: "CurrentEnrollment");

            migrationBuilder.RenameColumn(
                name: "credits",
                table: "Courses",
                newName: "Credits");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "classId",
                table: "Courses",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "academicYear",
                table: "Courses",
                newName: "AcademicYear");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_courses_teacherId",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_courses_classId",
                table: "Courses",
                newName: "IX_Courses_ClassId");

            migrationBuilder.RenameIndex(
                name: "UQ__courses__2AA84FD08F807AB6",
                table: "Courses",
                newName: "UQ_Coureses_CourseId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Classes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "classId",
                table: "Classes",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Classes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "UQ__classes__7577347F0696B23A",
                table: "Classes",
                newName: "UQ_Classes_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "所屬部門(理學院 = 1, 人文與教育學院 = 2, 商學院 = 3, 法學院 = 4, 電資學院 = 5, 工學院 = 6, 設計學院 =7)");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "職稱(助理教授 = 1, 副教授 = 2, 教授 = 3, 講師 = 4)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "學號",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "EnrollmentYear",
                table: "Students",
                type: "int",
                nullable: false,
                comment: "入學年份",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "所屬系所(心理學系 = 1, 特殊教育學系 = 2, 資訊管理學系 = 3, 資訊工程學系 = 4, 建築學系 = 5, 會計學系 = 6, 國際經營與貿易學系 =7");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedAt",
                table: "SelectedCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "SelectedCourses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "選課狀態，選課成功 = 0, 已退選 = 1",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Syllabus",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "課程簡介",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "Courses",
                type: "time",
                nullable: false,
                comment: "上課開始時間",
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<bool>(
                name: "Required",
                table: "Courses",
                type: "bit",
                nullable: false,
                comment: "必選修(必修為1，選修為0)",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "課程名稱",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MaximumEnrollment",
                table: "Courses",
                type: "int",
                nullable: false,
                comment: "開課人數上限",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "Courses",
                type: "int",
                nullable: false,
                comment: "授課語言(國語 = 0, 英語 = 1)",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Courses",
                type: "bit",
                nullable: false,
                comment: "已刪除為1，未刪除為0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "Courses",
                type: "time",
                nullable: false,
                comment: "上課結束時間",
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<byte>(
                name: "DayOfWeek",
                table: "Courses",
                type: "tinyint",
                nullable: false,
                comment: "課程為每週幾，星期一 = 1，星期二 = 2，星期三 = 3..., 星期日 = 7",
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentEnrollment",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "目前選課人數",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<short>(
                name: "AcademicYear",
                table: "Courses",
                type: "smallint",
                nullable: false,
                comment: "學年度",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classes",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "教室名稱",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "Classes",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "教室代碼",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedCourses",
                table: "SelectedCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courese",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UQ_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Teachers_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Students_StudentId",
                table: "Students",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courese_Classes",
                table: "Courses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courese_Teachers",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCourses_Courese",
                table: "SelectedCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCourses_Students",
                table: "SelectedCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users",
                table: "Teachers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courese_Classes",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courese_Teachers",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCourses_Courese",
                table: "SelectedCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCourses_Students",
                table: "SelectedCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ_Users_Phone",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "UQ_Teachers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "UQ_Students_StudentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedCourses",
                table: "SelectedCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courese",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "teachers");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameTable(
                name: "SelectedCourses",
                newName: "selectedCourses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "courses");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "classes");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "teachers",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "teachers",
                newName: "teacherId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "teachers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "UQ_Teachers_UserId",
                table: "teachers",
                newName: "UQ__teachers__CB9A1CFE171CCC77");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "students",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "students",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "EnrollmentYear",
                table: "students",
                newName: "enrollmentYear");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "students",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "UQ_Students_UserId",
                table: "students",
                newName: "UQ__students__CB9A1CFE2CB55CC4");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "selectedCourses",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "SelectedAt",
                table: "selectedCourses",
                newName: "selectedAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "selectedCourses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "selectedCourses",
                newName: "coursesId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedCourses_StudentId",
                table: "selectedCourses",
                newName: "IX_selectedCourses_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedCourses_CourseId",
                table: "selectedCourses",
                newName: "IX_selectedCourses_coursesId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "courses",
                newName: "teacherId");

            migrationBuilder.RenameColumn(
                name: "Syllabus",
                table: "courses",
                newName: "syllabus");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "courses",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "Required",
                table: "courses",
                newName: "required");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "courses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MaximumEnrollment",
                table: "courses",
                newName: "maximumEnrollment");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "courses",
                newName: "language");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "courses",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "courses",
                newName: "endTime");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "courses",
                newName: "dayOfWeek");

            migrationBuilder.RenameColumn(
                name: "CurrentEnrollment",
                table: "courses",
                newName: "currentEnrollment");

            migrationBuilder.RenameColumn(
                name: "Credits",
                table: "courses",
                newName: "credits");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "courses",
                newName: "courseId");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "courses",
                newName: "classId");

            migrationBuilder.RenameColumn(
                name: "AcademicYear",
                table: "courses",
                newName: "academicYear");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "courses",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "courses",
                newName: "IX_courses_teacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_ClassId",
                table: "courses",
                newName: "IX_courses_classId");

            migrationBuilder.RenameIndex(
                name: "UQ_Coureses_CourseId",
                table: "courses",
                newName: "UQ__courses__2AA84FD08F807AB6");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "classes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "classes",
                newName: "classId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "classes",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "UQ_Classes_ClassId",
                table: "classes",
                newName: "UQ__classes__7577347F0696B23A");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "所屬部門");

            migrationBuilder.AddColumn<int>(
                name: "positionId",
                table: "teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "學號");

            migrationBuilder.AlterColumn<int>(
                name: "enrollmentYear",
                table: "students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "入學年份");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "selectedCourses",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldComment: "選課狀態，選課成功 = 0, 已退選 = 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "selectedAt",
                table: "selectedCourses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "syllabus",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "課程簡介");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "startTime",
                table: "courses",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldComment: "上課開始時間");

            migrationBuilder.AlterColumn<bool>(
                name: "required",
                table: "courses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "必選修(必修為1，選修為0)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "課程名稱");

            migrationBuilder.AlterColumn<int>(
                name: "maximumEnrollment",
                table: "courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "開課人數上限");

            migrationBuilder.AlterColumn<int>(
                name: "language",
                table: "courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "授課語言(國語 = 0, 英語 = 1)");

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "courses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "已刪除為1，未刪除為0");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "endTime",
                table: "courses",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldComment: "上課結束時間");

            migrationBuilder.AlterColumn<byte>(
                name: "dayOfWeek",
                table: "courses",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldComment: "課程為每週幾，星期一 = 1，星期二 = 2，星期三 = 3..., 星期日 = 7");

            migrationBuilder.AlterColumn<int>(
                name: "currentEnrollment",
                table: "courses",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "目前選課人數");

            migrationBuilder.AlterColumn<short>(
                name: "academicYear",
                table: "courses",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComment: "學年度");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "classes",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "教室名稱");

            migrationBuilder.AlterColumn<string>(
                name: "classId",
                table: "classes",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "教室代碼");

            migrationBuilder.AddPrimaryKey(
                name: "PK__users__3213E83FCEAC9358",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__teachers__3213E83F8F85CF9D",
                table: "teachers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__students__3213E83FA4399641",
                table: "students",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__selected__3213E83FCE6CC156",
                table: "selectedCourses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__courses__3213E83FB2C69356",
                table: "courses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__classes__3213E83F86AA231D",
                table: "classes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "StudentDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDepartments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK__courses__teacher__4BAC3F29",
                table: "courses",
                column: "teacherId",
                principalTable: "teachers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_classes",
                table: "courses",
                column: "classId",
                principalTable: "classes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__selectedC__cours__49C3F6B7",
                table: "selectedCourses",
                column: "coursesId",
                principalTable: "courses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__selectedC__stude__48CFD27E",
                table: "selectedCourses",
                column: "studentId",
                principalTable: "students",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__students__userId__46E78A0C",
                table: "students",
                column: "userId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__teachers__userId__47DBAE45",
                table: "teachers",
                column: "userId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
