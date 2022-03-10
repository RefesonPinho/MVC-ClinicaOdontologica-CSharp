using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class AgendamentoProcedimento 
    {
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
        public AgendamentoProcedimento() 
        {}

        public AgendamentoProcedimento(
            int IdAgendamento,
            int IdProcedimento
        )
        {
            this.IdAgendamento = IdAgendamento;
            this.IdProcedimento = IdProcedimento;
            Context db = new Context();
            db.AgendamentoProcedimentos.Add(this);
            db.SaveChanges();
        }


        public static List<AgendamentoProcedimento> GetAgendamentoProcedimentos()
        {
            Context db = new Context();
            return (from AgendamentoProcedimento in db.AgendamentoProcedimentos select AgendamentoProcedimento).ToList();
        }

        public static void RemoverAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
        {
            Context db = new Context();
            db.AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }
    }
}