using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class AgendamentoProcedimentoController
    {
        public static AgendamentoProcedimento IncluirAgendamentoProcedimento(
            int IdAgendamento,
            int IdProcedimento
        )
        {
            if (String.IsNullOrEmpty(Numero)) {
                throw new Exception("Número é obrigatório");
            }

            return new AgendamentoProcedimento(IdAgendamento, IdProcedimento);
        }

        public static AgendamentoProcedimento ExcluirAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamentoProcedimento = GetAgendamentoProcedimento(Id);
            Models.AgendamentoProcedimento.RemoverAgendamentoProcedimento(agendamentoProcedimento);
            return agendamentoProcedimento;
        }

        public static List<AgendamentoProcedimento> VisualizarAgendamentoProcedimentos()
        {
            return Models.AgendamentoProcedimento.GetAgendamentoProcedimentos();  
        }

        public static AgendamentoProcedimento GetAgendamentoProcedimento(
            int Id
        )
        {
            List<AgendamentoProcedimento> agendamentoProcedimentosModels = Models.AgendamentoProcedimento.GetAgendamentoProcedimentos();
            IEnumerable<AgendamentoProcedimento> agendamentoProcedimentos = from AgendamentoProcedimento in agendamentoProcedimentosModels
                            where AgendamentoProcedimento.Id == Id
                            select AgendamentoProcedimento;
            AgendamentoProcedimento agendamentoProcedimento = agendamentoProcedimentos.First();
            
            if (agendamentoProcedimento == null)
            {
                throw new Exception("AgendamentoProcedimento não encontrada");
            }

            return agendamentoProcedimento;
        }
    }
}