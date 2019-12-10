using Dapper;
using JAS.DAL;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace JAS.Services
{
    public class ItemServices :IItemServices
    {

        protected DbConn db;
        public ItemServices()
        {
            db = new DbConn();

        }

        public List<ItemViewModel> ListItem()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<ItemViewModel>();


            FriendList = conn.Query<ItemViewModel>("select g.group_name,i.group_id,i.item_id,i.item_name,i.item_code,i.item_description,i.user_id,i.item_unit, i.item_sp, i.item_cp, i.item_quantity, i.photo, i.created_on,u.user_name from items i join groupes g on g.group_id = i.group_id join users u on u.user_id = i.user_id order by i.item_id desc").ToList();

            return (FriendList);
        }

       



        public bool AddItem(ItemViewModel _m)
        {

           


            DateTimeOffset currentTime = DateTimeOffset.Now;

            //  var identity = (ClaimsIdentity)User.Identity;

            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            int uid = int.Parse(prinicpal.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
           

          string sqlQuery = "Insert Into items (item_name,item_code,item_description,photo,group_id,user_id,item_cp,item_sp,item_unit,item_quantity,created_on) select '" + _m.item_name + "','" + _m.item_code + "','" + _m.item_description + "','" + _m.photo + "'," + _m.group_id + "," + uid + "," + _m.item_cp + "," + _m.item_sp + ",'" + _m.item_unit + "'," + _m.item_quantity + ",'" + currentTime + "';";


            var conn = db.ConnStrg();

      int rowsAffected = conn.Execute(sqlQuery);

            return true;
        }

        public bool DeleteItem(int id)
        {
            var conn = db.ConnStrg();
            string sqlQuery = "Delete from items WHERE item_id = " + id;

            int rowsAffected = conn.Execute(sqlQuery);

            return true;
        }

        public ItemViewModel GetItemById(int id)
        {
            var conn = db.ConnStrg();
            ItemViewModel _friend = new ItemViewModel();

            _friend = conn.Query<ItemViewModel>("Select * From items i join groupes g on g.group_id = i.group_id  " +
                                   "WHERE item_id =" + id, new { id }).SingleOrDefault();

            return (_friend);
        }

        public bool EditItem(ItemViewModel model)
        {
            var data = new ItemViewModel();

            if (data != null)
            {
                var conn = db.ConnStrg();

                string sqlQuery = "update items set item_name='" + model.item_name + "',item_code='" + model.item_code + "',item_description='" + model.item_description + "' ,photo='" + model.photo + "' ,group_id=" + model.group_id + " ,item_cp=" + model.item_cp + " ,item_sp=" + model.item_sp + " ,item_unit='" + model.item_unit + "' ,item_quantity=" + model.item_quantity + "  where item_id=" + model.item_id;

                int rowsAffected = conn.Execute(sqlQuery);


            }
            return true;
        }
    }

   
}