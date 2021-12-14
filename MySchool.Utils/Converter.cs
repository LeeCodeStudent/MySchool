using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;
using MySchool.ViewModels;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MySchool.Utils
{
    public static class Converter
    {
        public static DateTime DateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return System.DateTime.MinValue;
            }
            return Convert.ToDateTime(obj);
        }
        public static int Int32(object obj)
        {
            return (obj == null || obj == DBNull.Value) ? 0 : Convert.ToInt32(obj);
        }

        public static string String(object obj)
        {
            return (obj == null || obj == DBNull.Value) ? string.Empty : obj.ToString();
        }

        public static string TrimedString(object obj)
        {
            return (obj == null || obj == DBNull.Value) ? string.Empty : obj.ToString().Trim();
        }
        /// <summary>
        /// 去掉特殊字符
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string TrimSpecialString(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                //将特殊字符全部替换为下划线
                string pattern = "[\\//[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,;\"‘’“”-]";
                return Regex.Replace(str, pattern, "");
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 将父类型转化为子类型：一次只转一个对象
        /// 要求：属性名必须一致
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TTo To<TFrom ,TTo>(TFrom obj) where TFrom:class where TTo : new()
        {

            TTo to = new TTo();

            PropertyInfo[] props_to = typeof(TTo).GetProperties();
            PropertyInfo[] props = typeof(TFrom).GetProperties();
            foreach (PropertyInfo item in props_to)
            {
                PropertyInfo p = props.FirstOrDefault(p_ => p_.Name == item.Name);
                if (p != null)
                {
                    item.SetValue(to, p.GetValue(obj));
                }
            }
            return to;
        }

        /// <summary>
        /// 将父类型转化为子类型：转换一个集合
        /// 要求：属性名必须一致
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="listFrom"></param>
        /// <returns></returns>
        public static List<TTo> ToList<TFrom,TTo>(List<TFrom> listFrom) where TFrom:class where TTo: new()
        {
            List<TTo> list = new List<TTo>();
            foreach (TFrom item in listFrom)
            {
                list.Add(To<TFrom,TTo>(item));
            }
            return list;
        }


        #region 举例

        /// <summary>
        /// 举例
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static StudentViewModel To(StudentsModel obj)
        {
            StudentViewModel to = new StudentViewModel();

            PropertyInfo[] props_to = typeof(StudentViewModel).GetProperties();
            PropertyInfo[] props = typeof(StudentsModel).GetProperties();
            foreach (PropertyInfo item in props_to)
            {
                PropertyInfo p = props.FirstOrDefault(p_ => p_.Name == item.Name);
                if (p != null)
                {
                    item.SetValue(to,p.GetValue(obj));
                }
            }
            return to;
        }
        #endregion

        /// <summary>
        /// 执行类型转化，int32 string Datetime 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        private static object InvokeChanged(PropertyInfo p ,object Value)
        {
            string typeName = p.PropertyType.Name;  //属性类型的名字
            //获取本类Converter中数据类型转换的方法DateTime() String() Int32()
            MethodInfo method = typeof(Converter).GetMethod($"{typeName}");

            if (method != null)
            {
                return method.Invoke(null, new object[] { Value});
            }
            else
            {
                //这里获取的是ToString()方法
                MethodInfo method2 = typeof(Converter).GetMethod($"To{typeName}");
                return method2?.Invoke(null, new object[] { Value });
            }
        }

        /// <summary>
        /// 将从数据库中读取到的 DataRow 转化为相应的类型 的 对象属性
        /// 其中 转化为相应的类型 是通过 InvokeChanged 实现的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T To<T>(DataRow row) where T : new()
        {
            T t = new T();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo p  in props)
            {
                p.SetValue(t,InvokeChanged(p,row[p.Name]));
            }
            return t;
        }

        /// <summary>
        /// 将从数据库中读取到的 SqlDataReader 转化为相应的类型 的 对象属性
        /// 其中 转化为相应的类型 是通过 InvokeChanged 实现的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T To<T>(SqlDataReader reader) where T : new()
        {
            T t = new T();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo p in props)
            {
                p.SetValue(t, InvokeChanged(p, reader[p.Name]));
            }
            return t;
        }

        public static List<T> ToList<T>(DataTable table) where T:new ()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(To<T>(row));
            }
            return list;
        }
        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
