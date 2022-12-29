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
    public class MainAccountRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_MainAccount_Master_XML_New))
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

        public IEnumerable<Main_Account_Master> GetAll()
        {
            List<Main_Account_Master> _list = new List<Main_Account_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_MainAccount_Details))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {


                        while (rdr.Read())
                        {
                            Main_Account_Master _obj = new Main_Account_Master();
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.Customer_Name = Convert.ToString(rdr["Customer_Name"]);
                            _obj.Customer_Add1 = Convert.ToString(rdr["Customer_Add1"]);
                            _obj.Customer_Add2 = Convert.ToString(rdr["Customer_Add2"]);
                            _obj.Customer_Add3 = Convert.ToString(rdr["Customer_Add3"]);
                            _obj.Customer_Add4 = Convert.ToString(rdr["Customer_Add4"]);

                            _obj.State_Code = (Int32)(rdr["State_Code"]);
                            _obj.Pan_No = Convert.ToString(rdr["Pan_No"]);

                            _obj.No_Of_Regs = Convert.ToString(rdr["No_Of_Regs"]);
                            _obj.Def_Digit = Convert.ToString(rdr["Def_Digit"]);
                            _obj.CheckSum_Code = Convert.ToString(rdr["CheckSum_Code"]);

                            _obj.Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]);

                            _obj.Client_Group = new Client_Group
                            {
                                Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]),
                                Client_Group_Name = Convert.ToString(rdr["Client_Group_Name"])
                            };



                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public Main_Account_Master GetByID(int Id)
        {
            Main_Account_Master _obj = new Main_Account_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_MainAccount_Details))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Customer_Id", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                        _obj.Customer_Name = Convert.ToString(rdr["Customer_Name"]);
                        _obj.Customer_Add1 = Convert.ToString(rdr["Customer_Add1"]);
                        _obj.Customer_Add2 = Convert.ToString(rdr["Customer_Add2"]);
                        _obj.Customer_Add3 = Convert.ToString(rdr["Customer_Add3"]);
                        _obj.Customer_Add4 = Convert.ToString(rdr["Customer_Add4"]);

                        _obj.State_Code = (Int32)(rdr["State_Code"]);
                        _obj.Pan_No = Convert.ToString(rdr["Pan_No"]);

                        _obj.No_Of_Regs = Convert.ToString(rdr["No_Of_Regs"]);
                        _obj.Def_Digit = Convert.ToString(rdr["Def_Digit"]);
                        _obj.CheckSum_Code = Convert.ToString(rdr["CheckSum_Code"]);

                        _obj.Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]);

                        _obj.Client_Group = new Client_Group
                        {
                            Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]),
                            Client_Group_Name = Convert.ToString(rdr["Client_Group_Name"])
                        };

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
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_MainAccount))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
    }
}
