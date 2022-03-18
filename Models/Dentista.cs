using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Dentista : Pessoa
    {
        public string Registro { set; get; }
        public double Salario { set; get; }
        public int IdEspecialidade { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nRegistro (CRO): {this.Registro}" 
                + $"\nSalario: R$ {this.Salario}"
                + $"\nId da Especialiade: {this.IdEspecialidade}";
        }
        public Dentista() 
        {}

        public Dentista(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            int IdEspecialidade
        ) : base(Nome, Cpf, Fone, Email, Senha)
        {
            this.Registro = Registro;
            this.Salario = Salario;
            this.IdEspecialidade = IdEspecialidade;
            Context db = new Context();
            db.Dentistas.Add(this);
            db.SaveChanges();
        }


        public static List<Dentista> GetDentistas()
        {
            Context db = new Context();
            return (from Dentista in db.Dentistas select Dentista).ToList();
        }

        public static void AlterarDentista(
            int Id,
            String Nome,
            String Cpf,
            String Fone,
            String Email,
            String Senha,
            String Registro
        ) 
        {
            Context db = new Context();
            Dentista dentista = db.Dentistas.First(it => it.Id == Id);
            dentista.Nome = Nome;
            dentista.Cpf = Cpf;
            dentista.Fone = Fone;
            dentista.Email = Email;
            dentista.Senha = Senha;
            dentista.Registro = Registro;
            db.SaveChanges();
        }

        public static void RemoverDentista(Dentista dentista)
        {
            Context db = new Context();
            db.Dentistas.Remove(dentista);
            db.SaveChanges();
        }
    }
}