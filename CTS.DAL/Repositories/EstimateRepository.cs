using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CTS.Models;
using CTS.Models.ViewModels;

namespace CTS.DAL.Repositories
{
    public class EstimateRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Estimate_XML_NEW))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StrXML", strXML);
                    cmd.CommandTimeout = 200;
                    res = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }

            return res;
        }

        public Estimate_Master GetById(long PEstimateId)
        {
            Estimate_Master obj = new Estimate_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._GetEstimateEntry))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EstimateId", PEstimateId);
                    cmd.CommandTimeout = 200;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        #region master
                        while (rdr.Read())
                        {
                            obj.Estimate_Id = Convert.ToInt64(rdr["Estimate_Id"].ToString());
                            obj.Estimate_Date = Convert.ToDateTime(rdr["Estimate_Date"]);
                            obj.Estimate_No = Convert.ToInt64(rdr["Estimate_No"].ToString());
                            obj.Fin_Year = Convert.ToInt16(rdr["Fin_Year"].ToString());
                            obj.Cont_Id = Convert.ToInt32(rdr["Cont_Id"]);
                            obj.Actual_Estimate_No = rdr["Actual_Estimate_No"].ToString();

                            obj.Labour_Amount = (rdr["Labour_Amount"] == DBNull.Value) ? 0 : (decimal)(rdr["Labour_Amount"]);
                            obj.Material_Amount = (rdr["Material_Amount"] == DBNull.Value) ? 0 : (decimal)(rdr["Material_Amount"]);
                            obj.Lumpsum_Amount = (rdr["Lumpsum_Amount"] == DBNull.Value) ? 0 : (decimal)(rdr["Lumpsum_Amount"]);
                            obj.Total_Amount = (decimal)rdr["Total_Amount"];
                            obj.Net_Amount = (decimal)rdr["Net_Amount"];

                            obj.Bill_Year = (int)rdr["Bill_Year"];



                            obj.Remarks = rdr["Remarks"].ToString();

                            obj.Cont_Main = new Cont_Main
                            {
                                Cont_Id = Convert.ToInt32(rdr["Cont_Id"]),
                                Cont_No = Convert.ToString(rdr["Cont_No"]),
                                YARD_ID = Convert.ToInt32(rdr["YARD_ID"]),
                                Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]),

                                Cont_Size_Master = new Cont_Size_Master
                                {
                                    Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]),
                                    Cont_Size = Convert.ToString(rdr["Cont_Size"])
                                },




                                Cont_In = new Cont_In
                                {
                                    Cont_InDate = Convert.ToDateTime(rdr["Cont_InDate"]),
                                    EmptyDeStuffing = Convert.ToString(rdr["EmptyDestuffing"])
                                }
                            };

                            obj.Cont_Main.CustomerMaster = new CustomerMaster
                            {
                                CustomerID = Convert.ToInt32(rdr["CustomerID"]),
                                Customer_Name = Convert.ToString(rdr["Customer_Name"]),
                                ManHourRate = Convert.ToDecimal(rdr["ManHourRate"]),
                                Main_Account_Id = Convert.ToInt32(rdr["Main_Account_Id"]),

                                Main_Account_Master = new Main_Account_Master
                                {
                                    Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"])
                                },

                                Currency_Master = new Currency_Master
                                {
                                    Currency_Name = Convert.ToString(rdr["Currency_Name"])
                                },


                            };


                        }
                        #endregion

                        #region details
                        rdr.NextResult();
                        int slno = 0;
                        List<Estimate_Details> _list = new List<Estimate_Details>();
                        while (rdr.Read())
                        {
                            Estimate_Details _Item = new Estimate_Details();
                            _Item.Estimate_Details_Id = (Int64)rdr["Estimate_Details_Id"];
                            _Item.Location_Master = new Location_Master { Location_Id = (Int32)rdr["Location_Id"], Location_Name = rdr["Location_Name"].ToString() };
                            if (_Item.Location_Master.Location_Name != "-")
                            {


                                _Item.Location_Description = new Location_Description { Desc_Id = (long)rdr["Desc_Id"], Descriptions = rdr["Descriptions"].ToString() };
                                //_Item.Repair_Type_Master = new Repair_Type_Master { Repair_Type_Id = (Int32)rdr["Repair_Type_Id"], Repair_Type = rdr["Repair_Type"].ToString() };

                                _Item.Damage_Rate_Id = (long)rdr["Damage_Rate_Id"];
                                _Item.Damage_Code_Rates = new Damage_Code_Rates
                                {
                                    Damage_Rate_Id = (long)rdr["Damage_Rate_Id"],
                                    Repair_Type_Master = new Repair_Type_Master
                                    {
                                        Repair_Type_Id = (int)rdr["Repair_Type_Id"],
                                        Repair_Type = rdr["Repair_Type"].ToString()
                                    }
                                };
                                _Item.Damage_Code_Master = new Damage_Code_Master
                                {
                                    Damage_Id = (long)rdr["Damage_Id"],
                                    Damage_Code = rdr["Damage_Code"].ToString()

                                };
                            }

                            _Item.Account_Type = new Account_Type { Account_Type_Id = (Int32)rdr["Account_Type_Id"], Account_TypeName = rdr["Account_Type"].ToString() };
                            _Item.Length = (decimal)rdr["Length"];
                            _Item.Width = (decimal)rdr["Width"];
                            _Item.Hours = (decimal)rdr["Hours"];
                            _Item.Labour_Cost = (rdr["Labour_Cost"] == DBNull.Value) ? 0 : (decimal)(rdr["Labour_Cost"]);
                            _Item.Material_Cost = (rdr["Material_Cost"] == DBNull.Value) ? 0 : (decimal)(rdr["Material_Cost"]);
                            _Item.Lumpsum_Cost = (rdr["Lumpsum_Cost"] == DBNull.Value) ? 0 : (decimal)(rdr["Lumpsum_Cost"]);

                            _Item.Qty = (Int32)rdr["Qty"];

                            _Item.Total_Cost = (decimal)rdr["Total_Cost"];

                            _Item.AllParticulars = rdr["AllParticulars"].ToString();

                            _Item.Location_Id = (Int32)rdr["Location_Id"];
                            if (_Item.Location_Master.Location_Name != "-")
                            {
                                _Item.Desc_Id = (long)rdr["Desc_Id"];
                                _Item.Repair_Type_Id = (int)rdr["Repair_Type_Id"];
                                _Item.Damage_Id = (long)rdr["Damage_Id"];
                            }
                            _Item.Account_Type_Id = (Int32)rdr["Account_Type_Id"];

                            if (_Item.Location_Master.Location_Name != "-")
                            {
                                _Item.Slab_Hours = (decimal)rdr["Slab_Hours"];
                                _Item.Slab_Material_Cost = (decimal)rdr["Slab_Material_Cost"];
                                _Item.Slab_Lumpsum_Cost = (rdr["Slab_Lumpsum_Cost"] == DBNull.Value) ? 0 : (decimal)(rdr["Slab_Lumpsum_Cost"]);
                            }
                            else
                            {
                                _Item.Slab_Hours = 0;
                                _Item.Slab_Material_Cost = 0;
                                _Item.Slab_Lumpsum_Cost = 0;
                            }

                            _Item.SlNo = ++slno;
                            _Item.FLag = "S";
                            _list.Add(_Item);

                        }
                        obj.EstimateDetails = _list;
                        #endregion
                    }

                }
            }


            return obj;
        }

        #endregion

        public Estimate_Master GetContainerForEstimate(string PContNo, string PSerialNo = null)
        {
            Estimate_Master _obj = new Estimate_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_SingleContainer_ForEstimate))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cont_No", PContNo);
                    if (!string.IsNullOrEmpty(PSerialNo)) cmd.Parameters.AddWithValue("@SerialNo", PSerialNo);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Estimate_Id = (rdr["Estimate_Id"] == DBNull.Value) ? 0 : Convert.ToInt64(rdr["Estimate_Id"].ToString());
                            _obj.Estimate_No = (rdr["Estimate_No"] == DBNull.Value) ? 0 : Convert.ToInt64(rdr["Estimate_No"].ToString());
                            _obj.Fin_Year = (rdr["Fin_Year"] == DBNull.Value) ? 0 : Convert.ToInt16(rdr["Fin_Year"].ToString());
                            _obj.Cont_Id = Convert.ToInt32(rdr["Cont_Id"]);
                            _obj.Cont_Main = new Cont_Main
                            {
                                Cont_Id = Convert.ToInt32(rdr["Cont_Id"]),
                                Cont_No = Convert.ToString(rdr["Cont_No"]),
                                YARD_ID = Convert.ToInt32(rdr["YARD_ID"]),
                                Cont_Serial = Convert.ToInt32(rdr["Cont_Serial"]),

                                Image_Remarks = Convert.ToString(rdr["Image_Remarks"]),

                                Cont_Size_Master = new Cont_Size_Master
                                {
                                    Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]),
                                    Cont_Size = Convert.ToString(rdr["Cont_Size"])
                                },


                                Cont_Out = new Cont_Out
                                {
                                    Cont_OutDt = (rdr["Cont_OutDt"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["Cont_OutDt"].ToString())
                                },


                                Cont_In = new Cont_In
                                {
                                    Cont_InDate = Convert.ToDateTime(rdr["Cont_InDate"]),
                                    EmptyDeStuffing = Convert.ToString(rdr["EmptyDestuffing"])
                                }
                            };

                            _obj.Cont_Main.CustomerMaster = new CustomerMaster
                            {
                                CustomerID = Convert.ToInt32(rdr["CustomerID"]),
                                Customer_Name = Convert.ToString(rdr["Customer_Name"]),
                                ManHourRate = Convert.ToDecimal(rdr["ManHourRate"]),
                                Main_Account_Id = Convert.ToInt32(rdr["Main_Account_Id"]),


                                Currency_Master = new Currency_Master
                                {
                                    Currency_Name = Convert.ToString(rdr["Currency_Name"])
                                },

                                Main_Account_Master = new Main_Account_Master
                                {
                                    CustomerID = Convert.ToInt32(rdr["Main_Account_Id"]),
                                    Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"])
                                }


                            };


                        }
                    }
                }
            }


            return _obj;
        }


        public long Get_NextEstimateNo(int PFinYear)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_NextEstimateNo))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fin_Year", PFinYear);

                    long passno = 0;
                    passno = Convert.ToInt64(cmd.ExecuteScalar());
                    return (passno);
                }
            }
        }



        public long SaveImage(string strXML, string pLoginId = null, string pImageRemarks = null)
        {

            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._SaveEstimate_Images))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StrXML", strXML);
                    cmd.Parameters.AddWithValue("@CreatedBy", pLoginId);
                    if (!string.IsNullOrEmpty(pImageRemarks)) cmd.Parameters.AddWithValue("@ImageRemarks", pImageRemarks);
                    res = cmd.ExecuteNonQuery();

                }
            }

            return res;

        }

        public Int32 DeleteEstimate_Images(string pContd, string pName)
        {

            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._DelEstimate_ImageByName))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Contid", pContd);
                    cmd.Parameters.AddWithValue("@name", pName);
                    res = cmd.ExecuteNonQuery();
                }
            }

            return res;

        }


        public IEnumerable<VMContainerImage> GetContainersForImageUpload(string pFromDate, string pToDate, string pCustomerID = null, string pYardId = null,
                                                                string pAllowBranches = null, string pYardIds = null)
        {
            List<VMContainerImage> _list = new List<VMContainerImage>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainersForEstimate_Image))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@date", pFromDate);
                    cmd.Parameters.AddWithValue("@ToDate", pToDate);
                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@custid", pCustomerID);
                    if (!string.IsNullOrEmpty(pYardId)) cmd.Parameters.AddWithValue("@yardid", pYardId);


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            VMContainerImage _obj = new VMContainerImage();
                            _obj.Cont_Main = new Cont_Main
                            {
                                Cont_Id = (long)(rdr["Cont_Id"]),
                                Cont_No = Convert.ToString(rdr["Container_No"]),
                                Cont_Size_Master = new Cont_Size_Master { Cont_Size = Convert.ToString(rdr["Size"]) },
                                CustomerMaster = new CustomerMaster { Customer_Name = Convert.ToString(rdr["Customer_Name"]) }
                            };




                            _obj.Estimate_Id = (rdr["Estimate_Id"] == DBNull.Value) ? (long?)null : (long)rdr["Estimate_Id"];
                            _obj.Estimate_No = (rdr["Estimate_No"] == DBNull.Value) ? (long?)null : (long)rdr["Estimate_No"];
                            _obj.Estimate_Date = (rdr["ESTIMATE DATE"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(rdr["ESTIMATE DATE"].ToString());





                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }



        public IEnumerable<Tbl_EstImages> GetEstimateImages(string pContID, string pFlag = null)
        {
            List<Tbl_EstImages> _list = new List<Tbl_EstImages>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._GetEstImages))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", pContID);
                    cmd.Parameters.AddWithValue("@Flag", pFlag);

                    SqlDataReader rdr = cmd.ExecuteReader();



                    while (rdr.Read())
                    {
                        Tbl_EstImages _obj = new Tbl_EstImages();
                        _obj.ImageId = Convert.ToInt32(rdr["ImageId"]);
                        _obj.EstImage = Convert.ToString(rdr["EstImage"]);
                        _obj.Est_Flag = (bool)(rdr["Est_Flag"]);
                        _obj.File_Names = Convert.ToString(rdr["File_Names"]);



                        _list.Add(_obj);
                    }
                }
            }

            return _list;
        }


        public int DeleteEstimateImages(int Id)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._DelEstimate_Image))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }

        public int Save_EstimateImagsToTempTable(string PEstimateId, byte[] PImageBytes)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_EstimateImagesToTmpTbl))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Estimate_Id", PEstimateId);
                    cmd.Parameters.AddWithValue("@ContImage", PImageBytes);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }

        public int Delete_EstimateImagesFromTmptable(string Id)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Delete_EstimateImagesFromTmpTable))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Id);

                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }



        public long Get_EstimateId(int PEstimateNo, int PFinYear)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._GetEstimateId))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EstimateNo", PEstimateNo);
                    cmd.Parameters.AddWithValue("@FinYear", PFinYear);


                    long res = 0;
                    res = (long)(cmd.ExecuteScalar());
                    return (res);
                }
            }
        }
    }
}
