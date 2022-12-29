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
    public class RepairTypeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Insert_RepairTypeMaster))
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
                using (SqlCommand cmd = new SqlCommand(Procedures._DeleteRepairType))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Repair_Type_Id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        public IEnumerable<Repair_Type_Master> GetAll(string PDescId, string PSearch = null)
        {
            List<Repair_Type_Master> _list = new List<Repair_Type_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AllRepairTypes))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desc_Id", PDescId);
                    if (!string.IsNullOrEmpty(PSearch)) cmd.Parameters.AddWithValue("@Repair_Type", PSearch);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Repair_Type_Master _obj = new Repair_Type_Master();
                            _obj.Repair_Type_Id = Convert.ToInt32(rdr["Repair_Type_Id"]);
                            _obj.Repair_Type = Convert.ToString(rdr["Repair_Type"]);


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }


     

    }
}
