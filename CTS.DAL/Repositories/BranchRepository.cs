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
    public class BranchRepository
    {


        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Branch_Master_XML))
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

        public IEnumerable<Branch_Master> GetAll()
        {
            List<Branch_Master> _list = new List<Branch_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Branch_Details))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Branch_Master _obj = new Branch_Master();
                            _obj.Branch_Id = Convert.ToInt32(rdr["Branch_Id"]);
                            _obj.Branch_Name = Convert.ToString(rdr["Branch_Name"]);
                            _obj.State_Code = (Int32)(rdr["State_Code"]);
                            _obj.Pan_No = Convert.ToString(rdr["Pan_No"]);

                            _obj.No_Of_Regs = Convert.ToString(rdr["No_Of_Regs"]);
                            _obj.Def_Digit = Convert.ToString(rdr["Def_Digit"]);
                            _obj.CheckSum_Code = Convert.ToString(rdr["CheckSum_Code"]);
                            _obj.Branch_Comp_Name = Convert.ToString(rdr["Branch_Comp_Name"]);
                            _obj.Branch_Add1 = Convert.ToString(rdr["Branch_Add1"]);
                            _obj.Branch_Add2 = Convert.ToString(rdr["Branch_Add2"]);


                            _obj.Branch_Add3 = Convert.ToString(rdr["Branch_Add3"]);
                            _obj.Branch_Add4 = Convert.ToString(rdr["Branch_Add4"]);
                            _obj.Bank_Name = Convert.ToString(rdr["Bank_Name"]);
                            _obj.Account_No = Convert.ToString(rdr["Account_No"]);

                            _obj.Ifsc_Code = Convert.ToString(rdr["Ifsc_Code"]);
                            _obj.Bank_Branch = Convert.ToString(rdr["Bank_Branch"]);
                            //   _obj.GSTN_No = Convert.ToString(rdr["GSTN_No"]);



                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public Branch_Master GetByID(int Id)
        {
            Branch_Master _obj = new Branch_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Branch_Details))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Branch_Id", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Branch_Id = Convert.ToInt32(rdr["Branch_Id"]);
                            _obj.Branch_Name = Convert.ToString(rdr["Branch_Name"]);
                            _obj.State_Code = (Int32)(rdr["State_Code"]);
                            _obj.Pan_No = Convert.ToString(rdr["Pan_No"]);

                            _obj.No_Of_Regs = Convert.ToString(rdr["No_Of_Regs"]);
                            _obj.Def_Digit = Convert.ToString(rdr["Def_Digit"]);
                            _obj.CheckSum_Code = Convert.ToString(rdr["CheckSum_Code"]);
                            _obj.Branch_Comp_Name = Convert.ToString(rdr["Branch_Comp_Name"]);
                            _obj.Branch_Add1 = Convert.ToString(rdr["Branch_Add1"]);
                            _obj.Branch_Add2 = Convert.ToString(rdr["Branch_Add2"]);


                            _obj.Branch_Add3 = Convert.ToString(rdr["Branch_Add3"]);
                            _obj.Branch_Add4 = Convert.ToString(rdr["Branch_Add4"]);
                            _obj.Bank_Name = Convert.ToString(rdr["Bank_Name"]);
                            _obj.Account_No = Convert.ToString(rdr["Account_No"]);

                            _obj.Ifsc_Code = Convert.ToString(rdr["Ifsc_Code"]);
                            _obj.Bank_Branch = Convert.ToString(rdr["Bank_Branch"]);

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
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_Branch))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Branch_Id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
       
    }
}
