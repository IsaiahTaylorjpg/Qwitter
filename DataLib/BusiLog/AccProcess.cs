using DataLib.DataAccess;
using DataLib.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.BusiLog
{
   public static class AccProcess
    {
        public static int CreateAccount(string username, string password, string firstName, string lastName, string email, string street, string city, string state, int zipCode, string bday)
        {
            UserInfo data = new UserInfo
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Street = street,
                City = city,
                State = state,
                ZipCode = zipCode,
                Bday = bday
            };

            string sql = @"insert into dbo.AccountInfo (Username, Password, FirstName, LastName, Email, Street, City, State, ZipCode, Birthday)
                                                       values ( @Username, @Password, @FirstName, @LastName, @Email, @Street, @City, @State, @ZipCode, @Bday);";

            return SqlDA.SaveData(sql, data);
        }

        public static List<UserInfo> LoadUser()
        {
            string sql = @"select Username, FirstName, LastName, Email, Street, City, State, ZipCode, Birthday
                            from dbo.AccountInfo;";

            return SqlDA.LoadData<UserInfo>(sql);
        }
      public static List<PostsModel> LoadPost()
      {
          string sql = @"select ai.Username, us.Status from dbo.AccountInfo ai INNER JOIN dbo.UserStatus us ON ai.UserId = us.UserId;";

            return SqlDA.LoadPost<PostsModel>(sql);
        }
        public static List<UserInfo> LoginUser(string email, string password)
        {

            UserInfo log = new UserInfo
            {
                Email = email,
                Password = password
            };

            string sql = @"select * from dbo.AccountInfo where email = @Email and password = @Password;";

            

            return SqlDA.LoginUser<UserInfo>(sql, log);
        }

        public static int PostStatus(string status, string userId)
        {
            StatusMod data = new StatusMod
            {
                Status = status,
                UserId = userId
            };

            string sql = @"insert into dbo.UserStatus (Status, UserId)
                            values (@Status, @UserId);";

            return SqlDA.PostStatus(sql, data);
        }
    }
}
