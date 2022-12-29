using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Booking_Master_Sub
    {
        public long Booking_Sub_Id { get; set; }
        public long Booking_Id { get; set; }
        public int Cont_SizeId { get; set; }
        public Nullable<int> TotalNo { get; set; }

        public int Balance { get; set; }
    }
}
