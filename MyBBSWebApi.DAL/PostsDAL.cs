using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using MyBBSWebApi.Model;
using MyBBSWebApi.DAL.Core;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace  MyBBSWebApi.DAL
{
    public partial class PostsDAL
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public PostsDAL()
        { }

        /// <summary>
        /// 添加记录
        /// </summary>
        public void InsertRecord(Posts md)
        {
            SqlHelper.ExecuteNonQuery(@"INSERT INTO Posts (PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down )
VALUES   (@PostTitle, @PostIcon, @PostTypeId, @PostType, @PostContent, @Clicks, @Replys, @CreateTime, @CreateUserId, @EditTime, @EditUserId, @LastReplyTime, @LastReplyUserId, @Up, @Down )",
            new SqlParameter("@PostTitle", SqlHelper.ToDbValue( md.PostTitle))
,             new SqlParameter("@PostIcon", SqlHelper.ToDbValue( md.PostIcon))
,             new SqlParameter("@PostTypeId", SqlHelper.ToDbValue( md.PostTypeId))
,             new SqlParameter("@PostType", SqlHelper.ToDbValue( md.PostType))
,             new SqlParameter("@PostContent", SqlHelper.ToDbValue( md.PostContent))
,             new SqlParameter("@Clicks", SqlHelper.ToDbValue( md.Clicks))
,             new SqlParameter("@Replys", SqlHelper.ToDbValue( md.Replys))
,             new SqlParameter("@CreateTime", SqlHelper.ToDbValue( md.CreateTime))
,             new SqlParameter("@CreateUserId", SqlHelper.ToDbValue( md.CreateUserId))
,             new SqlParameter("@EditTime", SqlHelper.ToDbValue( md.EditTime))
,             new SqlParameter("@EditUserId", SqlHelper.ToDbValue( md.EditUserId))
,             new SqlParameter("@LastReplyTime", SqlHelper.ToDbValue( md.LastReplyTime))
,             new SqlParameter("@LastReplyUserId", SqlHelper.ToDbValue( md.LastReplyUserId))
,             new SqlParameter("@Up", SqlHelper.ToDbValue( md.Up))
,             new SqlParameter("@Down", SqlHelper.ToDbValue( md.Down))

            );
        }

        /// <summary>
        /// 删除所有记录
        /// </summary>
        public void DeleteRecord(){
            SqlHelper.ExecuteNonQuery(@"DELETE FROM Posts");
        }

        /// <summary>
        /// 根据Id删除记录
        /// </summary>
        public void DeleteRecordById(int Id){
            SqlHelper.ExecuteNonQuery(@"DELETE FROM Posts WHERE Id =@Id",
            new SqlParameter("@Id",Id));
            }

        /// <summary>
        /// 根据Guid删除记录
        /// </summary>
        public void DeleteRecordByGuid(Guid Id){
            SqlHelper.ExecuteNonQuery(@"DELETE FROM Posts WHERE Id =@Id",
            new SqlParameter("@Id",Id));
            }

        /// <summary>
        /// 修改记录
        /// </summary>
        public void UpdateRecord(Posts md)
        {
            SqlHelper.ExecuteNonQuery(@"UPDATE Posts SET PostTitle=@PostTitle, PostIcon=@PostIcon, PostTypeId=@PostTypeId, PostType=@PostType, PostContent=@PostContent, Clicks=@Clicks, Replys=@Replys, CreateTime=@CreateTime, CreateUserId=@CreateUserId, EditTime=@EditTime, EditUserId=@EditUserId, LastReplyTime=@LastReplyTime, LastReplyUserId=@LastReplyUserId, Up=@Up, Down=@Down WHERE Id =@Id",
            new SqlParameter("@Id", SqlHelper.ToDbValue( md.Id))
,             new SqlParameter("@PostTitle", SqlHelper.ToDbValue( md.PostTitle))
,             new SqlParameter("@PostIcon", SqlHelper.ToDbValue( md.PostIcon))
,             new SqlParameter("@PostTypeId", SqlHelper.ToDbValue( md.PostTypeId))
,             new SqlParameter("@PostType", SqlHelper.ToDbValue( md.PostType))
,             new SqlParameter("@PostContent", SqlHelper.ToDbValue( md.PostContent))
,             new SqlParameter("@Clicks", SqlHelper.ToDbValue( md.Clicks))
,             new SqlParameter("@Replys", SqlHelper.ToDbValue( md.Replys))
,             new SqlParameter("@CreateTime", SqlHelper.ToDbValue( md.CreateTime))
,             new SqlParameter("@CreateUserId", SqlHelper.ToDbValue( md.CreateUserId))
,             new SqlParameter("@EditTime", SqlHelper.ToDbValue( md.EditTime))
,             new SqlParameter("@EditUserId", SqlHelper.ToDbValue( md.EditUserId))
,             new SqlParameter("@LastReplyTime", SqlHelper.ToDbValue( md.LastReplyTime))
,             new SqlParameter("@LastReplyUserId", SqlHelper.ToDbValue( md.LastReplyUserId))
,             new SqlParameter("@Up", SqlHelper.ToDbValue( md.Up))
,             new SqlParameter("@Down", SqlHelper.ToDbValue( md.Down))

            );
        }

        /// <summary>
        /// 根据Id查询记录
        /// </summary>
        public DataTable GetById(int Id)
        {
            DataTable dt = SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE Id =@Id",
            new SqlParameter("@Id",Id));
            return dt;
        }

        /// <summary>
        /// 根据Guid查询记录
        /// </summary>
        public DataTable GetByGuid(Guid Id)
        {
            DataTable dt = SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE Id =@Id",
            new SqlParameter("@Id",Id));
            return dt;
        }

        /// <summary>
        /// 按照自定义要求查询记录
        /// </summary>
        public DataTable GetByCustom(string SearchType, string SearchContent )
        {
            DataTable dt = SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE " + SearchType + " =@SearchContent",
            new SqlParameter("@SearchContent",SearchContent));
            return dt;
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        public DataTable GetAll()
        {
            return SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts");
        }

        /// <summary>
        /// 查询所有记录并分页
        /// </summary>
        public DataTable GetAllOfPage(int? StartPage, int? EndPage)
        {
            return SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM ( SELECT PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down , ROW_NUMBER() OVER(ORDER BY Id) AS num  FROM Posts ) AS PageTable WHERE PageTable.num BETWEEN @StartPage AND @EndPage",
            new SqlParameter("@StartPage",StartPage),
            new SqlParameter("@EndPage",EndPage));
        }

        /// <summary>
        /// 查询所有不重复记录
        /// </summary>
        public DataTable GetAllOfDistinct(string tbColumn)
        {
            return SqlHelper.ExecuteTable(@"SELECT DISTINCT "+ tbColumn +" FROM Posts");
        }

        /// <summary>
        /// 查询所有记录给数组
        /// </summary>
        public Posts[] GetAllToArray()        {
            DataTable dt = SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts");
            Posts[] arrayMod = new Posts[dt.Rows.Count];
                for(int i = 0 ; i < dt.Rows.Count ; i++ )
                {
                DataRow dr = dt.Rows[i];
                Posts mod = new Posts();
                mod.Id = (System.Int32)dr["Id"];
                mod.PostTitle = (System.String)dr["PostTitle"];
                mod.PostIcon = (System.String)dr["PostIcon"];
                mod.PostTypeId = (System.Int32)dr["PostTypeId"];
                mod.PostType = (System.String)dr["PostType"];
                mod.PostContent = (System.String)dr["PostContent"];
                mod.Clicks = (System.Int32)dr["Clicks"];
                mod.Replys = (System.Int32)dr["Replys"];
                mod.CreateTime = (System.DateTime?)dr["CreateTime"];
                mod.CreateUserId = (System.Int32)dr["CreateUserId"];
                mod.EditTime = (System.DateTime?)dr["EditTime"];
                mod.EditUserId = (System.Int32)dr["EditUserId"];
                mod.LastReplyTime = (System.DateTime?)dr["LastReplyTime"];
                mod.LastReplyUserId = (System.Int32)dr["LastReplyUserId"];
                mod.Up = (System.String)dr["Up"];
                mod.Down = (System.String)dr["Down"];
                arrayMod[i] = mod;
            }
            return arrayMod;
        }

        /// <summary>
        /// 查询所有记录到序列
        /// </summary>
        public IEnumerable<Posts> ListAll()
        {
            List<Posts> list = new List<Posts>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts");
            foreach (DataRow dr in dt.Rows)
            {
                Posts md = ToModel(dr);
                list.Add(md);
            }
            return list;
        }

        /// <summary>
        /// 查询所有记录到序列并分页
        /// </summary>
        public IEnumerable<Posts> ListAllOfPage(int? StartPage, int? EndPage)
        {
            List<Posts> list = new List<Posts>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM (SELECT * , ROW_NUMBER() OVER(ORDER BY Id) AS num FROM Posts ) AS PageTable WHERE PageTable.num BETWEEN @StartPage AND @EndPage",
            new SqlParameter("@StartPage",StartPage),
            new SqlParameter("@EndPage",EndPage));
            foreach (DataRow dr in dt.Rows)
            {
                Posts md = ToModel(dr);
                list.Add(md);
            }
            return list;
        }

        /// <summary>
        /// 根据Id查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListById(int Id)
        {
            List<Posts> list = new List<Posts>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE Id=@Id",
            new SqlParameter("@Id", Id));
            foreach (DataRow dr in dt.Rows)
            {
                Posts md = ToModel(dr);
                list.Add(md);
            }
            return list;
        }

        /// <summary>
        /// 根据Guid查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListByGuid(Guid Id)
        {
            List<Posts> list = new List<Posts>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE Id=@Id",
            new SqlParameter("@Id", Id));
            foreach (DataRow dr in dt.Rows)
            {
                Posts md = ToModel(dr);
                list.Add(md);
            }
            return list;
        }

        /// <summary>
        /// 按照自定义要求查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListByCustom(string SearchType, string SearchContent)
        {
            List<Posts> list = new List<Posts>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE " + SearchType + " = @SearchContent",
            new SqlParameter("@SearchContent", SearchContent));
            foreach (DataRow dr in dt.Rows)
            {
                Posts md = ToModel(dr);
                list.Add(md);
            }
            return list;
        }

        /// <summary>
        /// 按照自定义要求使用WHERE IN查询记录到序列
        /// </summary>
        public IEnumerable<Posts> ListByCustomUseWhereIn(string SearchType, string[] SearchContents)
        {
            List<Posts> list = new List<Posts>();
             StringBuilder sb = new StringBuilder();
             SqlParameter[] sqlParameters = new SqlParameter[SearchContents.Length];
             sb.Append("SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down FROM Posts WHERE " ).Append(SearchType).Append(" IN(");
            for (int i = 0; i < SearchContents.Length; i++){
                 sb.Append("@SearchContents").Append(i);
                 if (i < SearchContents.Length - 1) sb.Append(", ");
                 sqlParameters[i] = new SqlParameter("@SearchContents" + i, SearchContents[i]);
             }
             sb.Append(")");
            DataTable dt = SqlHelper.ExecuteTable(sb.ToString(), sqlParameters);
            
            foreach (DataRow dr in dt.Rows)
            {
                Posts md = ToModel(dr);
                list.Add(md);
            }
            return list;
        }

        /// <summary>
        /// 根据Id查询并给所有属性赋值
        /// </summary>
        public Posts GetByIdToAttribute(int Id)
        {
            DataTable dt = SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down  FROM Posts WHERE Id =@Id",
            new SqlParameter("@Id",Id));
            return ToModel(dt.Rows[0]);
        }

        /// <summary>
        /// 根据Guid查询并给所有属性赋值
        /// </summary>
        public Posts GetByGuidToAttribute(Guid Id)
        {
            DataTable dt = SqlHelper.ExecuteTable(@"SELECT Id, PostTitle, PostIcon, PostTypeId, PostType, PostContent, Clicks, Replys, CreateTime, CreateUserId, EditTime, EditUserId, LastReplyTime, LastReplyUserId, Up, Down  FROM Posts WHERE Id =@Id",
            new SqlParameter("@Id",Id));
            return ToModel(dt.Rows[0]);
        }

        /// <summary>
        /// ToModel
        /// </summary>
        private Posts ToModel(DataRow dr)
        {
            Posts md = new Posts();
            md.Id=(System.Int32)SqlHelper.FromDbValue(dr["Id"]);
            md.PostTitle=(System.String)SqlHelper.FromDbValue(dr["PostTitle"]);
            md.PostIcon=(System.String)SqlHelper.FromDbValue(dr["PostIcon"]);
            md.PostTypeId=(System.Int32)SqlHelper.FromDbValue(dr["PostTypeId"]);
            md.PostType=(System.String)SqlHelper.FromDbValue(dr["PostType"]);
            md.PostContent=(System.String)SqlHelper.FromDbValue(dr["PostContent"]);
            md.Clicks=(System.Int32)SqlHelper.FromDbValue(dr["Clicks"]);
            md.Replys=(System.Int32)SqlHelper.FromDbValue(dr["Replys"]);
            md.CreateTime=(System.DateTime?)SqlHelper.FromDbValue(dr["CreateTime"]);
            md.CreateUserId=(System.Int32)SqlHelper.FromDbValue(dr["CreateUserId"]);
            md.EditTime=(System.DateTime?)SqlHelper.FromDbValue(dr["EditTime"]);
            md.EditUserId=(System.Int32)SqlHelper.FromDbValue(dr["EditUserId"]);
            md.LastReplyTime=(System.DateTime?)SqlHelper.FromDbValue(dr["LastReplyTime"]);
            md.LastReplyUserId=(System.Int32)SqlHelper.FromDbValue(dr["LastReplyUserId"]);
            md.Up=(System.String)SqlHelper.FromDbValue(dr["Up"]);
            md.Down=(System.String)SqlHelper.FromDbValue(dr["Down"]);
            return md;
        }

    }
}
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
