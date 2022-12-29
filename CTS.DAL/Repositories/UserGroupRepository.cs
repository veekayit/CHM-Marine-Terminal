using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CTS.Models;

namespace CTS.DAL.Repositories
{
    public class UserGroupRepository

    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public IEnumerable<User_Group> GetAll()
        {
            List<User_Group> _list = new List<User_Group>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AllUserGroups))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            User_Group _obj = new User_Group();
                            _obj.Group_Id = Convert.ToInt32(rdr["Group_Id"]);
                            _obj.Group_Name = Convert.ToString(rdr["Group_Name"]);

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

    }
}
