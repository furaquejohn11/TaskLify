﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


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

                    string query = "INSERT INTO tblTask (username, taskTitle,taskDate,taskStatus, taskDetails) " +
                        "VALUES (@username, @taskTitle, @taskDate, @taskStatus, @taskDetails)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        string deadline = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@taskTitle", txtTitle.Text);
                        command.Parameters.AddWithValue("@taskDate", deadline);
                        command.Parameters.AddWithValue("@taskStatus", CheckIfMissed(deadline));
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
                var home = Application.OpenForms.OfType<FormHome>().FirstOrDefault();

                if (home != null)
                {
                    home.ReloadFormTodo();
                }
                this.Close();
            }
            
        }
        private string CheckIfMissed(string date)
        {
            var deadline = DateTime.ParseExact(date, "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);

            TimeSpan difference = deadline - DateTime.Now.Date;
            MessageBox.Show(difference.TotalDays.ToString());

            return (difference.TotalDays >= 0) ? "Ongoing" : "Missed";
        }

        private void FormAddTask_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
