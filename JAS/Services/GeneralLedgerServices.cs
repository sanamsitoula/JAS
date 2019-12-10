using Dapper;
using JAS.DAL;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace JAS.Services
{
    public class GeneralLedgerServices : IGeneralLedgerServices
    {

        protected DbConn db;
        public GeneralLedgerServices()
        {
            db = new DbConn();

        }

        public List<GLViewModel> ListGL()
        {
            var conn = db.ConnStrg();

            var FriendList = new List<GLViewModel>();


            FriendList = conn.Query<GLViewModel>("select * from gl").ToList();

            return (FriendList);
        }
        public bool AddGL(GLViewModel _m)
        {
            string sqlQuery = "Insert Into gl (gl_name,gl_code,gl_master_type) select '" + _m.gl_name + "','" + _m.gl_code + "','" + _m.gl_master_type + "';";


            var conn = db.ConnStrg();

            int rowsAffected = conn.Execute(sqlQuery);

            return true;

        }

       

    }
}