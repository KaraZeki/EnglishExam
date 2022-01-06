using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EnglishExam.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constants",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    IsDelete = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsSystem = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ExamText = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstantsValues",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ConstantsId = table.Column<decimal>(type: "TEXT", nullable: true),
                    GeneralCode = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsDelete = table.Column<decimal>(type: "TEXT", nullable: false),
                    Order = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstantsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstantsValues_Constants_ConstantsId",
                        column: x => x.ConstantsId,
                        principalTable: "Constants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamLists",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    OptionA = table.Column<string>(type: "TEXT", nullable: true),
                    OptionB = table.Column<string>(type: "TEXT", nullable: true),
                    OptionC = table.Column<string>(type: "TEXT", nullable: true),
                    OptionD = table.Column<string>(type: "TEXT", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "TEXT", nullable: true),
                    ExamId = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamLists_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstantsValues_ConstantsId",
                table: "ConstantsValues",
                column: "ConstantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamLists_ExamId",
                table: "ExamLists",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstantsValues");

            migrationBuilder.DropTable(
                name: "ExamLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Constants");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
