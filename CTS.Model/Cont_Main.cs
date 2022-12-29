using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Cont_Main
    {
        public Cont_Main()
        { }
        public long Cont_Id { get; set; }
        public string Cont_No { get; set; }
        public Nullable<int> Cont_Serial { get; set; }
        public Nullable<int> Contsize_Id { get; set; }
        public string Cont_Construction { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<short> Fin_Year { get; set; }
        public Nullable<bool> Flg_RKM { get; set; }
        public Nullable<int> Modified_UserID { get; set; }
        public Nullable<System.DateTime> Modified_Time { get; set; }
        public Nullable<decimal> TotTime_ElectricChrges { get; set; }
        public Nullable<int> YARD_ID { get; set; }
        public Nullable<int> Upload_Id { get; set; }
        public Nullable<System.DateTime> PluggIn_From { get; set; }
        public Nullable<System.DateTime> PluggIn_To { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Gate_In_Pass { get; set; }
        public Nullable<int> Gate_Out_Pass { get; set; }
        public string csc_detail { get; set; }
        public string manufact_date { get; set; }
        public string Gross_Weight { get; set; }
        public string Tire_Weight { get; set; }
        public string Repair_Grade { get; set; }
        public string Current_Status { get; set; }
        public Nullable<System.DateTime> PTI_Date { get; set; }
        public Nullable<System.DateTime> PTI_Validity { get; set; }
        public Nullable<System.DateTime> Re_PTI_Date { get; set; }
        public Nullable<bool> Van_EDI_Flag { get; set; }
        public Nullable<bool> MTIN_EDI_Flag { get; set; }
        public Nullable<decimal> Pay_Load { get; set; }
        public Nullable<bool> MIR_EDI_FLAG { get; set; }
        public Nullable<bool> MOR_EDI_FLAG { get; set; }
        public string Old_grosswt { get; set; }
        public string Old_tirewt { get; set; }
        public Nullable<bool> Hold { get; set; }
        public Nullable<bool> Cancel { get; set; }
        public Nullable<bool> Cancelled { get; set; }
        public string Hold_Remarks { get; set; }
        public Nullable<bool> Make_AV_Witout_Est { get; set; }
        public Nullable<int> Make_AV_Contractor_Id { get; set; }
        public string Make_AV_Est_No { get; set; }
        public Nullable<System.DateTime> Make_AV_Rep_Date { get; set; }
        public Nullable<System.DateTime> Make_AV_Act_Repair_Completion { get; set; }
        public Nullable<bool> Return_Box { get; set; }
        public Nullable<bool> RET_EDI_FLAG { get; set; }
        public Nullable<bool> CABO_EDI_FLAG { get; set; }
        public string Repair_Status { get; set; }
        public string SR_NO { get; set; }
        public string JOB_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string Destination { get; set; }

        public string Image_Remarks { get; set; }
       

        public virtual Yard_Master Yard_Master { get; set; }
        public virtual CustomerMaster CustomerMaster { get; set; }
        public virtual Cont_Size_Master Cont_Size_Master { get; set; }
        
        public virtual Cont_In Cont_In { get; set; }
        public virtual Cont_Out Cont_Out { get; set; }

        public virtual User_Master User_Master { get; set; }
       
    }


    public class Cont_Main2
    {
        public Cont_Main2()
        { }
        public long Cont_Id { get; set; }
        public string Cont_No { get; set; }
        public Nullable<int> Cont_Serial { get; set; }
        public Nullable<int> Contsize_Id { get; set; }
        public string Cont_Construction { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<short> Fin_Year { get; set; }
        public Nullable<bool> Flg_RKM { get; set; }
        public Nullable<int> Modified_UserID { get; set; }
        public Nullable<System.DateTime> Modified_Time { get; set; }
        public Nullable<decimal> TotTime_ElectricChrges { get; set; }
        public Nullable<int> YARD_ID { get; set; }
        public Nullable<int> Upload_Id { get; set; }
        public Nullable<System.DateTime> PluggIn_From { get; set; }
        public Nullable<System.DateTime> PluggIn_To { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Gate_In_Pass { get; set; }
        public Nullable<int> Gate_Out_Pass { get; set; }
        public string csc_detail { get; set; }
        public string manufact_date { get; set; }
        public string Gross_Weight { get; set; }
        public string Tire_Weight { get; set; }
        public string Repair_Grade { get; set; }
        public string Current_Status { get; set; }
        public Nullable<System.DateTime> PTI_Date { get; set; }
        public Nullable<System.DateTime> PTI_Validity { get; set; }
        public Nullable<System.DateTime> Re_PTI_Date { get; set; }
        public Nullable<bool> Van_EDI_Flag { get; set; }
        public Nullable<bool> MTIN_EDI_Flag { get; set; }
        public Nullable<decimal> Pay_Load { get; set; }
        public Nullable<bool> MIR_EDI_FLAG { get; set; }
        public Nullable<bool> MOR_EDI_FLAG { get; set; }
        public string Old_grosswt { get; set; }
        public string Old_tirewt { get; set; }
        public Nullable<bool> Hold { get; set; }
        public Nullable<bool> Cancel { get; set; }
        public Nullable<bool> Cancelled { get; set; }
        public string Hold_Remarks { get; set; }
        public Nullable<bool> Make_AV_Witout_Est { get; set; }
        public Nullable<int> Make_AV_Contractor_Id { get; set; }
        public string Make_AV_Est_No { get; set; }
        public Nullable<System.DateTime> Make_AV_Rep_Date { get; set; }
        public Nullable<System.DateTime> Make_AV_Act_Repair_Completion { get; set; }
        public Nullable<bool> Return_Box { get; set; }
        public Nullable<bool> RET_EDI_FLAG { get; set; }
        public Nullable<bool> CABO_EDI_FLAG { get; set; }
        public string Repair_Status { get; set; }
        public string SR_NO { get; set; }
        public string JOB_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string Destination { get; set; }


        public virtual CustomerMaster CustomerMaster { get; set; }
        public virtual Cont_Size_Master Cont_Size_Master { get; set; }

        public virtual Cont_In Cont_In { get; set; }
        public virtual Cont_Out Cont_Out { get; set; }

    }
}
