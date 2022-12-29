using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Yard_Master
    {
        public int Yard_Id { get; set; }
        public string Yard_Code { get; set; }
        public string Yard_Name { get; set; }
        public Nullable<decimal> Yard_Rent { get; set; }
        public Nullable<decimal> Yard_Space { get; set; }
        public Nullable<bool> IS_CURRENT { get; set; }
        public Nullable<int> Branch_Id { get; set; }

        public virtual Branch_Master Branch_Master { get; set; }
    }

    public class Yard_Master_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Yard_Master> data = new List<Yard_Master>();
    }
}
