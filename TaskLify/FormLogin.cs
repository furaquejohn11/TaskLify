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

namespace TaskLify
{
    public partial class FormLogin : Form
    {
        private const string connectionString = "Data Source = database.sqlite3";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateAccount(txtUsername.Text, txtPassword.Text))
            {
                var home = new FormHome(txtUsername.Text);
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong");
            }
        }
        private bool ValidateAccount(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblAccounts WHERE username = @username AND password = @password";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            return reader.Read();
                        }
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
