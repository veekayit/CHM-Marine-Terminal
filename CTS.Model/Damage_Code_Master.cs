using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
     [Serializable]
    public class Damage_Code_Master
    {
         public Damage_Code_Master()
        { }
        public long Damage_Id { get; set; }
        public string Damage_Code { get; set; }
        public Nullable<long> Desc_Id { get; set; }
        public Nullable<int> Location_Id { get; set; }
        public Nullable<double> Hrs { get; set; }
        public Nullable<decimal> LabourAmt { get; set; }
        public Nullable<decimal> MaterialAmt { get; set; }
        public string Code { get; set; }
        public Nullable<decimal> LumpsumAmt { get; set; }
        public string TypeOfRepair { get; set; }
        public Nullable<int> Repair_Type_Id { get; set; }


        public virtual Location_Master Location_Master { get; set; }
        public virtual Location_Description Location_Description { get; set; }
        public virtual Repair_Type_Master Repair_Type_Master { get; set; }
    }
}
