using System;
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
using System.Globalization;

namespace TaskLify
{
    public partial class FormDisplayTask : Form
    {
        private readonly string username;
        private const string connectionString = "Data Source = database.sqlite3";


        private bool isView = true;
        private string selectedMenu;
        public TaskModel tasks { get; set; }

        public FormDisplayTask(string username, string selectedMenu)
        {
            InitializeComponent();
            this.username = username;
            this.selectedMenu = selectedMenu;
        }

        private void FormDisplayTask_Load(object sender, EventArgs e)
        {
            LoadTaskInfo();
            ViewMode();
        }
        private void LoadTaskInfo()
        {
            txtTitle.Text = tasks.title;

            var dateTime = DateTime.ParseExact(tasks.date, "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
            dateTimePicker1.Value = dateTime;

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
            btnSaveDone.Text = (tasks.status == "Finished") ? "MARK AS UNDONE" : "MARK AS DONE";
            //btnSaveDone.Enabled = (tasks.status == "Finished") ? false : true;
            btnEdit.Enabled = (tasks.status == "Finished") ? false : true;
            txtTitle.Enabled = false;
            txtDetails.Enabled = false;
            dateTimePicker1.Enabled = false;

            btnUndo.Visible = false;
            btnRedo.Visible = false;
        }
        private void MarkDone()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE tblTask SET taskStatus =  @taskStatus " +
                        "WHERE username = @username AND taskId = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@id", tasks.id);
                        command.Parameters.AddWithValue("@taskStatus", "Finished");

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
        private void MarkUndone()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE tblTask SET taskStatus =  @taskStatus " +
                        "WHERE username = @username AND taskId = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        string date = dateTimePicker1.Value.ToString("MM/dd/yyyy");

                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@id", tasks.id);
                        command.Parameters.AddWithValue("@taskStatus", CheckIfMissed(date));

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
        private void EditMode()
        {
            //btnSaveDone.Enabled = true;
            btnEdit.Visible = false;
            btnDelCancel.Text = "CANCEL";
            btnSaveDone.Text = "SAVE CHANGES";
            txtTitle.Enabled = true;
            txtDetails.Enabled = true;
            dateTimePicker1.Enabled = true;

            btnUndo.Visible = true;
            btnRedo.Visible = true;
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
                if (btnSaveDone.Text == "MARK AS DONE")
                {
                    MarkDone();
                    MessageBox.Show("Task Completed");
                }
                else if (btnSaveDone.Text == "MARK AS UNDONE")
                {
                    MarkUndone();
                    MessageBox.Show("Task Undone");
                }
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
        private bool CheckValues()
        {
            return String.IsNullOrEmpty(txtTitle.Text) || String.IsNullOrEmpty(txtDetails.Text);
        }
        private void UpdateTask()
        {
            if (CheckValues())
            {
                MessageBox.Show("Fill empty text boxes!");
                return;
            }

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE tblTask SET taskTitle = @taskTitle, taskDate = @taskDate, taskDetails = @taskDetails, taskStatus = @taskStatus " +
                        "WHERE username = @username AND taskId = @id";

                    using (var command = new SQLiteCommand(query,connection))
                    {
                        string date = dateTimePicker1.Value.ToString("MM/dd/yyyy");

                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@id", tasks.id);
                        command.Parameters.AddWithValue("@taskTitle", txtTitle.Text);
                        command.Parameters.AddWithValue("@taskStatus", CheckIfMissed(date));
                        command.Parameters.AddWithValue("@taskDetails", txtDetails.Text);
                        command.Parameters.AddWithValue("@taskDate", date);

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
        private string CheckIfMissed(string date)
        {
            var deadline = DateTime.ParseExact(date, "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);

            TimeSpan difference = deadline - DateTime.Now.Date;

            return (difference.TotalDays >= 0) ? "Ongoing" : "Missed";
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
                switch (selectedMenu)
                {
                    case "ALL":
                        home.ReloadFormTodo();
                        break;
                    case "FINISHED":
                        home.ReloadFormFinished();
                        break;
                    case "ONGOING":
                        home.ReloadFormOngoing();
                        break;
                    case "MISSED":
                        home.ReloadFormMissed();
                        break;
                    default:
                        home.ReloadFormTodo();
                        break;
                }
            }
        }

        private Stack<string> undoStack = new Stack<string>();
        private Stack<string> redoStack = new Stack<string>();

        private void txtDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Push the current state onto the undo stack
            undoStack.Push(txtDetails.Text);

            // Clear the redo stack since we're starting a new change
            redoStack.Clear();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 1)
            {
                // Pop the current state from undo stack and push onto redo stack
                redoStack.Push(undoStack.Pop());

                // Set the TextBox text to the previous state
                txtDetails.Text = undoStack.Peek();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                // Pop the top of the redo stack and push onto undo stack
                undoStack.Push(redoStack.Pop());

                // Set the TextBox text to the redo state
                txtDetails.Text = undoStack.Peek();
            }
        }

        
    }
}
