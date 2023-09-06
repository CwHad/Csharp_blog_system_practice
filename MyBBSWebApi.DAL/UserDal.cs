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

        public int AddUser(string userNo, string userName, int userLevel, string IsDelete, string password)
        {
            return SqlHelper.ExecuteNonQuery("INSERT INTO Users(UserNo,UserName,UserLevel,IsDelete,Password) VALUES(@userNo,@userName,@userLevel,@IsDelete,@password)",
                new SqlParameter("@userNo", userNo),
                new SqlParameter("@userName", userName),
                new SqlParameter("@userLevel", userLevel),
                new SqlParameter("@IsDelete", IsDelete),
                new SqlParameter("@password", password)
                );
        }

        public int UpdateUser(int id, string? UserNo, string? UserName, string? IsDelete, string? password, int? UserLevel)
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
                user.IsDelete = row["IsDelete"] as bool? ?? false;
                user.Password = password ?? row["Password"]?.ToString() ?? string.Empty;

                rowCount = SqlHelper.ExecuteNonQuery("UPDATE Users Set UserNo = @UserNo,UserName = @UserName, UserLevel = @UserLevel, IsDelete = @IsDelete, Password = @Password WHERE Id = @Id",
                    new SqlParameter("@UserNo", user.UserNo),
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@UserLevel", user.UserLevel),
                    new SqlParameter("@IsDelete", user.IsDelete),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Id", user.Id)
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
            user.Id = (int)row["Id"];
            user.UserNo = row["UserNo"]?.ToString() ?? string.Empty;
            user.UserName = row["UserName"]?.ToString() ?? string.Empty;
            user.UserLevel = (int)row["UserLevel"];
            user.IsDelete = row["IsDelete"] as bool? ?? false;
            user.Password = row["Password"]?.ToString() ?? string.Empty;
            return user;
        }
    }
}