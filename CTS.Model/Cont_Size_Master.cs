using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Cont_Size_Master
    {
        public int Contsize_Id { get; set; }
        public string Cont_Size { get; set; }
        public Nullable<int> Container_Type_Id { get; set; }
        public Nullable<bool> Is_Reefer { get; set; }
        public string oth_size { get; set; }
        public Nullable<int> Show_Order { get; set; }
        public string ISO { get; set; }
        public Nullable<int> Client_Group_Id { get; set; }
        public string All_Size { get; set; }

        public virtual Client_Group Client_Group { get; set; }
        public virtual Container_Type_Master Container_Type_Master { get; set; }
    }

    public class Cont_Size_Master_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Cont_Size_Master> data = new List<Cont_Size_Master>();
    }
}
