using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Agendamento
    {
        public int Id { set; get; }
        public int PacienteId { set; get; }
        public Paciente Paciente { get; }
        public int DentistaId { set; get; }
        public Dentista Dentista { get; }
        public int SalaId { set; get; }
        public Sala Sala { get; }
        public DateTime Data { set; get; }
        public bool Confirmado { set; get; }

        public Agendamento() 
        {}

        public Agendamento(
            int PacienteId,
            int DentistaId,
            int SalaId,
            DateTime Data
        )
        {
            this.PacienteId = PacienteId;
            this.Paciente = Paciente.GetPacientes().Find(Paciente => Paciente.Id == PacienteId);
            this.DentistaId = DentistaId;
            this.Dentista = Dentista.GetDentistas().Find(Dentista => Dentista.Id == DentistaId);
            this.SalaId = SalaId;
            this.Sala = Sala.GetSalas().Find(Sala => Sala.Id == SalaId);
            this.Data = Data;
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
            Context db = new Context();
            return (from Agendamento in db.Agendamentos select Agendamento).ToList();
        }

        public static void AlterarAgendamento(
            int Id,
            int SalaId,
            DateTime Data
        )
        {
            Context db = new Context();
            Agendamento agendamento = db.Agendamentos.First(it => it.Id == Id);
            agendamento.SalaId = SalaId;
            agendamento.Data = Data;
            db.SaveChanges();
        }

        public static void RemoverAgendamento(
            Agendamento agendamento
        )
        {
            Context db = new Context();
            db.Agendamentos.Remove(agendamento);
            db.SaveChanges();
        }
    }
}