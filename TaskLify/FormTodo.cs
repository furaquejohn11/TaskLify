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
    public partial class FormTodo : Form
    {
        private const string connectionString = "Data Source = database.sqlite3";
        private List<TaskModel> taskList = new List<TaskModel>();


        private readonly string username;
        public FormTodo(string username)
        {
            InitializeComponent();

            //TaskModel t = new TaskModel();
            // TaskController taskController = new TaskController(username);
            //foreach (var task in taskController.tasks)
            //{
            //    GenerateTaskBlocks(task.title, task.details);
            // }

            this.username = username;
        }
        private void FormTodo_Load(object sender, EventArgs e)
        {
            LoadTask();
        }
        private void LoadTask()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblTask WHERE username = @username";
                    
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                while (reader.Read())
                                {
                                    TaskModel taskModel = new TaskModel()
                                    {
                                        title = reader["taskTitle"].ToString(),
                                        details = reader["taskDetails"].ToString()
                                    };
                                    taskList.Add(taskModel);
                                }
                            }
                            else
                            {
                                TaskModel taskModel = new TaskModel()
                                {
                                    title = "Title",
                                    details = " Details"
                                };
                                taskList.Add(taskModel);
                            }
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
        private void LoadTaskList()
        {
            foreach (var tasks in taskList)
            {
                GenerateTaskBlocks(tasks.title, tasks.details);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateTaskBlocks();
        }
        
        private void GenerateTaskBlocks(string title = "Title ", string details = "details")
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
                Text = title,
                Location = new Point(3, 5),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold)
            };

            Label dateLabel = new Label()
            {
                Text = "10/15/2024",
                Location = new Point(3, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.75f)
            };

            Label statusLabel = new Label()
            {
                Text = "Ongoing",
                Location = new Point(151, 5),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8),
                
            };

            Label detailsLabel = new Label()
            {
                Text = details,
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


            //panel.Controls.Add(btnEdit);
            //panel.Controls.Add(btnView);


            void DisplayInfo()
            {
                var displayTask = new FormDisplayTask()
                {
                    title = title
                };
                displayTask.ShowDialog();
            }
            panel.Click += (btnSender, btnE) =>
            {
                DisplayInfo();
            };
            titleLabel.Click += (btnSender, btnE) =>
            {
                DisplayInfo();
            };
            detailsLabel.Click += (btnSender, btnE) =>
            {
                DisplayInfo();
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addTask = new FormAddTask(username);
            addTask.ShowDialog();
        }

       
    }
}
