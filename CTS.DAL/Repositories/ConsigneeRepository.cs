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
    public class ConsigneeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Consignee_Master_XML_New))
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

        public IEnumerable<Consignee_Master> GetAll()
        {
            List<Consignee_Master> _list = new List<Consignee_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Consignees))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Consignee_Master _obj = new Consignee_Master();
                            _obj.Consignee_Id = Convert.ToInt32(rdr["Consignee_Id"]);
                            _obj.Consignee_Name = Convert.ToString(rdr["Consignee_Name"]);



                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public Consignee_Master GetByID(int Id)
        {
            Consignee_Master _obj = new Consignee_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Consignees))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Consignee_Id", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Consignee_Id = Convert.ToInt32(rdr["Consignee_Id"]);
                            _obj.Consignee_Name = Convert.ToString(rdr["Consignee_Name"]);


                        }
                    }
                }
            }


            return _obj;
        }

        public int Delete(int Id)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._ConsigneeDelete))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsigneeId", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
    }
}
