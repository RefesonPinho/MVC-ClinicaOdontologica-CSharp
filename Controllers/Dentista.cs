using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class DentistaController 
    {
        public static Dentista InserirDentista(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            int IdEspecialidade
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }
            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (String.IsNullOrEmpty(Cpf) || !rx.IsMatch(Cpf))
            {
                throw new Exception("Cpf inválido");
            }

            if (String.IsNullOrEmpty(Fone))
            {
                throw new Exception("Telefone inválido");
            }

            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("Email inválido");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválido");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (String.IsNullOrEmpty(Registro))
            {
                throw new Exception("Registro inválido");
            }

            return new Dentista(Nome, Cpf, Fone, Email, Senha, Registro, Salario, IdEspecialidade);
        }

        public static Dentista AlterarDentista(
            int DentistaId,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            int IdEspecialidade
        )
        {
            Dentista dentista = GetDentista(DentistaId);

            if (!String.IsNullOrEmpty(Nome))
            {
                dentista.Nome = Nome;
            }

            if (!String.IsNullOrEmpty(Cpf))
            {
                dentista.Cpf = Cpf;
            }

            if (!String.IsNullOrEmpty(Fone))
            {
                dentista.Fone = Fone;
            }

            if (!String.IsNullOrEmpty(Email))
            {
                dentista.Email = Email;
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                dentista.Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (!String.IsNullOrEmpty(Registro))
            {
                dentista.Registro = Registro;
            }

            return dentista;
        }

        public static Dentista ExcluirDentista(
            int DentistaId
        )
        {
            Dentista dentista = GetDentista(DentistaId);
            Dentista.RemoverDentista(dentista);
            return dentista;
        }

        public static List<Dentista> VisualizarDentista()
        {
            return Dentista.GetDentistas();
        }

        public static Dentista GetDentista(int DentistaId)
        {
            int ListLenght = Dentista.GetCount();

            if (DentistaId < 0 || ListLenght <= DentistaId) {
                throw new Exception ("Id informado é inválido.");
            }

            return Dentista.GetDentista (DentistaId);
        }
    }
}