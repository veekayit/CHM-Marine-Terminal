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
    public class AccountTypeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public IEnumerable<Account_Type> GetAll()
        {
            List<Account_Type> _list = new List<Account_Type>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AccountType))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Account_Type _obj = new Account_Type();
                            _obj.Account_Type_Id = Convert.ToInt32(rdr["Account_Type_Id"]);
                            _obj.Account_TypeName = Convert.ToString(rdr["Account_Type"]);
                            _obj.Code = Convert.ToString(rdr["Code"]);
                            _obj.IsReefer = Convert.ToBoolean(rdr["IsReefer"]);
                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
    }
}
