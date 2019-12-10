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
    public class JournalEntryServices :IJournalEntryServices
    {

        protected DbConn db;
        public JournalEntryServices()
        {
            db = new DbConn();

        }

        public List<JournalEntryViewModel> ListJournalEntry(SearchViewModel  vm)
        {
            var conn = db.ConnStrg();

            var FriendList = new List<JournalEntryViewModel>();

            var query = "select u.user_name,t.transaction_name as journal_name,t.transaction_code as journal_code,t.transaction_date as journal_date,t.transactions_type,t.transaction_descriptions, g.gl_name,t.Debit as Debit_Amount,t.credit as Credit_Amount,t.gl_id from transactions t  join gl g on g.gl_id = t.gl_id join users u on u.user_id = t.user_id order by t.transaction_id desc ";
            if (String.IsNullOrEmpty(vm.SearchFrom) && String.IsNullOrEmpty(vm.SearchTo))
            {
                FriendList = conn.Query<JournalEntryViewModel>(query).ToList();
            }
            else
            {
               var  sql  = "select u.user_name,t.transaction_name as journal_name,t.transaction_code as journal_code,t.transaction_date as journal_date,t.transactions_type,t.transaction_descriptions, g.gl_name,t.Debit as Debit_Amount,t.credit as Credit_Amount,t.gl_id from transactions t  join gl g on g.gl_id = t.gl_id join users u on u.user_id = t.user_id    WHERE transaction_date BETWEEN '" + vm.SearchFrom + "' AND '" + vm.SearchTo + "' order by t.transaction_id desc ";
                FriendList = conn.Query<JournalEntryViewModel>(sql).ToList();
            }
            // FriendList = conn.Query<PurchaseViewModel>("select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,p.price,t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type, p.purchase_date from purchases p join transactions t on t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id").ToList();
            return (FriendList);
        }


        public bool AddJournalEntry(List<JournalEntryViewModel> _m)
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


                    Guid g;
                    // Create and display the value of two GUIDs.
                    g = Guid.NewGuid();
                    foreach (JournalEntryViewModel pvm in _m)
                    {
                        var param = new DynamicParameters();
                        param.Add("@transaction_name", pvm.journal_name);
                        param.Add("@transaction_code", pvm.journal_date);

                        param.Add("@user_id", uid);
                        param.Add("@transaction_description", pvm.transaction_descriptions);

                        param.Add("@transaction_date", pvm.journal_date);
                        param.Add("@gl_id", pvm.gl_id);
                        param.Add("@debit", pvm.Debit_Amount);
                        param.Add("@transaction_type","journalsentries");

                        param.Add("@guid", g.ToString());
                        param.Add("@credit",pvm.Credit_Amount);
                        param.Add("@created_on", getSystemCurrentTime);

                     var affectedRows = 
                       conn.Execute("Insert_into_journal_transactions", param,commandType:CommandType.StoredProcedure, transaction:transaction);

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