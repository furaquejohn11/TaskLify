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
    public partial class FormHome : Form
    {
        private readonly string username;
        public FormHome(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            openChildForm(new FormDashboard());
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public static Form currentForm = null;
        /// <summary>
        /// Display forms in other panel
        /// </summary>
        /// <param name="childForm"></param>
        public void openChildForm(Form childForm)
        {
            try
            {
                // Check if there's a form in panel
                if (currentForm != null) currentForm.Close();

                // Setting up the panel
                currentForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnlBody.Controls.Add(childForm);
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static void ShowFormInPanel(Form form, Panel panel)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Show();
        }
        public void ReloadFormTodo()
        {
            openChildForm(new FormTodo(username, "ALL"));
        }
        public void ReloadFormFinished()
        {
            openChildForm(new FormTodo(username, "FINISHED"));
        }
        public void ReloadFormOngoing()
        {
            openChildForm(new FormTodo(username, "ONGOING"));
        }
        public void ReloadFormMissed()
        {
            openChildForm(new FormTodo(username, "MISSED"));
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDashboard());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTodo(username, "ALL"));
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTodo(username, "FINISHED"));
        }

        private void btnOngoing_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTodo(username, "ONGOING"));
        }

        private void btnMissed_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTodo(username, "MISSED"));
        }
    }
}
