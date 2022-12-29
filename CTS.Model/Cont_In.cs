using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Cont_In
    {
        public Cont_In()
        { }
        public long Cont_In_Id { get; set; }
        public Nullable<long> Cont_Id { get; set; }
        public Nullable<int> Vessel_Id { get; set; }
        public string Cont_Voyage { get; set; }
        public Nullable<int> Consignee_ID { get; set; }
        public string Cont_BLNo { get; set; }
        public Nullable<System.DateTime> Cont_BLDate { get; set; }
        public string Cont_Cargo { get; set; }
        public string Cont_Remark1 { get; set; }
        public string Cont_Remark2 { get; set; }
        public Nullable<System.DateTime> Cont_InDate { get; set; }
        public string Cont_Comodity { get; set; }
        public string Cont_InPass { get; set; }
        public string Cont_InTime { get; set; }
        public Nullable<System.DateTime> Cont_OutTime { get; set; }
        public string Cont_TrailerNo { get; set; }
        public string Cont_DoNo { get; set; }
        public Nullable<System.DateTime> Cont_DoDate { get; set; }
        public string Cont_Destuff { get; set; }
        public string Cont_Shippername { get; set; }
        public string Cont_Remarks { get; set; }
        public Nullable<int> Lift_Id { get; set; }
        public Nullable<int> Yard_Id { get; set; }
        public Nullable<int> Bay_Id { get; set; }
        public string Cont_Status { get; set; }
        public Nullable<System.DateTime> Upload_Time { get; set; }
        public Nullable<int> Cont_TranporterID { get; set; }
        public Nullable<int> Pos_LocationId { get; set; }
        public Nullable<int> Modified_UserID { get; set; }
        public Nullable<System.DateTime> Cont_DoValidity { get; set; }
        public string EmptyDeStuffing { get; set; }
        public string In_Grade { get; set; }
        public Nullable<long> In_Consg_Note_No { get; set; }
        public Nullable<bool> In_Payment { get; set; }
        public Nullable<int> In_Payment_RcptNo { get; set; }
        public Nullable<decimal> In_Handling_STax { get; set; }
        public Nullable<decimal> In_Handling_Amount { get; set; }
        public Nullable<decimal> Tot_In_Handling_Amount { get; set; }
        public string Suitable_Cargo { get; set; }
        public string Damage_Type { get; set; }
        public string Cha_In { get; set; }
        public Nullable<long> Vessel_Container_Details_ID { get; set; }
        public Nullable<System.DateTime> Act_InDate { get; set; }
        public string Driver { get; set; }
        public string IN_Transporter { get; set; }
        public Nullable<System.DateTime> Created_Time { get; set; }
        public string ERO_No { get; set; }
        public Nullable<System.DateTime> ERO_Date { get; set; }
        public string Driver_Contact { get; set; }
        public Nullable<long> ERO_Sequence { get; set; }

        public virtual Consignee_Master Consignee_Master { get; set; }
        //public virtual Cont_Main Cont_Main { get; set; }
        //public virtual Lift_Master Lift_Master { get; set; }
        //public virtual Position_Location Position_Location { get; set; }
        public virtual Transporter_Master Transporter_Master { get; set; }
        public virtual Vessel_Master Vessel_Master { get; set; }
        public virtual Yard_Master Yard_Master { get; set; }
    }
}
