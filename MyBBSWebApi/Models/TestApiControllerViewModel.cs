using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Models
{
    public class TestApiControllerViewModel
    {
        [MaxLength(2)]
        public string Id {get; set;}
    }
}