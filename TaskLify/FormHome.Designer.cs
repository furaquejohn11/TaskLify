
namespace TaskLify
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMissed = new System.Windows.Forms.Button();
            this.btnOngoing = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlSide.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(182, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(882, 621);
            this.pnlBody.TabIndex = 4;
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(31)))), ((int)(((byte)(54)))));
            this.pnlSide.Controls.Add(this.panel2);
            this.pnlSide.Controls.Add(this.panel1);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(182, 621);
            this.pnlSide.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMissed);
            this.panel2.Controls.Add(this.btnOngoing);
            this.panel2.Controls.Add(this.btnFinished);
            this.panel2.Controls.Add(this.btnAll);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 240);
            this.panel2.TabIndex = 2;
            // 
            // btnMissed
            // 
            this.btnMissed.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMissed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMissed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMissed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(233)))));
            this.btnMissed.Location = new System.Drawing.Point(0, 172);
            this.btnMissed.Name = "btnMissed";
            this.btnMissed.Size = new System.Drawing.Size(182, 43);
            this.btnMissed.TabIndex = 4;
            this.btnMissed.Text = "Missed";
            this.btnMissed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMissed.UseVisualStyleBackColor = true;
            // 
            // btnOngoing
            // 
            this.btnOngoing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOngoing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOngoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOngoing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(233)))));
            this.btnOngoing.Location = new System.Drawing.Point(0, 129);
            this.btnOngoing.Name = "btnOngoing";
            this.btnOngoing.Size = new System.Drawing.Size(182, 43);
            this.btnOngoing.TabIndex = 3;
            this.btnOngoing.Text = "Ongoing";
            this.btnOngoing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOngoing.UseVisualStyleBackColor = true;
            // 
            // btnFinished
            // 
            this.btnFinished.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFinished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(233)))));
            this.btnFinished.Location = new System.Drawing.Point(0, 86);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(182, 43);
            this.btnFinished.TabIndex = 2;
            this.btnFinished.Text = "Finished";
            this.btnFinished.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinished.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(233)))));
            this.btnAll.Location = new System.Drawing.Point(0, 43);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(182, 43);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "All";
            this.btnAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(233)))));
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(182, 43);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 120);
            this.panel1.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(233)))));
            this.lblUsername.Location = new System.Drawing.Point(50, 51);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 621);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlSide);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.pnlSide.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMissed;
        private System.Windows.Forms.Button btnOngoing;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsername;
        public System.Windows.Forms.Panel pnlBody;
    }
}