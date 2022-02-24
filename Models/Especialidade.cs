using System;
using System.Collections.Generic;

namespace Models
{
    public class Especialidade
    {
        public static int ID = 0;
        private static List<Especialidade> Especialidades = new List<Especialidade>();
        public int Id;
        public string Descricao;
        public string Detalhamento;

        public override string ToString()
    {
        return $"\nId : {this.Id}" 
             + $"\nDescricao: R$ {this.Descricao}"
            + $"\nDetalhamento: {this.Detalhamento}";
    }


        public Especialidade(
            string Descricao,
            string Detalhamento
        ) : this(++ID,Descricao,Detalhamento)
        {}

        public Especialidade(
            int Id,
            string Descricao,
            string Detalhamento
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Detalhamento = Detalhamento;
        }

        public static List<Especialidade> GetEspecialidades()
        {
            return Especialidades;
        }

        public static void RemoverEspecialidade(
            Especialidade especialidade
        )
        {
            Especialidades.Remove(especialidade);
        }
    }
}