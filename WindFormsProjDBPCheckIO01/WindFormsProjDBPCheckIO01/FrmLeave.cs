using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindFormsProjDBPCheckIO01
{
    public partial class FrmLeave : Form
    {
        public FrmLeave()
        {
            InitializeComponent();
        }
        private SqlConnection connection;
        public SqlCommand command;
        public DataSet data;
        public SqlDataAdapter adapter;
        public string sql;
        public BindingSource bindingsrc;


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLeave_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";

            connection = new SqlConnection(constr);
            connection.Open();
            txtAppr.Text = FrmLogin.userName;
        }

        private void SelectEmp()
        {
            sql = "Select emFirstName, emLastName, photo From tbEmployees where emID = " + txtID.Text;

            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            data = new DataSet();
            adapter.Fill(data, "emp");

            DataTable table = data.Tables["emp"];
            DataRow rows = table.Rows[0];
            txtFirstName.Text = rows["emFirstName"].ToString();
            txtLastName.Text = rows["emLastName"].ToString();

            byte[] imgByte = (byte[])rows["Photo"];
            MemoryStream memStream = new MemoryStream(imgByte);
            picboxEmp.Image = Image.FromStream(memStream);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            int x;
            if (!int.TryParse(txtID.Text, out x))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດພະນັກງານທີ່ເປັນຕົວເລກ");
                TextClear();
                return;
            }
            try
            {
                SelectEmp();
            }
            catch
            {
                TextClear();
            }
        }

        private void TextClear()
        {
            txtID.Clear();
            txtDescr.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            picboxEmp.Image = null;
        }
        private void FrmLeave_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("ກະລຸນາໃສ່ລະຫັດພະນັກງານ");
                return;
            }
            InsertLeave();
            TextClear();
            txtID.Focus();
        }
        private void InsertLeave()
        {
            string dl, ml, yl, da, ma, ya, ha, mia;
            string dateAppr, lwdate;
            da = DateTime.Now.Day.ToString();
            ma = DateTime.Now.Month.ToString();
            ya = DateTime.Now.Year.ToString();
            ha = DateTime.Now.Hour.ToString();
            mia = DateTime.Now.Minute.ToString();
            dateAppr = Convert.ToString(ya + '/' + ma + '/' + da+' '+ha+':'+mia);
            dl = dtpLeave.Value.Day.ToString();
            ml = dtpLeave.Value.Month.ToString();
            yl = dtpLeave.Value.Year.ToString();
            lwdate = Convert.ToString(yl + '/'+ ml + '/' + dl);


            sql = @"Insert into LeaveWork(LwDate, emID, emFirstName, emLastName, descriptionLeave, approver, dateAppr)
                    Values(@date, @id, @name, @last, @descr, @appro, @dt)";
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("date", lwdate);
            command.Parameters.AddWithValue("id", txtID.Text);
            command.Parameters.AddWithValue("name", txtFirstName.Text);
            command.Parameters.AddWithValue("last", txtLastName.Text);
            command.Parameters.AddWithValue("descr", txtDescr.Text);
            command.Parameters.AddWithValue("appro", FrmLogin.userName);
            command.Parameters.AddWithValue("dt", dateAppr);

            int result = command.ExecuteNonQuery();
            if (result == -1)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ", "ຜົນລັບ");
            }
            else
            {
                MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ", "ຜົນລັບ");
            }
        }
        private void dtpLeave_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
