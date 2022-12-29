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
    public class LocationService
    {

        private LocationRepository _iLocationRepository;

          public LocationService()
        {
            _iLocationRepository = new LocationRepository();
        }

          public Int32 Save(Location_Master mdl)
          {
              ConvertToXML objConvertToXML = new ConvertToXML();
              string strXML = objConvertToXML.GetXMLForSave(mdl);
              return _iLocationRepository.Save(strXML);
          }
          public int Delete(int Id)
          {
              return _iLocationRepository.Delete(Id);
          }
        public IEnumerable<Location_Master> GetAll()
        {
            return _iLocationRepository.GetAll();
        }

        public IEnumerable<Location_Master> GetAll(string PMainAccId, string PSearch=null)
        {
            return _iLocationRepository.GetAll().Where(e =>e.Main_Account_Id==Convert.ToInt32( PMainAccId)  &&  e.Location_Name.ToLower().StartsWith(PSearch.ToLower())).ToList();
        }

        public IEnumerable<Location_Master> GetAll(int PClientGroupId, string PSearch = null)
        {
            return _iLocationRepository.GetAll().Where(e => e.Client_Group_Id ==  PClientGroupId && e.Location_Name.ToLower().StartsWith(PSearch.ToLower())).ToList();
        }
    }
}
