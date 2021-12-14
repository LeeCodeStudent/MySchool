using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.ViewModels;
using MySchool.BLL;

namespace MySchool.UI
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrEmpty(item.Text.Trim()))
                    {
                        MessageBox.Show("请填写完整信息");
                        item.Focus();
                        return;
                    }
                }
            }
            StudentViewModel model = new StudentViewModel()
            {
                Number = txt_Number.Text.Trim(),
                Name = txt_Name.Text.Trim(),
                Sex = radio_Man.Checked ? "男" : "女",
                Age = Convert.ToInt32(txt_Age.Text),
                Grade = txt_Grade.Text.Trim(),
                BornDate = txt_BornDate.Value,
                PhoneNumber = txt_PhoneNumber.Text.Trim()
        };
            if (StudentService.CreateStudent(model))
            {
                MessageBox.Show("添加成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
