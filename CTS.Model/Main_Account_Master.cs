using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
   public class Main_Account_Master
    {
        public int CustomerID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Add1 { get; set; }
        public string Customer_Add2 { get; set; }
        public string Customer_Add3 { get; set; }
        public string Customer_Add4 { get; set; }
        public int State_Code { get; set; }
        public string Pan_No { get; set; }
        public string No_Of_Regs { get; set; }
        public string Def_Digit { get; set; }
        public string CheckSum_Code { get; set; }
        public Nullable<int> Client_Group_Id { get; set; }
        

        public virtual Client_Group Client_Group { get; set; }
    }

   public class Main_Account_Master_Datatable
   {
       public int draw { get; set; }
       public int recordsTotal { get; set; }
       public int recordsFiltered { get; set; }
       public List<Main_Account_Master> data = new List<Main_Account_Master>();
   }
}
