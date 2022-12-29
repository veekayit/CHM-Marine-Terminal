using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Container_Type_Master
    {
        public int Container_Type_Id { get; set; }
        public string Container_Type { get; set; }
        public Nullable<int> Type_Size { get; set; }
        public Nullable<int> Teus_Nos { get; set; }
    
    }

    public class Container_Type_Master_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Container_Type_Master> data = new List<Container_Type_Master>();
    }
}
