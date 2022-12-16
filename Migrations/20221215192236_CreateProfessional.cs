using Microsoft.EntityFrameworkCore.Migrations;

namespace STC.Migrations
{
    public partial class CreateProfessional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    ProfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfName = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    ProfCell = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    ProfJob = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    ProfConsultation = table.Column<bool>(type: "BIT", nullable: false),
                    ProfActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.ProfId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professional");
        }
    }
}
