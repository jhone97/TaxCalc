using TaxApp.Entites;
using TaxEngine.ComputationContext;
using TaxEngine.Interfaces;

namespace TaxEngine.Commands
{
    public class OrdinaryCitizenCommand : ICOMPUTATION_CONTEXT
    {
        public bool Excute(COMPUTATION_CONTEXT ctx)
        {
            TaxDTO td = (TaxDTO)ctx.Get("tax_cargo");
            td.taxparams.TaxLiability = 1000;
            td.taxparams.Computed = true;
            return true;
        }
    }
}
