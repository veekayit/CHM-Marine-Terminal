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
    public class BranchService
    {

        private BranchRepository  _iBranchRepository;

        public BranchService()
        {
            _iBranchRepository = new BranchRepository();
        }


        public Int32 Save(Branch_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iBranchRepository.Save(strXML);
        }

        public IEnumerable<Branch_Master> GetAll()
        {
            return _iBranchRepository.GetAll();
        }
        public IEnumerable<Branch_Master> GetAll(string namelike)
        {
            return _iBranchRepository.GetAll().Where(e => e.Bank_Name.Contains(namelike));
        }
    

        public Branch_Master GetByID(int Id)
        {
            return _iBranchRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iBranchRepository.Delete(Id);
        }
    }
}
