using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.BLL;
using MyBBSWebApi.BLL.Interfaces;
using MyBBSWebApi.Model;
using MyBBSWebApi.Models;
using MyBBSWebApi.Models.Models;

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
        public List<Post> GetPosts(string token) {
            // Users user = _userBll.GetUserByToken(token);
            // 获取Posts
            List<Post> list = _postBll.GetAllOfPage().ToList();
            // return _postBll.GetAll();
            return list;    
        }
    }
}