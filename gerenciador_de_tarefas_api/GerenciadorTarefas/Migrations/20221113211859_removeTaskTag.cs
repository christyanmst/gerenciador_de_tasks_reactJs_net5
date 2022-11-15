using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorTarefas.Migrations
{
    public partial class removeTaskTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTag",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tagId = table.Column<long>(type: "bigint", nullable: false),
                    taskId = table.Column<long>(type: "bigint", nullable: false)
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
    }
}
