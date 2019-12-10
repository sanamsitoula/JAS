using Dapper;
using JAS.DAL;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public class RoleServices :IRoleServices
    {

        protected DbConn db;
        public RoleServices()
        {
            db = new DbConn();
        }

        public List<RolesViewModel> getAllDetails()
        {
            var conn = db.ConnStrg();
            var FriendList = new List<RolesViewModel>();


            FriendList = conn.Query<RolesViewModel>("select * from Roles r join userroleassigned ur on r.role_id = ur.role_id join  users u on ur.User_id = u.User_id").ToList();

            return (FriendList);

        }

        public List<RoleNamesViewModel> getAllRoleList()
        {
            var conn = db.ConnStrg();
            var FriendList = new List<RoleNamesViewModel>();


            FriendList = conn.Query<RoleNamesViewModel>("select * from Roles").ToList();

            return (FriendList);
        }

    }
}