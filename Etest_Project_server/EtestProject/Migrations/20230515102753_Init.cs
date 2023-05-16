using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtestProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserStudentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudentTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTeacherTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeacherTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gradeStudent = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_studentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeTable_UserStudentTable_User_studentId",
                        column: x => x.User_studentId,
                        principalTable: "UserStudentTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameOfTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Random = table.Column<bool>(type: "bit", nullable: false),
                    User_teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestTable_UserTeacherTable_User_teacherId",
                        column: x => x.User_teacherId,
                        principalTable: "UserTeacherTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErrorsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    ErrorAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrueAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorsTable_GradeTable_GradeId",
                        column: x => x.GradeId,
                        principalTable: "GradeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correctAnswer = table.Column<int>(type: "int", nullable: false),
                    questionURLImageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    studentChoose = table.Column<int>(type: "int", nullable: false),
                    valueOfQuestion = table.Column<int>(type: "int", nullable: false),
                    isOpen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionTable_TestTable_TestId",
                        column: x => x.TestId,
                        principalTable: "TestTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerTable_QuestionTable_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTable_QuestionId",
                table: "AnswerTable",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorsTable_GradeId",
                table: "ErrorsTable",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeTable_User_studentId",
                table: "GradeTable",
                column: "User_studentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTable_TestId",
                table: "QuestionTable",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestTable_User_teacherId",
                table: "TestTable",
                column: "User_teacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerTable");

            migrationBuilder.DropTable(
                name: "ErrorsTable");

            migrationBuilder.DropTable(
                name: "QuestionTable");

            migrationBuilder.DropTable(
                name: "GradeTable");

            migrationBuilder.DropTable(
                name: "TestTable");

            migrationBuilder.DropTable(
                name: "UserStudentTable");

            migrationBuilder.DropTable(
                name: "UserTeacherTable");
        }
    }
}
