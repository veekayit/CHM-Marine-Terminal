using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Booking_Master
    {
        public long Booking_ID { get; set; }
        public int CustomerID { get; set; }
        public string BookingNo { get; set; }
        public Nullable<System.DateTime> DateOf { get; set; }
        public string ShipperName { get; set; }
        public string Cargo { get; set; }
        public string SpecialInstruction { get; set; }
        public Nullable<int> Temperature { get; set; }
        public Nullable<bool> CFS { get; set; }
        public Nullable<bool> CY { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public string DischargePort { get; set; }
        public Nullable<System.DateTime> Modified_Time { get; set; }
        public Nullable<int> Modified_UserID { get; set; }
        public Nullable<int> YARD_ID { get; set; }
        public Nullable<int> Upload_Id { get; set; }
        public Nullable<int> TotalNo { get; set; }
        public Nullable<int> Cont_SizeId { get; set; }
        public string Cont_No { get; set; }
        public string SL_No { get; set; }
        public string Book_RefNo { get; set; }
        public Nullable<int> Vessel_Id { get; set; }
        public string Voyage { get; set; }

        public virtual Booking_Master_Sub Booking_Master_Sub { get; set; }
    }
}
