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
    public class CustomerService
    {
          private CustomerRepository  _iCustomerRepository;

          public CustomerService()
        {
            _iCustomerRepository = new CustomerRepository();
        }


        public Int32 Save(CustomerMaster mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iCustomerRepository.Save(strXML);
        }

        public IEnumerable<CustomerMaster> GetAll()
        {
            return _iCustomerRepository.GetAll();
        }
        public IEnumerable<CustomerMaster> GetAll(string namelike)
        {
            return _iCustomerRepository.GetAll().Where(e => e.Customer_Name.ToLower().StartsWith(namelike.ToLower()));
        }
    

        public CustomerMaster GetByID(int Id)
        {
            return _iCustomerRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iCustomerRepository.Delete(Id);
        }

        public IEnumerable<CustomerMaster> Get_CompanyCustomers(string PCustomerId = null, string PCustomerName = null, string pMainAccids = null)
        {
            return _iCustomerRepository.Get_CompanyCustomers(PCustomerId,PCustomerName, pMainAccids);
        }
    }
}
