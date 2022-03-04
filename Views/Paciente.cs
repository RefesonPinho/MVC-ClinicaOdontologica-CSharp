using System;
using Controllers;
using Models;

namespace Views
{
    public class PacienteView
    {
        public static void InserirPaciente()
        {
            DateTime DataNascimento = DateTime.Now;
            Console.WriteLine("Digite o Nome do Paciente: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o C.P.F. do Paciente: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite o Telefone do Paciente: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Digite o Email do Paciente: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite o Senha do Paciente: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Digite o Data de Nascimento do Paciente: ");
            try
            {
                DataNascimento = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data de Nascimento inválida.");
            }

            PacienteController.InserirPaciente(
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                DataNascimento
            );

        }

        public static void AlterarPaciente()
        {
            int PacienteId = 0;
            DateTime DataNascimento = DateTime.Now;
            Console.WriteLine("Digite o ID do Paciente: ");
            try
            {
                PacienteId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Nome do Paciente: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o C.P.F. do Paciente: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite o Telefone do Paciente: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Digite o Email do Paciente: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite o Senha do Paciente: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Digite o Data de Nascimento do Paciente: ");
            try
            {
                DataNascimento = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data de Nascimento inválida.");
            }

            PacienteController.AlterarPaciente(
                PacienteId,
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                DataNascimento
            );

        }

        public static void ExcluirPaciente()
        {
            int PacienteId = 0;
            Console.WriteLine("Digite o ID do Paciente: ");
            try
            {
                PacienteId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            PacienteController.ExcluirPaciente(
                PacienteId
            );

        }

        public static void ListarPacientes()
        {
            foreach (Paciente item in PacienteController.VisualizarPaciente())
            {
                Console.WriteLine(item);
            }
        }
    }
}