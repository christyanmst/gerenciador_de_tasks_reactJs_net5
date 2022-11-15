using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorTarefas.Migrations
{
    public partial class removeVirtualListTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Task_Taskid",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_Taskid",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "Taskid",
                table: "Tag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Taskid",
                table: "Tag",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Taskid",
                table: "Tag",
                column: "Taskid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Task_Taskid",
                table: "Tag",
                column: "Taskid",
                principalTable: "Task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
