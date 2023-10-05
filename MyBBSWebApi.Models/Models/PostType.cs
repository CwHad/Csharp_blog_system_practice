using System;
using System.Collections.Generic;

namespace MyBBSWebApi.Models.Models;

public partial class PostType
{
    public int Id { get; set; }

    public string PostType1 { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public int CreateUserId { get; set; }
}
