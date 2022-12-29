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
    public class ContainerTypeService
    {
         private ContainerTypeRepository  _iContainerTypeRepository;

        public ContainerTypeService()
        {
            _iContainerTypeRepository = new ContainerTypeRepository();
        }


        public Int32 Save(Container_Type_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iContainerTypeRepository.Save(strXML);
        }

        public IEnumerable<Container_Type_Master> GetAll()
        {
            return _iContainerTypeRepository.GetAll();
        }
        public IEnumerable<Container_Type_Master> GetAll(string namelike)
        {
            return _iContainerTypeRepository.GetAll().Where(e => e.Container_Type.Contains(namelike));
        }
    

        public Container_Type_Master GetByID(int Id)
        {
            return _iContainerTypeRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iContainerTypeRepository.Delete(Id);
        }
    }
}
