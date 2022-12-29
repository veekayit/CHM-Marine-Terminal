using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using CTS.BAL.Services;
using CTS.Models;
using CTS.DAL;
using CTS.DAL.Repositories;
using CTS.Models.ViewModels;

namespace CTS.BAL.Services
{
    public class EstimateService
    {
        private EstimateRepository _iEstimateRepository;

        public EstimateService()
        {
            _iEstimateRepository = new EstimateRepository();
        }


        public Int32 Save(Estimate_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iEstimateRepository.Save(strXML);
        }

        public Estimate_Master GetByEstimateNo(int PEstimateNo, int PFinYear)
        {
            long EstId = _iEstimateRepository.Get_EstimateId(PEstimateNo, PFinYear);
            return _iEstimateRepository.GetById(EstId);
        }

        public Estimate_Master GetById(long PEstimateId)
        {
            return _iEstimateRepository.GetById(PEstimateId);
        }

        public Estimate_Master GetContainerForEstimate(string PContNo, string PSerialNo = null)
        {
            return _iEstimateRepository. GetContainerForEstimate(  PContNo,   PSerialNo );
        }

        public long Get_NextEstimateNo(int PFinYear)
        {
            return _iEstimateRepository.Get_NextEstimateNo(PFinYear);
        }


        public long SaveImage(Estimate_Master mdl, string pLoginId = null,string pImageRemarks=null)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string xmlText = objConvertToXML.GetXMLForSave(mdl);
            long res = _iEstimateRepository.SaveImage(xmlText, pLoginId, pImageRemarks);
            return (res);
        }

        public Int32 DeleteEstimate_Images(string pContd, string pName)
        {
            return _iEstimateRepository.DeleteEstimate_Images(pContd, pName);
        }

        public IEnumerable<VMContainerImage> GetContainersForImageUpload(string pFromDate, string pToDate, string pCustomerID = null, string pYardId = null,
                                                               string pAllowBranches = null, string pYardIds = null)
        {
            return _iEstimateRepository.GetContainersForImageUpload(  pFromDate,   pToDate,  pCustomerID , pYardId , pAllowBranches , pYardIds );
        }

        public IEnumerable<Tbl_EstImages> GetEstimateImages(string pContID, string pFlag = null)
        {
            return _iEstimateRepository.GetEstimateImages(pContID, pFlag);
        }

        public int DeleteEstimateImages(int Id)
        {
            return _iEstimateRepository.DeleteEstimateImages(Id);
        }

        public int Save_EstimateImagsToTempTable(string PEstimateId, byte[] PImageBytes)
        {
            return _iEstimateRepository.Save_EstimateImagsToTempTable(PEstimateId, PImageBytes);
        }
        public int Delete_EstimateImagesFromTmptable(string Id)
        {
            return _iEstimateRepository.Delete_EstimateImagesFromTmptable(Id);

        }

        public long Get_EstimateId(int PEstimateNo, int PFinYear)
        {
            return _iEstimateRepository.Get_EstimateId(PEstimateNo, PFinYear);
        }
    }
}
