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
    public class MenuService
    {
        private MenuRepository  _iMenuRepository;

        public MenuService()
        {
            _iMenuRepository = new MenuRepository();
        }


        public IEnumerable<Menu_Master> GetAllParents()
        {
            return _iMenuRepository.GetAllParents();
        }

        public IEnumerable<Permission> GetPermissions(string GroupId, int MastermenuId, string strUserFlag)
        {
            return _iMenuRepository.GetPermissions(GroupId, MastermenuId, strUserFlag);
        }
    }
}
