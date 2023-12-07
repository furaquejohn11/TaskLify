﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaskLify.Models;
using System.Data.SQLite;

namespace TaskLify
{
    public partial class FormDisplayTask : Form
    {
        private readonly string username;
        private const string connectionString = "Data Source = database.sqlite3";


        private bool isView = true;
        public TaskModel tasks { get; set; }

        public FormDisplayTask(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FormDisplayTask_Load(object sender, EventArgs e)
        {
            LoadTaskInfo();
            ViewMode();
        }
        private void LoadTaskInfo()
        {
            txtTitle.Text = tasks.title;
            txtDeadline.Text = tasks.date;
            txtDetails.Text = tasks.details;
        }
 
        private void LoadMode()
        {         
            if (isView)
                ViewMode();
            else
                EditMode();


        }
        private void ViewMode()
        {
            btnEdit.Visible = true;
            btnDelCancel.Text = "DELETE";
            btnSaveDone.Text = "MARK AS DONE";
            txtTitle.Enabled = false;
            txtDetails.Enabled = false;
        }
        private void EditMode()
        {
            btnEdit.Visible = false;
            btnDelCancel.Text = "CANCEL";
            btnSaveDone.Text = "SAVE CHANGES";
            txtTitle.Enabled = true;
            txtDetails.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isView = false;
            LoadMode();
             
        }

        private void btnDelCancel_Click(object sender, EventArgs e)
        {
            if (isView)
            {
                DeleteTask();
                MessageBox.Show("You deleted an item");
                this.Close();
            }
            else
            {
                MessageBox.Show("Item Canceled");
            }

            isView = btnDelCancel.Text == "DELETE" ? false : true;
            LoadMode();
            

        }
        private void btnSaveDone_Click(object sender, EventArgs e)
        {
            if (isView)
            {
                MessageBox.Show("Mark as done");
            }
            else
            {
                
                UpdateTask();
                MessageBox.Show("Save success");
            }
            //isView = btnDelCancel.Text == "MARK AS DONE" ? false : true;
            //LoadMode();
            this.Close();

        }
        private void UpdateTask()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE tblTask SET taskTitle = @taskTitle, taskDetails = @taskDetails " +
                        "WHERE username = @username AND taskId = @id";

                    using (var command = new SQLiteCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@id", tasks.id);
                        command.Parameters.AddWithValue("@taskTitle", txtTitle.Text);
                        command.Parameters.AddWithValue("@taskDetails", txtDetails.Text);

                        //MessageBox.Show(command.CommandText);

                        command.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void DeleteTask()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM tblTask WHERE username = @username AND taskId = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@id", tasks.id);

                        //MessageBox.Show(command.CommandText);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void FormDisplayTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            var home = Application.OpenForms.OfType<FormHome>().FirstOrDefault();

            if (home != null)
            {
                home.ReloadFormTodo();
            }
        }
    }
}
