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
    public class YardService
    {
          private YardRepository  _iYardRepository;

        public YardService()
        {
            _iYardRepository = new YardRepository();
        }


        public Int32 Save(Yard_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iYardRepository.Save(strXML);
        }

        public IEnumerable<Yard_Master> GetAll()
        {
            return _iYardRepository.GetAll();
        }
        public IEnumerable<Yard_Master> GetAll(string namelike)
        {
            return _iYardRepository.GetAll().Where(e => e.Yard_Name.Contains(namelike));
        }

        public IEnumerable<Yard_Master> GetYardsForBranches(string pAllowBranches = null)
        {
            return _iYardRepository.GetYardsForBranches(pAllowBranches);
        }

        public IEnumerable<Yard_Master> GetYardsForUser(string PUserid)
        {
             return _iYardRepository.GetYardsForUser(PUserid);
        
        }
        public Yard_Master GetByID(int Id)
        {
            return _iYardRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iYardRepository.Delete(Id);
        }
    }
}
