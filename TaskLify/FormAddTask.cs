using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SQLite;
using TaskLify.Models;

namespace TaskLify
{
    public partial class FormAddTask : Form
    {
        private const string connectionString = "Data Source = database.sqlite3";
        private List<TaskModel> taskList = new List<TaskModel>();

        private readonly string username;
        public FormAddTask(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FormAddTask_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO tblTask (username, taskTitle, taskDetails) VALUES (@username, @taskTitle, @taskDetails)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@taskTitle", txtTitle.Text);
                        command.Parameters.AddWithValue("@taskDetails", txtDetails.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Add Task Success");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
            
        }

        private void FormAddTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            var home = Application.OpenForms.OfType<FormHome>().FirstOrDefault();

            if (home != null)
            {
                home.ReloadFormTodo();
            }
        }
    }
}
