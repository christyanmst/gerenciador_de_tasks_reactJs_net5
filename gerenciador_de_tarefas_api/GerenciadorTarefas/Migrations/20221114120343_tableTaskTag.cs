using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorTarefas.Migrations
{
    public partial class tableTaskTag : Migration
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

            migrationBuilder.CreateTable(
                name: "TaskTag",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<long>(type: "bigint", nullable: false),
                    tagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTag", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskTag_Tag_tagId",
                        column: x => x.tagId,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTag_Task_taskId",
                        column: x => x.taskId,
                        principalTable: "Task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTag_tagId",
                table: "TaskTag",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTag_taskId",
                table: "TaskTag",
                column: "taskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTag");

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
