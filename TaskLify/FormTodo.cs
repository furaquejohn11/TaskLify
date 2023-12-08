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
    public partial class FormTodo : Form
    {
        private const string connectionString = "Data Source = database.sqlite3";
        private List<TaskModel> taskList = new List<TaskModel>();


        private readonly string username;
        private string selectedMenu;
        public FormTodo(string username, string selectedMenu)
        {
            InitializeComponent();

            //TaskModel t = new TaskModel();
            // TaskController taskController = new TaskController(username);
            //foreach (var task in taskController.tasks)
            //{
            //    GenerateTaskBlocks(task.title, task.details);
            // }

            this.username = username;
            this.selectedMenu = selectedMenu;
        }
        private void FormTodo_Load(object sender, EventArgs e)
        {
            LoadTask();
        }
        private string SetQuery()
        {
            switch(selectedMenu)
            {
                case "ALL":
                    return "SELECT * FROM tblTask WHERE username = @username";
                case "FINISHED":
                    return "SELECT * FROM tblTask WHERE username = @username AND taskStatus = 'Finished'";
                case "ONGOING":
                    return "SELECT * FROM tblTask WHERE username = @username AND taskStatus = 'Ongoing'";
                case "MISSED":
                    return "SELECT * FROM tblTask WHERE username = @username AND taskStatus = 'Missed'";
                default:
                    return "SELECT * FROM tblTask WHERE username = @username";
            }
        }
        private void LoadTask()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = SetQuery();
                    
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                if (IsMissed(reader["taskDate"].ToString()) && 
                                    reader["taskStatus"].ToString() != "Finished")
                                {
                                    UpdateMissedTask(Convert.ToInt32(reader["taskId"]), connection);
                                }

                                TaskModel taskModel = new TaskModel()
                                {
                                    id = Convert.ToInt32(reader["taskId"]),
                                    title = reader["taskTitle"].ToString(),
                                    date = reader["taskDate"].ToString(),
                                    status = reader["taskStatus"].ToString(),
                                    details = reader["taskDetails"].ToString()
                                };
                                taskList.Add(taskModel);
                            }
                            
                            /*
                            else
                            {
                                TaskModel taskModel = new TaskModel()
                                {
                                    title = "Title",
                                    date = DateTime.Now.ToString("MM/dd/yyyy HH:mm"),
                                    status = "N/A",
                                    details = " Details"
                                };
                                taskList.Add(taskModel);
                            }
                            */
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                LoadTaskList();
            }
            
        }
        private bool IsMissed(string date)
        {
            var deadline = DateTime.ParseExact(date, "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);

            TimeSpan difference = deadline - DateTime.Now.Date;
            return difference.TotalDays < 0;
        }

        private void UpdateMissedTask(int id, SQLiteConnection connection)
        {
            try
            {
               
                string query = "UPDATE tblTask SET taskStatus =  @taskStatus " +
                    "WHERE username = @username AND taskId = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@taskStatus", "Missed");

                    //MessageBox.Show(command.CommandText);

                    command.ExecuteNonQuery();

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void LoadTaskList()
        {
            foreach (var tasks in taskList)
            {
                GenerateTaskBlocks(tasks);
            }
        }

        
        private void GenerateTaskBlocks(TaskModel tasks)
        {
            //string t = title + count++.ToString();


            // Main Panel
            Panel panel = new Panel()
            {
                Size = new Size(208, 220),
                BackColor = Color.FromArgb(36, 43, 64)
            };

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(0)
            };

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            Panel topPanel = new Panel()
            {
                Size = new Size(208, 56),
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(26, 33, 54),
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            Panel mainPanel = new Panel()
            {
                BackColor = Color.FromArgb(36, 43, 64),
                Padding = new Padding(0),
                Margin = new Padding(0),
                Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };

            Label titleLabel = new Label()
            {
                Text = tasks.title,
                Location = new Point(3, 5),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold)
            };

            Label dateLabel = new Label()
            {
                Text = tasks.date,
                Location = new Point(3, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.75f)
            };

            Label statusLabel = new Label()
            {
                Text = tasks.status,
                Location = new Point(151, 5),
                ForeColor = SetStatusColor(tasks.status),
                Font = new Font("Segoe UI", 8),
                
            };

            Label detailsLabel = new Label()
            {
                Text = tasks.details,
                //Location = new Point(5, 5),
                AutoSize = false,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8)
            };
            

            flowLayoutPanel1.Controls.Add(panel);
            panel.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.Controls.Add(topPanel, 0, 0);
            tableLayoutPanel.Controls.Add(mainPanel, 0, 1);
            topPanel.Controls.Add(titleLabel);
            topPanel.Controls.Add(dateLabel);
            topPanel.Controls.Add(statusLabel);
            mainPanel.Controls.Add(detailsLabel);


         
            // Displaying details of tasks
            void DisplayInfo()
            {
                var displayTask = new FormDisplayTask(username, selectedMenu)
                {
                    tasks = tasks
                };
                displayTask.ShowDialog();
            }
            panel.Click += (btnSender, btnE) =>  DisplayInfo();
            tableLayoutPanel.Click += (btnSender, btnE) => DisplayInfo();
            topPanel.Click += (btnSender, btnE) => DisplayInfo();
            titleLabel.Click += (btnSender, btnE) => DisplayInfo();
            mainPanel.Click += (btnSender, btnE) => DisplayInfo();
            detailsLabel.Click += (btnSender, btnE) => DisplayInfo();
            dateLabel.Click += (btnSender, btnE) => DisplayInfo();
            statusLabel.Click += (btnSender, btnE) => DisplayInfo();

        }
        private Color SetStatusColor(string title)
        {
            switch (title)
            {
                case "Ongoing":
                    return Color.White;
                case "Finished":
                    return Color.Green;
                case "Missed":
                    return Color.Red;
                default:
                    return Color.Yellow;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addTask = new FormAddTask(username,selectedMenu);
            addTask.ShowDialog();
        }

       
    }
}
