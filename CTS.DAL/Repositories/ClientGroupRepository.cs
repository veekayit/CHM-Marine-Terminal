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
    public class ClientGroupRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
  

        public IEnumerable<Client_Group> GetAll()
        {
            List<Client_Group> _list = new List<Client_Group>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ClientGroups))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Client_Group _obj = new Client_Group();
                            _obj.Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]);
                            _obj.Client_Group_Name = Convert.ToString(rdr["Client_Group_Name"]);
                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

 
   
        #endregion
       
    }
}
