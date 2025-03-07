using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxApp.Entites;

namespace TaxEngine.ComputationContext
{
    /// <summary>
    ///  v1.0
    /// </summary>
    public class COMPUTATION_CONTEXT 
    {
        private Dictionary<string, object> symbols = new Dictionary<string, object>();

        public void Put(string name, object value)
        {
            symbols[name] = value;
        }

        public object Get(string name)
        {
            return symbols[name];

        }

       
    }
}
