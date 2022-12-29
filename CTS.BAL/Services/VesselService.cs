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
   public  class VesselService
    {
         private VesselRepository  _iVesselRepository;

        public VesselService()
        {
            _iVesselRepository = new VesselRepository();
        }


        public Int32 Save(Vessel_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iVesselRepository.Save(strXML);
        }

        public IEnumerable<Vessel_Master> GetAll()
        {
            return _iVesselRepository.GetAll();
        }
        public IEnumerable<Vessel_Master> GetAll(string namelike)
        {
            return _iVesselRepository.GetAll().Where(e => e.Vessel_Name.ToLower().StartsWith(namelike.ToLower()));
        }
    

        public Vessel_Master GetByID(int Id)
        {
            return _iVesselRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iVesselRepository.Delete(Id);
        }
    }
}
