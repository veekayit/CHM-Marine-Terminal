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
    public class CurrencyService
    {
         private CurrencyRepository  _iCurrencyRepository;

         public CurrencyService()
        {
            _iCurrencyRepository = new CurrencyRepository();
        }


        public Int32 Save(Currency_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iCurrencyRepository.Save(strXML);
        }

        public IEnumerable<Currency_Master> GetAll()
        {
            return _iCurrencyRepository.GetAll();
        }
        public IEnumerable<Currency_Master> GetAll(string namelike)
        {
            return _iCurrencyRepository.GetAll().Where(e => e.Currency_Name.Contains(namelike));
        }
    

        public Currency_Master GetByID(int Id)
        {
            return _iCurrencyRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iCurrencyRepository.Delete(Id);
        }
    }
}
