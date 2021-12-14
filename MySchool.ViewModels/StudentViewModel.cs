using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;
namespace MySchool.ViewModels
{
    /// <summary>
    /// 学生信息的视图模型
    /// 继承自学生的数据模型
    /// </summary>
    public class StudentViewModel : StudentsModel
    {
        public override string Number { get; set; }

        public override string Name { get; set; }

        public override string Sex { get; set; }

        public override int Age { get; set; }

        public override string Grade { get; set; }

        public override DateTime BornDate { get; set; }

        public override string PhoneNumber { get; set; }

    }
}
