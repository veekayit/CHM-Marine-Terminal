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
    public class RPRDamageCodeService
    {
        private RPRDamageCodeRepository _iRPRDamageCodeRepository;

         public RPRDamageCodeService()
        {
            _iRPRDamageCodeRepository = new RPRDamageCodeRepository();
        }

         public IEnumerable<RPR_DamageCode> GetAll()
         {
             return _iRPRDamageCodeRepository.GetAll();
         }
         public IEnumerable<RPR_DamageCode> GetAll(string PSearch = null)
         {
             return _iRPRDamageCodeRepository.GetAll().Where(e => e.Damage_Desc.ToLower().StartsWith(PSearch.ToLower()));
         }
    }
}
