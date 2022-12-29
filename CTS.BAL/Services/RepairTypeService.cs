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
   public class RepairTypeService
    {
         private RepairTypeRepository  _iRepairTypeRepository;

         public RepairTypeService()
        {
            _iRepairTypeRepository = new RepairTypeRepository();
        }

         public Int32 Save(Repair_Type_Master  mdl)
         {
             ConvertToXML objConvertToXML = new ConvertToXML();
             string strXML = objConvertToXML.GetXMLForSave(mdl);
             return _iRepairTypeRepository.Save(strXML);
         }
         public int Delete(int Id)
         {
             return _iRepairTypeRepository.Delete(Id);
         }

        public IEnumerable<Repair_Type_Master> GetAll(string PDescId, string PSearch=null)
        {
            return _iRepairTypeRepository.GetAll(PDescId, PSearch);
        }
    }
}
