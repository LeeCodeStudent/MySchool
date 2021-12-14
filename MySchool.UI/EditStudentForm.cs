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
    public partial class EditStudentForm : Form
    {
        private StudentViewModel _model;

        public EditStudentForm(StudentViewModel model)
        {
            InitializeComponent();

            this._model = model;
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            txt_Number.Text = _model.Number;
            txt_Number.ReadOnly = true;
            txt_Name.Text = _model.Name;
            txt_Age.Text = _model.Age.ToString();
            txt_Grade.Text = _model.Grade.ToString();
            txt_BornDate.Value = _model.BornDate;
            txt_PhoneNumber.Text = _model.PhoneNumber;
            if (_model.Sex == "男")
            {
                radio_Man.Checked = true;
            }
            else
            {
                radio_Woman.Checked = true;
            }
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

            //主键学号不动
            _model.Name = txt_Name.Text.Trim();
            _model.Sex = radio_Man.Checked ? "男" : "女";
            _model.Age = Convert.ToInt32(txt_Age.Text);
            _model.Grade = txt_Grade.Text.Trim();
            _model.BornDate = txt_BornDate.Value;
            _model.PhoneNumber = txt_PhoneNumber.Text.Trim();

            if (StudentService.UpdataStudent(_model))
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}
