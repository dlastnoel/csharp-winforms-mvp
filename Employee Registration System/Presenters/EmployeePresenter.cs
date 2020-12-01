using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Registration_System.Models;

namespace Employee_Registration_System.Presenters
{
    class EmployeePresenter
    {
        private Employee _employee;

        public EmployeePresenter()
        {
            _employee = new Employee();
        }

        public void loadEmployees(DataGridView myDataGridView)
        {
            _employee.loadEmployees(myDataGridView);
        }

        public void setEmployee(string last_name, string first_name, string middle_initial, string gender, 
            string nationality, int salary, string sss, string pagibig, string gsis)
        {
            _employee.last_name = last_name;
            _employee.first_name = first_name;
            _employee.middle_initial = middle_initial;
            _employee.gender = gender;
            _employee.nationality = nationality;
            _employee.salary = salary;
            _employee.sss = sss;
            _employee.pagibig = pagibig;
            _employee.gsis = gsis;
        }

        public bool prepareEmployee(int id, TextBox txtLastName, TextBox txtFirstName, TextBox txtMiddleInitial, 
            RadioButton rbnMale, RadioButton rbnFemale, ComboBox cmbNationality, TextBox txtSalary, 
            TextBox txtSss, TextBox txtPagibig, TextBox txtGsis)
        {
            if(_employee.searchEmployee(id))
            {
                txtLastName.Text = _employee.getEmployeeDetails("last_name");
                txtFirstName.Text = _employee.getEmployeeDetails("first_name");
                txtMiddleInitial.Text = _employee.getEmployeeDetails("middle_initial");
                if (_employee.getEmployeeDetails("gender") == "Male")
                {
                    rbnMale.Checked = true;
                }
                else
                {
                    rbnFemale.Checked = true;
                }
                cmbNationality.SelectedIndex = cmbNationality.FindStringExact(_employee.getEmployeeDetails("nationality"));
                txtSalary.Text = _employee.getEmployeeDetails("salary");
                txtSss.Text = _employee.getEmployeeDetails("sss");
                txtPagibig.Text = _employee.getEmployeeDetails("pagibig");
                txtGsis.Text = _employee.getEmployeeDetails("gsis");

                return true;
            } else
            {
                return false;
            }
        }
            

        public void saveEmployee()
        {
            _employee.addEmployee();
        }

        public void updateEmployee(int id)
        {
            _employee.updateEmployee(id);
        }

        public void deleteEmployee(int id)
        {
            _employee.deleteEmployee(id);
        }
    }
}
