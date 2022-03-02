using System;
using Controllers;
using Models;

namespace Views
{
    public class EspecialidadeView
    {
        public static void InserirEspecialidade()
        {
            Console.WriteLine("Digite a descricao da Especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite o detalhamento da Especialidade: ");
            string Detalhamento = Console.ReadLine();
            
            EspecialidadeController.InserirEspecialidade(
                Descricao,
                Detalhamento
            );
        }

        public static void AlterarEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            Console.WriteLine("Digite a descricao da Especialidade: ");
            string Descricao = Console.ReadLine();

            string Detalhamento = Console.ReadLine();            
            

            EspecialidadeController.AlterarEspecialidade(
                Id,
                Descricao,
                Detalhamento
            );
        }

        public static void ExcluirEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            EspecialidadeController.ExcluirEspecialidade(
                Id
            );

        }

        public static void ListarEspecialidades()
        {
            foreach (Especialidade item in EspecialidadeController.VisualizarEspecialidades())
            {
                Console.WriteLine(item);
            }
        }
    }
}