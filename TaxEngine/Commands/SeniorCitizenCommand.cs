using TaxApp.Entites;
using TaxEngine.ComputationContext;
using TaxEngine.Interfaces;

namespace TaxEngine.Commands
{
    public class SeniorCitizenCommand : ICOMPUTATION_CONTEXT
    {
        public bool Excute(COMPUTATION_CONTEXT ctx)
        {
            TaxDTO taxDTO = (TaxDTO)ctx.Get("tax_cargo");
            taxDTO.taxparams.TaxLiability = 1500;
            return true;
        }
    }
}
