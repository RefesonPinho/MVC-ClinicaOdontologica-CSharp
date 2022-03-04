using System.Collections.Generic;
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
        public Dentista() : base()
        {}

        private Dentista(
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

        public static int GetCount() {
            return GetDentistas().Count();
        }

        public static List<Dentista> GetDentistas()
        {
            Context db = new Context();
            return (from Dentista in db.Dentistas select Dentista).ToList();
        }

        public static void RemoverDentista(Dentista dentista)
        {
           Context db = new Context();
           db.Dentistas.Remove(dentista);
        }

        public static Dentista GetDentista (int DentistaId) {
            Context db = new Context();
            return (
                from Dentista in db.Dentistas
                where Dentista.DentistaId == Id
                select Dentista
            ).First();
        }
    }
}