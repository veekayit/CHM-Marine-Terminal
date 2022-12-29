using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Estimate_Tax_Details
    {
        public long Estimate_Sub_Id { get; set; }
        public Nullable<long> Estimate_Id { get; set; }
        public Nullable<int> Tax_Id { get; set; }
        public Nullable<decimal> Tax_Amount { get; set; }
        public Nullable<decimal> Round_Off_Amt { get; set; }
    
    }
}
