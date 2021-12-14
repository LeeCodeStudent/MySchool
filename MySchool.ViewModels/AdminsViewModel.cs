using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.ViewModels
{
    public class AdminsViewModel: AdminsModel
    {
        /// <summary>
        /// 管理员登陆账号
        /// </summary>
        public override string LoginID { set; get; }


        /// <summary>
        /// 管理员登陆密码
        /// </summary>
        public override string LoginPwd { set; get; }
    }
}
