using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Repair_Type_Master
    {
        public int Repair_Type_Id { get; set; }
        public string Repair_Type { get; set; }
        public long Desc_Id { get; set; }

        
        public virtual Location_Description Location_Description { get; set; }
    }
}
