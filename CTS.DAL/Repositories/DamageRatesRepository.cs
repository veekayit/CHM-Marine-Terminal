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
    public class DamageRatesRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;



        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_DamageRates_XML))
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
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_DamageCodeRates))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Damage_Rate_Id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }

        public IEnumerable<Damage_Code_Rates> GetAll()
        {
            List<Damage_Code_Rates> _list = new List<Damage_Code_Rates>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AllDamageCodeRates))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Damage_Code_Rates _obj = new Damage_Code_Rates();
                            _obj.Damage_Rate_Id = Convert.ToInt32(rdr["Damage_Rate_Id"]);
                            _obj.Damage_Id = Convert.ToInt32(rdr["Damage_Id"]);
                            _obj.Hrs = (double)(rdr["Hrs"]);
                            _obj.MaterialAmt = (decimal)(rdr["MaterialAmt"]);

                            _obj.LumpsumAmt = (decimal)(rdr["LumpsumAmt"]);

                            _obj.Repair_Type_Master = new Repair_Type_Master
                            {
                                Repair_Type_Id = Convert.ToInt32(rdr["Repair_Type_Id"]),
                                Repair_Type = Convert.ToString(rdr["Repair_Type"])
                            };

                            _obj.Damage_Code_Master = new Damage_Code_Master
                            {
                                Damage_Id = (long)(rdr["Damage_Id"]),
                                Damage_Code = Convert.ToString(rdr["Damage_Code"]),

                                Location_Description = new Location_Description
                                {
                                    Desc_Id = (long)(rdr["Desc_Id"]),
                                    Descriptions = rdr["Descriptions"].ToString()
                                }

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
