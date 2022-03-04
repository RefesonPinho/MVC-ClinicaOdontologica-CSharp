using System;
using System.Collections.Generic;

namespace Models
{
    public class Paciente : Pessoa
    {
        public DateTime DataNascimento { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nData de Nascimento: {this.DataNascimento}";
        }

        public Paciente() : base()
        {}

        public Paciente(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        ) : base(Nome, Cpf, Fone, Email, Senha)
        {
            this.DataNascimento = DataNascimento;
            Context db = new Context()
            db.Pacientes.Add(this);
            db.SaveChanges();
        }

       public static int GetCount() {
            return GetPacientes().Count();
        }

        public static List<Paciente> GetPacientes()
        {
            Context db = new Context();
            return (from Paciente in db.Pacientes select Paciente).ToList();
        }

        public static void RemoverPaciente(Paciente paciente)
        {
           Context db = new Context();
           db.Pacientes.Remove(paciente);
        }

        public static Paciente GetPaciente (int PacienteId) {
            Context db = new Context();
            return (
                from Paciente in db.Pacientes
                where Paciente.PacienteId == Id
                select Paciente
            ).First();
        }
    }
}