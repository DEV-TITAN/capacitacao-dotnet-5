using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaTitanica.Migrations
{
    public partial class CorrecaoMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Narca",
                table: "Produtos",
                newName: "Marca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Produtos",
                newName: "Narca");
        }
    }
}
