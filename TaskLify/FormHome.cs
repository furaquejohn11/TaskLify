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
        public FormHome()
        {
            InitializeComponent();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDashboard());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTodo());
        }
    }
}
