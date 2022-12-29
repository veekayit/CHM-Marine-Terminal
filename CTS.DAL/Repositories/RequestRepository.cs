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
   public  class RequestRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        public IEnumerable<Cont_In_Edit_Request> GetAllINRequests(string FromDate = null, string ToDate = null, string ContNo = null, 
                                                                    string UserId = null, string RequestType = null)
        {
            List<Cont_In_Edit_Request> _list = new List<Cont_In_Edit_Request>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContInRequests))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(FromDate))  cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    if (!string.IsNullOrEmpty(ToDate))  cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    if (!string.IsNullOrEmpty(ContNo))  cmd.Parameters.AddWithValue("@ContNo", ContNo);
                    if (!string.IsNullOrEmpty(UserId))  cmd.Parameters.AddWithValue("@UserId", UserId);
                    if (!string.IsNullOrEmpty(RequestType))  cmd.Parameters.AddWithValue("@RequestType", RequestType);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Cont_In_Edit_Request _obj = new Cont_In_Edit_Request();
                            _obj.Request_Id = (long)(rdr["Request_Id"]);
                            _obj.Request_Type = Convert.ToString(rdr["Request_Type_Desc"]);
                            _obj.Request_Date = Convert.ToDateTime(rdr["Request_Date"]);
                            _obj.Cont_Id = (long)(rdr["Cont_Id"]);
                            _obj.Cont_No = Convert.ToString(rdr["Cont_No"]);
                            _obj.Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]);
                            _obj.Cont_Main = new Cont_Main
                            {
                                Cont_Id = Convert.ToInt32(rdr["Cont_Id"]),
                                Cont_No = Convert.ToString(rdr["Cont_No"]),
                                Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"])
                            };
                            _obj.Cont_Main.User_Master = new User_Master { User_Name = Convert.ToString(rdr["EUM_User_Name"]) };
                            _obj.Cont_Main.Cont_Size_Master = new Cont_Size_Master
                            {
                                Contsize_Id = (int)rdr["Contsize_Id"],
                                Cont_Size = Convert.ToString(rdr["Cont_Size"])
                            };

                            _obj.Cont_Main.Cont_In = new Cont_In { Cont_InDate = Convert.ToDateTime(rdr["Cont_In_Date"]) };

                            _obj.Request_Description = Convert.ToString(rdr["Request_Description"]);

                            _obj.Requested_User_Master = new User_Master { User_Id = (int)rdr["Request_By_User_Id"], User_Name = Convert.ToString(rdr["Requested_By"]) };





                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
          public Int32 Save_InEditRequest(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_ContainerInEditRequest_XML))
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
          public int CancelContInEditRequest(string pRequestId, string pUserId, string pRemarks)
          {
              int res;
              using (SqlConnection con = new SqlConnection(strcon))
              {
                  using (SqlCommand cmd = new SqlCommand(Procedures._Cancel_ContInEditRequest))
                  {
                      con.Open();
                      cmd.Connection = con;
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@Request_Id", pRequestId);
                      cmd.Parameters.AddWithValue("@User_Id", pUserId);
         
                      if (!String.IsNullOrEmpty(pRemarks)) cmd.Parameters.AddWithValue("@Remarks", pRemarks);
                      res = cmd.ExecuteNonQuery();
                  }

              }

              return res;
          }

          public int ApproveContInEditRequest(string pRequestId, string pUserId, string pRemarks, string pRequestType)
          {
              int res;
              using (SqlConnection con = new SqlConnection(strcon))
              {
                  using (SqlCommand cmd = new SqlCommand(Procedures._Approve_ContInEditRequest))
                  {
                      con.Open();
                      cmd.Connection = con;
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@Request_Id", pRequestId);
                      cmd.Parameters.AddWithValue("@User_Id", pUserId);
                      cmd.Parameters.AddWithValue("@RequestType", pRequestType);
                      if (!String.IsNullOrEmpty(pRemarks)) cmd.Parameters.AddWithValue("@Remarks", pRemarks);
                      res = cmd.ExecuteNonQuery();
                  }
    
              }

              return res;
          }

        public IEnumerable<Cont_Main> GetContainerForInEditRequest(string ContNoLike)
        {
            List<Cont_Main> _list = new List<Cont_Main>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainerForEditRequest))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@GroupId", FromDate);
                    //cmd.Parameters.AddWithValue("@GroupId", ToDate);
                    cmd.Parameters.AddWithValue("@p_likecont", ContNoLike);


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Cont_Main _obj = new Cont_Main();
                            _obj.Cont_Id = Convert.ToInt64(rdr["Cont_Id"]);
                            _obj.Cont_No = Convert.ToString(rdr["Cont_No"]);
                            _obj.Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]);
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.YARD_ID = Convert.ToInt32(rdr["Yard_Id"]);

                            _obj.Cont_Size_Master = new Cont_Size_Master { Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]), Cont_Size = rdr["Cont_Size"].ToString() };
                            _obj.Yard_Master = new Yard_Master { Yard_Id = Convert.ToInt32(rdr["Yard_Id"]), Yard_Name = rdr["Yard_Name"].ToString() };
                            _obj.CustomerMaster = new CustomerMaster
                            {
                                CustomerID = Convert.ToInt32(rdr["CustomerID"]),
                                Customer_Name = rdr["Customer_Name"].ToString()
                            };

                            _obj.Cont_In = new Cont_In
                            {
                                Cont_InDate = Convert.ToDateTime((rdr["Cont_InDate"] == DBNull.Value) ? DateTime.MinValue : rdr["Cont_InDate"]),
                                Cont_Remarks = rdr["Cont_Remarks"].ToString()
                            };

                            _list.Add(_obj);

                        }

                    }
                   
                }
            }

            return _list;
        }




        public IEnumerable<Cont_In_Edit_Request> Get_RequestsLogs(string FromDate, string ToDate, string ContNo = null,
                                                                        string UserId = null, string RequestType = null, 
                                                                        string AppRejUserId = null)
        {
            List<Cont_In_Edit_Request> _list = new List<Cont_In_Edit_Request>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ChangRequestsLogs))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(FromDate)) cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    if (!string.IsNullOrEmpty(ToDate)) cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    if (!string.IsNullOrEmpty(ContNo)) cmd.Parameters.AddWithValue("@ContNo", ContNo);
                    if (!string.IsNullOrEmpty(UserId)) cmd.Parameters.AddWithValue("@UserId", UserId);
                    if (!string.IsNullOrEmpty(RequestType)) cmd.Parameters.AddWithValue("@RequestType", RequestType);
                    if (!string.IsNullOrEmpty(AppRejUserId)) cmd.Parameters.AddWithValue("@ApprRejUserId", AppRejUserId);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Cont_In_Edit_Request _obj = new Cont_In_Edit_Request();
                            _obj.Request_Id = (long)(rdr["Request_Id"]);
                            _obj.Request_Type = Convert.ToString(rdr["Request_Type_Desc"]);
                            _obj.Request_Date = Convert.ToDateTime(rdr["Request_Date"]);
                            _obj.Cancelled_Date = (rdr["Cancelled_Date"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cancelled_Date"].ToString());
                            _obj.Approved_Date = (rdr["Approved_Date"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Approved_Date"].ToString());
                            _obj.Cont_Id = (long)(rdr["Cont_Id"]);
                            _obj.Cont_No = Convert.ToString(rdr["Cont_No"]);
                            _obj.Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]);
                            _obj.Appr_Cancl_Remarks = Convert.ToString(rdr["Appr_Cancl_Remarks"]);
                            _obj.Flag = Convert.ToString(rdr["Flag"]);
                            _obj.Cont_Main = new Cont_Main
                            {
                                Cont_Id = Convert.ToInt32(rdr["Cont_Id"]),
                                Cont_No = Convert.ToString(rdr["Cont_No"]),
                                Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"])
                            };
                            _obj.Cont_Main.User_Master = new User_Master { User_Name = Convert.ToString(rdr["Entered_By"]) };
                            //_obj.Cont_Main.Cont_Size_Master = new Cont_Size_Master
                            //{
                            //    Contsize_Id = (int)rdr["Contsize_Id"],
                            //    Cont_Size = Convert.ToString(rdr["Cont_Size"])
                            //};

                            // _obj.Cont_Main.Cont_In = new Cont_In { Cont_InDate = Convert.ToDateTime(rdr["Cont_In_Date"]) };

                            _obj.Request_Description = Convert.ToString(rdr["Request_Description"]);

                            _obj.Requested_User_Master = new User_Master { User_Name = Convert.ToString(rdr["Requested_By"]) };

                            _obj.Approved_User_Master = new User_Master { User_Name = Convert.ToString(rdr["Approved_By"]) };
                            _obj.Cancelled_User_Master = new User_Master { User_Name = Convert.ToString(rdr["Cancelled_By"]) };


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
    }
}
