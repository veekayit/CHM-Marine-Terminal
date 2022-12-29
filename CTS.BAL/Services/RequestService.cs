using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CTS.BAL.Services;
using CTS.Models;
using CTS.DAL;
using CTS.DAL.Repositories;

namespace CTS.BAL.Services
{
    public class RequestService
    {
        
        private RequestRepository  _iRequestRepository;

        public RequestService()
        {
            _iRequestRepository = new RequestRepository();
        }

        public Int32 Save_InEditRequest(Cont_In_Edit_Request mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iRequestRepository.Save_InEditRequest(strXML);
        }
        public IEnumerable<Cont_Main> GetContainerForInEditRequest( string ContNoLike)
        {
            return _iRequestRepository.GetContainerForInEditRequest( ContNoLike);
        }

        public int ApproveContInEditRequest(string pRequestId, string pUserId, string pRemarks, string pRequestType)
        {
              return _iRequestRepository.ApproveContInEditRequest( pRequestId,  pUserId,  pRemarks,  pRequestType);
        }
        public int CancelContInEditRequest(string pRequestId, string pUserId, string pRemarks)
        {
            return _iRequestRepository.CancelContInEditRequest(  pRequestId,   pUserId,   pRemarks);
        }
        public IEnumerable<Cont_In_Edit_Request> GetAllINRequests(string FromDate = null, string ToDate = null, string ContNo = null,
                                                                    string UserId = null, string RequestType = null)
        {
            return _iRequestRepository.GetAllINRequests(  FromDate , ToDate , ContNo,UserId , RequestType);
        }

        public IEnumerable<Cont_In_Edit_Request> Get_RequestsLogs(string FromDate, string ToDate, string ContNo = null,
                                                                      string UserId = null, string RequestType = null,
                                                                      string AppRejUserId = null)
        {
            return _iRequestRepository.Get_RequestsLogs(  FromDate,   ToDate,   ContNo , UserId ,RequestType ,AppRejUserId);
        }
    }
}
