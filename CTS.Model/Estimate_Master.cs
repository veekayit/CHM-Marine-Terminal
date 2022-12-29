using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
     [Serializable]
    public class Estimate_Master
    {
         public Estimate_Master()
         { }
        public long Estimate_Id { get; set; }
        public Nullable<long> Estimate_No { get; set; }
        public Nullable<System.DateTime> Estimate_Date { get; set; }
        public Nullable<long> Cont_Id { get; set; }
        public Nullable<decimal> Service_Tax_Per { get; set; }
        public Nullable<decimal> Edu_Cess_Per { get; set; }
        public Nullable<decimal> High_Edu_Cess_Per { get; set; }
        public Nullable<decimal> Vat_Tax_Material { get; set; }
        public Nullable<decimal> Service_Tax_Amount { get; set; }
        public Nullable<decimal> Edu_Cess_Amount { get; set; }
        public Nullable<decimal> High_Edu_Cess_Amount { get; set; }
        public Nullable<decimal> Material_Amount { get; set; }
        public Nullable<decimal> Labour_Amount { get; set; }
        public Nullable<decimal> Lumpsum_Amount { get; set; }
        public Nullable<decimal> Net_Amount { get; set; }
        public Nullable<int> Fin_Year { get; set; }
        public Nullable<bool> Approved { get; set; }
        public Nullable<System.DateTime> Approved_Date { get; set; }
        public Nullable<bool> WorkOrder_Closed { get; set; }
        public Nullable<System.DateTime> WorkOrder_Closed_Date { get; set; }
        public Nullable<long> Bill_Id { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> Upload_Time { get; set; }
        public Nullable<decimal> Man_Hour_Rate { get; set; }
        public Nullable<int> Company_id { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<System.DateTime> In_Date { get; set; }
        public string Actual_Estimate_No { get; set; }
        public Nullable<bool> Upgrade_Entry { get; set; }
        public Nullable<decimal> Swachh_Cess_Per { get; set; }
        public Nullable<decimal> Swachh_Cess_Amount { get; set; }
        public Nullable<bool> Import_Flag { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public Nullable<int> Bill_Year { get; set; }
        public Nullable<int> Ref_No { get; set; }
        public Nullable<bool> Release_Job { get; set; }
        public Nullable<decimal> Approval_Amount { get; set; }

        public virtual Cont_Main Cont_Main { get; set; }
      

        public virtual List<Estimate_Details> EstimateDetails { get; set; }
        public virtual List<Estimate_Tax_Details> EstimateTax_Details { get; set; }

        public virtual List<Estimate_Imageprop> Estimate_ImageDetails { get; set; }
    }
}
