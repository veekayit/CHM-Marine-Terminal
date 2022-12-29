using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class User_Group
    {
        public int Group_Id { get; set; }
        public string Group_Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> System_Generated { get; set; }
    
    }
}
