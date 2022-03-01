using System;
using Controllers;
using Models;

namespace Views
{
    public class ProcedimentoView
    {
        public static void InserirProcedimento()
        {
            Console.WriteLine("Digite a Descrição do Procedimento: ");
            string Descricao = Console.ReadLine();
            double Preco = 0;
             Console.WriteLine("Digite o Preço do Procedimento: ");
            try
            {
                Preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Preço inválido.");
            }

            ProcedimentoController.InserirProcedimento(
                Descricao,
                Preco
            );
        }

        public static void AlterarProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Dentista: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            Console.WriteLine("Digite a Descrição do Procedimento: ");
            string Descricao = Console.ReadLine();
            double Preco = 0;
             Console.WriteLine("Digite o Preço do Procedimento: ");
            try
            {
                Preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Preço inválido.");
            }

            ProcedimentoController.AlterarProcedimento(
                Id,
                Descricao,
                Preco
            );

        }

        public static void ExcluirProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            ProcedimentoController.ExcluirProcedimento(
                Id
            );

        }

        public static void ListarProcedimentos()
        {
            foreach (Procedimento item in ProcedimentoController.VisualizarProcedimento())
            {
                Console.WriteLine(item);
            }
        }
    }
}