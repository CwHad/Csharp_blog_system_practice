namespace MyBBSWebApi.Models
{
    public class Users
    {
        // 这应该是个领域模型，用于和数据库之间的交互，映射了数据库中的表结构
        public int Id { get; set; }
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }
        public string IsDelete { get; set; }
        public string Password { get; set; }
        public Guid Token { get; set; }
        public Guid AutoLoginTag { get; set; }
        public DateTime? AutoLoginLimitTime { get; set; }
    }
}
