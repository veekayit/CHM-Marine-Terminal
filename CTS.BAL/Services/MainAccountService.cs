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
    public class MainAccountService
    {
         private MainAccountRepository  _iMainAccountRepository;

         public MainAccountService()
        {
            _iMainAccountRepository = new MainAccountRepository();
        }


        public Int32 Save(Main_Account_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iMainAccountRepository.Save(strXML);
        }

        public IEnumerable<Main_Account_Master> GetAll()
        {
            return _iMainAccountRepository.GetAll();
        }
        public IEnumerable<Main_Account_Master> GetAll(string namelike)
        {
            return _iMainAccountRepository.GetAll().Where(e => e.Customer_Name.Contains(namelike));
        }
    

        public Main_Account_Master GetByID(int Id)
        {
            return _iMainAccountRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iMainAccountRepository.Delete(Id);
        }
    }
}
