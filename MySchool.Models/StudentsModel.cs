using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    /// <summary>
    /// 学生类
    /// 对应数据库中学生数据库
    /// </summary>
    public class StudentsModel
    {
        //在这里必须必须必须为属性设置get访问器，不然DataGridView绑定不到

        [DisplayName("学号")]
        public virtual string Number { get; set; }

        [DisplayName("名字")]
        public virtual string Name { get; set; }

        [DisplayName("性别")]
        public virtual string Sex { get; set; }

        [DisplayName("年龄")]
        public virtual int Age { get; set; }

        [DisplayName("年级")]
        public virtual string Grade { get; set; }

        [DisplayName("出生日期")]
        public virtual DateTime BornDate { get; set; }

        [DisplayName("电话号码")]
        public virtual string PhoneNumber { get; set; }
    }
}
