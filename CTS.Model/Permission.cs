using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Permission
    {
        public int Permission_ID { get; set; }
        public int GroupID_UserId { get; set; }
        public int Menu_ID { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowView { get; set; }
        public string Flag { get; set; }
        public Nullable<bool> Individual { get; set; }
        public Nullable<bool> System_Generated { get; set; }


        public virtual Menu_Master Menu_Master { get; set; }
    }
}
