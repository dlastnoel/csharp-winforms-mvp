using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Employee_Registration_System.Helpers
{
    class DatabaseHelper
    {
        // DB connection fields
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string port;
        private string password;
        private MySqlCommand commandQuery;
        private MySqlDataReader sqlDataReader;


        // Default constructor
        public DatabaseHelper()
        {
            server = "localhost";
            user = "root";
            database = "employee_registration";
            port = "3306";
            password = "";
            connection = new MySqlConnection
                ("SERVER=" + server + ";DATABASE=" + database + ";USER=" + user + ";PORT=" + port + ";PASSWORD=" + password + ";");
        }

        // Open MySQL Connection
        public void openConnection()
        {
            connection.Open();
        }

        // Counts query
        public int getCount()
        {
            openConnection();
            int count = int.Parse(commandQuery.ExecuteScalar().ToString());
            closeConnection();
            return count;
        }

        // Close MySQL Connection
        public void closeConnection()
        {
            connection.Close();
        }

        // Creates command query
        public void createQuery(string query)
        {
            openConnection();

            commandQuery = new MySqlCommand(query, connection);

            closeConnection();
        }

        // Binds parameters from commannd query if any
        // param - parameter name
        // value - parameter value
        public void bindParam(string param, dynamic value)
        {
            openConnection();

            commandQuery.Parameters.AddWithValue(param, value);

            closeConnection();
        }

        // Executes command query
        public void executeQuery()
        {
            openConnection();

            commandQuery.ExecuteNonQuery();

            closeConnection();
        }

        // Extracts value from reader
        // item - field from reader to be read
        public string getFromReader(string item)
        {
            string data = "";
            openConnection();

            sqlDataReader = commandQuery.ExecuteReader();
            if (sqlDataReader.Read())
            {
                data = sqlDataReader[item].ToString();
            }

            closeConnection();

            return data;
        }

        // Executes command query and populates dataGridView
        // myDataGridView - dataGridView to be populated
        public void populateDataGridView(DataGridView myDataGridView)
        {
            openConnection();

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(commandQuery);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            myDataGridView.DataSource = dataSet.Tables[0];

            closeConnection();

        }
    }
}
