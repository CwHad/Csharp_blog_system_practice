using Microsoft.Data.SqlClient;
using MyBBSWebApi.DAL.Core;
using MyBBSWebApi.Models;
using System.Data;

namespace MyBBSWebApi.DAL
{
    public class UserDal
    {
        /*
         * 这里只要放关于User的增删改查， Dal全称应该是 Data Access Layer， 这里是专门处理与数据源之间的交互
         * 包括但是不限于是数据库 也可以是文件 API 或者任何的数据存储
         */
        public List<Users> GetAll()
        {
            // 这里不需要所有的筛选条件了 直接获取所有的用户
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users");
            List<Users> userList = ToModelList(res);
            return userList;
        }
        public Users GetUserById(int id)
        {
            DataRow row = null;
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE Id = @Id",
                new SqlParameter("@Id", id));
            // 这里能这样写的原因是因为吧SqlHelper定义成了静态的 作为工具类 尽量的是静态的比较好
            if (res.Rows.Count > 0)
            {
                row = res.Rows[0];
            }
            Users user = ToModel(row);
            return user;
        }

        public Users GetUserByToken(string token)
        {
            DataRow row = null;
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE Token = @Token",
                new SqlParameter("@Token", token));
            // 这里能这样写的原因是因为吧SqlHelper定义成了静态的 作为工具类 尽量的是静态的比较好
            if (res.Rows.Count > 0)
            {
                row = res.Rows[0];
            }
            Users user = ToModel(row);
            return user;
        }

        public List<Users> GetUserByUserNoAndPassword(string? userNo = null, string? password = null)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE UserNo = @UserNo AND Password = @Password",
                new SqlParameter("@UserNo", userNo),
                new SqlParameter("@Password", password)
                );
            // 这里能这样写 (SqlHelper) 直接使用SqlHelper类 的原因是因为吧SqlHelper定义成了静态的 作为工具类 尽量的是静态的比较好

            List<Users> userList = ToModelList(res);
            return userList;
        }

        public List<Users> GetUserByUserNoAndAutoLoginTag(string userNo, string autoLoginTag)
        {
            try
            {
                DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE UserNo = @UserNo AND AutoLoginTag = @AutoLoginTag",
                new SqlParameter("@UserNo", userNo),
                new SqlParameter("@AutoLoginTag", autoLoginTag)
                );
                // 这里能这样写 (SqlHelper) 直接使用SqlHelper类 的原因是因为吧SqlHelper定义成了静态的 作为工具类 尽量的是静态的比较好

                List<Users> userList = ToModelList(res);
                return userList;
            }
            catch (System.Exception)
            {
                return default;
            }

        }

        public int AddUser(Users user)
        {
            return SqlHelper.ExecuteNonQuery("INSERT INTO Users(UserNo,UserName,UserLevel,IsDelete,Password) VALUES(@userNo,@userName,@userLevel,@IsDelete,@password)",
                new SqlParameter("@userNo", user.UserNo),
                new SqlParameter("@userName", user.UserName),
                new SqlParameter("@userLevel", user.UserLevel),
                new SqlParameter("@IsDelete", user.IsDelete),
                new SqlParameter("@password", user.Password)
                );
        }

        public int UpdateUserOfUI(Users user)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE Id = @Id",
                new SqlParameter("@Id", user.Id));
            int rowCount = 0;
            if (res.Rows.Count > 0)
            {
                DataRow row = res.Rows[0];
                rowCount = SqlHelper.ExecuteNonQuery("UPDATE Users Set UserNo = @UserNo,UserName = @UserName, UserLevel = @UserLevel, IsDelete = @IsDelete, Password = @Password, Token = @Token, AutoLoginTag = @AutoLoginTag, AutoLoginLimitTime = @AutoLoginLimitTime WHERE Id = @Id",
                    new SqlParameter("@UserNo", user.UserNo),
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@UserLevel", user.UserLevel),
                    new SqlParameter("@IsDelete", user.IsDelete),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Token", user.Token),
                    new SqlParameter("@Id", user.Id),
                    new SqlParameter("@AutoLoginTag", user.AutoLoginTag),
                    new SqlParameter("@AutoLoginLimitTime", user.AutoLoginLimitTime)
                    );
            }
            return rowCount;
        }

        public int UpdateUser(int id,
        string? UserNo,
        string? UserName,
        string? IsDelete,
        string? password,
        int? UserLevel,
        Guid? token,
        Guid? autoLoginTag,
        DateTime? autoLoginLimitTime)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE Id = @Id",
                new SqlParameter("@Id", id));
            int rowCount = 0;
            if (res.Rows.Count > 0)
            {
                DataRow row = res.Rows[0];
                Users user = new Users();
                user.Id = (int)row["Id"];
                user.UserNo = UserNo ?? row["UserNo"]?.ToString() ?? string.Empty;
                user.UserName = UserName ?? row["UserName"]?.ToString() ?? string.Empty;
                user.UserLevel = UserLevel ?? (int)row["UserLevel"];
                // user.IsDelete = row["IsDelete"] as bool? ?? false;
                user.IsDelete = (string)row["IsDelete"];
                user.Password = password ?? row["Password"]?.ToString() ?? string.Empty;
                user.Token = token ?? new Guid();
                user.AutoLoginTag = autoLoginTag ?? new Guid();
                user.AutoLoginLimitTime = autoLoginLimitTime;

                rowCount = SqlHelper.ExecuteNonQuery("UPDATE Users Set UserNo = @UserNo,UserName = @UserName, UserLevel = @UserLevel, IsDelete = @IsDelete, Password = @Password, Token = @Token, AutoLoginTag = @AutoLoginTag, AutoLoginLimitTime = @AutoLoginLimitTime WHERE Id = @Id",
                    new SqlParameter("@UserNo", user.UserNo),
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@UserLevel", user.UserLevel),
                    new SqlParameter("@IsDelete", user.IsDelete),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Token", user.Token),
                    new SqlParameter("@Id", user.Id),
                    new SqlParameter("@AutoLoginTag", user.AutoLoginTag),
                    new SqlParameter("@AutoLoginLimitTime", user.AutoLoginLimitTime)
                    );
            }
            return rowCount;
        }

        public int RemoveUser(int id)
        {
            return SqlHelper.ExecuteNonQuery("DELETE FROM Users WHERE Id = @Id",
                new SqlParameter("@Id", id));

        }

        private List<Users> ToModelList(DataTable table)
        {
            List<Users> userList = new();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                Users user = ToModel(row);
                userList.Add(user);
            }
            return userList;
        }

        private Users ToModel(DataRow row)
        {
            Users user = new();
            // 这个方法只是在这个类中进行使用 所以是private的
            user.Id = (int)SqlHelper.FromDbValue(row["Id"]);
            user.UserNo = SqlHelper.FromDbValue(row["UserNo"])?.ToString() ?? string.Empty;
            user.UserName = SqlHelper.FromDbValue(row["UserName"])?.ToString() ?? string.Empty;
            user.UserLevel = (int)SqlHelper.FromDbValue(row["UserLevel"]);
            // user.IsDelete = row["IsDelete"] as bool? ?? false;
            user.IsDelete = (string)SqlHelper.FromDbValue(row["IsDelete"]);
            user.Password = SqlHelper.FromDbValue(row["Password"])?.ToString() ?? string.Empty;
            user.Token = (Guid?)SqlHelper.FromDbValue(row["Token"]);
            // user.AutoLoginTag =  new Guid(row["AutoLoginTag"].ToString());
            user.AutoLoginTag = (Guid?)SqlHelper.FromDbValue(row["AutoLoginTag"]);
            user.AutoLoginLimitTime = (DateTime?)SqlHelper.FromDbValue(row["AutoLoginLimitTime"]);
            return user;
        }
    }
}