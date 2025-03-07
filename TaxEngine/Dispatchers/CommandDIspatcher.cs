using TaxEngine.Commands;
using TaxEngine.ComputationContext;

namespace TaxEngine.Dispatchers
{
    public static class CommandDIspatcher
    {
        public static bool Dispatch(string archtype, COMPUTATION_CONTEXT ctx)
        {
            if (archtype == "SeniorCitizen")
            {
                SeniorCitizenCommand seniorCitizenCommand = new SeniorCitizenCommand();
                return seniorCitizenCommand.Excute(ctx);
            }
            else if (archtype == "OrdinaryCitizen")
            {
                OrdinaryCitizenCommand ordinaryCitizenCommand = new OrdinaryCitizenCommand();
                return ordinaryCitizenCommand.Excute(ctx);
            }
            else
            {
                return false;
            }
        }
    }
}
