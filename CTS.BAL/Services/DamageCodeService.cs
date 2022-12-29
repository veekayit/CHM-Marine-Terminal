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
    public class DamageCodeService
    {
        private DamageCodeRepository _iDamageCodeRepository;

        public DamageCodeService()
        {
            _iDamageCodeRepository = new DamageCodeRepository();
        }

        public Int32 Save(Damage_Code_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iDamageCodeRepository.Save(strXML);
        }
        public int Delete(int Id)
        {
            return _iDamageCodeRepository.Delete(Id);
        }
        public IEnumerable<Damage_Code_Master> GetAll(string PLocDescId, string PSearch = null)
        {
            return _iDamageCodeRepository.GetAll(PLocDescId, PSearch);
        }
        public int UpdateDamageCodeRates(string DamageRateId, string Desc, string Hrs = "", string MatAmt = "", string LumAmt = "", string LabrRate = "")
        {
            return _iDamageCodeRepository.UpdateDamageCodeRates(DamageRateId, Desc, Hrs, MatAmt, LumAmt, LabrRate); 
        }
    }
}
