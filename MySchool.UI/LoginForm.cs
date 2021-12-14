using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.BLL;

namespace MySchool.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string message = null;
            string id = txt_LoginID.Text.Trim();
            string pwd = txt_LoginPwd.Text.Trim();
            try
            {
                if (AdminService.Login(id, pwd,out message))
                {
                    MessageBox.Show(message);
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //ConfigBLL.GetDBConfig();
        }
    }
}
