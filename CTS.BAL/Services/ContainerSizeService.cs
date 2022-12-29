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
    public class ContainerSizeService
    {
         private ContainerSizeRepository  _iContainerSizeRepository;

         public ContainerSizeService()
        {
            _iContainerSizeRepository = new ContainerSizeRepository();
        }


         public Int32 Save(Cont_Size_Master mdl)
        {
            ConvertToXML objConvertToXML = new ConvertToXML();
            string strXML = objConvertToXML.GetXMLForSave(mdl);
            return _iContainerSizeRepository.Save(strXML);
        }

        public IEnumerable<Cont_Size_Master> GetAll()
        {
            return _iContainerSizeRepository.GetAll();
        }
        public IEnumerable<Cont_Size_Master> GetAll(string namelike)
        {
            return _iContainerSizeRepository.GetAll().Where(e => e.Cont_Size.ToLower().StartsWith(namelike.ToLower()));
        }


        public IEnumerable<Cont_Size_Master> GetAll(string namelike,int ClientGroupId)
        {
            return _iContainerSizeRepository.GetAll().Where(e =>e.Client_Group_Id== ClientGroupId &&  e.Cont_Size.ToLower().StartsWith(namelike.ToLower())).ToList();
        }

        public Cont_Size_Master GetByID(int Id)
        {
            return _iContainerSizeRepository.GetByID(Id);
        }

        public int Delete(int Id)
        {
            return _iContainerSizeRepository.Delete(Id);
        }
    }
}
