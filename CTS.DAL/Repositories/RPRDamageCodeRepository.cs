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
    public class RPRDamageCodeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public IEnumerable<RPR_DamageCode> GetAll()
        {
            List<RPR_DamageCode> _list = new List<RPR_DamageCode>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_RprDamageCode))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            RPR_DamageCode _obj = new RPR_DamageCode();
                            _obj.Damage_Id = Convert.ToInt32(rdr["Damage_Id"]);
                            _obj.Damage_Desc = Convert.ToString(rdr["Damage_Desc"]);
                            _obj.CDEXCode = Convert.ToString(rdr["CDEXCode"]);

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
    }
}
