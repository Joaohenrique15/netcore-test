using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaEasy.Models
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(80)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Senha { get; set; }
    }
}
