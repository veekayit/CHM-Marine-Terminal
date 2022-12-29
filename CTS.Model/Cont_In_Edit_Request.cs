using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Cont_In_Edit_Request
    {
        public Cont_In_Edit_Request()
        { }
        public long Request_Id { get; set; }
        public DateTime Request_Date { get; set; }
        public  long Cont_Id { get; set; }
        public string Cont_No { get; set; }
        public Nullable<int> Cont_Size_Id { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public Nullable<int> Yard_Id { get; set; }
        public Nullable<System.DateTime> Cont_In_Date { get; set; }
        public Nullable<System.DateTime> Cont_In_Time { get; set; }
        public Nullable<int> Transporter { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> Request_By_User_Id { get; set; }
        public string To_Cont_No { get; set; }
        public Nullable<int> To_Cont_Size_Id { get; set; }
        public Nullable<int> To_Customer_Id { get; set; }
        public Nullable<int> To_Yard_Id { get; set; }
        public Nullable<System.DateTime> To_Cont_In_Date { get; set; }
        public Nullable<System.DateTime> To_Cont_In_Time { get; set; }
        public Nullable<int> To_Transporter { get; set; }
        public string To_Remarks { get; set; }
        public Nullable<int> Approved_By_User_Id { get; set; }
        public Nullable<System.DateTime> Approved_Date { get; set; }
        public Nullable<int> Cancelled_By_User_Id { get; set; }
        public Nullable<System.DateTime> Cancelled_Date { get; set; }
        public string Request_Description { get; set; }
        public Nullable<int> Cont_Serial { get; set; }
        public Nullable<long> Cont_In_Id { get; set; }
        public string Request_Type { get; set; }
        public string Edit_Del_Remarks { get; set; }
        public string Appr_Cancl_Remarks { get; set; }
        public string EmptyDeStuffing { get; set; }
        public string TrailerNo { get; set; }
        public string To_TrailerNo { get; set; }
        public string Voyage { get; set; }
        public string To_Voyage { get; set; }
        public Nullable<bool> MoveTypeChk { get; set; }
        public Nullable<bool> TransporterChk { get; set; }
        public Nullable<bool> VesselChk { get; set; }
        public Nullable<bool> VoyageChk { get; set; }
        public Nullable<int> To_Vessel_Id { get; set; }
        public Nullable<int> Vessel_Id { get; set; }
        public string SR_NO { get; set; }
        public string JOB_NO { get; set; }
        public string ERO_No { get; set; }
        public Nullable<System.DateTime> ERO_Date { get; set; }
        public string To_SR_NO { get; set; }
        public string To_JOB_NO { get; set; }
        public string To_ERO_No { get; set; }
        public Nullable<System.DateTime> To_ERO_Date { get; set; }

        public string Flag { get; set; } //for report
        public virtual Cont_Main Cont_Main { get; set; }
        public virtual User_Master Requested_User_Master { get; set; }
        public virtual User_Master Approved_User_Master { get; set; }

        public virtual User_Master Cancelled_User_Master { get; set; }
         
    }
}
