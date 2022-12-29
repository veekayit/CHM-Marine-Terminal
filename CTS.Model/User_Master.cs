using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    [Serializable]
    public class User_Master
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public Nullable<int> Dept_Id { get; set; }
        public int Group_Id { get; set; }

        public Nullable<bool> System_Generated { get; set; }
        public string User_FName { get; set; }

        public string Branch_Id { get; set; }
        public string Yard_Ids { get; set; }
        public bool Blocked { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Main_Account_Id { get; set; }
        public Nullable<int> Client_Group_Id { get; set; }


        public bool IsPassExpired
        {
            get;
            set;
        }
        public string Block_Reason
        {
            get;
            set;
        }

      //  public virtual Department_Master Department_Master { get; set; }
        public virtual User_Group User_Group { get; set; }
        public virtual Dept_Master Dept_Master { get; set; }
    }


    public class User_Master_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<User_Master> data = new List<User_Master>();
    }
}
