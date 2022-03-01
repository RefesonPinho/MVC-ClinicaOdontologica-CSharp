using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class EspecialidadeController
    {
        public static Especialidade InserirEspecialidade(
            string Descricao,
            string Detalhamento
        )
        {

            if (GetConflito(
                0
                
            ))
            {
                throw new Exception("Já existe um Especialidade com esse nome no sistema");
            }

            return new Especialidade(Descricao, Detalhamento);
        }

        private static bool GetConflito(
            int IdAtual
        )
        {
            IEnumerable<Especialidade> especialidades =
                from Especialidade in Especialidade.GetEspecialidades()
                    where Especialidade.Id != IdAtual
                    select Especialidade;

            return especialidades.Count() > 0;
        }

        public static Especialidade AlterarEspecialidade(
            int Id,
            string Descricao,
            string Detalhamento
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);

            if (GetConflito(
                especialidade.Id
            ))
            {
                throw new Exception("Já existe um Especialidade com esse nome no sistema");
            }

            return especialidade;
        }
        public static Especialidade ExcluirEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);
            Especialidade.RemoverEspecialidade(especialidade);
            return especialidade;
        }
        public static List<Especialidade> VisualizarEspecialidades()
        {
            return Especialidade.GetEspecialidades();
        }
        public static Especialidade GetEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = (
                from Especialidade in Especialidade.GetEspecialidades()
                    where Especialidade.Id == Id
                    select Especialidade
            ).First();

            if (especialidade == null)
            {
                throw new Exception("Especialidade não encontrado.");
            }

            return especialidade;
        }
    }
}