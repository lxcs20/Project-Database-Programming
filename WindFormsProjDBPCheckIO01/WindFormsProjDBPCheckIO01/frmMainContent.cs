using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindFormsProjDBPCheckIO01
{
    public partial class frmMainContent : Form
    {
        public frmMainContent()
        {
            InitializeComponent();
        }

        

        private void frmMainContent_Load(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labdate.Text = DateTime.Now.ToShortDateString();
            labtime.Text = DateTime.Now.ToLongTimeString();
        }
    }
    
}
