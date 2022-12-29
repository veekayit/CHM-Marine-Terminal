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
    public class MovementService
    {
        private MovementRepository  _iMovementRepository;

        public MovementService()
        {
            _iMovementRepository = new MovementRepository();
        }


        public Int32 Save(Movement_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iMovementRepository.Save(strXML);
        }

        public IEnumerable<Movement_Master> GetAll()
        {
            return _iMovementRepository.GetAll();
        }

        public IEnumerable<Movement_Master> GetMovementsByType(String PmoveType)
        {
            return _iMovementRepository.GetAll().Where(e=>e.Move_Type== PmoveType);
        }
        public IEnumerable<Movement_Master> GetAll(string namelike)
        {
            return _iMovementRepository.GetAll().Where(e => e.Movement_Name.Contains(namelike));
        }
    

        public Movement_Master GetByID(int Id)
        {
            return _iMovementRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iMovementRepository.Delete(Id);
        }
    }
}
