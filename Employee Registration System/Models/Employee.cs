using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Registration_System.Helpers;

namespace Employee_Registration_System.Models
{
    class Employee
    {
        private DatabaseHelper dbHelper;
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_initial { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public int salary { get; set; }
        public string  sss { get; set; }
        public string pagibig { get; set; }
        public string gsis { get; set; }


        public Employee()
        {
            dbHelper = new DatabaseHelper();
        }

        public void loadEmployees(DataGridView myDataGridView)
        {
            dbHelper.createQuery(
                "SELECT " +
                    "id AS 'ID', " +
                    "last_name AS 'Last Name', " +
                    "first_name AS 'First Name', " +
                    "middle_initial AS 'Middle Initial', " +
                    "gender AS 'Gender', " +
                    "nationality AS 'Nationality', " +
                    "salary AS 'Salary', " +
                    "sss AS 'SSS', " +
                    "pagibig AS 'PAGIBIG', " +
                    "gsis AS 'GSIS '" +
                "FROM employees; ");
            dbHelper.populateDataGridView(myDataGridView);
        }

        public void addEmployee()
        {
            dbHelper.createQuery("INSERT INTO employees (last_name, first_name, middle_initial, gender, nationality, " +
                "salary, sss, pagibig, gsis) VALUES (@last_name, @first_name, @middle_initial, @gender, @nationality, " +
                "@salary, @sss, @pagibig, @gsis)");
            dbHelper.bindParam("@last_name", last_name);
            dbHelper.bindParam("@first_name", first_name);
            dbHelper.bindParam("@middle_initial", middle_initial);
            dbHelper.bindParam("@gender", gender);
            dbHelper.bindParam("@nationality", nationality);
            dbHelper.bindParam("@salary", salary);
            dbHelper.bindParam("@sss", sss);
            dbHelper.bindParam("@pagibig", pagibig);
            dbHelper.bindParam("@gsis", gsis);

            dbHelper.executeQuery();
        }

        public bool searchEmployee(int id)
        {
            dbHelper.createQuery("SELECT COUNT(*) FROM employees WHERE id = @id");
            dbHelper.bindParam("@id", id);
            if(dbHelper.getCount() > 0)
            {
                dbHelper.createQuery("SELECT * FROM employees WHERE id = @id");
                dbHelper.bindParam("@id", id);
                return true;
            } else
            {
                return false;
            }
        }

        public string getEmployeeDetails(string item)
        {
            return dbHelper.getFromReader(item);
        }
        
        public void updateEmployee(int id)
        {
            dbHelper.createQuery(
                "UPDATE employees SET " +
                "last_name = @last_name, " +
                "first_name = @first_name, " +
                "middle_initial = @middle_initial, " +
                "gender = @gender, " +
                "nationality = @nationality, " +
                "salary = @salary, " +
                "sss = @sss, " +
                "pagibig = @pagibig, " +
                "gsis = @gsis " +
                "WHERE id = @id");

            dbHelper.bindParam("@last_name", last_name);
            dbHelper.bindParam("@first_name", first_name);
            dbHelper.bindParam("@middle_initial", middle_initial);
            dbHelper.bindParam("@gender", gender);
            dbHelper.bindParam("@nationality", nationality);
            dbHelper.bindParam("@salary", salary);
            dbHelper.bindParam("@sss", sss);
            dbHelper.bindParam("@pagibig", pagibig);
            dbHelper.bindParam("@gsis", gsis);
            dbHelper.bindParam("@id", id);

            dbHelper.executeQuery();
        }

        public void deleteEmployee(int id)
        {
            dbHelper.createQuery("DELETE FROM employees WHERE id = @id");
            dbHelper.bindParam("@id", id);

            dbHelper.executeQuery();
        }
    }
}
