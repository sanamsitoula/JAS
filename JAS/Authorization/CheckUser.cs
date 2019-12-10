using Dapper;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JAS.Authorization
{
    public static  class CheckUser
    {

        //check if user exist
        public static UserViewModel IsUserExist(string username)
        {

            using (
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["JASDBContext"].ConnectionString))
            {
                

                var IsExistUser = db.Query<UserViewModel>("Select * From dbo.users where user_name='"+username+"'").FirstOrDefault();
                if (IsExistUser != null)
                {
                    var data = new UserViewModel()
                    {
                        user_id = IsExistUser.user_id,
                        user_name = IsExistUser.user_name,
                        Password = IsExistUser.Password,
                        first_name = IsExistUser.first_name,
                        last_name = IsExistUser.last_name,
                        dateofbirth = IsExistUser.dateofbirth,
                        email_id = IsExistUser.email_id,
                        isEmailVerified =IsExistUser.isEmailVerified
                    };
                    var roleDetails = GetRoleDetails((int)data.user_id);
                    data.role_name = roleDetails.role_name;
                    return data;
                }
                else
                {
                    return null;
                }

            }

        }

        //check if role exist
        public static RoleNamesViewModel GetRoleDetails(int user_id)
        {
            using (
          IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["JASDBContext"].ConnectionString))

            {
                var getRoles = db.Query<RoleNamesViewModel>("select role_name from Roles r join userroleassigned ur on r.role_id = ur.role_id join  users u on ur.User_id = u.User_id where ur.user_id=" + user_id).FirstOrDefault();


                return getRoles;
            }
        }


    }
}