using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyBBSWebApi.BLL.Interfaces;
using MyBBSWebApi.DAL;
using MyBBSWebApi.Model;

namespace  MyBBSWebApi.BLL
{
   

    [System.ComponentModel.DataObject]
    public partial class PostsBLL : IPostsBLL
    {
        PostsDAL mdd = new PostsDAL();
        /// <summary>
        /// 构造方法
        /// </summary>
        public PostsBLL()
        { }

        /// <summary>
        /// 添加记录
        /// </summary>
        public void InsertRecord(Posts md)
        {
            mdd.InsertRecord(md);
        }

        /// <summary>
        /// 删除所有记录
        /// </summary>
        public void DeleteRecord()
        {
            mdd.DeleteRecord();
        }

        /// <summary>
        /// 根据Id删除记录
        /// </summary>
        public void DeleteRecordById(int Id)
        {
            mdd.DeleteRecordById(Id);
        }

        /// <summary>
        /// 根据Guid删除记录
        /// </summary>
        public void DeleteRecordByGuid(Guid Id)
        {
            mdd.DeleteRecordByGuid(Id);
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        public void UpdateRecord(Posts md)
        {
            mdd.UpdateRecord(md);
        }

        /// <summary>
        /// 根据Id查询记录
        /// </summary>
        public DataTable GetById(int Id)
        {
            return mdd.GetById(Id);
        }

        /// <summary>
        /// 根据Guid查询记录
        /// </summary>
        public DataTable GetByGuid(Guid Id)
        {
            return mdd.GetByGuid(Id);
        }

        /// <summary>
        /// 按照自定义要求查询记录
        /// </summary>
        public DataTable GetByCustom(string SearchType, string SearchContent)
        {
            return mdd.GetByCustom(SearchType, SearchContent);
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        public DataTable GetAll()
        {
            return mdd.GetAll();
        }

        /// <summary>
        /// 查询所有记录并分页
        /// </summary>
        public DataTable GetAllOfPage(int? pageIndex, int? pageSize)
        {
            int? StartPage = (pageIndex * pageSize) - (pageSize - 1);
            int? EndPage = (pageIndex * pageSize);
            return mdd.GetAllOfPage(StartPage, EndPage);
        }

        /// <summary>
        /// 查询所有不重复记录
        /// </summary>
        public DataTable GetAllOfDistinct(string tbColumn)
        {
            return mdd.GetAllOfDistinct(tbColumn);
        }

        /// <summary>
        /// 查询所有记录给数组
        /// </summary>
        public Posts[] GetAllToArray()
        {
            return mdd.GetAllToArray();
        }

        /// <summary>
        /// 查询所有记录到序列
        /// </summary>
        public IEnumerable<Posts> ListAll()
        {
            return mdd.ListAll();
        }
        /// <summary>
        /// 查询所有记录到序列并分页
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页多少数据</param>
        /// <returns></returns>
        public IEnumerable<Posts> ListAllOfPage(int? pageIndex, int? pageSize)
        {
            int? StartPage = (pageIndex * pageSize) - (pageSize - 1);
            int? EndPage = (pageIndex * pageSize);
            return mdd.ListAllOfPage(StartPage, EndPage);
        }
        /// <summary>
        /// 根据Id查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListById(int Id)
        {
            return mdd.ListById(Id);
        }
        /// <summary>
        /// 根据Guid查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListByGuid(Guid Id)
        {
            return mdd.ListByGuid(Id);
        }
        /// <summary>
        /// 按照自定义要求查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListByCustom(string SearchType, string SearchContent)
        {
            return mdd.ListByCustom(SearchType, SearchContent);
        }
        /// <summary>
        /// 按照自定义要求使用WHERE IN查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListByCustomUseWhereIn(string SearchType, string[] SearchContent)
        {
            return mdd.ListByCustomUseWhereIn(SearchType, SearchContent);
        }
        /// <summary>
        /// 根据Id查询并给所有属性赋值
        /// </summary>
        public Posts GetByIdToAttribute(int Id)
        {
            Posts mod = new PostsDAL().GetByIdToAttribute(Id);
            return mod;
        }

        /// <summary>
        /// 根据Guid查询并给所有属性赋值
        /// </summary>
        public Posts GetByGuidToAttribute(Guid Id)
        {
            Posts mod = new PostsDAL().GetByGuidToAttribute(Id);
            return mod;
        }


    }
}
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
