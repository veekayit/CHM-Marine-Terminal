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
    public class MenuRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        public IEnumerable<Menu_Master> GetAllParents()
        {
            List<Menu_Master> _list = new List<Menu_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Select_AllParentMenu))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Menu_Master _obj = new Menu_Master();
                            _obj.Menu_Id = Convert.ToInt32(rdr["Menu_Id"]);
                            _obj.Menu_Caption = Convert.ToString(rdr["Menu_Caption"]);


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public IEnumerable<Permission> GetPermissions(string GroupId, int MastermenuId, string strUserFlag)
        {
            List<Permission> _list = new List<Permission>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_GroupPermissions))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", GroupId);
                    cmd.Parameters.AddWithValue("@MastermenuId", MastermenuId);
                    cmd.Parameters.AddWithValue("@UserFlag", strUserFlag);
                    SqlDataReader rdr = cmd.ExecuteReader();



                    while (rdr.Read())
                    {
                        Permission _obj = new Permission();
                        _obj.Permission_ID = (rdr["Permission_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["Permission_ID"].ToString()); 
                        _obj.Menu_ID = Convert.ToInt32(rdr["Menu_ID"]);
                       
                        _obj.GroupID_UserId = (rdr["GroupID_UserId"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["GroupID_UserId"].ToString());
                        _obj.AllowView = (rdr["AllowView"] == DBNull.Value) ? false : Convert.ToBoolean(rdr["AllowView"].ToString());
                        _obj.AllowAdd = (rdr["AllowAdd"] == DBNull.Value) ? false : Convert.ToBoolean(rdr["AllowAdd"].ToString());
                        _obj.AllowEdit = (rdr["AllowEdit"] == DBNull.Value) ? false : Convert.ToBoolean(rdr["AllowEdit"].ToString());
                        _obj.AllowDelete = (rdr["AllowDelete"] == DBNull.Value) ? false : Convert.ToBoolean(rdr["AllowDelete"].ToString());

                        _obj.Menu_Master = new Menu_Master { Parent_id = Convert.ToInt32(rdr["Parent_id"]),
                                                             Menu_Caption = rdr["Menu_Caption"].ToString()
                        };
                        _list.Add(_obj);
                    }
                }
            }

 

            return _list;
        }
    }
}
