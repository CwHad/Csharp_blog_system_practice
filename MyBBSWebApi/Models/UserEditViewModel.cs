using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Models
{
    // 这里是一个DTO模型，在实例开发中，UserDTO是API对外公开的版本
    // DTOs 通常是用于将数据从API发送到客户端  或者接收客户端发送到API的数据
    public class UserEditViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string  Password { get; set; }
    }
}