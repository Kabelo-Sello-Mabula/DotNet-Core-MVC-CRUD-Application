using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STUDATACRUD.Migrations
{
    public partial class StudCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
