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
    public class PermissionService
    {

        private PermissionRepository _iPermissionRepository;

         public PermissionService()
        {
            _iPermissionRepository = new PermissionRepository();
        }
         public Permission GetUserPermission(int UserId, string PagePath)
         {
             return _iPermissionRepository.GetUserPermission(UserId, PagePath);
         }


         public bool AllowView(int userid, string PagePath)
         {

             if (userid == 2)
             {
                 return true;
             }
             else
             {
                 return GetUserPermission(userid, PagePath).AllowView;
             }
         }

         public bool AllowAdd(int userid, string PagePath)
         {
             if (userid == 2)
             {
                 return true;
             }
             else
             {
                 return GetUserPermission(userid, PagePath).AllowAdd;
             }
         }

         public bool AllowEdit(int userid, string PagePath)
         {
             if (userid == 2)
             {
                 return true;
             }
             else
             {
                 return GetUserPermission(userid, PagePath).AllowEdit;
             }
         }

         public bool AllowDelete(int userid, string PagePath)
         {
             if (userid == 2)
             {
                 return true;
             }
             else
             {
                 return GetUserPermission(userid, PagePath).AllowDelete;
             }
         }
    }


        

}
