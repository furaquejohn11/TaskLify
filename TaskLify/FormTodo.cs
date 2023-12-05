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
            Panel panel = new Panel()
            {
                Size = new Size(181, 189),
                BackColor = Color.FromArgb(36, 43, 64)

            };

            Label titleLabel = new Label()
            {
                //Text = "Title " + x++.ToString(),
                Text = title ,
                Location = new Point(4, 10),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 12)
            };

            Label detailsLabel = new Label()
            {
                //Text = "Details",
                Text = details,
                Location = new Point(65, 53),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10)
            };
            /*Button btnEdit = new Button()
            {
                Text = "Ewan",
                Location = new Point(4, 163),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8)

            };

            Button btnView = new Button()
            {
                Text = "View",
                Location = new Point(103, 163),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8)

            };
            */
            
            flowLayoutPanel1.Controls.Add(panel);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(detailsLabel);
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
