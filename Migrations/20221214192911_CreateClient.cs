using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STC.Migrations
{
    public partial class CreateClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliName = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliNameMother = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliNameFather = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliBirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CliAddressStreet = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliAddressNeighborhood = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliAddressFull = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliAddressNumber = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliAddressCity = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliSchool = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliSchoolGrade = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliSchoolCity = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliSchoolState = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CliPhoneNumber = table.Column<string>(type: "NVARCHAR(16)", maxLength: 16, nullable: false),
                    CliPhoneCell = table.Column<string>(type: "NVARCHAR(16)", maxLength: 16, nullable: false),
                    CliNote = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    CliActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CliId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
