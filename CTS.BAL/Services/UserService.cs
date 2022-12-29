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
    public class UserService
    {
        private UserRepository  _iUserRepository;

        public UserService()
        {
            _iUserRepository = new UserRepository();
        }

        public bool Authenticate(ref User_Master user)
        {
            User_Master _user = _iUserRepository.Authenticate(user);
            user = _user;

            if (_user == null) return false;
            if ((user.User_Name == _user.User_Name && (user.User_Password == _user.User_Password)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User_Master GetByID(int Id)
        {
            return _iUserRepository.GetByID(Id);
        }

        public int Save(string UserName, string User_Password, string Dept_Id, string Group_Id,
                          string User_FName, string User_id, string BranchId = null, string YardIds = null)
        {
            return _iUserRepository.Save(UserName, User_Password, Dept_Id, Group_Id, User_FName, User_id, BranchId, YardIds);
        }

        public IEnumerable<User_Master> GetAll()
        {
            return _iUserRepository.GetAll();
        }

        public int Delete(int Id)
        {
            return _iUserRepository.Delete(Id);
        }

        public int SaveUserPermissions(string lblPermissionId, string pstrUserFlag, string pstruserid, string plblMenuId, string pchkAddVal = null, string pchkEditVal = null, string pchkViewVal = null, string pchkDelVal = null)
        {
            return _iUserRepository.SaveUserPermissions(lblPermissionId, pstrUserFlag, pstruserid, plblMenuId, pchkAddVal, pchkEditVal, pchkViewVal, pchkDelVal);
        }


        public int UpdatePassword(int UserId, string Password)
        {
            return _iUserRepository.UpdatePassword(  UserId,   Password);
        }

        public int UserActivation(int UserId, bool Activation)
        {
            return _iUserRepository.UserActivation(UserId, Activation);
        }
    }
}
