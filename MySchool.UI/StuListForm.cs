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
using MySchool.ViewModels;

namespace MySchool.UI
{
    public partial class StuListForm : Form
    {
        public StuListForm()
        {
            InitializeComponent();
        }

        private void Mian_Load(object sender, EventArgs e)
        {
            LoadStudents();
            dgv_Students.ClearSelection();

        }
        private void LoadStudents()
        {
            List<StudentViewModel> list = StudentService.GetStudents();
            dgv_Students.DataSource = list;
        }
        private void datagridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Students.ClearSelection();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            AddStudentForm addStu = new AddStudentForm();
            addStu.Show();
            LoadStudents();
        }

        private void tsmi_Deletet_Click(object sender, EventArgs e)
        {
            if (dgv_Students.SelectedRows.Count == 0)
            {
                MessageBox.Show("选择要删除的学生信息");
                return;
            }
            string Number = dgv_Students.SelectedRows[0].Cells[0].Value.ToString();
            if (StudentService.RemoveStudentByNumber(Number))
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            LoadStudents();
        }

        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_Students.SelectedRows.Count == 0)
            {
                MessageBox.Show("选择要修改的学生信息");
                return;
            }
            string Number = dgv_Students.SelectedRows[0].Cells[0].Value.ToString();

            StudentViewModel model = StudentService.GetStudentByNumber(Number);
            EditStudentForm editStu = new EditStudentForm(model);
            editStu.ShowDialog();
            LoadStudents();
        }

        private void tsmi_Refresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
    }
}
