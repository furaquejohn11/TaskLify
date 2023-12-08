using System;
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
        private string selectedMenu;
        public FormAddTask(string username, string selectedMenu)
        {
            InitializeComponent();
            this.username = username;
            this.selectedMenu = selectedMenu;
        }

        private void FormAddTask_Load(object sender, EventArgs e)
        {

        }

        private bool CheckValues()
        {
            return String.IsNullOrEmpty(txtTitle.Text) || String.IsNullOrEmpty(txtDetails.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                this.Close();
            }
            
        }
        private string CheckIfMissed(string date)
        {
            var deadline = DateTime.ParseExact(date, "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);

            TimeSpan difference = deadline - DateTime.Now.Date;

            return (difference.TotalDays >= 0) ? "Ongoing" : "Missed";
        }

        private void FormAddTask_FormClosing(object sender, FormClosingEventArgs e)
        {
           
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
