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
    public class UserRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public User_Master Authenticate(User_Master user)
        {

            User_Master _obj = new User_Master();

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Authenticate_User))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uName", user.User_Name);
                    cmd.Parameters.AddWithValue("@uPswd", user.User_Password);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        #region master
                        while (rdr.Read())
                        {
                            _obj.User_Id = (Int32)rdr["User_Id"];
                            _obj.User_Name = Convert.ToString(rdr["User_Name"]);
                            _obj.User_Password = Convert.ToString(rdr["User_Password"]);
                            //  _obj.Dept_Id = Convert.ToInt32(rdr["Dept_Id"]);
                            // _obj.Group_Id = Convert.ToInt32(rdr["Group_Id"]);
                            //  _obj.System_Generated = Convert.ToBoolean(rdr["System_Generated"]);
                            _obj.User_FName = Convert.ToString(rdr["User_FName"]);
                            //_obj.Blocked = Convert.ToBoolean(rdr["Blocked"]);
                            //_obj.IsPassExpired = Convert.ToBoolean(rdr["IsPassExpired"]);
                            //_obj.Block_Reason = rdr["Block_Reason"].ToString();

                            //_obj.User_Group = new User_Group
                            //{
                            //    Group_Id = Convert.ToInt32(rdr["Group_Id"]),
                            //    Group_Name = Convert.ToString(rdr["Group_Name"])
                            //};

                            //if (!string.IsNullOrEmpty(rdr["Dept_Id"].ToString()))
                            //{
                            //    _obj.Department_Master = new Department_Master
                            //    {

                            //        Dept_Id = Convert.ToInt32(rdr["Dept_Id"]),
                            //        Dept_Name = Convert.ToString(rdr["Dept_Name"]),

                            //    };
                            //}


                        }
                        #endregion
                    }

                }
            }
            return _obj;
        }

        public User_Master GetByID(int Id)
        {
            User_Master _obj = new User_Master();

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_User))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", Id);
                  //  cmd.Parameters.AddWithValue("@User_Id", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        #region master
                        while (rdr.Read())
                        {
                            _obj.User_Id = (Int32)rdr["User_Id"];
                            _obj.User_Name = Convert.ToString(rdr["User_Name"]);
                            _obj.User_Password = Convert.ToString(rdr["User_Password"]);

                            _obj.Group_Id = Convert.ToInt32(rdr["Group_Id"]);
                            //  _obj.System_Generated = Convert.ToBoolean(rdr["System_Generated"]);
                            _obj.User_FName = Convert.ToString(rdr["User_FName"]);
                            //_obj.Blocked = Convert.ToBoolean(rdr["Blocked"]);

                            _obj.Active = Convert.ToBoolean(rdr["Active"]);
                            _obj.Branch_Id = Convert.ToString(rdr["Branch_Id"]);
                            _obj.Yard_Ids = Convert.ToString(rdr["Yard_Ids"]);

                            _obj.Main_Account_Id = (rdr["Main_Account_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Main_Account_Id"].ToString());
                            _obj.Client_Group_Id = (rdr["Client_Group_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Client_Group_Id"].ToString());

                            _obj.User_Group = new User_Group
                            {
                                Group_Id = Convert.ToInt32(rdr["Group_Id"]),
                                Group_Name = Convert.ToString(rdr["Group_Name"])
                            };

                            _obj.Dept_Master = new Dept_Master
                            {
                                Dept_Id = Convert.ToInt32(rdr["Dept_Id"]),
                                Dept_Name = Convert.ToString(rdr["dept_name"])
                            };




                        }
                        #endregion
                    }

                }
            }
            return _obj;
        }


        public int Save(string UserName, string User_Password, string Dept_Id, string Group_Id,
                           string User_FName, string User_id, string BranchId = null, string YardIds = null)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_User_Master))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@p_User_Id", User_id);
                    cmd.Parameters.AddWithValue("@p_User_Name", UserName);
                    cmd.Parameters.AddWithValue("@p_User_Password", User_Password);
                    cmd.Parameters.AddWithValue("@p_Dept_Id", Dept_Id);
                    cmd.Parameters.AddWithValue("@p_Group_Id", Group_Id);
                    cmd.Parameters.AddWithValue("@p_System_Generated", false);
                    cmd.Parameters.AddWithValue("@p_User_FName", User_FName);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }


        public IEnumerable<User_Master> GetAll()
        {
            List<User_Master> _list = new List<User_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_AllUsers))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            User_Master _obj = new User_Master();
                            _obj.User_Id = Convert.ToInt32(rdr["User_Id"]);
                            _obj.User_Name = Convert.ToString(rdr["User_Name"]);
                            _obj.User_FName = Convert.ToString(rdr["User_FName"]);
                            _obj.User_Password = Convert.ToString(rdr["User_Password"]);

                            _obj.User_Group = new User_Group
                            {
                                Group_Id = Convert.ToInt32(rdr["Group_Id"]),
                                Group_Name = Convert.ToString(rdr["Group_Name"])
                            };


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }


        public int Delete(int Id)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_user))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }


        public int SaveUserPermissions(string lblPermissionId, string pstrUserFlag, string pstruserid, string plblMenuId, string pchkAddVal = null, string pchkEditVal = null, string pchkViewVal = null, string pchkDelVal = null)
        {


            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._sp_UserPermissionSaves))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Permission_ID", lblPermissionId);
                    cmd.Parameters.AddWithValue("@SaveFlag", pstrUserFlag);
                    cmd.Parameters.AddWithValue("@struserid", pstruserid);

                    cmd.Parameters.AddWithValue("@MenuId", plblMenuId);
                
                    cmd.Parameters.AddWithValue("@AddVal", pchkAddVal);
                    cmd.Parameters.AddWithValue("@EditVal", pchkEditVal);
                    cmd.Parameters.AddWithValue("@DelVal", pchkDelVal);
                    cmd.Parameters.AddWithValue("@ViewVal", pchkViewVal);
 
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
 
        }




        public int UpdatePassword(int UserId, string Password)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Update_UserPassword))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User_Id", UserId);
                    cmd.Parameters.AddWithValue("@User_Password", Password);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }


        public int UserActivation(int UserId, bool Activation)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._User_Activation))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User_Id", UserId);
                    cmd.Parameters.AddWithValue("@Active", Activation);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
    }



}
