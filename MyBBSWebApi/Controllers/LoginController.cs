using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.BLL;
using MyBBSWebApi.Common;
using MyBBSWebApi.Models;
using System.Data;

namespace MyBBSWebApi.Controllers
{
    // [Route("api/[controller]/[action]")]  // 这里体现路由的业务
    [ApiController] // 通过访问规则去体现做什么业务
    [Route("[controller]")] // restful风格
    [EnableCors("any")]  // 允许跨域
    public class LoginController : ControllerBase
    {
        private readonly IUserBll _userBll;

        public LoginController(IUserBll userBll)
        {
            // 在构造函数中去进行依赖注入, 如果在开始的时候进行注入了，这个时候的userbll就已经有数据了

            // 这里是一种命名规范 有下划线的是意味着私有变量
            _userBll = userBll;

        }

        [HttpGet]
        public List<Users> GetAll()
        {
            // 这里就实现了一个面向抽象的开发 依赖倒置
            // IUserBll userBll = new UserBll(); 如果上面的依赖注入已经拿到了数据 这里就可以不用实例化了
            // Console.WriteLine("这里拿取了所有的数据");
            List<Users> userList = _userBll.GetAll();
            
            return userList;
        }
        [HttpGet("{userNo}/{password}")]
        // 如果这样定义了路由规则的话 那么会在swaggle里面限定死 一定要传这两个参数
        public Users GetLoginRes(string userNo, string password)
        {
            // string md5Str = password.ToMd5();
            Users user = _userBll.CheckLogin(userNo, password);
            return user;
        }
        [HttpPost]
        public string Insert(Users user)
        {   
            return _userBll.AddUser(user);
        }
         [HttpPost("test")]
        public void Test(TestApiControllerViewModel test)
        {   
            // return _userBll.AddUser(user);
        }
        [HttpPut]
        public string Update(int id, 
        string? UserNo, 
        string? UserName, 
        string? IsDelete, 
        string? password, 
        int? UserLevel,
        Guid token,
        Guid autoLoginTag)
        {
            return _userBll.UpdateUser(id, UserNo, UserName, IsDelete, password, UserLevel, token,autoLoginTag, null);
        }
        [HttpDelete]
        public string Remove(int id)
        {
            return _userBll.RemoveUser(id);
        }
    }
}
