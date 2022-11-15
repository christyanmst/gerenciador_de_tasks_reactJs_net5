using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorTarefas.Migrations
{
    public partial class ColumnExecuted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "executed",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "executed",
                table: "Job");
        }
    }
}
