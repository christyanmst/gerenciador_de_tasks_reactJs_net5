using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Models
{
    [Table("User")]
    public class User
    {
        public long id { get; set; }
        [StringLength(100), Required]
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
