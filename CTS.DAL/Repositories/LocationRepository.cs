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
   public  class LocationRepository
    {

       string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

       public IEnumerable<Location_Master> GetAll()
       {
           List<Location_Master> _list = new List<Location_Master>();
           using (SqlConnection con = new SqlConnection(strcon))
           {
               using (SqlCommand cmd = new SqlCommand(Procedures._Get_Location))
               {
                   con.Open();
                   cmd.Connection = con;
                   cmd.CommandType = CommandType.StoredProcedure;

                   using (SqlDataReader rdr = cmd.ExecuteReader())
                   {

                       while (rdr.Read())
                       {
                           Location_Master _obj = new Location_Master();
                           _obj.Location_Id = Convert.ToInt32(rdr["Location_Id"]);
                           _obj.Location_Name = Convert.ToString(rdr["Location_Name"]);
                           _obj.CdexCode = Convert.ToString(rdr["CdexCode"]);
                           _obj.Main_Account_Id = (rdr["Main_Account_Id"] == DBNull.Value) ? (Int32?)null : (Int32)(rdr["Main_Account_Id"]);
                           _obj.Client_Group_Id = (Int32)(rdr["Client_Group_Id"]);
                           //_obj.Main_Account_Master = new Main_Account_Master {
                           //    CustomerID = Convert.ToInt32(rdr["Main_Account_Id"]),
                           //    Customer_Name = Convert.ToString(rdr["Customer_Name"]),
                           //    Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"])
                           //};

                           _list.Add(_obj);
                       }
                   }
               }
           }

           return _list;
       }
       public Int32 Save(string strXML)
       {
           int res;
           using (SqlConnection con = new SqlConnection(strcon))
           {
               using (SqlCommand cmd = new SqlCommand(Procedures._Save_LocationMaster))
               {
                   con.Open();
                   cmd.Connection = con;
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@StrXML", strXML);
                   res = cmd.ExecuteNonQuery();

               }
           }

           return res;
       }

       public int Delete(int Id)
       {
           int res = 0;
           using (SqlConnection con = new SqlConnection(strcon))
           {
               using (SqlCommand cmd = new SqlCommand(Procedures._DeleteLocation))
               {
                   con.Open();
                   cmd.Connection = con;
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@p_Loc_Id", Id);
                   res = cmd.ExecuteNonQuery();

               }
           }
           return res;
       }
    }
}
