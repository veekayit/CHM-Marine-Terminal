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
    public class DamageRatesService
    {
        private DamageRatesRepository _iDamageRatesRepository;

         public DamageRatesService()
        {
            _iDamageRatesRepository = new DamageRatesRepository();
        }


        public Int32 Save(Damage_Code_Rates mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iDamageRatesRepository.Save(strXML);
        }

        public IEnumerable<Damage_Code_Rates> GetAll()
        {
            return _iDamageRatesRepository.GetAll();
        }

        public int Delete(int Id)
        {
            return _iDamageRatesRepository.Delete(Id);
        }
    }
}
