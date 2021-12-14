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
    /// 学生的数据访问类
    /// </summary>
    public class StudentDAL
    {
        //如果DataGridView中只需要表中的部分列，可以随时删除不需要的数据
        public static List<StudentsModel> Select()
        {
            string sql = $@"SELECT Number, Name, Sex, Age, Grade, BornDate, PhoneNumber FROM Students";
            DataTable table = DBHelper.GetTable(sql);

            //优化
            List<StudentsModel> list = Converter.ToList<StudentsModel>(table);

            #region 旧版
            //List<Students> list = new List<Students>();
            ////循环遍历 表中的每一行
            //foreach (DataRow row in table.Rows)
            //{
            //    Students student = new Students()
            //    {
            //        Number = Converter.TrimedString(row["Number"]),
            //        Name = Converter.TrimedString(row["Name"]),
            //        Sex = Converter.TrimedString(row["Sex"]),
            //        Age = Convert.ToInt32(row["Age"]),
            //        Grade = Converter.TrimedString(row["Grade"]),
            //        //判断读取的是不是数据库中的空值 DBNull.Value
            //        //BornDate = row["BornDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["BornDate"])
            //        BornDate = Converter.DateTime(row["BornDate"]),
            //        PhoneNumber = Converter.TrimedString(row["PhoneNumber"]),

            //    };
            //    list.Add(student);
            //}
            #endregion
            return list;
        }
        /// <summary>
        /// 通过一个参数获取集合
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static List<StudentsModel> Select(string column,string value)
        {
            string sql = $@"SELECT Number, Name, Sex, Age, Grade, BornDate, PhoneNumber FROM Students where {column} = '" + value + "'";
            DataTable table = DBHelper.GetTable(sql);

            //优化
            List<StudentsModel> list = Converter.ToList<StudentsModel>(table);

            return list;
        }
        /// <summary>
        /// 通过两个参数获取集合
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static List<StudentsModel> Select(string column1, string value1, string column2, string value2)
        {
            string sql = $@"SELECT Number, Name, Sex, Age, Grade, BornDate, PhoneNumber FROM Students where {column1} = '"+ value1 + $@"' and {column2} = '"+ value2 + "'";
            DataTable table = DBHelper.GetTable(sql);

            //优化
            List<StudentsModel> list = Converter.ToList<StudentsModel>(table);

            return list;
        }

        public static bool Insert(StudentsModel student)
        {
            #region 拼接 SQL 语句
            //string sql = $@"insert into Students values('{student.Number}','{student.Name}','{student.Sex}','{student.Age}','{student.Grade}','{student.BornDate}','{MD5Helper.GenerateMD5(student.PhoneNumber)}')";
            //return DBHelper.ExecuteNonQuery_(sql);
            #endregion

            #region 参数化 SQL 语句

            //sql 语句中 @ + 变量名 中的变量名不是 SQLServer 中的列名， 是值的变量名， 必须与 SqlParameter 中的 @ + 变量名 一致
            string sql = $@"insert into Students values(@Number, @Name, @Sex, @Age, @Grade, @BornDate, @PhoneNumber)";
            SqlParameter[] parasInsert =
            {
                        new SqlParameter("@Number",student.Number),
                        new SqlParameter("@Name",student.Name),
                        new SqlParameter("@Sex",student.Sex),
                        new SqlParameter("@Age",student.Age),
                        new SqlParameter("@Grade",student.Grade),
                        new SqlParameter("@BornDate",student.BornDate),
                        new SqlParameter("@PhoneNumber",student.PhoneNumber)
                        //new SqlParameter("@PhoneNumber",MD5Helper.GenerateMD5(student.PhoneNumber))
            };
            return DBHelper.ExecuteNonQuery_(sql, parasInsert);

            #endregion
        }
        /// <summary>
        /// 根据学生学号删除学生
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static bool Delete(string Number)
        {
            #region 拼接 SQL 语句
            //string sql = $@"delete from Students where Number = '{Number}'";
            //return DBHelper.ExecuteNonQuery_(sql);
            #endregion

            #region 参数化 SQL 语句

            string sql = $@"delete from Students where Number = @Number";
            SqlParameter[] parasDelete =
            {
                        new SqlParameter("@Number",Number)
            };
            return DBHelper.ExecuteNonQuery_(sql, parasDelete);

            #endregion
        }

        /// <summary>
        /// 修改学生信息，除了学号其他信息都改，学号是主键
        /// </summary>
        /// <param name="stu"></param>
        public static bool Update(StudentsModel student)
        {
            #region 拼接 SQL 语句
            //string sql = $@"update Students Set Name ='{student.Name}',Sex = '{student.Sex}',Age = '{student.Age}',Grade = '{student.Grade}',BornDate = '{student.BornDate}',PhoneNumber = '{student.PhoneNumber}' where Number='{student.Number}'";
            //return DBHelper.ExecuteNonQuery_(sql);
            #endregion

            #region 参数化 SQL 语句

            string sql = $@"update Students Set Name =  @Name, Sex = @Sex, Age = @Age, Grade = @Grade, BornDate = @BornDate, PhoneNumber = @PhoneNumber where Number = @Number ";
            SqlParameter[] parasUpdate =
            {
                        new SqlParameter("@Number",student.Number),
                        new SqlParameter("@Name",student.Name),
                        new SqlParameter("@Sex",student.Sex),
                        new SqlParameter("@Age",student.Age),
                        new SqlParameter("@Grade",student.Grade),
                        new SqlParameter("@BornDate",student.BornDate),
                        new SqlParameter("@PhoneNumber",student.PhoneNumber)
                        //new SqlParameter("@PhoneNumber",MD5Helper.GenerateMD5(student.PhoneNumber))
            };
            return DBHelper.ExecuteNonQuery_(sql, parasUpdate);

            #endregion
        }


        /// <summary>
        /// 根据提供的列名，值 查找第一个满足条件的学生对象
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static StudentsModel Find(string column ,object value)
        {
            #region 拼接 SQL 语句
            //string sql = $@"select Number ,Name, Sex, Age, Grade, BornDate, PhoneNumber from Students where {column} = '{value}'";
            //SqlDataReader reader = DBHelper.ExecuteReader(sql);
            #endregion

            #region 参数化 SQL 语句

            string sql = $@"select Number ,Name, Sex, Age, Grade, BornDate, PhoneNumber from Students where {column} = @value";
            SqlParameter[] parasFind =
            {
                        new SqlParameter("@value",value),
            };
            SqlDataReader reader = DBHelper.ExecuteReader(sql, parasFind);

            #endregion

            try
            {
                if (reader != null)
                {
                    if (reader.HasRows)     //判断是不是有数
                    {
                        if (reader.Read())  //只读取第一行满足条件的数据
                        {
                            StudentsModel student = Converter.To<StudentsModel>(reader);

                            #region 旧版
                            //Students student = new Students()
                            //{
                            //    Number = Converter.TrimedString(reader["Number"]),
                            //    Name = Converter.TrimedString(reader["Name"]),
                            //    Sex = Converter.TrimedString(reader["Sex"]),
                            //    Age = Convert.ToInt32(reader["Age"]),
                            //    Grade = Converter.TrimedString(reader["Grade"]),
                            //    BornDate = Convert.ToDateTime(reader["BornDate"]),
                            //    PhoneNumber = Converter.TrimedString(reader["PhoneNumber"])
                            //};
                            #endregion 

                            return student;
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
