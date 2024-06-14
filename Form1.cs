using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string phoneNumber = txtPhone.Text;
            string email = txtEmail.Text;
            Student student = new Student()
            {
                Id=Guid.NewGuid(),
                Name=name,
                Surname=surname,
                PhoneNumber=phoneNumber,
                Email=email
            };
            int result = AddRecord(student);
            if (result > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Success! Would you like to add a record ?","Info",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    bildirimGoster.Visible = true;
                    bildirimGoster.BalloonTipText = $"There are {VirtualDatabase.students.Count} students";
                    bildirimGoster.Icon = SystemIcons.Information;
                    bildirimGoster.BalloonTipTitle = "Count Information";
                    bildirimGoster.ShowBalloonTip(2000);
                }
                EmptyTextBoxes();
                ListAllStudents();
            }
        }
        private void ListAllStudents()
        {
            listBox1.DataSource = VirtualDatabase.students;
        }
        private void EmptyTextBoxes()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSurname.Text = string.Empty;
        }

        private int AddRecord(Student student)
        {
            VirtualDatabase.students.Add(student);
            return 1;
        }
    }
}
