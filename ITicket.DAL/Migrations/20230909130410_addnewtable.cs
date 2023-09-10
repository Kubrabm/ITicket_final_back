using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITicket.DAL.Migrations
{
    public partial class addnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailPageImg",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailPageImg",
                table: "Concerts");
        }
    }
}
