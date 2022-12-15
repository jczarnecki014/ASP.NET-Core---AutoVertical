using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Utility.Validation
{
    /// <summary>
    /// It Provides properties needed to return specific information about validation specific part of program
    /// </summary>
    public class Validate
    {
        public bool isValid { get;set;}
        public int errorCount{ get;set;}
        public Dictionary<string,bool> values { get;set;}

        public Validate(Dictionary<string,bool> values)
        {
            this.values = values;
            this.isValid = true;
            this.errorCount = 0;
        }
    }
}
