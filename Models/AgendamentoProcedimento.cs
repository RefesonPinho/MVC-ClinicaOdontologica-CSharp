using System.Collections.Generic;

namespace Models
{
    public class AgendamentoProcedimento 
    {
        public static int ID = 0;
        private static List<AgendamentoProcedimento> AgendamentoProcedimentos = new List<AgendamentoProcedimento>();
        public int Id { set; get; }
        public int IdAgendamento { set; get; }
        public int IdProcedimento{ set; get; }
        
        public override string ToString()
        {
            return base.ToString()
                + $"\nId: {this.Id}" 
                + $"\nIdAgendamento: R$ {this.IdAgendamento}"
                + $"\nIdProcedimento: {this.IdProcedimento}";
        }
        public AgendamentoProcedimento(
            int IdAgendamento,
            int IdProcedimento
        ) : this(++ID, IdAgendamento, IdProcedimento)
        {}

        private AgendamentoProcedimento(
            int Id,
            int IdAgendamento,
            int IdProcedimento
        )
        {
            this.Id = Id;
            this.IdAgendamento = IdAgendamento;
            this.IdProcedimento = IdProcedimento;

            AgendamentoProcedimentos.Add(this);
        }


        public static List<AgendamentoProcedimento> GetAgendamentoProcedimentos()
        {
            return AgendamentoProcedimentos;
        }

        public static void RemoverAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
        {
            AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }
    }
}