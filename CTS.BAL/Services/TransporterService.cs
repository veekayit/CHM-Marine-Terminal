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
    public class TransporterService
    {
        private TransporterRepository  _iTransporterRepository;

        public TransporterService()
        {
            _iTransporterRepository = new TransporterRepository();
        }


        public Int32 Save(Transporter_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iTransporterRepository.Save(strXML);
        }

        public IEnumerable<Transporter_Master> GetAll()
        {
            return _iTransporterRepository.GetAll();
        }
        public IEnumerable<Transporter_Master> GetAll(string namelike)
        {
            return _iTransporterRepository.GetAll().Where(e => e.Transporter_Name.ToLower().StartsWith(namelike.ToLower()));
        }
    

        public Transporter_Master GetByID(int Id)
        {
            return _iTransporterRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iTransporterRepository.Delete(Id);
        }
    }
}
