using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Update_Entity_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Acesso",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acesso",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Logins");
        }
    }
}
