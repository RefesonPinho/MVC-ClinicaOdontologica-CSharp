using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class AgendamentoProcedimentoController 
    {
        public static AgendamentoProcedimento InserirAgendamentoProcedimento(
            int IdAgendamento,
            int IdProcedimento
        )
        {

            return new AgendamentoProcedimento(IdAgendamento, IdProcedimento);
        }


        public static AgendamentoProcedimento ExcluirAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamentoProcedimento = GetAgendamentoProcedimento(Id);
            AgendamentoProcedimento.RemoverAgendamentoProcedimento(agendamentoProcedimento);
            return agendamentoProcedimento;
        }

        public static List<AgendamentoProcedimento> VisualizarAgendamentoProcedimento()
        {
            return AgendamentoProcedimento.GetAgendamentoProcedimentos();
        }

        public static AgendamentoProcedimento GetAgendamentoProcedimento(int Id)
        {
            AgendamentoProcedimento agendamentoProcedimento = (
                from AgendamentoProcedimento in AgendamentoProcedimento.GetAgendamentoProcedimentos()
                    where AgendamentoProcedimento.Id == Id
                    select AgendamentoProcedimento
            ).First();

            if (agendamentoProcedimento == null)
            {
                throw new Exception("AgendamentoProcedimento não encontrado");
            }

            return agendamentoProcedimento;
        }
    }
}