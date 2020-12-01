using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Registration_System.Presenters;

namespace Employee_Registration_System
{
    public partial class FrmEmployeeRegistration : Form
    {
        private EmployeePresenter employeePresenter;
        public FrmEmployeeRegistration()
        {
            InitializeComponent();
            employeePresenter = new EmployeePresenter();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            employeePresenter.loadEmployees(dataEmployees);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                int id;
                if (int.TryParse(txtSearch.Text, out id))
                {
                    if(employeePresenter.prepareEmployee(id, txtLastName, txtFirstName, txtMiddleInitial,
                        rbnMale, rbnFemale, cmbNationality, txtSalary, txtSss, txtPagibig, txtGsis))
                    {
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Text = "&CANCEL";
                    } else
                    {
                        MessageBox.Show("ID not found", "Employee Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                } else
                {
                    MessageBox.Show("Input was not an ID", "Employee Registration System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Search field is empty", "Employee Registration System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employeePresenter.deleteEmployee(int.Parse(txtSearch.Text));
            MessageBox.Show("Employee successfully deleted", "Event Registration System", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            employeePresenter.loadEmployees(dataEmployees);
            clearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLastName.Text) && !String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtMiddleInitial.Text) && (rbnMale.Checked || rbnFemale.Checked) &&
                cmbNationality.SelectedIndex != -1 && !String.IsNullOrEmpty(txtSalary.Text) &&
                !String.IsNullOrEmpty(txtSss.Text) && !String.IsNullOrEmpty(txtPagibig.Text) &&
                !String.IsNullOrEmpty(txtGsis.Text))
            {
                string gender;
                if (rbnMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                employeePresenter.setEmployee(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text, gender,
                    cmbNationality.Text, int.Parse(txtSalary.Text), txtSss.Text, txtPagibig.Text, txtGsis.Text);
                employeePresenter.updateEmployee(int.Parse(txtSearch.Text));

                MessageBox.Show("Employee successfully updated", "Employee Registration System", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                employeePresenter.loadEmployees(dataEmployees);
                clearFields();
            }
            else
            {
                MessageBox.Show("Please fill up all the fields correctly", "Employee Registratoin System",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&SAVE")
            {
                if (!String.IsNullOrEmpty(txtLastName.Text) && !String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtMiddleInitial.Text) && (rbnMale.Checked || rbnFemale.Checked) &&
                cmbNationality.SelectedIndex != -1 && !String.IsNullOrEmpty(txtSalary.Text) &&
                !String.IsNullOrEmpty(txtSss.Text) && !String.IsNullOrEmpty(txtPagibig.Text) &&
                !String.IsNullOrEmpty(txtGsis.Text))
                {
                    string gender;
                    if (rbnMale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }
                    employeePresenter.setEmployee(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text, gender,
                        cmbNationality.Text, int.Parse(txtSalary.Text), txtSss.Text, txtPagibig.Text, txtGsis.Text);
                    employeePresenter.saveEmployee();

                    MessageBox.Show("Employee successfully saved", "Employee Registration System", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    employeePresenter.loadEmployees(dataEmployees);
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Please fill up all the fields correctly", "Employee Registratoin System",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                clearFields();
            }
        }


        private void clearFields()
        {
            txtSearch.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleInitial.Clear();
            rbnMale.Checked = false;
            rbnFemale.Checked = false;
            cmbNationality.SelectedIndex = -1;
            txtSalary.Clear();
            txtSss.Clear();
            txtPagibig.Clear();
            txtGsis.Clear();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Text = "&SAVE";
        }
    }
}
