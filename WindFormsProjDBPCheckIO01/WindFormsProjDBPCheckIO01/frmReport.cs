using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindFormsProjDBPCheckIO01
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        
        private SqlConnection connection;
        public SqlCommand command;
        public DataSet data;
        public SqlDataAdapter adapter;
        public string sql;
        public BindingSource bindingsrc;
        private void frmReport_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";

            connection = new SqlConnection(constr);
            connection.Open();
            
        }

        private void btnRpLeave_Click(object sender, EventArgs e)
        {
            DataLeave();
            Activebtn(btnRpLeave);
        }
        private void DataLeave()
        {
            if (dataGRpContent.DataSource != null)
            {
                dataGRpContent.DataSource = null;
            }
            string dl, ml, yl, da, ma, ya;
            string datefrom, dateto;
            da = dtpFrom.Value.Day.ToString();
            ma = dtpFrom.Value.Month.ToString();
            ya = dtpFrom.Value.Year.ToString();
            datefrom = Convert.ToString(ya + '/' + ma + '/' + da );
            ml = dtpTo.Value.Month.ToString();
            dl = dtpTo.Value.Day.ToString();
            yl = dtpTo.Value.Year.ToString();
            dateto = Convert.ToString(yl + '/' + ml + '/' + dl);

            sql = @"SELECT emID, emFirstName, emLastName, lwDate, approver FROM LeaveWork
                    WHERE lwDate BETWEEN @from AND @to";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@from", datefrom);
            command.Parameters.AddWithValue("@to", dateto);
            adapter = new SqlDataAdapter(command);
            data = new DataSet();
            adapter.Fill(data, "leave");

            dataGRpContent.DataSource = data.Tables["leave"];

            dataGRpContent.Columns["emID"].HeaderText = "ລະຫັດ";
            dataGRpContent.Columns["emFirstName"].HeaderText = "ຊື່";
            dataGRpContent.Columns["emLastName"].HeaderText = "ນາມສະກຸນ";
            dataGRpContent.Columns["lwDate"].HeaderText = "ວັນລາພັກ";
            dataGRpContent.Columns["approver"].HeaderText = "ຜູ້ອະນຸຍາດ";

        }

        private void btnRpOut_Click(object sender, EventArgs e)
        {
            if(dataGRpContent.DataSource != null)
            {
                dataGRpContent.DataSource = null;
            }
            DataCheckOut();
            Activebtn(btnRpOut);
        }
        private void DataCheckOut()
        {
            string dl, ml, yl, da, ma, ya;
            string datefrom, dateto;
            da = dtpFrom.Value.Day.ToString();
            ma = dtpFrom.Value.Month.ToString();
            ya = dtpFrom.Value.Year.ToString();
            datefrom = Convert.ToString(ya + '/' + ma + '/' + da);
            ml = dtpTo.Value.Month.ToString();
            dl = dtpTo.Value.Day.ToString();
            yl = dtpTo.Value.Year.ToString();
            dateto = Convert.ToString(yl + '/' + ml + '/' + dl);

            sql = @"SELECT emID, emFirstName, emLastName, coDate, coTime FROM CheckOut
                    WHERE coDate BETWEEN @from AND @to";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@from", datefrom);
            command.Parameters.AddWithValue("@to", dateto);
            adapter = new SqlDataAdapter(command);
            data = new DataSet();
            adapter.Fill(data, "leave");

            dataGRpContent.DataSource = data.Tables["leave"];

            dataGRpContent.Columns["emID"].HeaderText = "ລະຫັດ";
            dataGRpContent.Columns["emFirstName"].HeaderText = "ຊື່";
            dataGRpContent.Columns["emLastName"].HeaderText = "ນາມສະກຸນ";
            dataGRpContent.Columns["coDate"].HeaderText = "ວັນທີ";
            dataGRpContent.Columns["coTime"].HeaderText = "ເວລາ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGRpContent.DataSource != null)
            {
                dataGRpContent.DataSource = null;
            }
            DataCheckIn();
            Activebtn(btnCheckIn);
        }
        private void DataCheckIn()
        {
            string dl, ml, yl, da, ma, ya;
            string datefrom, dateto;
            da = dtpFrom.Value.Day.ToString();
            ma = dtpFrom.Value.Month.ToString();
            ya = dtpFrom.Value.Year.ToString();
            datefrom = Convert.ToString(ya + '/' + ma + '/' + da);
            ml = dtpTo.Value.Month.ToString();
            dl = dtpTo.Value.Day.ToString();
            yl = dtpTo.Value.Year.ToString();
            dateto = Convert.ToString(yl + '/' + ml + '/' + dl);

            sql = @"SELECT emID, emFirstName, emLastName, ciDate, ciTime FROM CheckIn
                    WHERE ciDate BETWEEN @from AND @to";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@from", datefrom);
            command.Parameters.AddWithValue("@to", dateto);
            adapter = new SqlDataAdapter(command);
            data = new DataSet();
            adapter.Fill(data, "leave");

            dataGRpContent.DataSource = data.Tables["leave"];

            dataGRpContent.Columns["emID"].HeaderText = "ລະຫັດ";
            dataGRpContent.Columns["emFirstName"].HeaderText = "ຊື່";
            dataGRpContent.Columns["emLastName"].HeaderText = "ນາມສະກຸນ";
            dataGRpContent.Columns["ciDate"].HeaderText = "ວັນທີ";
            dataGRpContent.Columns["ciTime"].HeaderText = "ເວລາ";

        }

        private Button Currentbtn;
        private void Activebtn(Button btn)
        {
            if (Currentbtn != null)
            {
                Currentbtn.BackColor = SystemColors.ActiveCaption;
            }
            Currentbtn = btn;
            Currentbtn.BackColor = SystemColors.Highlight;
        }
    }
}
