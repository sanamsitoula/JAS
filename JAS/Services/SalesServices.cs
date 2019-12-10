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
    public class SalesServices :ISalesServices
    {

        protected DbConn db;
        public SalesServices()
        {
            db = new DbConn();

        }

        public List<SalesViewModel> ListSale()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<SalesViewModel>();


            FriendList = conn.Query<SalesViewModel>("  select s.sale_id,s.customer_id,s.sale_name,i.item_id,i.item_name, s.quantity, s.price, t.transaction_name,g.gl_name, g.gl_master_type, t.debit, t.transactions_type,s.sale_date from  Sales s  join transactions t on t.linking_transaction_id = s.sale_id  join gl g on g.gl_id = t.gl_id   join items i on i.item_id = s.item_id where transactions_type='sales' order by transaction_Id DESC  ").ToList();

            return (FriendList);
        }


        public bool AddSale(List<SalesViewModel> _m)
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

                 

                    foreach(SalesViewModel pvm in _m)
                    {
                        var param = new DynamicParameters();
                        param.Add("@transaction_name", pvm.sale_name);
                        param.Add("@sale_name", pvm.sale_name);

                        param.Add("@user_id", uid);
                        param.Add("@item_id", pvm.item_id);
                        param.Add("@quantity", pvm.quantity);
                        param.Add("@price", pvm.price);

                        param.Add("@sale_date", pvm.sale_date);
                        param.Add("@quantity", pvm.quantity);
                        param.Add("@price", pvm.price);

                        param.Add("@customer_id", 1);
                        param.Add("@transaction_code", pvm.sale_name);
                        param.Add("@gl_id", 2);
                        param.Add("@transaction_date", pvm.sale_date);
                        if (pvm.quantity!= 0)
                        {
                            param.Add("@debit", pvm.price*pvm.quantity);
                        }
                        else
                        {
                            param.Add("@debit", pvm.price);
                        }
                       
                        param.Add("@transaction_type","sales");
                        param.Add("@created_on", getSystemCurrentTime);

                        var affectedRows = conn.Execute("Insert_into_sales_transactions", param,commandType:CommandType.StoredProcedure, transaction:transaction);

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

        public List<ChartSaleViewModel> getChartTopItemSaleList()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<ChartSaleViewModel>();


            FriendList = conn.Query<ChartSaleViewModel>("select TOP 5(p.quantity), i.item_name from sales p join items i on i.item_id = p.item_id order by p.quantity desc").ToList();

            return (FriendList);
        }
    }
}