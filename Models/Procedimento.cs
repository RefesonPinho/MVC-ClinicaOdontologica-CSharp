using System;
using System.Collections.Generic;

namespace Models
{
    public class Procedimento
    {
        public static int ID = 0;
        private static List<Procedimento> Procedimentos = new List<Procedimento>();
        public int Id { set; get; }
        public string Descricao { set; get; }
        public double preco { set; get; }


        public override string ToString()
        {
            return $"\nId : {this.Id}" 
                + $"\nDescricao: R$ {this.Descricao}"
                + $"\nPreco: {this.preco}";
        }

        public Procedimento(
            string Descricao,
            double preco
        ) : this(++ID,Descricao,preco)
        {}

        public Procedimento(
            int Id,
            string Descricao,
            double preco
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.preco = preco;
        } 

        public static List<Procedimento> GetProcedimentos()
        {
            return Procedimentos;
        }

        public static void RemoverProcedimento(
            Procedimento procedimento
        )
        {
            Procedimentos.Remove(procedimento);
        }
    }
}