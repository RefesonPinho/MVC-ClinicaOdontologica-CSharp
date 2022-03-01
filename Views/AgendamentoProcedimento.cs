using System;
using Controllers;
using Models;

namespace Views
{
    public class AgendamentoProcedimentoView
    {
        public static void InserirAgendamentoProcedimento()
        {
            int IdAgendamento = 0;
            int IdProcedimento = 0;
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                IdAgendamento= Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            Console.WriteLine("Digite o ID do Procedimento: ");
            try
            {
                IdProcedimento= Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            AgendamentoProcedimentoController.InserirAgendamentoProcedimento(
                IdAgendamento,
                IdProcedimento
            );
        }


        public static void ExcluirAgendamentoProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do AgendamentoProcedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            AgendamentoProcedimentoController.ExcluirAgendamentoProcedimento(
                Id
            );

        }

        public static void ListarAgendamentoProcedimentos()
        {
            foreach (AgendamentoProcedimento item in AgendamentoProcedimentoController.VisualizarAgendamentoProcedimento())
            {
                Console.WriteLine(item);
            }
        }
    }
}