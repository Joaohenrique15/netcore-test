using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaEasy.Models
{
    [Table("Medicos")]
    public class Medico
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Informe o nome")]
        [StringLength(80, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Informe o CRM")]
        [StringLength(07, MinimumLength = 04)]
        public string CRM { get; set; }
        public int? EspecialidadeId { get; set; }

        [ForeignKey(nameof(EspecialidadeId))]
        public virtual Especialidade Especialidade { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
