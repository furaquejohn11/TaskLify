using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLify
{
    public partial class FormTodo : Form
    {
        public FormTodo()
        {
            InitializeComponent();

            //TaskModel t = new TaskModel();
           // TaskController taskController = new TaskController(username);
            //foreach (var task in taskController.tasks)
            //{
            //    GenerateTaskBlocks(task.title, task.details);
           // }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateTaskBlocks();
        }
        static int count = 1;
        private void GenerateTaskBlocks(string title = "Title ", string details = "details")
        {
            string t = title + count++.ToString();
            Panel panel = new Panel()
            {
                Size = new Size(181, 189),
                BackColor = Color.FromArgb(36, 43, 64)

            };

            Label titleLabel = new Label()
            {
                //Text = "Title " + x++.ToString(),
                Text = t ,
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
                    title = t
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
    }
}
