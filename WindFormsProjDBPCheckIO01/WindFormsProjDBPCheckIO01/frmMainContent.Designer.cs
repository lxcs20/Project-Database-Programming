
namespace WindFormsProjDBPCheckIO01
{
    partial class frmMainContent
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labdate = new System.Windows.Forms.Label();
            this.labtime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans Lao Medium", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(232, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "ລະບົບບັນທຶກ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans Lao Medium", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(102, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(579, 74);
            this.label2.TabIndex = 1;
            this.label2.Text = "ການເຂົ້າ-ອອກວຽກ ແລະ ລາວຽກ";
            // 
            // labdate
            // 
            this.labdate.AutoSize = true;
            this.labdate.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labdate.ForeColor = System.Drawing.Color.White;
            this.labdate.Location = new System.Drawing.Point(266, 224);
            this.labdate.Name = "labdate";
            this.labdate.Size = new System.Drawing.Size(76, 40);
            this.labdate.TabIndex = 30;
            this.labdate.Text = "date";
            this.labdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labtime
            // 
            this.labtime.AutoSize = true;
            this.labtime.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labtime.ForeColor = System.Drawing.Color.White;
            this.labtime.Location = new System.Drawing.Point(277, 184);
            this.labtime.Name = "labtime";
            this.labtime.Size = new System.Drawing.Size(78, 40);
            this.labtime.TabIndex = 31;
            this.labtime.Text = "time";
            this.labtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMainContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(743, 389);
            this.Controls.Add(this.labdate);
            this.Controls.Add(this.labtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainContent";
            this.Text = "frmMainContent";
            this.Load += new System.EventHandler(this.frmMainContent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labdate;
        private System.Windows.Forms.Label labtime;
        private System.Windows.Forms.Timer timer;
    }
}