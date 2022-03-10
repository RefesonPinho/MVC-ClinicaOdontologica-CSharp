using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Procedimento 
    {
        public int Id { set; get; }
        public string Descricao { set; get; }
        public double Preco { set; get; }

         public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nDescrição: {this.Descricao}"
                + $"\nPreco: {this.Preco}";
        }

        public Procedimento()
        {}

        public Procedimento(
            string Descricao,
            double Preco
        )
        {
            this.Descricao = Descricao;
            this.Preco = Preco;
            Context db = new Context();
            db.Procedimentos.Add(this);
            db.SaveChanges();
        }


        public static List<Procedimento> GetProcedimentos()
        {
            Context db = new Context();
            return (from Procedimento in db.Procedimentos select Procedimento).ToList();
        }

        public static void RemoverProcedimento(Procedimento procedimento)
        {
           Context db = new Context();
           db.Procedimentos.Remove(procedimento);
        }
    }
}