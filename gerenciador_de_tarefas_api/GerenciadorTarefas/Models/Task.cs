using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Models
{
    [Table("Task")]
    public class Task
    {
        public long id { get; set; }

        [StringLength(100), Required]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public decimal hoursLong { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime executionDate { get; set; }

        public virtual List<TaskTag> tagList { get; set; }

    }
}
