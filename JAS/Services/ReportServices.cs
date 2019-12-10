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
    public class ReportServices :IReportServices
    {

        protected DbConn db;
        public ReportServices()
        {
            db = new DbConn();

        }

        public List<GLedgerReportViewModel> ListGledger(SearchViewModel  vm)
        {
            var conn = db.ConnStrg();

            var FriendList = new List<GLedgerReportViewModel>();

            var query = "select coalesce(sum(t.Debit),0) AS Debit_Amount,coalesce(sum(t.credit),0) As Credit_Amount,g.gl_id,g.gl_name from transactions t join gl g on g.gl_id = t.gl_id group by g.gl_id,  g.gl_name order by gl_id ";
            if (String.IsNullOrEmpty(vm.SearchFrom) && String.IsNullOrEmpty(vm.SearchTo))
            {
                FriendList = conn.Query<GLedgerReportViewModel>(query).ToList();
            }
            else
            {
                var sql = "select coalesce(sum(t.Debit),0) AS Debit_Amount,coalesce(sum(t.credit),0) As Credit_Amount,g.gl_id,g.gl_name from transactions t join gl g on g.gl_id = t.gl_id WHERE CAST(t.transaction_date AS DATE) >= '" + vm.SearchFrom+"' AND CAST(t.transaction_date AS date) <= '"+vm.SearchTo+ "'group by g.gl_id,  g.gl_name order by gl_id";
                FriendList = conn.Query<GLedgerReportViewModel>(sql).ToList();
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

                        param.Add("@credit",pvm.price);
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


     
      
    }
}