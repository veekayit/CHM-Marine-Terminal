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
    public class DepartmentRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public IEnumerable<Dept_Master> GetAll()
        {
            List<Dept_Master> _list = new List<Dept_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Departments))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Dept_Master _obj = new Dept_Master();
                            _obj.Dept_Id = Convert.ToInt32(rdr["Dept_Id"]);
                            _obj.Dept_Name = Convert.ToString(rdr["Dept_Name"]);

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

    }
}
