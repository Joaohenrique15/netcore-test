using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaEasy.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public int? EspecialidadeId { get; set; }

        [ForeignKey(nameof(EspecialidadeId))]
        public virtual Especialidade Especialidade { get; set; }
        public int? MedicoId { get; set; }

        [ForeignKey(nameof(MedicoId))]
        public virtual Medico Medicos { get; set; }
        public int? ProntuarioId { get; set; }

        [ForeignKey(nameof(ProntuarioId))]
        public virtual Prontuario Prontuarios { get; set; }
    }

    public enum Unidades
    {
        Alphaville,
        Morumbi,
        Ibirapuera,
        Jardins,
        Perdizes
    }

}
