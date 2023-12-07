using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class firsttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComparyID",
                table: "Company_Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "Company_Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComparyID",
                table: "Company_Tickets");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Company_Tickets");
        }
    }
}
