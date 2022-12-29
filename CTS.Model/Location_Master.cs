using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
  [Serializable]
    public class Location_Master
    {
        public int Location_Id { get; set; }
        public string Location_Name { get; set; }
        public string CdexCode { get; set; }
        public Nullable<int> Upload_Id { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public Nullable<int> Main_Account_Id { get; set; }
        public Nullable<int> Client_Group_Id { get; set; }
      
        public virtual Main_Account_Master Main_Account_Master { get; set; }
    
    }
}
