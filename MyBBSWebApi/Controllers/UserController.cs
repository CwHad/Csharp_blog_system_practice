using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.BLL;
using MyBBSWebApi.Models;

namespace MyBBSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBll _userBll;
        public UserController(IUserBll userBll)
        {
            this._userBll = userBll;
        }
        [HttpPost]
        public bool EditUser(UserEditViewModel edit) {
            try
            {
                var users = _userBll.GetAll();
                var user =  _userBll.GetAll().FirstOrDefault(m => m.Id == edit.Id);
                user.UserName = edit.UserName;
                if(edit.Password == null && edit.Password.Trim() == "") 
                    user.Password = edit.Password;
                _userBll.UpdateUserOfUI(user);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                throw;
            }

        }
    }
}