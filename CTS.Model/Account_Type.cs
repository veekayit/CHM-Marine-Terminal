using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class Account_Type
    {
        public int Account_Type_Id { get; set; }
        public string Account_TypeName { get; set; }
        public Nullable<bool> IsReefer { get; set; }
        public Nullable<int> Show_Order { get; set; }
        public string Code { get; set; }
    }
}
