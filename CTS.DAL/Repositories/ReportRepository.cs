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
    public class ReportRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;



        public DataSet Get_EstimateRegister(string pFromDate = null, string pToDate = null, string pCustomerID = null)
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_EstimateRegister))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                    if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@customerid", pCustomerID);



                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }



                }
            }

        }

        public DataSet Get_InOutRegister(string pFromDate = null, string pToDate = null, string pCustomerID = null, string pYardID = null,
                                        string pType = null, string pAllowBranches = null,
                                         string pContNo = null)
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_InoutDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                    if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                    if (!string.IsNullOrEmpty(pContNo)) cmd.Parameters.AddWithValue("@Cont_No", pContNo);

                    if (!string.IsNullOrEmpty(pType)) cmd.Parameters.AddWithValue("@Type", pType);
                    if (!string.IsNullOrEmpty(pAllowBranches)) cmd.Parameters.AddWithValue("@AllowBranchIds", pAllowBranches);
                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@customerid", pCustomerID);
                    if (!string.IsNullOrEmpty(pYardID)) cmd.Parameters.AddWithValue("@YardId", pYardID);


                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }

                     

                }
            }

        }



        public DataSet Get_ContainerList(string pCont_No = null, string pCustId = null, string pDoNo = null)
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Container_List))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pCont_No)) cmd.Parameters.AddWithValue("@p_ContNo", pCont_No);
                    if (!string.IsNullOrEmpty(pCustId)) cmd.Parameters.AddWithValue("@p_CustomerId", pCustId);
                    if (!string.IsNullOrEmpty(pDoNo)) cmd.Parameters.AddWithValue("@P_DoNo", pDoNo);

                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }



                }
            }
        }


        public DataSet Get_StockHold(string pCustomerID = null)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_StockHold))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@custid", pCustomerID);
                    

                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }



                }
            }
        }


        public DataSet  Get_InRegister(string pFromDate = null, string pToDate = null, string pCustomerID = null, string pYardID = null, string pAllowBranches = null)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_InDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                    if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@customerid", pCustomerID);
                  
                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }

                }
            }
        }


        public DataSet Get_DailyReportForCHM(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                                     string pYardID = null, string pMainAccIds = null, string pSearch = null)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_DailyReport_CHM))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                    if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@customerid", pCustomerID);
                    if (!string.IsNullOrEmpty(pSearch)) cmd.Parameters.AddWithValue("@Search", pSearch);
                    if (!string.IsNullOrEmpty(pMainAccIds)) cmd.Parameters.AddWithValue("@Main_Account_Ids", "," + pMainAccIds + ",");

                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }

                }
            }
        }


         public DataSet Get_EROData_Empty(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                                string pYardID = null)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ERO_Data_Empty))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                    if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                    if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@customerid", pCustomerID);
      

                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                    {

                        DataSet dsres = new DataSet();
                        dbDataAdapter.Fill(dsres);
                        return dsres;
                    }

                }
            }
        }

         public DataSet Get_EROData_Export(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                               string pYardID = null)
         {
             using (SqlConnection con = new SqlConnection(strcon))
             {
                 using (SqlCommand cmd = new SqlCommand(Procedures._Get_ERO_Data_Export))
                 {
                     con.Open();
                     cmd.Connection = con;
                     cmd.CommandType = CommandType.StoredProcedure;


                     if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                     if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                     if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@customerid", pCustomerID);


                     using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                     {

                         DataSet dsres = new DataSet();
                         dbDataAdapter.Fill(dsres);
                         return dsres;
                     }

                 }
             }
         }


         public DataSet Get_ContainersOnHold(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                               string pYardID = null)
         {
             using (SqlConnection con = new SqlConnection(strcon))
             {
                 using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainersOnHold))
                 {
                     con.Open();
                     cmd.Connection = con;
                     cmd.CommandType = CommandType.StoredProcedure;


                     if (!string.IsNullOrEmpty(pFromDate)) cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                     if (!string.IsNullOrEmpty(pToDate)) cmd.Parameters.AddWithValue("@ToDate", pToDate);
                     if (!string.IsNullOrEmpty(pCustomerID)) cmd.Parameters.AddWithValue("@custid", pCustomerID);


                     using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter(cmd))
                     {

                         DataSet dsres = new DataSet();
                         dbDataAdapter.Fill(dsres);
                         return dsres;
                     }

                 }
             }
         }
        
    }
}
