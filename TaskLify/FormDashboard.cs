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
using System.Data.SQLite;

namespace TaskLify
{
    public partial class FormDashboard : Form
    {
        private readonly string username;
        private const string connectionString = "Data Source = database.sqlite3";
        public FormDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadTaskInfo();
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
    }
}
