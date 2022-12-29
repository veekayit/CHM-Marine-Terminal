using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Tax_Master
    {
        public int Tax_Id { get; set; }
        public string Tax_Name { get; set; }
        public Nullable<double> TaxRate { get; set; }
        public Nullable<System.DateTime> Tax_Date { get; set; }
        public string Tax_Type { get; set; }
        public Nullable<bool> Intra_State { get; set; }
        public Nullable<int> Tax_Per_Desc { get; set; }
        public Nullable<bool> System_Defined { get; set; }
        public Nullable<int> Show_Order { get; set; }

        public Nullable<double> Tax_Amount { get; set; }
    }
}
