using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Damage_Code_Rates
    {
        public Damage_Code_Rates()
        { }
        public long Damage_Rate_Id { get; set; }
        public long Damage_Id { get; set; }

        public int Repair_Type_Id { get; set; }
        public Nullable<double> Hrs { get; set; }
        public Nullable<decimal> MaterialAmt { get; set; }
        public Nullable<decimal> LumpsumAmt { get; set; }

        public virtual Damage_Code_Master Damage_Code_Master { get; set; }
        public virtual Repair_Type_Master Repair_Type_Master { get; set; }
    }
}
