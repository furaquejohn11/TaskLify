
namespace TaskLify
{
    partial class FormDisplayTask
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeadline = new System.Windows.Forms.Label();
            this.btnSaveDone = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(103, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(439, 29);
            this.txtTitle.TabIndex = 0;
            // 
            // txtDetails
            // 
            this.txtDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(45, 136);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(497, 265);
            this.txtDetails.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(41, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Deadline: ";
            // 
            // txtDeadline
            // 
            this.txtDeadline.AutoSize = true;
            this.txtDeadline.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeadline.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDeadline.Location = new System.Drawing.Point(134, 74);
            this.txtDeadline.Name = "txtDeadline";
            this.txtDeadline.Size = new System.Drawing.Size(78, 20);
            this.txtDeadline.TabIndex = 4;
            this.txtDeadline.Text = "Deadline: ";
            // 
            // btnSaveDone
            // 
            this.btnSaveDone.Location = new System.Drawing.Point(435, 438);
            this.btnSaveDone.Name = "btnSaveDone";
            this.btnSaveDone.Size = new System.Drawing.Size(107, 37);
            this.btnSaveDone.TabIndex = 5;
            this.btnSaveDone.Text = "MARK AS DONE";
            this.btnSaveDone.UseVisualStyleBackColor = true;
            this.btnSaveDone.Click += new System.EventHandler(this.btnSaveDone_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(41, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Details: ";
            // 
            // btnDelCancel
            // 
            this.btnDelCancel.Location = new System.Drawing.Point(322, 438);
            this.btnDelCancel.Name = "btnDelCancel";
            this.btnDelCancel.Size = new System.Drawing.Size(107, 37);
            this.btnDelCancel.TabIndex = 7;
            this.btnDelCancel.Text = "DELETE";
            this.btnDelCancel.UseVisualStyleBackColor = true;
            this.btnDelCancel.Click += new System.EventHandler(this.btnDelCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(209, 438);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 37);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FormDisplayTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(588, 503);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveDone);
            this.Controls.Add(this.txtDeadline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.txtTitle);
            this.MaximizeBox = false;
            this.Name = "FormDisplayTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDisplayTask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDisplayTask_FormClosing);
            this.Load += new System.EventHandler(this.FormDisplayTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtDeadline;
        private System.Windows.Forms.Button btnSaveDone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelCancel;
        private System.Windows.Forms.Button btnEdit;
    }
}