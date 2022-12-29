using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Menu_Master
    {
        public int Menu_Id { get; set; }
        public string Menu_Caption { get; set; }
        public string Menu_Name { get; set; }
        public Nullable<int> Parent_id { get; set; }
        public Nullable<int> Menu_Index { get; set; }
        public Nullable<bool> Flag { get; set; }
        public string Page_Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
