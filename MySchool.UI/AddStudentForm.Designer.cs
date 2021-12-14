namespace MySchool.UI
{
    partial class AddStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Age = new System.Windows.Forms.TextBox();
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.txt_Grade = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.radio_Man = new System.Windows.Forms.RadioButton();
            this.radio_Woman = new System.Windows.Forms.RadioButton();
            this.txt_BornDate = new System.Windows.Forms.DateTimePicker();
            this.txt_PhoneNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(82, 102);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(237, 28);
            this.txt_Name.TabIndex = 1;
            // 
            // txt_Age
            // 
            this.txt_Age.Location = new System.Drawing.Point(82, 208);
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.Size = new System.Drawing.Size(237, 28);
            this.txt_Age.TabIndex = 4;
            // 
            // txt_Number
            // 
            this.txt_Number.Location = new System.Drawing.Point(82, 46);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(237, 28);
            this.txt_Number.TabIndex = 0;
            // 
            // txt_Grade
            // 
            this.txt_Grade.Location = new System.Drawing.Point(82, 264);
            this.txt_Grade.Name = "txt_Grade";
            this.txt_Grade.Size = new System.Drawing.Size(237, 28);
            this.txt_Grade.TabIndex = 5;
            // 
            // OK
            // 
            this.OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Location = new System.Drawing.Point(82, 495);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(237, 49);
            this.OK.TabIndex = 7;
            this.OK.Text = "添加";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // radio_Man
            // 
            this.radio_Man.AutoSize = true;
            this.radio_Man.Location = new System.Drawing.Point(82, 158);
            this.radio_Man.Name = "radio_Man";
            this.radio_Man.Size = new System.Drawing.Size(51, 22);
            this.radio_Man.TabIndex = 2;
            this.radio_Man.TabStop = true;
            this.radio_Man.Text = "男";
            this.radio_Man.UseVisualStyleBackColor = true;
            // 
            // radio_Woman
            // 
            this.radio_Woman.AutoSize = true;
            this.radio_Woman.Location = new System.Drawing.Point(181, 158);
            this.radio_Woman.Name = "radio_Woman";
            this.radio_Woman.Size = new System.Drawing.Size(51, 22);
            this.radio_Woman.TabIndex = 3;
            this.radio_Woman.TabStop = true;
            this.radio_Woman.Text = "女";
            this.radio_Woman.UseVisualStyleBackColor = true;
            // 
            // txt_BornDate
            // 
            this.txt_BornDate.Location = new System.Drawing.Point(82, 320);
            this.txt_BornDate.Name = "txt_BornDate";
            this.txt_BornDate.Size = new System.Drawing.Size(237, 28);
            this.txt_BornDate.TabIndex = 6;
            // 
            // txt_PhoneNumber
            // 
            this.txt_PhoneNumber.Location = new System.Drawing.Point(82, 376);
            this.txt_PhoneNumber.Name = "txt_PhoneNumber";
            this.txt_PhoneNumber.Size = new System.Drawing.Size(237, 28);
            this.txt_PhoneNumber.TabIndex = 5;
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 617);
            this.Controls.Add(this.txt_BornDate);
            this.Controls.Add(this.radio_Woman);
            this.Controls.Add(this.radio_Man);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.txt_PhoneNumber);
            this.Controls.Add(this.txt_Grade);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.txt_Age);
            this.Controls.Add(this.txt_Name);
            this.MaximumSize = new System.Drawing.Size(419, 673);
            this.MinimumSize = new System.Drawing.Size(419, 673);
            this.Name = "AddStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Age;
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.TextBox txt_Grade;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.RadioButton radio_Man;
        private System.Windows.Forms.RadioButton radio_Woman;
        private System.Windows.Forms.DateTimePicker txt_BornDate;
        private System.Windows.Forms.TextBox txt_PhoneNumber;
    }
}