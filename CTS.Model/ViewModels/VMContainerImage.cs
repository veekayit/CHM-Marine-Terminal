using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models.ViewModels
{
    [Serializable]
    public class VMContainerImage
    {
        public virtual Cont_Main Cont_Main { get; set; }

        public Nullable<long> Estimate_Id { get; set; }
        public Nullable<long> Estimate_No { get; set; }
        public Nullable<System.DateTime> Estimate_Date { get; set; }
    }
}
