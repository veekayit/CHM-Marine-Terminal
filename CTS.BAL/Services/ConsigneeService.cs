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
    public class ConsigneeService
    {
         private ConsigneeRepository  _iConsigneeRepository;

        public ConsigneeService()
        {
            _iConsigneeRepository = new ConsigneeRepository();
        }


        public Int32 Save(Consignee_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iConsigneeRepository.Save(strXML);
        }

        public IEnumerable<Consignee_Master> GetAll()
        {
            return _iConsigneeRepository.GetAll();
        }
        public IEnumerable<Consignee_Master> GetAll(string namelike)
        {
            return _iConsigneeRepository.GetAll().Where(e => e.Consignee_Name.ToLower().StartsWith(namelike.ToLower()));
        }
    

        public Consignee_Master GetByID(int Id)
        {
            return _iConsigneeRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iConsigneeRepository.Delete(Id);
        }
    }
}
