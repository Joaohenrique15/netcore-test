using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaEasy.Migrations
{
    public partial class PopulaTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Especialidades(Descricao) values('Cardiologia')");
            migrationBuilder.Sql("INSERT INTO Especialidades(Descricao) values('Dermatologia')");
            migrationBuilder.Sql("INSERT INTO Especialidades(Descricao) values('Pediatria')");
            migrationBuilder.Sql("INSERT INTO Especialidades(Descricao) values('Clinica Medica')");

            migrationBuilder.Sql("INSERT INTO Medicos(Nome, CRM, EspecialidadeId) values('Joice de Souza Brito', '1234-SP', 1)");
            migrationBuilder.Sql("INSERT INTO Medicos(Nome, CRM, EspecialidadeId) values('Kellen Cristina Faustino', '4321-MG', 2)");

            migrationBuilder.Sql("INSERT INTO Prontuarios(Nome, CPF, Convenio, Plano, Telefone) values('João Henrique Faustino', '123.456.789-10', 'Amil', 'Dix 100', '(11)96585-7443')");

            migrationBuilder.Sql("INSERT INTO Consultas(DataHora, Local, EspecialidadeId, MedicoId, ProntuarioId) values('2020-03-10 09:30:00.0000000', 'Alphaville', 1, 1, 1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
