using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Branch_Master
    {
        public int Branch_Id { get; set; }
        public string Branch_Name { get; set; }
        public Nullable<int> State_Code { get; set; }
        public string Pan_No { get; set; }
        public string No_Of_Regs { get; set; }
        public string Def_Digit { get; set; }
        public string CheckSum_Code { get; set; }
        public string Branch_Comp_Name { get; set; }
        public string Branch_Add1 { get; set; }
        public string Branch_Add2 { get; set; }
        public string Branch_Add3 { get; set; }
        public string Branch_Add4 { get; set; }
        public string Bank_Name { get; set; }
        public string Account_No { get; set; }
        public string Ifsc_Code { get; set; }
        public string Bank_Branch { get; set; }

        public string GSTN_No { get; set; }
    }

    public class Branch_Master_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Branch_Master> data = new List<Branch_Master>();
    }
}
