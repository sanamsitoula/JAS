using Dapper;
using JAS.DAL;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace JAS.Services
{
    public class PurchaseServices :IPurchaseServices
    {

        protected DbConn db;
        public PurchaseServices()
        {
            db = new DbConn();

        }

        public List<PurchaseViewModel> ListPurchase(SearchViewModel  vm)
        {
            var conn = db.ConnStrg();

            var FriendList = new List<PurchaseViewModel>();

            var query = "select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,t.credit,t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type, p.purchase_date from purchases p join transactions t on t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id where transactions_type='purchases' order by transaction_Id DESC";
            if (String.IsNullOrEmpty(vm.SearchFrom) && String.IsNullOrEmpty(vm.SearchTo))
            {
                FriendList = conn.Query<PurchaseViewModel>(query).ToList();
            }
            else
            {
               var  sql  = "select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,t.credit,t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type, p.purchase_date from purchases p join transactions t on t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id  WHERE purchase_date BETWEEN '" + vm.SearchFrom + "' AND '" + vm.SearchTo + "' AND  transactions_type='purchases' order by transaction_id DESC";
                FriendList = conn.Query<PurchaseViewModel>(sql).ToList();
            }
            // FriendList = conn.Query<PurchaseViewModel>("select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,p.price,t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type, p.purchase_date from purchases p join transactions t on t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id").ToList();
            return (FriendList);
        }


        public bool AddPurchase(List<PurchaseViewModel> _m)
        {
            DateTimeOffset getSystemCurrentTime = DateTimeOffset.Now;

            //  var identity = (ClaimsIdentity)User.Identity;
            var conn = db.ConnStrg();
            conn.Open();
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            int uid = int.Parse(prinicpal.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
           // string sqlQuery = "Insert Into purchases (item_name,item_code,item_description,photo,group_id,user_id,item_cp,item_sp,item_unit,item_quantity,created_on) select '" + _m.purchase_name + "";

            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    //create and fill up master table data 

                 

                    foreach(PurchaseViewModel pvm in _m)
                    {
                        var param = new DynamicParameters();
                        param.Add("@transaction_name", pvm.purchase_name);
                        param.Add("@purchase_name", pvm.purchase_name);

                        param.Add("@user_id", uid);
                        param.Add("@item_id", pvm.item_id);
                        param.Add("@quantity", pvm.quantity);
                        param.Add("@price", pvm.price);

                        param.Add("@purchase_date", pvm.purchase_date);
                        param.Add("@quantity", pvm.quantity);
                        param.Add("@price", pvm.price);


                        param.Add("@transaction_code", pvm.purchase_name);
                        param.Add("@gl_id", 1);
                        param.Add("@transaction_date", pvm.purchase_date);
                        if (pvm.quantity != 0)
                        {
                            param.Add("@credit", pvm.price * pvm.quantity);
                        }
                        else
                        {
                            param.Add("@credit", pvm.price * pvm.quantity);
                        }
                      
                        param.Add("@transaction_type","purchases");
                        param.Add("@created_on", getSystemCurrentTime);

                        var affectedRows = conn.Execute("Insert_into_purchases_and_transactions", param,commandType:CommandType.StoredProcedure, transaction:transaction);

                    }

                    // your code


                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }



           

        }

        public List<ChartPurchaseViewModel> getChartTopItemPurchaseList()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<ChartPurchaseViewModel>();


            FriendList = conn.Query<ChartPurchaseViewModel>("select TOP 5(p.quantity), i.item_name from purchases p join items i on i.item_id = p.item_id order by p.quantity desc").ToList();

            return (FriendList);
        }

        public List<ChartSalePurchaseViewModel> getChartItemSalePurchaseList()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<ChartSalePurchaseViewModel>();


            FriendList = conn.Query<ChartSalePurchaseViewModel>(
                "select (p.quantity) as purchase_quantity," +
                         " s.quantity as sale_quantity, i.item_name  from  purchases p join items i on i.item_id = p.item_id  join sales s on s.item_id = p.item_id order by s.item_id").ToList();

            return (FriendList);
        }

        //public List<PurchaseViewModel> ListPurchaseFromSearch(SearchViewModel vm)
        //{
        //    var conn = db.ConnStrg();

        //    var FriendList = new List<PurchaseViewModel>();


        //    FriendList = conn.Query<PurchaseViewModel>("select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,p.price,t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type, p.purchase_date from purchases p join transactions t on t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id  WHERE purchase_date BETWEEN '"+vm.SearchFrom+"' AND '"+vm.SearchTo+"'").ToList();

        //    return (FriendList);

        //}
    }
}