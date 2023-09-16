using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.BLL;
using MyBBSWebApi.BLL.Interfaces;
using MyBBSWebApi.Model;
using MyBBSWebApi.Models;

namespace MyBBSWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostlistController : ControllerBase
    {
        private readonly IUserBll _userBll;
        private readonly IPostsBLL _postBll;
        public PostlistController(IUserBll userBll, IPostsBLL postsBLL)
        {
            _userBll = userBll;
            _postBll = postsBLL;
        }
        [HttpGet("{token}")]
        public List<Posts> GetPosts(string token) {
            Users user = _userBll.GetUserByToken(token);
            // 获取Posts
            return _postBll.ListAll().ToList();
        }
    }
}