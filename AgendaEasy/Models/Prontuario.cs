using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaEasy.Models
{
    [Table("Prontuarios")]
    public class Prontuario
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Informe o nome")]
        [StringLength(80, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Informe o CPF")]
        [StringLength(14, MinimumLength = 14)]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Informe o Convênio")]
        [StringLength(50, MinimumLength = 3)]
        public string Convenio { get; set; }

        [Required]
        [Display(Name = "Informe o Plano")]
        [StringLength(50, MinimumLength = 3)]
        public string Plano { get; set; }
        public string Telefone { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}