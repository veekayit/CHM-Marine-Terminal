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
    public class CustomerRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Customer_Master_XML_New))
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

        public IEnumerable<CustomerMaster> GetAll()
        {
            List<CustomerMaster> _list = new List<CustomerMaster>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Customer_Details))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            CustomerMaster _obj = new CustomerMaster();
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.Customer_Name = Convert.ToString(rdr["Customer_Name"]);

                            _obj.Customer_Add1 = Convert.ToString(rdr["Customer_Add1"]);
                            _obj.Customer_Add2 = Convert.ToString(rdr["Customer_Add2"]);
                            _obj.Customer_Add3 = Convert.ToString(rdr["Customer_Add3"]);
                            _obj.Customer_Add4 = Convert.ToString(rdr["Customer_Add4"]);


                            _obj.currency_id = Convert.ToInt32(rdr["currency_id"]);
                            _obj.Repair = Convert.ToBoolean(rdr["Repair"]);
                            _obj.Cust_code = Convert.ToString(rdr["Cust_code"]);


                            _obj.ManHourRate = (decimal)(rdr["ManHourRate"]);
                            _obj.Reefer_ManHourRate = (decimal)(rdr["Reefer_ManHourRate"]);
                            _obj.FreeRentDays = Convert.ToInt32(rdr["FreeRentDays"]);

                            _obj.State_Code = Convert.ToInt32((rdr["State_Code"] == DBNull.Value) ? null : rdr["State_Code"]);
                            _obj.No_Of_Regs = Convert.ToString(rdr["No_Of_Regs"]);
                            _obj.Def_Digit = Convert.ToString(rdr["Def_Digit"]);
                            _obj.CheckSum_Code = Convert.ToString(rdr["CheckSum_Code"]);



                            _obj.Main_Account_Id = Convert.ToInt32(rdr["Main_Account_Id"]);
                            _obj.Main_Account_Master = new Main_Account_Master
                            {
                                CustomerID = Convert.ToInt32(rdr["Main_Account_id"]),
                                Customer_Name = Convert.ToString(rdr["MAM_Customer_Name"]),


                                Client_Group = new Client_Group
                                {
                                    Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"])
                                }
                            };

                            _obj.Currency_Master = new Currency_Master
                            {
                                Currency_Id = Convert.ToInt32(rdr["Currency_Id"]),
                                Currency_Name = Convert.ToString(rdr["Currency_Name"])
                            };



                            _obj.Email_Ids = Convert.ToString(rdr["Email_Ids"]);




                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public CustomerMaster GetByID(int Id)
        {
            CustomerMaster _obj = new CustomerMaster();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Customer_Details))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Customer_Id", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.Customer_Name = Convert.ToString(rdr["Customer_Name"]);

                            _obj.Customer_Add1 = Convert.ToString(rdr["Customer_Add1"]);
                            _obj.Customer_Add2 = Convert.ToString(rdr["Customer_Add2"]);
                            _obj.Customer_Add3 = Convert.ToString(rdr["Customer_Add3"]);
                            _obj.Customer_Add4 = Convert.ToString(rdr["Customer_Add4"]);


                            _obj.currency_id = Convert.ToInt32(rdr["currency_id"]);
                            _obj.Repair = Convert.ToBoolean(rdr["Repair"]);
                            _obj.Cust_code = Convert.ToString(rdr["Cust_code"]);


                            _obj.ManHourRate = (decimal)(rdr["ManHourRate"]);
                            _obj.Reefer_ManHourRate = (decimal)(rdr["Reefer_ManHourRate"]);
                            _obj.FreeRentDays = Convert.ToInt32(rdr["FreeRentDays"]);

                            _obj.State_Code = Convert.ToInt32(rdr["State_Code"]);
                            _obj.No_Of_Regs = Convert.ToString(rdr["No_Of_Regs"]);
                            _obj.Def_Digit = Convert.ToString(rdr["Def_Digit"]);
                            _obj.CheckSum_Code = Convert.ToString(rdr["CheckSum_Code"]);



                            _obj.Main_Account_Id = Convert.ToInt32(rdr["Main_Account_Id"]);
                            _obj.Main_Account_Master = new Main_Account_Master
                            {
                                CustomerID = Convert.ToInt32(rdr["Main_Account_id"]),
                                Customer_Name = Convert.ToString(rdr["MAM_Customer_Name"])
                            };
                            _obj.Currency_Master = new Currency_Master
                            {
                                Currency_Id = Convert.ToInt32(rdr["Currency_Id"]),
                                Currency_Name = Convert.ToString(rdr["Currency_Name"])
                            };


                            _obj.Email_Ids = Convert.ToString(rdr["Email_Ids"]);

                            _obj.Ero_Prefix = Convert.ToString(rdr["Ero_Prefix"]);

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
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_customer))
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



        public IEnumerable<CustomerMaster> Get_CompanyCustomers(string PCustomerId = null, string PCustomerName = null, string pMainAccids = null)
        {
            List<CustomerMaster> _list = new List<CustomerMaster>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Company_Customers))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(pMainAccids)) cmd.Parameters.AddWithValue("@Main_Account_ids", ","+pMainAccids+",");
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            CustomerMaster _obj = new CustomerMaster();
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.Customer_Name = Convert.ToString(rdr["Customer_Name"]);

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
    }
}
