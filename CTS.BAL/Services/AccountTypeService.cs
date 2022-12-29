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
    public class AccountTypeService
    {
        private AccountTypeRepository _iAccountTypeRepository;

         public AccountTypeService()
        {
            _iAccountTypeRepository = new AccountTypeRepository();
        }

         public IEnumerable<Account_Type> GetAll()
         {
             return _iAccountTypeRepository.GetAll();
         }
         public IEnumerable<Account_Type> GetAll(string PSearch = null)
         {
             return _iAccountTypeRepository.GetAll().Where(e => e.Account_TypeName.ToLower().StartsWith(PSearch.ToLower()));
         }
    }
}
