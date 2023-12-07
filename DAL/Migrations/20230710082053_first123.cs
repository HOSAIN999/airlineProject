using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class first123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Tickets_Companies_CompanyID",
                table: "Company_Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Tickets_Tickets_TicketBEID",
                table: "Company_Tickets");

            migrationBuilder.DropColumn(
                name: "ComparyID",
                table: "Company_Tickets");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Company_Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketBEID",
                table: "Company_Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "Company_Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Tickets_Companies_CompanyID",
                table: "Company_Tickets",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Tickets_Tickets_TicketBEID",
                table: "Company_Tickets",
                column: "TicketBEID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Tickets_Companies_CompanyID",
                table: "Company_Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Tickets_Tickets_TicketBEID",
                table: "Company_Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketBEID",
                table: "Company_Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "Company_Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Tickets_Companies_CompanyID",
                table: "Company_Tickets",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Tickets_Tickets_TicketBEID",
                table: "Company_Tickets",
                column: "TicketBEID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
