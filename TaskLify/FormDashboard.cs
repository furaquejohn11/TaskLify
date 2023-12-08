using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Data.SQLite;
using TaskLify.Models;

namespace TaskLify
{
    public partial class FormDashboard : Form
    {
        private readonly string username;
        private const string connectionString = "Data Source = database.sqlite3";

        private List<TaskModel> tasks = new List<TaskModel>();
        public FormDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadTaskInfo();
            LoadTodayTask();
        }
        private void LoadTaskInfo()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT
                    (SELECT COUNT(*) FROM tblTask WHERE taskStatus = 'Finished' AND username = @username) AS FinishedCount,
                    (SELECT COUNT(*) FROM tblTask WHERE taskStatus = 'Ongoing' AND username = @username) AS OngoingCount,
                    (SELECT COUNT(*) FROM tblTask WHERE taskStatus = 'Missed' AND username = @username) AS MissedCount;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);


                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int finishedCount = Convert.ToInt32(reader["FinishedCount"]);
                            int ongoingCount = Convert.ToInt32(reader["OngoingCount"]);
                            int missedCount = Convert.ToInt32(reader["MissedCount"]);

                            txtFinish.Text = finishedCount.ToString();
                            txtMissed.Text = missedCount.ToString();
                            txtReminders.Text = ongoingCount.ToString();


                            // Calculate total count
                            int totalCount = finishedCount + ongoingCount + missedCount;

                            // Clear existing series in chart1
                            chart1.Series.Clear();

                            

                            // Create a new series
                            Series series = new Series("TaskStatus");
                            series.ChartType = SeriesChartType.Pie;

                            // Add data points to the series with percentage labels
                            series.Points.AddXY("Finished", GetPercentage(finishedCount, totalCount));
                            series.Points.AddXY("Ongoing", GetPercentage(ongoingCount, totalCount));
                            series.Points.AddXY("Missed", GetPercentage(missedCount, totalCount));

                            // Add the series to the existing chart1
                            chart1.Series.Add(series);

                            // Set chart properties for percentage display
                            chart1.Series["TaskStatus"].Label = "#PERCENT{P0}";
                            chart1.Series["TaskStatus"].LegendText = "#VALX";

                            // Refresh the chart
                            chart1.Refresh();
                        }
                    }
                }
            }
        }

        private double GetPercentage(int count, int total)
        {
            return (count * 100.0) / total;
        }

        private void LoadTodayTask()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblTask WHERE taskDate = @taskDate AND username = @username";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@taskDate", DateTime.Now.ToString("MM/dd/yyyy"));
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaskModel taskModel = new TaskModel()
                                {
                                    id = Convert.ToInt32(reader["taskId"]),
                                    title = reader["taskTitle"].ToString(),
                                    date = reader["taskDate"].ToString(),
                                    status = reader["taskStatus"].ToString(),
                                    details = reader["taskDetails"].ToString()
                                };
                                tasks.Add(taskModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadList();
            }
            
        }

        private void LoadList()
        {
            foreach (var task in tasks)
            {
                dataGridView1.Rows.Add(task.title, task.details, task.status);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null && e.Value.ToString() == "Finished")
            {
                // Set the ForeColor for the specific cell in the "Status" column
                e.CellStyle.ForeColor = Color.Green; // Change the color as needed
            }
        }
    }
}
