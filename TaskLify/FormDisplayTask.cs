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

namespace TaskLify
{
    public partial class FormDisplayTask : Form
    {
        private readonly string username;
        public TaskModel tasks { get; set; }
        public FormDisplayTask(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FormDisplayTask_Load(object sender, EventArgs e)
        {
            LoadTaskInfo();
        }
        private void LoadTaskInfo()
        {
            txtTitle.Text = tasks.title;
            txtDeadline.Text = tasks.date;
            txtDetails.Text = tasks.details;
        }
    }
}
