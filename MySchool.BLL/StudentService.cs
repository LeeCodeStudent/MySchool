using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.DAL;
using MySchool.Models;
using MySchool.ViewModels;
using System.Windows.Forms;
using MySchool.Utils;

namespace MySchool.BLL
{
    /// <summary>
    /// 学生服务类
    /// UI 不直接引用 Models 数据，而是引用 ViewModels
    /// 因此 StudentService 就是将相关数据赋值给 ViewModels
    /// </summary>
    public static class StudentService
    {

        /// <summary>
        /// 将Students对象的值 赋值 给StudentViewModel对象
        /// </summary>
        /// <returns></returns>
        public static List<StudentViewModel> GetStudents()
        {
            List<StudentsModel> stus = StudentDAL.Select();

            #region 旧版
            //List<StudentViewModel> list = new List<StudentViewModel>();
            //foreach (Students item in stus)
            //{
            //    StudentViewModel stu = new StudentViewModel()
            //    {
            //        Number = item.Number,
            //        Name = item.Name,
            //        Sex = item.Sex,
            //        Age = item.Age,
            //        Grade = item.Grade,
            //        BornDate = item.BornDate,
            //        PhoneNumber = item.PhoneNumber
            //    };               
            //    list.Add(stu);
            //}
            #endregion

            List<StudentViewModel> list = Converter.ToList<StudentsModel, StudentViewModel>(stus);

            return list;
        }
        public static List<StudentViewModel> GetStudents(string column, string value)
        {
            List<StudentsModel> stus = StudentDAL.Select(column, value); 

            List<StudentViewModel> list = Converter.ToList<StudentsModel, StudentViewModel>(stus);

            return list;
        }
        public static List<StudentViewModel> GetStudents(string column1, string value1, string column2, string value2)
        {
            List<StudentsModel> stus = StudentDAL.Select(column1, value1, column2, value2);

            List<StudentViewModel> list = Converter.ToList<StudentsModel, StudentViewModel>(stus);

            return list;
        }

        /// <summary>
        /// 添加学生
        /// 里氏替换原则
        /// UI => ViewModel => DAL => Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CreateStudent(StudentViewModel model)
        {
            //判断要添加的学生的学号是否存在
            //定义的是一个父类对象stu，而实际传给他的值是一个子类对象new StudentViewModel
            StudentsModel stu = StudentDAL.Find("Number",model.Number);
            if (stu != null)    //说明存在
            {
                return false;
            }
            return StudentDAL.Insert(model);
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static bool RemoveStudentByNumber(string Number) => StudentDAL.Delete(Number);

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdataStudent(StudentViewModel model) => StudentDAL.Update(model);


        /// <summary>
        /// 根据学号获取学生对象
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static StudentViewModel GetStudentByNumber(string Number)
        {
            StudentsModel stu = StudentDAL.Find("Number",Number);

            #region 旧版
            //StudentViewModel stuViewModel = new StudentViewModel()
            //{
            //    Number = stu.Number,
            //    Name = stu.Name,
            //    Sex = stu.Sex,
            //    Age = stu.Age,
            //    Grade = stu.Grade,
            //    BornDate = stu.BornDate,
            //    PhoneNumber = stu.PhoneNumber
            //};
            #endregion

            StudentViewModel stuViewModel = Converter.To<StudentsModel,StudentViewModel>(stu);

            return stuViewModel;
        }
    }
}
