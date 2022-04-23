using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Entity_Usuario_IncluirAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Usuarios");
        }
    }
}
