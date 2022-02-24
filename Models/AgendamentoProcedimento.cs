using System;
using System.Collections.Generic;

namespace Models
{
    public class AgendamentoProcedimento
    {   
        public static int ID = 0;
        public int Id;
        public int IdProcedimento;
        public int IdAgendamento;

        public AgendamentoProcedimento(
            int IdProcedimento,
            int IdAgendamento
        ) : this(++ID,IdProcedimento,IdAgendamento)
        {}

        public AgendamentoProcedimento(
            int Id,
            int IdProcedimento,
            int IdAgendamento
        )
        {
            this.Id = Id;
            this.IdProcedimento = IdProcedimento;
            this.IdAgendamento = IdAgendamento;
        }
    }
}