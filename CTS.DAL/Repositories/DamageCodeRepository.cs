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
    public class DamageCodeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public IEnumerable<Damage_Code_Master> GetAll(string PLocDescId, string PSearch = null)
        {
            List<Damage_Code_Master> _list = new List<Damage_Code_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AllDamageCode))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(PLocDescId)) cmd.Parameters.AddWithValue("@Desc_Id", PLocDescId);
                    if (!string.IsNullOrEmpty(PSearch)) cmd.Parameters.AddWithValue("@DamageCode", PSearch);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Damage_Code_Master _obj = new Damage_Code_Master();
                            _obj.Damage_Id = Convert.ToInt32(rdr["Damage_Id"]);
                            _obj.Damage_Code = Convert.ToString(rdr["Damage_Code"]);
                            _obj.Desc_Id = (long)(rdr["Desc_Id"]);
                            _obj.Location_Id = (Int32)(rdr["Location_Id"]);
                            _obj.Hrs = (double)(rdr["Hrs"]);
                            _obj.LabourAmt = (decimal)(rdr["LabourAmt"]);
                            _obj.MaterialAmt = (decimal)(rdr["MaterialAmt"]);
                            _obj.LumpsumAmt = (decimal)(rdr["LumpsumAmt"]);

                            _obj.TypeOfRepair = Convert.ToString(rdr["TypeOfRepair"]);
                            //_obj.Repair_Type_Master = new Repair_Type_Master
                            //{
                            //    Repair_Type_Id = Convert.ToInt32(rdr["Repair_Type_Id"]),
                            //    Repair_Type = Convert.ToString(rdr["Repair_Type"])
                            //};
                            _obj.Location_Description = new Location_Description
                            {
                                Desc_Id = Convert.ToInt32(rdr["Desc_Id"]),
                                Descriptions = Convert.ToString(rdr["Descriptions"])
                            };
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


        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_DamageCode_XML))
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
        public int Delete(int  Id)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_DamageCode))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DamageId", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }

        public int UpdateDamageCodeRates(string DamageRateId, string Desc, string Hrs = "", string MatAmt = "", string LumAmt = "", string LabrRate = "")
        {

            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Update_DamageCodeMaster_Rates))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Damage_Rate_Id", DamageRateId);
                    cmd.Parameters.AddWithValue("@Desc", Desc);
                    cmd.Parameters.AddWithValue("@Hrs", Hrs);
                    cmd.Parameters.AddWithValue("@MaterialAmt", MatAmt);
                    cmd.Parameters.AddWithValue("@LumpsumAmt", LumAmt);
                   // cmd.Parameters.AddWithValue("@ManHrRate", LabrRate);

                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;

  
        }
    }
}
