using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;
using MySchool.DAL;
using MySchool.Utils;
using MySchool.ViewModels;

namespace MySchool.BLL
{
    public static class AdminService
    {
        public static List<AdminsViewModel> GetAdmins()
        {
            List<AdminsModel> admin = AdminDAL.Select();

            List<AdminsViewModel> list = Converter.ToList<AdminsModel, AdminsViewModel>(admin);

            return list;
        }
        public static List<AdminsViewModel> GetAdmins(string column, string value)
        {
            List<AdminsModel> admin = AdminDAL.Select(column, value);

            List<AdminsViewModel> list = Converter.ToList<AdminsModel, AdminsViewModel>(admin);

            return list;
        }

        public static bool CreateAdmin(AdminsViewModel admin)
        {
            AdminsModel adm = AdminDAL.Find("LoginID", admin.LoginID);
            if (adm != null)    //说明存在
            {
                return false;
            }
            return AdminDAL.Insert(admin);
        }

        public static bool RemoveAdminByLogin(string LoginID) => AdminDAL.Delete(LoginID);

        public static bool UpdataAdmin(AdminsViewModel admin) => AdminDAL.Update(admin);


        public static AdminsViewModel GetAdminByLogin(string LoginID)
        {
            AdminsModel admin = AdminDAL.Find("LoginID", LoginID);

            AdminsViewModel adminViewModel = Converter.To<AdminsModel, AdminsViewModel>(admin);

            return adminViewModel;
        }

        /// <summary>
        /// 思路：将管理员账号和密码取出来，并与界面上的填的内容做对比，正确则登陆
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        //public static bool Login(string id, string pwd, out string msg))
        //{
        //    List<AdminsModel> admins = AdminDAL.Select();
        //    return admins.Any(a => a.LoginID == id && a.LoginPwd == pwd);
        //}


        /// <summary>
        /// 登陆
        /// 思路：通过Find函数将取出数据库中第一个满足账号的对象，如果不存在则直接返回false；如果存在再去判读密码对不对
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool Login(string id, string pwd, out string msg)
        {
            AdminsViewModel admin = Converter.To<AdminsModel, AdminsViewModel>(AdminDAL.Find("LoginID", id));
            if (admin == null)
            {
                msg = LoginMessage.Log.用户名错误.ToString();
                return false;
            }
            else
            {
                if (admin.LoginPwd == pwd)
                {
                    msg = LoginMessage.Log.登陆成功.ToString();
                    return true;
                }
                else
                {
                    msg = LoginMessage.Log.密码错误.ToString();
                    return false;
                }
            }
        }
    }
}
