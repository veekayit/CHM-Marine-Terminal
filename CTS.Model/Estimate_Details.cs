using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Estimate_Details
    {
        public Estimate_Details() { }
        public long Estimate_Details_Id { get; set; }
        public Nullable<long> Estimate_Id { get; set; }
        public Nullable<long> Description { get; set; }
        public decimal Length { get; set; }
        public Nullable<decimal> Width { get; set; }
        public string UOM { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> Hours { get; set; }
        public Nullable<decimal> Labour_Cost { get; set; }
        public Nullable<decimal> Material_Cost { get; set; }
        public Nullable<decimal> Total_Cost { get; set; }
        public Nullable<int> Account_Type_Id { get; set; }
        public Nullable<int> DamageArea_Id { get; set; }
        public Nullable<long> Damage_Id { get; set; }
        
        public Nullable<int> Location_Id { get; set; }
        public Nullable<decimal> Lumpsum_Cost { get; set; }
        public Nullable<decimal> ManHourRate { get; set; }
        public Nullable<int> RPR_Damage_Id { get; set; }
        public Nullable<int> RPR_Repair_Id { get; set; }
        //public Nullable<int> Sl_No { get; set; }
        public Nullable<int> View_order { get; set; }
        public string ISO_Code { get; set; }
        public Nullable<int> Part_Id { get; set; }
        public Nullable<int> Repair_Type_Id { get; set; }

        public Nullable<long> Desc_Id { get; set; }
        
        public string AllParticulars { get; set; }

        #region MyRegion
        public string FLag { get; set; } //for edit
        public int SlNo { get; set; }

        public Nullable<decimal> Slab_Hours { get; set; }
        public Nullable<decimal> Slab_Lumpsum_Cost { get; set; }
        public Nullable<decimal> Slab_Material_Cost { get; set; }


        public Nullable<long> Damage_Rate_Id { get; set; }
        #endregion
    

        public virtual Damage_Code_Master Damage_Code_Master { get; set; }
        public virtual Location_Master Location_Master { get; set; }
        public virtual Location_Description Location_Description { get; set; }
        public virtual Repair_Type_Master Repair_Type_Master { get; set; }
        public virtual Damage_Code_Rates Damage_Code_Rates { get; set; }
        public virtual Account_Type Account_Type { get; set; }
    }
}
