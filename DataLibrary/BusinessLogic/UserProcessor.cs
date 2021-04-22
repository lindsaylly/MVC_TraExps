using Dapper;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLibrary.DataAccess.SqlDataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class  UserProcessor
    {
        public static int CreateUser(string userName, string userPassword)
        {
            string sql = @"dbo.User_Insert  @UserName, @UserPassword";

            User user = new User
            {
                UserName = userName,
                UserPassword = userPassword
            };

            return EditData(sql, user);

        }

        public static User GetUser(string userName)
        {
            string sql = @"dbo.User_Get  @UserName";
            var p = new DynamicParameters();
            p.Add("@UserName", userName);

            return LoadSingleData<User>(sql, p);

        }

        public static int UpdateUser(string userName, string userPassword)
        {
            string sql = @"dbo.User_Update  @UserName, @UserPassword";

            User user = new User
            {
                UserName = userName,
                UserPassword = userPassword
            };

            return EditData(sql, user);
        }
    }
}
