using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    /// <summary>
    /// 管理员类
    /// </summary>
    public class AdminsModel
    {
        /// <summary>
        /// 管理员登陆账号
        /// </summary>
        public virtual string LoginID { set; get; }


        /// <summary>
        /// 管理员登陆密码
        /// </summary>
        public virtual string LoginPwd { set; get; }
    }
}
