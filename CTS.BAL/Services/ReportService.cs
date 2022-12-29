using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CTS.BAL.Services;
using CTS.Models;
using CTS.DAL;
using CTS.DAL.Repositories;
using System.Data;

namespace CTS.BAL.Services
{
    public class ReportService
    {

        private ReportRepository _iReportRepository;

        public ReportService()
        {
            _iReportRepository = new ReportRepository();
        }


        public DataSet Get_EstimateRegister(string pFromDate = null, string pToDate = null, string pCustomerID = null)
        {
            return _iReportRepository.Get_EstimateRegister(pFromDate, pToDate, pCustomerID);
        }

        public DataSet Get_InOutRegister(string pFromDate = null, string pToDate = null, string pCustomerID = null, string pYardID = null,
                                       string pType = null, string pAllowBranches = null,
                                        string pContNo = null)
        {

            return _iReportRepository.Get_InOutRegister(pFromDate, pToDate, pCustomerID, pYardID, pType, pAllowBranches, pContNo);
        }


        public DataSet Get_ContainerList(string pCont_No = null, string pCustId = null, string pDoNo = null)
        {
            return _iReportRepository.Get_ContainerList(pCont_No, pCustId, pDoNo);
        }

        public DataSet Get_StockHold(string pCustomerID = null)
        {
            return _iReportRepository.Get_StockHold(pCustomerID);
        }

        public DataSet Get_InRegister(string pFromDate = null, string pToDate = null, string pCustomerID = null, string pYardID = null, string pAllowBranches = null)
        {
            return _iReportRepository.Get_InRegister(pFromDate, pToDate, pCustomerID);
        }

        public DataSet Get_DailyReportForCHM(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                                    string pYardID = null, string pMainAccIds = null, string pSearch = null)
        {
            return _iReportRepository.Get_DailyReportForCHM(pFromDate, pToDate, pCustomerID, pYardID, pMainAccIds, pSearch);
        }

        public DataSet Get_EROData_Empty(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                              string pYardID = null)
        {
            return _iReportRepository.Get_EROData_Empty(pFromDate, pToDate, pCustomerID, pYardID);
        }

        public DataSet Get_EROData_Export(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                             string pYardID = null)
        {
            return _iReportRepository.Get_EROData_Export(pFromDate, pToDate, pCustomerID, pYardID);
        }

        public DataSet Get_ContainersOnHold(string pFromDate = null, string pToDate = null, string pCustomerID = null,
                              string pYardID = null)
        {
            return _iReportRepository.Get_ContainersOnHold(pFromDate, pToDate, pCustomerID, pYardID);
        }
    }
}
