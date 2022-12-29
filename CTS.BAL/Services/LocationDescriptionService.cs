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
    public class LocationDescriptionService
    {
           private LocationDescriptionRepository  _iLocationDescriptionRepository;

        public LocationDescriptionService()
        {
            _iLocationDescriptionRepository = new LocationDescriptionRepository();
        }

        public Int32 Save(Location_Description mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iLocationDescriptionRepository.Save(strXML);
        }

        public int Delete(int Id)
        {
            return _iLocationDescriptionRepository.Delete(Id);
        }
     

        public IEnumerable<Location_Description> GetAll(string PLocationId, string PSearch=null)
        {
            return _iLocationDescriptionRepository.GetAll(PLocationId, PSearch);
        }
    }
}
