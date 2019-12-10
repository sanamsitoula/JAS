
using JAS.DAL;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Security.Claims;
using System.Threading;

namespace JAS.Services
{
    public class GroupServices :IGroupServices
    {



        protected DbConn db;
        public GroupServices()
        {
            db = new DbConn();

        }


        public List<GroupViewModel> ListGroup()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<GroupViewModel>();
     

            FriendList = conn.Query<GroupViewModel>("Select * From dbo.groupes").ToList();

            return (FriendList);
        }



        public bool AddGroup(GroupViewModel _m)
        {
            DateTimeOffset currentTime = DateTimeOffset.Now;

          //  var identity = (ClaimsIdentity)User.Identity;
            
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            int uid = int.Parse(prinicpal.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());

            string sqlQuery = "Insert Into groupes (group_name,group_code,user_id,created_on) select '" + _m.group_name + "','" + _m.group_code + "'," + uid + ",'" + currentTime + "';";


            var conn = db.ConnStrg();

            int rowsAffected = conn.Execute(sqlQuery);

            return true;
        }



        public GroupViewModel GetGroupById(int id)
        {
            var conn = db.ConnStrg();
            GroupViewModel _friend = new GroupViewModel();

            _friend = conn.Query<GroupViewModel>("Select * From groupes " +
                                   "WHERE group_id =" + id, new { id }).SingleOrDefault();

            return (_friend);
        }

        public bool EditGroup(GroupViewModel model)
        {
            var data = new GroupViewModel();

            if (data != null)
            {
                var conn = db.ConnStrg();

                string sqlQuery = "update groupes set group_name='" + model.group_name + "',group_code='" + model.group_code + "'  where group_id=" + model.group_id;

                int rowsAffected = conn.Execute(sqlQuery);


            }
            return true;
        }

        public bool DeleteGroup(int id)
        {
            var conn = db.ConnStrg();
            string sqlQuery = "Delete From groupes WHERE group_id = " + id;

            int rowsAffected = conn.Execute(sqlQuery);

            return true;


        }


    }


}
