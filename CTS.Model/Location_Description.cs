using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Location_Description
    {
        public long Desc_Id { get; set; }
        public string Descriptions { get; set; }
        public Nullable<int> Location_Id { get; set; }
        public string Loc_Desc_Code { get; set; }

 
        public virtual Location_Master Location_Master { get; set; }
    }
}
