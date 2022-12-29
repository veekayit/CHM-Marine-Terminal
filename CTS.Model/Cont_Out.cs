using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Cont_Out
    {
        public Cont_Out()
        { }
        public long Cont_Out_Id { get; set; }
        public long Cont_Id { get; set; }
        public Nullable<int> Vessel_Id { get; set; }
        public string Cont_Voyage { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> Cont_OutDt { get; set; }
        public string Con_Status { get; set; }
        public string Con_Stuffing { get; set; }
        public string Cont_OutPass { get; set; }
        public Nullable<System.DateTime> Cont_InTime { get; set; }
        public Nullable<System.DateTime> Cont_OutTime { get; set; }
        public string Cont_TrailerNo { get; set; }
        public Nullable<int> Movement_Id { get; set; }
        public Nullable<long> Cont_BookingID { get; set; }
        public string Cont_ReleaseNo { get; set; }
        public string Cont_SealNo { get; set; }
        public string Cont_DoNo { get; set; }
        public Nullable<System.DateTime> Cont_Dodate { get; set; }
        public Nullable<System.DateTime> Cont_GateInDate { get; set; }
        public Nullable<System.DateTime> Upload_Time { get; set; }
        public Nullable<int> TransporterID { get; set; }
        public Nullable<int> Position_Location_Id { get; set; }
        public Nullable<int> Modified_UserID { get; set; }
        public Nullable<int> YARD_ID { get; set; }
        public string Driver_Cont_No { get; set; }
        public string EmptyExport { get; set; }
        public string old_booking { get; set; }
        public string Shipper_Name { get; set; }
        public string Cargo { get; set; }
        public Nullable<long> Out_Consg_Note_No { get; set; }
        public string Out_Remarks { get; set; }
        public Nullable<bool> Out_Payment { get; set; }
        public Nullable<int> Out_Payment_RcptNo { get; set; }
        public Nullable<decimal> Out_Handling_STax { get; set; }
        public Nullable<decimal> Out_Handling_Amount { get; set; }
        public Nullable<decimal> Tot_Out_Handling_Amount { get; set; }
        public string Vent_SealNo { get; set; }
        public Nullable<decimal> Out_Grade { get; set; }
        public string Cha_Out { get; set; }
        public Nullable<System.DateTime> Bulk_Upd_Time { get; set; }
        public Nullable<System.DateTime> Act_OutDate { get; set; }
        public string Driver { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string OUT_Transporter { get; set; }
        public Nullable<int> Modified_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }

        public string Temperature { get; set; }
        

        public virtual Booking_Master Booking_Master { get; set; }
  
        public virtual CustomerMaster CustomerMaster { get; set; }
        public virtual Movement_Master Movement_Master { get; set; }
       // public virtual Position_Location Position_Location { get; set; }
        public virtual Transporter_Master Transporter_Master { get; set; }
        public virtual Vessel_Master Vessel_Master { get; set; }
        public virtual Yard_Master Yard_Master { get; set; }
    }
}
