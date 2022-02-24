using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    
    public class AgendamentoProcedimentoController
    {
        public static Procedimento GetProcedimento(
            int Id
        )
        {
            List<Procedimento> procedimentoModels = Models.Procedimento.GetProcedimentos();
            IEnumerable<Procedimento> procedimentos = from Procedimento in procedimentoModels
                            where Procedimento.Id == Id
                            select Procedimento;
            Procedimento procedimento = procedimentos.First();
            
            if (procedimento == null)
            {
                throw new Exception("Sala não encontrada");
            }

            return procedimento;
        }
    }
}