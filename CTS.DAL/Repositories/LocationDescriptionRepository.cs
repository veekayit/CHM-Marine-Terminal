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
    public class LocationDescriptionRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Location_Description_Master))
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
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_LocDescription))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Desc_Id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }

        public IEnumerable<Location_Description> GetAll(string PLocationId, string PSearch = null)
        {
            List<Location_Description> _list = new List<Location_Description>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_LocationDescriptions))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Location_Id", PLocationId);
                    if (!string.IsNullOrEmpty(PSearch)) cmd.Parameters.AddWithValue("@Location_Name", PSearch);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Location_Description _obj = new Location_Description();
                            _obj.Desc_Id = Convert.ToInt32(rdr["Desc_Id"]);
                            _obj.Descriptions = Convert.ToString(rdr["Descriptions"]);
                            _obj.Location_Id = (Int32)(rdr["Location_Id"]);

                            _obj.Location_Master = new Location_Master
                            {
                                Location_Id = Convert.ToInt32(rdr["Location_Id"]),
                                Location_Name = Convert.ToString(rdr["Location_Name"])
                            };


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
    }
}
