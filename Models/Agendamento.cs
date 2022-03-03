using System;
using System.Collections.Generic;
using Repository;

namespace Models
{
    public class Agendamento
    {
    
        private static List<Agendamento> Agendamentos = new List<Agendamento>();
        public int Id { set; get; }
        public int IdPaciente { set; get; }
        public Paciente Paciente { get; }
        public int IdDentista { set; get; }
        public Dentista Dentista { get; }
        public int IdSala { set; get; }
        public Sala Sala { get; }
        public DateTime Data { set; get; }
        public string Procedimento { set; get; }
        public bool Confirmado { set; get; }

        public Agendamento(
            int IdPaciente,
            int IdDentista,
            int IdSala,
            DateTime Data,
            string Procedimento
        ) 
        {
            this.IdPaciente = IdPaciente;
            this.IdDentista = IdDentista;
            this.IdSala = IdSala;
            this.Data = Data;
        }

        public Agendamento(
            int Id,
            int IdPaciente,
            int IdDentista,
            int IdSala,
            DateTime Data,
            string Procedimento
        )
        {
            this.Id = Id;
            this.IdPaciente = IdPaciente;
            this.Paciente = Paciente.GetPacientes().Find(Paciente => Paciente.Id == IdPaciente);
            this.IdDentista = IdDentista;
            this.Dentista = Dentista.GetDentistas().Find(Dentista => Dentista.Id == IdDentista);
            this.IdSala = IdSala;
            this.Sala = Sala.GetSalas().Find(Sala => Sala.Id == IdSala);
            this.Data = Data;
            this.Procedimento = Procedimento;
            Context db = new Context();
            db.Agendamentos.Add(this);
            db.SaveChanges();
            
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nPaciente: {this.Paciente.Nome}"
                + $"\nDentista: {this.Dentista.Nome}"
                + $"\nSala: {this.Sala.Numero}"
                + $"\nData: {this.Data}"
                + $"\nProcedimento: {this.Procedimento}"
                + $"\nConfirmado: {(this.Confirmado ? "Sim" : "Não")}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Agendamento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Agendamento it = (Agendamento) obj;
            return it.Id == this.Id;
        }
        public static List<Agendamento> GetAgendamentos()
        {
            return Agendamentos;
        }

        public static void RemoverAgendamento(
            Agendamento agendamento
        )
        {
            Agendamentos.Remove(agendamento);
        }
    }
}