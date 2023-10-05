using MyBBSWebApi.DAL;
using MyBBSWebApi.Models;
using MyBBSWebApi.Common;

namespace MyBBSWebApi.BLL
{
    public class UserBll : IUserBll
    {
        // 这一层是业务处理层
        UserDal userDal = new();  // 这里是简便的写法
        public List<Users> GetAll()
        {
            // Find是返回一个user，而FindAll方法是返回List
            return userDal.GetAll().FindAll(m => m.IsDelete != "1");
        }
        public Users CheckLogin(string userNo, string password)
        {
            List<Users> userlist = userDal.GetUserByUserNoAndPassword(userNo, password.ToMd5());
            if (userlist.Count <= 0) 
            {
                userlist = userDal.GetUserByUserNoAndAutoLoginTag(userNo, password);
                // 这里还要再做一步处理，这里userlist是null的话，是没有Count这个属性的你
                if(userlist == null) return default;
                userlist = userlist.FindAll(m => m.AutoLoginLimitTime > DateTime.Now);
                if(userlist.Count <= 0) 
                {
                    return default;
                }
                else 
                {
                    return GetLoginResult(userlist, false);
                }
            }
            else
            {
                return GetLoginResult(userlist, true);
            }
        }

        private Users GetLoginResult(List<Users> userlist, bool isPasswordLogin)
        {
            Users user = userlist.Find(m => m.IsDelete != "1");
            user.Token = Guid.NewGuid();
            // 如果是用户密码登录 则赋予新的AutoLoginTag
            if(isPasswordLogin)
            {
                user.AutoLoginTag = Guid.NewGuid();
                user.AutoLoginLimitTime = DateTime.Now.AddDays(7);
            } 
            UpdateUser(user.Id, user.UserNo, user.UserName, user.IsDelete, user.Password, user.UserLevel, user.Token, user.AutoLoginTag, user.AutoLoginLimitTime);
            if (user == null)
            {
                return default;
            }
            else return user;
        }

        public Users GetUserByToken(string token) {
            Users user =  userDal.GetUserByToken(token);
            if(user == null) 
            {
                throw new Exception("Token错误");
            }
            return user;
        }
        public string AddUser(Users user)
        {
            user.IsDelete = user.IsDelete ?? "0";
            UserDal userDal = new UserDal();
            int rows = userDal.AddUser(user);
            if (rows > 0)
            {

                return "数据添加成功";

            }
            else
            {
                return "数据添加失败";
            }
        }

        public string UpdateUser(int id, 
        string? UserNo, 
        string? UserName, 
        string? IsDelete, 
        string? password, 
        int? UserLevel, 
        Guid? token,
        Guid? autoLoginTag,
        DateTime? autoLoginLimitTime)
        {
            // 这里UserLevel 前的 int + ？的原因是让这个int可以为空
            // 这里需要理解一个概念是视图模型和领域模型

            UserDal userDal=new UserDal();
            int rows = userDal.UpdateUser(id, UserNo, UserName, IsDelete, password, UserLevel, token, autoLoginTag, autoLoginLimitTime);
            if (rows > 0)
            {

            return "数据修改成功";

            }
            else
            {
                return "数据修改失败";
            }
        }
        public string UpdateUserOfUI(Users user)
        {
            // 这里UserLevel 前的 int + ？的原因是让这个int可以为空
            // 这里需要理解一个概念是视图模型和领域模型

            UserDal userDal=new UserDal();
            int rows = userDal.UpdateUserOfUI(user);
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