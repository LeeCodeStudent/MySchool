using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;
using System.Data;
using System.Data.SqlClient;
using MySchool.Utils;

namespace MySchool.DAL
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
    public class AdminDAL
    {
        public static List<AdminsModel> Select()
        {
            string sql = @"SELECT LoginID ,LoginPwd FROM Admins";
            DataTable table = DBHelper.GetTable(sql);

            //优化
            List<AdminsModel> list = Converter.ToList<AdminsModel>(table);

            return list;
        }
        public static List<AdminsModel> Select(string column, string value)
        {
            string sql = $@"SELECT LoginID ,LoginPwd FROM Admins where {column} = '" + value + "'";
            DataTable table = DBHelper.GetTable(sql);

            //优化
            List<AdminsModel> list = Converter.ToList<AdminsModel>(table);

            return list;
        }
        public static bool Insert(AdminsModel admin)
        {
            #region 参数化 SQL 语句

            //sql 语句中 @ + 变量名 中的变量名不是 SQLServer 中的列名， 是值的变量名， 必须与 SqlParameter 中的 @ + 变量名 一致
            string sql = $@"insert into Admins values(@LoginID, @LoginPwd)";
            SqlParameter[] parasInsert =
            {
                        new SqlParameter("@LoginID",admin.LoginID),
                        new SqlParameter("@LoginPwd",admin.LoginPwd),
            };
            return DBHelper.ExecuteNonQuery_(sql, parasInsert);

            #endregion
        }
        public static bool Delete(string LoginID)
        {
            #region 参数化 SQL 语句

            string sql = $@"delete from Admins where LoginID = @LoginID";
            SqlParameter[] parasDelete =
            {
                        new SqlParameter("@LoginID",LoginID)
            };
            return DBHelper.ExecuteNonQuery_(sql, parasDelete);

            #endregion
        }

        public static bool Update(AdminsModel admin)
        {
            #region 参数化 SQL 语句

            string sql = $@"update Admins Set LoginPwd = @LoginPwd where LoginID = @LoginID ";
            SqlParameter[] parasUpdate =
            {
                        new SqlParameter("@LoginID",admin.LoginID),
                        new SqlParameter("@LoginPwd",admin.LoginPwd),
            };
            return DBHelper.ExecuteNonQuery_(sql, parasUpdate);

            #endregion
        }

        public static AdminsModel Find(string column,object value)
        {
            string sql = $@"select LoginID,LoginPwd from Admins where {column} = '{value}'";

            SqlDataReader reader = DBHelper.ExecuteReader(sql);

            try
            {
                if (reader != null)
                {
                    if (reader.HasRows)     //判断是不是有数
                    {
                        if (reader.Read())  //只读取第一行满足条件的数据
                        {
                            AdminsModel admin = new AdminsModel()
                            {
                                LoginID = reader["LoginID"].ToString().Trim(),
                                LoginPwd = reader["LoginPwd"].ToString().Trim(),
                            };

                            return admin;
                        }
                    }
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
