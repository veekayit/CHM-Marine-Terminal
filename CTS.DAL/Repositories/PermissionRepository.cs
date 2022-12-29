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
   public  class PermissionRepository
    {

       string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


       public Permission GetUserPermission(int  UserId, string PagePath)
       {
           Permission _obj = new Permission();
           using (SqlConnection con = new SqlConnection(strcon))
           {
               using (SqlCommand cmd = new SqlCommand(Procedures._Select_UserPermissionForPage))
               {
                   con.Open();
                   cmd.Connection = con;
                   cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@PageName", PagePath);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Permission_ID = Convert.ToInt32(rdr["Permission_ID"]);
                            //  _obj.GroupID_UserId = (Int32)(rdr["GroupID_UserId"]);
                            _obj.Menu_ID = (Int32)(rdr["Menu_ID"]);
                            _obj.AllowAdd = Convert.ToBoolean(rdr["AllowAdd"]);

                            _obj.AllowEdit = Convert.ToBoolean(rdr["AllowEdit"]);
                            _obj.AllowDelete = Convert.ToBoolean(rdr["AllowDelete"]);
                            _obj.AllowView = Convert.ToBoolean(rdr["AllowView"]);

                        }
                    }
               }
           }


           return _obj;
       }

        
    }
}
