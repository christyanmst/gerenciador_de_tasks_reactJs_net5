using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Models
{
    [Table("TaskTag")]
    public class TaskTag
    {
        public long id { get; set; }

        public long taskId { get; set; }
        [ForeignKey("taskId")]
        public Task task { get; set; }
        public long tagId { get; set; }
        [ForeignKey("tagId")]
        public Tag tag { get; set; }
    }
}
