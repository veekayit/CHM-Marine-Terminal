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
    public class TransporterRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Transporter_Master_XML_New))
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

        public IEnumerable<Transporter_Master> GetAll()
        {
            List<Transporter_Master> _list = new List<Transporter_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Transporters))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Transporter_Master _obj = new Transporter_Master();
                            _obj.Transporter_ID = Convert.ToInt32(rdr["Transporter_Id"]);
                            _obj.Transporter_Name = Convert.ToString(rdr["Transporter_Name"]);



                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public Transporter_Master GetByID(int Id)
        {
            Transporter_Master _obj = new Transporter_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Transporters))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Transporter_Id", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Transporter_ID = Convert.ToInt32(rdr["Transporter_Id"]);
                            _obj.Transporter_Name = Convert.ToString(rdr["Transporter_Name"]);


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
                using (SqlCommand cmd = new SqlCommand(Procedures._TransporterDelete))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransporterId", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
    }
}
