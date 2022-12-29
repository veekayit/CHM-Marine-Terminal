using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Movement_Master
    {
        public int Movement_Id { get; set; }
        public string Movement_Name { get; set; }
        public string Move_Type { get; set; }
        public Nullable<short> Show_Order { get; set; }
    }

    public class Movement_Master_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Movement_Master> data = new List<Movement_Master>();
    }
}
