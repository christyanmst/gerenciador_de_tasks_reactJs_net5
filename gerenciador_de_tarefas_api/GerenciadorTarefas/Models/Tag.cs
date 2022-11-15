using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Models
{
    [Table("Tag")]
    public class Tag
    {
        public long id { get; set; }

        [StringLength(100), Required]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public DateTime creationDate { get;set;}
    }
}
