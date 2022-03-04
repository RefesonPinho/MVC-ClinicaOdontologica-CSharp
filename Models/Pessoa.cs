namespace Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public override string ToString()
        {
            return $"\nNome: {this.Nome}"
                + $"\nC.P.F.: {this.Cpf}"
                + $"\nTelefone: {this.Fone}"
                + $"\nEmail: {this.Email}";
        }

        public Pessoa()
        {}

        public Pessoa(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha
        )
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Fone = Fone;
            this.Email = Email;
            this.Senha = Senha;
        }
    }
}