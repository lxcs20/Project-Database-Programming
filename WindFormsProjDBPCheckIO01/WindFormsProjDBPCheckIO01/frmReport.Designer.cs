
namespace WindFormsProjDBPCheckIO01
{
    partial class frmReport
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
            this.dataGRpContent = new System.Windows.Forms.DataGridView();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnRpOut = new System.Windows.Forms.Button();
            this.btnRpLeave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRpContent)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGRpContent
            // 
            this.dataGRpContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGRpContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGRpContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRpContent.Location = new System.Drawing.Point(111, 37);
            this.dataGRpContent.Name = "dataGRpContent";
            this.dataGRpContent.ReadOnly = true;
            this.dataGRpContent.RowTemplate.Height = 25;
            this.dataGRpContent.Size = new System.Drawing.Size(479, 259);
            this.dataGRpContent.TabIndex = 1;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Noto Sans Lao", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCheckIn.Location = new System.Drawing.Point(111, 4);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(61, 29);
            this.btnCheckIn.TabIndex = 2;
            this.btnCheckIn.Text = "ເຂົ້າວຽກ";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRpOut
            // 
            this.btnRpOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRpOut.FlatAppearance.BorderSize = 0;
            this.btnRpOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpOut.Font = new System.Drawing.Font("Noto Sans Lao", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRpOut.Location = new System.Drawing.Point(176, 4);
            this.btnRpOut.Name = "btnRpOut";
            this.btnRpOut.Size = new System.Drawing.Size(61, 29);
            this.btnRpOut.TabIndex = 3;
            this.btnRpOut.Text = "ອອກວຽກ";
            this.btnRpOut.UseVisualStyleBackColor = false;
            this.btnRpOut.Click += new System.EventHandler(this.btnRpOut_Click);
            // 
            // btnRpLeave
            // 
            this.btnRpLeave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRpLeave.FlatAppearance.BorderSize = 0;
            this.btnRpLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpLeave.Font = new System.Drawing.Font("Noto Sans Lao", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRpLeave.Location = new System.Drawing.Point(241, 4);
            this.btnRpLeave.Name = "btnRpLeave";
            this.btnRpLeave.Size = new System.Drawing.Size(61, 29);
            this.btnRpLeave.TabIndex = 4;
            this.btnRpLeave.Text = "ລາພັກ";
            this.btnRpLeave.UseVisualStyleBackColor = false;
            this.btnRpLeave.Click += new System.EventHandler(this.btnRpLeave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans Lao", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(-2, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "ຈາກ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans Lao", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(-4, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "ຫາ";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(2, 112);
            this.dtpTo.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(103, 23);
            this.dtpTo.TabIndex = 9;
            this.dtpTo.Value = new System.DateTime(2022, 7, 20, 18, 20, 40, 0);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(2, 61);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(103, 23);
            this.dtpFrom.TabIndex = 10;
            this.dtpFrom.Value = new System.DateTime(2022, 7, 1, 0, 0, 0, 0);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 351);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRpLeave);
            this.Controls.Add(this.btnRpOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.dataGRpContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGRpContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGRpContent;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnRpOut;
        private System.Windows.Forms.Button btnRpLeave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}