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
    public class RPRRepairCodeService
    {
         private RPRRepairCodeRepository _iRepairCodeRepository;

         public RPRRepairCodeService()
        {
            _iRepairCodeRepository = new RPRRepairCodeRepository();
        }

         public IEnumerable<RPR_RepairCode> GetAll()
         {
             return _iRepairCodeRepository.GetAll();
         }
         public IEnumerable<RPR_RepairCode> GetAll(string PSearch=null)
         {
             return _iRepairCodeRepository.GetAll().Where(e=>e.Repair_Desc.ToLower().StartsWith(PSearch.ToLower()));
         }
    }
}
