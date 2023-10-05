using Microsoft.EntityFrameworkCore;
using MyBBSWebApi.DAL.Core;

namespace MyBBSWebApi.DAL.Factorys
{
    public class DbContextFactory
    {
        private static MySecondDbContext _dbContext = null;
        private DbContextFactory()
        {
            // 由于构造函数是私有的 所以不能从类外创建DbContextFactory的实例
            // 但是可以通过调用DbContextFactory.GetDbContext()来获取实例
        }
        public static MySecondDbContext GetDbContext() {
            if(_dbContext == null)
            {
                _dbContext = new MySecondDbContext();
                _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
            return _dbContext;
        }
    }
}