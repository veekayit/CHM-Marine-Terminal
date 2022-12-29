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
    public class GateMovementRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        public Cont_Main GetByID(int Id)
        {
            Cont_Main _obj = new Cont_Main();

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Container))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_ContId", Id);
                    cmd.CommandTimeout = 200;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Cont_Id = Convert.ToInt64(rdr["Cont_Id"]);
                            _obj.Cont_No = Convert.ToString(rdr["Cont_No"]);
                            _obj.Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]);
                            _obj.Cont_Construction = Convert.ToString(rdr["Cont_Construction"]);
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.Hold = Convert.ToBoolean(rdr["Hold"]);

                            _obj.csc_detail = Convert.ToString(rdr["csc_detail"]);
                            _obj.manufact_date = Convert.ToString(rdr["manufact_date"]);

                            _obj.Gross_Weight = Convert.ToString(rdr["Gross_Weight"]);
                            _obj.Tire_Weight = Convert.ToString(rdr["Tire_Weight"]);

                            _obj.Return_Box = Convert.ToBoolean(rdr["Return_Box"]);
                            _obj.JOB_NO = Convert.ToString(rdr["JOB_NO"]);
                            _obj.SR_NO = Convert.ToString(rdr["SR_NO"]);

                            _obj.Cont_Size_Master = new Cont_Size_Master { Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]), Cont_Size = rdr["Cont_Size"].ToString() };
                            _obj.Yard_Master = new Yard_Master { Yard_Id = Convert.ToInt32(rdr["Yard_Id"]) };
                            _obj.CustomerMaster = new CustomerMaster
                            {
                                CustomerID = Convert.ToInt32(rdr["CustomerID"]),
                                Customer_Name = rdr["Customer_Name"].ToString(),
                                Cust_code = rdr["Cust_code"].ToString(),
                                ManHourRate = Convert.ToDecimal(rdr["ManHourRate"])
                            };

                            _obj.Yard_Master = new Yard_Master
                           {
                               Yard_Id = Convert.ToInt32(rdr["Yard_Id"]),
                               Yard_Name = Convert.ToString(rdr["Yard_Name"])
                           };
                            _obj.Cont_In = new Cont_In
                            {
                                Cont_In_Id = (long)rdr["Cont_In_Id"],
                                Cont_Id = (long)rdr["Cont_Id"],
                                Vessel_Id = (rdr["Vessel_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Vessel_Id"].ToString()),
                                Vessel_Master = new Vessel_Master
                                {
                                    Vessel_Id = (rdr["Vessel_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["Vessel_Id"].ToString()),
                                    Vessel_Name = rdr["VMI_Vessel_Name"].ToString()
                                },

                                Cont_Voyage = rdr["Cont_Voyage"].ToString(),
                                Consignee_ID = (rdr["Consignee_ID"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Consignee_ID"].ToString()),

                                Cont_BLNo = rdr["Cont_BLNo"].ToString(),
                                Cont_BLDate = (rdr["Cont_BLDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cont_BLDate"].ToString()),
                                Cont_Cargo = rdr["Cont_Cargo"].ToString(),
                                Cont_Remark1 = rdr["Cont_Remark1"].ToString(),
                                Cont_Remark2 = rdr["Cont_Remark2"].ToString(),
                                Cont_InDate = Convert.ToDateTime(rdr["Cont_InDate"]),
                                Cont_Comodity = rdr["Cont_Comodity"].ToString(),
                                Cont_InPass = rdr["Cont_InPass"].ToString(),
                                Cont_InTime = rdr["Cont_InTime"].ToString(),
                                Cont_OutTime = Convert.ToDateTime(rdr["Cont_OutTime"]),
                                Cont_TrailerNo = rdr["Cont_TrailerNo"].ToString(),
                                Cont_DoNo = rdr["Cont_DoNo"].ToString(),
                                Cont_DoDate = (rdr["Cont_DoDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cont_DoDate"].ToString()),
                                Cont_DoValidity = (rdr["Cont_DoValidity"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cont_DoValidity"].ToString()),
                                Cont_Destuff = rdr["Cont_Destuff"].ToString(),
                                Cont_Shippername = rdr["Cont_Shippername"].ToString(),
                                Lift_Id = (rdr["Lift_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Lift_Id"].ToString()),
                                Yard_Id = (rdr["CI_Yard_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["CI_Yard_Id"].ToString()),
                                Bay_Id = (rdr["Bay_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Bay_Id"].ToString()),

                                Cont_Status = rdr["Cont_Status"].ToString(),

                                Transporter_Master = new Transporter_Master
                                {
                                    Transporter_ID = (rdr["Cont_TranporterID"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["Cont_TranporterID"].ToString()),
                                    Transporter_Name = rdr["In_Transporter_Name"].ToString()


                                },


                                Pos_LocationId = (rdr["Pos_LocationId"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Pos_LocationId"].ToString()),

                                Cont_Remarks = rdr["Cont_Remarks"].ToString(),
                                EmptyDeStuffing = rdr["EmptyDeStuffing"].ToString(),
                                In_Grade = rdr["In_Grade"].ToString(),


                                ERO_Date = (rdr["ERO_Date"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["ERO_Date"].ToString()),
                                ERO_No = rdr["ERO_No"].ToString()

                            };
                            _obj.Cont_Out = new Cont_Out
                            {
                                Cont_Out_Id = (long)rdr["Cont_Out_Id"],
                                Cont_Id = (long)rdr["Cont_Id"],
                                Vessel_Id = (rdr["CO_Vessel_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["CO_Vessel_Id"].ToString()),

                                Cont_Voyage = rdr["CO_Cont_Voyage"].ToString(),
                                CustomerID = (rdr["CO_CustomerID"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["CO_CustomerID"].ToString()),

                                Cont_OutDt = (rdr["Cont_OutDt"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cont_OutDt"].ToString()),
                                Con_Status = rdr["Con_Status"].ToString(),
                                Con_Stuffing = rdr["Con_Stuffing"].ToString(),
                                Cont_OutPass = rdr["Cont_OutPass"].ToString(),
                                Cont_InTime = (rdr["CO_Cont_InTime"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["CO_Cont_InTime"].ToString()),
                                Cont_OutTime = (rdr["CO_Cont_OutTime"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["CO_Cont_OutTime"].ToString()),
                                Cont_TrailerNo = rdr["CO_Cont_TrailerNo"].ToString(),

                                Cont_BookingID = (rdr["Cont_BookingID"] == DBNull.Value) ? (long?)null : (long)(rdr["Cont_BookingID"]),

                                Cont_ReleaseNo = rdr["Cont_ReleaseNo"].ToString(),
                                Cont_SealNo = rdr["Cont_SealNo"].ToString(),
                                Cont_DoNo = rdr["CO_Cont_DoNo"].ToString(),
                                Cont_Dodate = (rdr["CO_Cont_Dodate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["CO_Cont_Dodate"].ToString()),

                                Cont_GateInDate = (rdr["Cont_GateInDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cont_GateInDate"].ToString()),

                                Transporter_Master = new Transporter_Master
                                {
                                    Transporter_ID = (rdr["CO_TransporterID"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["CO_TransporterID"].ToString()),
                                    Transporter_Name = rdr["OT_Transporter_Name"].ToString()
                                },
                                TransporterID = (rdr["CO_TransporterID"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["CO_TransporterID"].ToString()),

                                Position_Location_Id = (rdr["Position_Location_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["Position_Location_Id"].ToString()),

                                //_ContOut_Prop.Modified_UserID = dt.Rows[0]["Modified_UserID"].ToString(),
                                YARD_ID = (rdr["YARD_ID"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["YARD_ID"].ToString()),
                                Driver_Cont_No = rdr["Driver_Cont_No"].ToString(),
                                EmptyExport = rdr["EmptyExport"].ToString(),
                                Booking_Master = new Booking_Master
                                {
                                    Booking_ID = (rdr["Cont_BookingID"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["Cont_BookingID"].ToString()),

                                    BookingNo = rdr["BookingNo"].ToString(),
                                },

                                Shipper_Name = rdr["Shipper_Name"].ToString(),
                                Cargo = rdr["Cargo"].ToString(),
                                //    rdrOut_Addl_Customer = rdr["Out_Addl_Customer"].ToString(),
                                Out_Remarks = rdr["Out_Remarks"].ToString(),
                                Movement_Id = (rdr["Movement_Id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(rdr["Movement_Id"].ToString()),

                                Movement_Master = new Movement_Master
                                {
                                    Movement_Id = (rdr["Movement_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["Movement_Id"].ToString()),
                                    Movement_Name = rdr["O_Movement_Name"].ToString(),
                                },

                                Vessel_Master = new Vessel_Master
                                {
                                    Vessel_Id = (rdr["CO_Vessel_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(rdr["CO_Vessel_Id"].ToString()),
                                    Vessel_Name = rdr["VMO_Vessel_Name"].ToString()
                                }


                            };



                        }
                    }
                }
            }
            return _obj;
        }

        public long SaveGateIn(string strXML)
        {
            long res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_GATEIN))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StrXML", strXML);
                    cmd.CommandTimeout = 200;

                    long.TryParse(cmd.ExecuteScalar().ToString(), out res);
                    return (res);

                }
            }


        }


        public long SaveGateOut(string strXML)
        {
            long res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_GATEOUT))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StrXML", strXML);
                    cmd.CommandTimeout = 200;

                    long.TryParse(cmd.ExecuteScalar().ToString(), out res);
                    return (res);

                }
            }


        }


        public long Save_BULKIN(string strXML)
        {
            long res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_GATEOUT))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StrXML", strXML);


                    long.TryParse(cmd.ExecuteScalar().ToString(), out res);
                    return (res);

                }
            }
        }

        public long Get_NewPassNo(string PType, string PYardId = null)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._GetNewPassNo))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", PType);
                    if (!string.IsNullOrEmpty(PYardId)) cmd.Parameters.AddWithValue("@Yardid", PYardId);
                    long passno = 0;
                    passno = Convert.ToInt64(cmd.ExecuteScalar());
                    return (passno);
                }
            }
        }


        public string Get_NextERONo(string PCustId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("select dbo.Get_Next_ERo_NO(@CustomerId)"))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", PCustId);

                    string ERONo = string.Empty;
                    ERONo = Convert.ToString(cmd.ExecuteScalar());

                    return (ERONo);
                }
            }
        }


        public Cont_Main Get_LatestContStatus(string PContNo, string PSerialNo = null)
        {
            Cont_Main _obj = new Cont_Main();

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_LatestCont))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Cont_No", PContNo);
                    if (!string.IsNullOrEmpty(PSerialNo)) cmd.Parameters.AddWithValue("@Sl_No", PSerialNo);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Cont_Id = Convert.ToInt64(rdr["Cont_Id"]);
                            _obj.Cont_No = Convert.ToString(rdr["Cont_No"]);
                            _obj.Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]);
                            _obj.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            _obj.Hold = Convert.ToBoolean(rdr["Hold"]);
                            _obj.Image_Remarks = Convert.ToString(rdr["Image_Remarks"]);

                            _obj.Cont_Size_Master = new Cont_Size_Master { Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]), Cont_Size = rdr["Cont_Size"].ToString() };
                            _obj.Yard_Master = new Yard_Master { Yard_Id = Convert.ToInt32(rdr["Yard_Id"]) };
                            _obj.CustomerMaster = new CustomerMaster
                            {
                                CustomerID = Convert.ToInt32(rdr["CustomerID"]),
                                Customer_Name = rdr["Customer_Name"].ToString(),
                                Cust_code = rdr["Cust_code"].ToString()
                            };

                            _obj.Cont_In = new Cont_In { Cont_InDate = Convert.ToDateTime((rdr["Cont_InDate"] == DBNull.Value) ? DateTime.MinValue : rdr["Cont_InDate"]) };
                            _obj.Cont_Out = new Cont_Out { Cont_Out_Id = (long)rdr["Cont_Out_Id"], Cont_OutDt = Convert.ToDateTime((rdr["Cont_OutDt"] == DBNull.Value) ? DateTime.MinValue : rdr["Cont_OutDt"]) };



                        }
                    }
                }
            }
            return _obj;
        }


        public int SaveHold(string pCont_Id = null, string pchkHoldVal = null, string pHRemarks = null)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Cont_Hold))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(pCont_Id)) cmd.Parameters.AddWithValue("@Cont_Id", pCont_Id);
                    if (!string.IsNullOrEmpty(pchkHoldVal)) cmd.Parameters.AddWithValue("@chkHoldVal", pchkHoldVal);
                    if (!string.IsNullOrEmpty(pHRemarks)) cmd.Parameters.AddWithValue("@HRemarks", pHRemarks);

                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;

        }

        public int UpdateMovementType(string pCont_Id, string pMovementType)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Update_Cont_In_MovementType))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cont_Id", pCont_Id);
                    cmd.Parameters.AddWithValue("@Movement_Type", pMovementType);


                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }

        public int UpdateContRemarks(string pCont_Id, string pRemarks = null, string pCargo = null, string pDestination = null, string pPOD = null)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Update_Cont_Remarks))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Cont_Id", pCont_Id);
                    if (!string.IsNullOrEmpty(pRemarks)) cmd.Parameters.AddWithValue("@Cont_Remarks", pRemarks);
                    if (!string.IsNullOrEmpty(pCargo)) cmd.Parameters.AddWithValue("@Cont_Cargo", pCargo);
                    if (!string.IsNullOrEmpty(pDestination)) cmd.Parameters.AddWithValue("@Destination", pDestination);
                    if (!string.IsNullOrEmpty(pPOD)) cmd.Parameters.AddWithValue("@POD", pPOD);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }




    }
}
