using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindFormsProjDBPCheckIO01
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labTitle.Text = "";
            Activebtn(btnMainFrm);
            OpenChildForm(new frmMainContent());
            labdate.Hide();
            labtime.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCheckIn());
            Activebtn(btnChekINFrm);
            labTitle.Text = "ລົງຊື່ເຂົ້າວຽກ";
            labdate.Show();
            labtime.Show();
        }

        private void btnEmployeesFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmEmployee());
            Activebtn(btnEmployeesFrm);
            labTitle.Text = "ຈັດການຂໍ້ມູນພະນັກງານ";
            labdate.Show();
            labtime.Show();
        }

        private void btnReportFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReport());
            Activebtn(btnReportFrm);
            labTitle.Text = "ລາຍງານ";
            labdate.Show();
            labtime.Show();
        }

        private void btnAdminFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAdmin());
            Activebtn(btnAdminFrm);
            labTitle.Text = "ຈັດການຂໍ້ມູນຜູ້ດູແລະບົບ";
            labdate.Show();
            labtime.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ທ່ານຕ້ອງການອອກຈາກໂປຣແກຣມບໍ?", "ຢືນຢັນ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            labUserLogin.Text = FrmLogin.userName;
            btnMainFrm.PerformClick();
        }

        private void btnCheckOUTFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCheckOut());
            Activebtn(btnCheckOUTFrm);
            labTitle.Text = "ລົງຊື່ເລີກວຽກ";
            labdate.Show();
            labtime.Show();
        }

        private void btnLeaveFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmLeave());
            Activebtn(btnLeaveFrm);
            labTitle.Text = "ລາພັກ";
            labdate.Show();
            labtime.Show();
        }

        private void timerNow_Tick(object sender, EventArgs e)
        {
            labdate.Text = DateTime.Now.ToShortDateString();
            labtime.Text = DateTime.Now.ToLongTimeString();
        }
        private Button Currentbtn;
        private void Activebtn(Button btn)
        {
            if (Currentbtn != null)
            {
                Currentbtn.BackColor = SystemColors.Window;
            }
            Currentbtn = btn;
            Currentbtn.BackColor = SystemColors.ControlLight;
        }
    }
}
