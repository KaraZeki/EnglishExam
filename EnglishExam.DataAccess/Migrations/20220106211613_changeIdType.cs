using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishExam.DataAccess.Migrations
{
    public partial class changeIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamLists_Exams_ExamId1",
                table: "ExamLists");

            migrationBuilder.DropIndex(
                name: "IX_ExamLists_ExamId1",
                table: "ExamLists");

            migrationBuilder.DropColumn(
                name: "ExamId1",
                table: "ExamLists");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "ExamLists",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_ExamLists_ExamId",
                table: "ExamLists",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamLists_Exams_ExamId",
                table: "ExamLists",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamLists_Exams_ExamId",
                table: "ExamLists");

            migrationBuilder.DropIndex(
                name: "IX_ExamLists_ExamId",
                table: "ExamLists");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExamId",
                table: "ExamLists",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ExamId1",
                table: "ExamLists",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamLists_ExamId1",
                table: "ExamLists",
                column: "ExamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamLists_Exams_ExamId1",
                table: "ExamLists",
                column: "ExamId1",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
