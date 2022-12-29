using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Tbl_EstImages
    {
        public int ImageId { get; set; }
        public Nullable<int> Estimate_Id { get; set; }
        public string EstImage { get; set; }
        public Nullable<bool> Est_Flag { get; set; }
        public string File_Names { get; set; }
        public Nullable<long> Cont_Id { get; set; }

        public virtual Cont_Main Cont_Main { get; set; }
    }
}
