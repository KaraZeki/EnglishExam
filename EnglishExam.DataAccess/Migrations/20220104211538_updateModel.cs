using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishExam.DataAccess.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstantsValues");

            migrationBuilder.DropTable(
                name: "Constants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constants",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDelete = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsSystem = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstantsValues",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    ConstantsId = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    GeneralCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDelete = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<decimal>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ConstantsValues_ConstantsId",
                table: "ConstantsValues",
                column: "ConstantsId");
        }
    }
}
