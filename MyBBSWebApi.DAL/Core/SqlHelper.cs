using Microsoft.Data.SqlClient;
using System.Data;

namespace MyBBSWebApi.DAL.Core
{
    public class SqlHelper
    {
        public static string ConnectionString { get; set; } = "server=.;database=MySecondDb;uid=sa;pwd=WangYu0330;TrustServerCertificate=true;";
        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] sqlParameters)
        {
            // 这里加 static 关键字是因为不需要每次都实例化工具类 直接用工具类的类去调用方法 
            // 但是要注意一个点 静态方法中必须要引用静态属性

            // 如果用了params关键字的话，意味着参数可以自适应 可以传一个对象 可以传数组 也可以不传
            // 但是 params必须是最后一个参数 并且参数类型要是数组
            // 获取数据的封装
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            /*
             严格意义上来说，SqlDataAdapter类是用于在数据源和ADO.NET数据结构(DataSet或者DataTable)之间传输的类
             */
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            // 除了查询以外的
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            // 这里是直接返回被影响的行数
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 这是将值传入数据库的时候，如果为null的时候，就转换成数据库的DBNull
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbValue(object value) {
            if(value == null)
            {
                return DBNull.Value;
            }
            else {
                return value;
            }
        }

        /// <summary>
        /// 这是从数据库取值的时候，如果取出的值为DBNull, 则转换为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object FromDbValue(object value)
        {
            return value == DBNull.Value ? null : value;
        }
    }
}
