using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySchool.Models;

namespace MySchool.DAL
{
    /// <summary>
    /// 数据库操作工具类
    /// 
    /// using System.Data;
    //  using System.Data.SqlClient;
    //
    /// </summary>
    public class DBHelper
    {
        private static readonly string _connStr = @"server = .;database = MySchool;uid = sa;pwd = 123456";

        //private static string _connStr;

        //public static void GetDBConfig(DBConfigModel config)
        //{
        //    _connStr = $@"server = '{config.Server}';database = '{config.DataBase}';uid = '{config.UerID}';pwd = '{config.Password}'";
        //}
        //1.创建连接

        private static SqlConnection _conn;

        public static SqlConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new SqlConnection(_connStr);
                }
                if (_conn.State != ConnectionState.Open)
                {
                    //2.打开连接
                    _conn.Open();
                }
                return _conn;
            }
        }

        //3.创建命令对象

        //SQLCommand就是SQL Server中新建查询的界面

        public static SqlCommand PrepareCmd(string sql,params SqlParameter[] paras)
        {
            SqlCommand cmd = Conn.CreateCommand();  //通过当前的连接对象创建一个命令对象

            cmd.CommandText = sql;                  // 指定Command对象 要执行的 SQL语句

            // CommandType
            // cmd.Parameters   //与SQL语句 所携带的参数 对应的 参数的列表   

            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }

            // cmd.Connection   //与当前命令对象 相关联的数据库对象

            return cmd;
        }
        //4.操作
        //      4.1 ExecuteNonQuery：执行SQL，常用于增、删、改，返回受影响的行数，为int类型
        //      4.2 ExecuteReader：执行查询，并返回第一个DataReader对象
        //      4.3 ExecuteScalar：执行SQL，并返回执行结果的首行首列的值，为object类型



        /// <summary>
        /// 4.1 ExecuteNonQuery：执行SQL，常用于增、删、改，返回受影响的行数，为int类型
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] paras)
        {
            SqlCommand cmd = PrepareCmd(sql,paras);
            //SqlParameter 只读 只能通过 Add() 和 AddRange()
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                if (cmd.Parameters != null)
                {
                    cmd.Parameters.Clear();
                }
                //5.关闭连接
                cmd.Connection.Close();
            }
        }


        /// <summary>
        /// 4.2 ExecuteReader：执行查询，并返回第一个DataReader对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] paras)
        {
            SqlCommand cmd = PrepareCmd(sql,paras);
            try
            {
                // CommandBehavior.CloseConnection：检测数据读取完后自动关闭连接
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 4.3 ExecuteScalar：执行SQL，并返回执行结果的首行首列的值，为object类型
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] paras)
        {
            SqlCommand cmd = PrepareCmd(sql,paras);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (cmd.Parameters != null)
                {
                    cmd.Parameters.Clear();
                }
                //5.关闭连接
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 4.1 ExecuteNonQuery：执行SQL，并返回执行结果，常用于增、删、改
        /// 如果 ExecuteNonQuery 得到的结果 > 0 则说明执行成功，返回 true
        /// 否则执行失败，返回 false 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery_(string sql, params SqlParameter[] paras)
        {
            SqlCommand cmd = PrepareCmd(sql,paras);
            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Parameters != null)
                {
                    cmd.Parameters.Clear();
                }
                //5.关闭连接
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 根据提供的SQL 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetSet(string sql)
        {
            //类似 数据库，里面包含多张表
            DataSet set = new DataSet();
            //set.Tables[x]     x 索引，也可以时表名

            //创建 数据适配器对象
            SqlDataAdapter adapter = new SqlDataAdapter(sql,_connStr);  //操作完成后会自动关闭连接
            //填充数据集
            adapter.Fill(set);
            return set;
        }


        /// <summary>
        /// 根据提供的SQL 获取数据表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            //创建 数据适配器对象
            SqlDataAdapter adapter = new SqlDataAdapter(sql,_connStr);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
