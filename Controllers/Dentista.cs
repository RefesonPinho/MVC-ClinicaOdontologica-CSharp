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
            int Id,
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
            Dentista dentista = GetDentista(Id);
            string altNome = !String.IsNullOrEmpty(Nome) ? Nome : dentista.Nome;
            string altCpf = !String.IsNullOrEmpty(Cpf) ? Cpf : dentista.Cpf;
            string altFone = !String.IsNullOrEmpty(Fone) ? Fone : dentista.Fone; 
            string altEmail = !String.IsNullOrEmpty(Email) ? Email : dentista.Email;
            string altSenha = !String.IsNullOrEmpty(Senha) 
                ? BCrypt.Net.BCrypt.HashPassword(Senha)
                : dentista.Senha;
            string altRegistro = !String.IsNullOrEmpty(Registro) ? Registro : dentista.Registro ;

            Dentista.AlterarDentista(Id, altNome, altCpf, altFone, altEmail, altSenha, altRegistro);

            return dentista;
        }

        public static Dentista ExcluirDentista(
            int Id
        )
        {
            Dentista dentista = GetDentista(Id);
            Dentista.RemoverDentista(dentista);
            return dentista;
        }

        public static List<Dentista> VisualizarDentista()
        {
            return Dentista.GetDentistas();
        }

        public static Dentista GetDentista(int Id)
        {
            Dentista dentista = (
                from Dentista in Dentista.GetDentistas()
                    where Dentista.Id == Id
                    select Dentista
            ).First();

            if (dentista == null)
            {
                throw new Exception("Dentista não encontrado");
            }

            return dentista;
        }
    }
}