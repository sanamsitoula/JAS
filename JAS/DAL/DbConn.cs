using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JAS.DAL
{
    public class DbConn
    {

        //public IDbConnection DbConn()
        //{
        //    IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["JASDBContext"].ConnectionString);

        //    return db;
        //}

        public IDbConnection ConnStrg()
        {

            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["JASDBContext"].ConnectionString);

            return db;
        }

    }
}