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
    public class GateMovementService
    {
        private GateMovementRepository _GateMovementRepository;

        public GateMovementService()
        {
            _GateMovementRepository = new GateMovementRepository();
        }


        public Cont_Main GetByID(int Id)
        {
            return _GateMovementRepository.GetByID(Id);
        }
        public long SaveGateIn(Cont_Main mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _GateMovementRepository.SaveGateIn(strXML);
        }

        public long SaveGateOut(Cont_Main mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _GateMovementRepository.SaveGateOut(strXML);
        }


        public long Save_BULKIN(BulkInImportList mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _GateMovementRepository.SaveGateOut(strXML);
        }
        public long Get_NewPassNo(string PType, string PYardId = null)
        {
            return _GateMovementRepository.Get_NewPassNo(PType, PYardId);
        }

        public string Get_NextERONo(string PCustId)
        {
            return _GateMovementRepository.Get_NextERONo(PCustId);
        }


        public Cont_Main Get_LatestContStatus(string PContNo, string PSerialNo=null)
        {
            return _GateMovementRepository.Get_LatestContStatus(PContNo, PSerialNo);

        }

        public int SaveHold(string pCont_Id = null, string pchkHoldVal = null, string pHRemarks = null)
        {
            return _GateMovementRepository.SaveHold(pCont_Id , pchkHoldVal, pHRemarks);
        }

        public int UpdateMovementType(string pCont_Id, string pMovementType)
        {
            return _GateMovementRepository.UpdateMovementType(pCont_Id, pMovementType);
        }

        public int UpdateContRemarks(string pCont_Id, string pRemarks = null, string pCargo = null, string pDestination = null, string pPOD = null)
        {
            return _GateMovementRepository.UpdateContRemarks(pCont_Id,  pRemarks , pCargo, pDestination ,pPOD);
        }
    }
}
