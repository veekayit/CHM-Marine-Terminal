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
    public class ClientGroupService
    {
         private ClientGroupRepository  _iClientGroupRepository;

        public ClientGroupService()
        {
            _iClientGroupRepository = new ClientGroupRepository();
        }


     

        public IEnumerable<Client_Group> GetAll()
        {
            return _iClientGroupRepository.GetAll();
        }

        public IEnumerable<Client_Group> GetAll(string Search)
        {
            return _iClientGroupRepository.GetAll().ToList().Where(e=>e.Client_Group_Name.StartsWith(Search));
        }
    }
}
