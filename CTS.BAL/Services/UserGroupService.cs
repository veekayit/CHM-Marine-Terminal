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
    public class UserGroupService
    {
        
        private UserGroupRepository  _iUserGroupRepository;

        public UserGroupService()
        {
            _iUserGroupRepository = new UserGroupRepository();
        }

        public IEnumerable<User_Group> GetAll()
        {
            return _iUserGroupRepository.GetAll();
        }
    }
}
