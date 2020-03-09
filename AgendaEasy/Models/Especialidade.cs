using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaEasy.Models
{
    [Table("Especialidades")]
    public class Especialidade
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Informe o nome")]
        [StringLength(80, MinimumLength = 3)]
        public string Descricao { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
