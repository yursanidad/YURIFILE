using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YURIFILE
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string studentNumber = txtStudentNo.Text.Trim();
            if (string.IsNullOrEmpty(studentNumber))
            {
                MessageBox.Show("Please enter a student number.");
                return;
            }

            string[] studentInfo = {
                "Student Number: " + studentNumber,
                "Last Name: " + txtLastName.Text,
                "First Name: " + txtFirstName.Text,
                "Middle Name: " + txtMiddleName.Text,
                "Gender: " + cbGender.Text,
                "Birthday: " + dateTimeBirthday.Value.ToShortDateString(),
                "Program: " + cbProgram.Text,
                "Contact No: " + txtContactNo.Text,
                "Age: " + txtAge.Text
            };

            string relativePath = @"..\..\FILE_LAB";
            string docPath = Path.GetFullPath(relativePath);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, studentNumber + ".txt")))
            {
                foreach (string info in studentInfo)
                {
                    outputFile.WriteLine(info);
                }
            }
            MessageBox.Show("Registration file created!");
            Application.Exit();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
           {
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"
           };
            for (int i = 6; i < ListOfProgram.Length; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i]);

            }
            string[] ListOfGender = new string[]
      {
            "Male",
            "Female",

      };
            for (int i = 2; i < ListOfGender.Length; i++)
            {
                cbGender.Items.Add(ListOfGender[i]);
            }
        }
    }
}
