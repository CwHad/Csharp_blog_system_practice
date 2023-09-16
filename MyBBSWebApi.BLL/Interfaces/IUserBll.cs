using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBBSWebApi.BLL
{
    public interface IUserBll
    {
        // 这个前面可以添加访问修饰符 也可以不添加 新版的添加
        List<Users> GetAll();
        Users CheckLogin(string userNo, string password);
        Users GetUserByToken(string token);
        string AddUser(string userNo, string userName, int userLevel, string IsDelete, string password);
        string UpdateUser(int id, string? UserNo, string? UserName, string? IsDelete, string? password, int? UserLevel, Guid? token, Guid? autoLoginTag, DateTime? autoLoginLimitTime);
        string RemoveUser(int id);
         
    }
}
