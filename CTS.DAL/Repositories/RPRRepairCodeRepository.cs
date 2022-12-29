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
    public class RPRRepairCodeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public IEnumerable<RPR_RepairCode> GetAll()
        {
            List<RPR_RepairCode> _list = new List<RPR_RepairCode>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AllRprRepairCodes))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            RPR_RepairCode _obj = new RPR_RepairCode();
                            _obj.Repair_Id = Convert.ToInt32(rdr["Repair_Id"]);
                            _obj.Repair_Desc = Convert.ToString(rdr["Repair_Desc"]);
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
