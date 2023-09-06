using MyBBSWebApi.DAL;
using MyBBSWebApi.Models;

namespace MyBBSWebApi.BLL
{
    public class UserBll : IUserBll
    {
        // 这一层是业务处理层
        UserDal userDal = new();  // 这里是简便的写法
        public List<Users> GetAll()
        {
            // Find是返回一个user，而FindAll方法是返回List
            return userDal.GetAll().FindAll(m => !m.IsDelete);
        }
        public Users CheckLogin(string userNo, string password)
        {
            List<Users> userlist = userDal.GetUserByUserNoAndPassword(userNo, password);
            if (userlist.Count <= 0)
            {
                return default;
            }
            else
            {
                Users user = userlist.Find(m => !m.IsDelete);
                if (user == null)
                {
                    return default;
                }
                else return user;
            }
        }
        public string AddUser(string userNo, string userName, int userLevel, string IsDelete, string password)
        {
            UserDal user = new UserDal();
            int rows = user.AddUser(userNo, userName, userLevel, IsDelete, password);
            if (rows > 0)
            {

                return "数据添加成功";

            }
            else
            {
                return "数据添加失败";
            }
        }

        public string UpdateUser(int id, string? UserNo, string? UserName, string? IsDelete, string? password, int? UserLevel)
        {
            // 这里UserLevel 前的 int + ？的原因是让这个int可以为空
            // 这里需要理解一个概念是视图模型和领域模型

            UserDal userDal=new UserDal();
            int rows = userDal.UpdateUser(id, UserNo, UserName, IsDelete, password, UserLevel);
            if (rows > 0)
            {

            return "数据修改成功";

            }
            else
            {
                return "数据修改失败";
            }
        }
        public string RemoveUser(int id)
        {
            UserDal userDal = new UserDal();
            int rows = userDal.RemoveUser(id);
            if (rows > 0)
            {
                return "数据删除成功";
            }
            else
            {
                return "数据删除失败";
            }
        }
    }
}