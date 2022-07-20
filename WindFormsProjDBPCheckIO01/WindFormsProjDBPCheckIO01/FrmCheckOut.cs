using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindFormsProjDBPCheckIO01
{
    public partial class FrmCheckOut : Form
    {
        public FrmCheckOut()
        {
            InitializeComponent();
        }
        private SqlConnection connection;
        public SqlCommand command;
        public DataSet data;
        public SqlDataAdapter adapter;
        public string sql;
        public BindingSource bindingsrc;
        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";

            connection = new SqlConnection(constr);
            connection.Open();
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
            txtName.Text = rows["emFirstName"].ToString();
            txtLast.Text = rows["emLastName"].ToString();

            byte[] imgByte = (byte[])rows["Photo"];
            MemoryStream memStream = new MemoryStream(imgByte);
            picBox.Image = Image.FromStream(memStream);
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
            txtName.Clear();
            txtLast.Clear();
            picBox.Image = null;
        }
        private void InsertCheckOut()
        {
            string da, ma, ya;
            string codate, cotime;
            da = DateTime.Now.Day.ToString();
            ma = DateTime.Now.Month.ToString();
            ya = DateTime.Now.Year.ToString();
            codate = Convert.ToString(ya + '/' + ma + '/' + da);
            cotime = DateTime.Now.TimeOfDay.ToString();


            sql = @"Insert into CheckOut(coDate, coTime, emID, emFirstName, emLastName)
                    Values(@date, @time, @id, @name, @last)";
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("date", codate);
            command.Parameters.AddWithValue("time", cotime);
            command.Parameters.AddWithValue("id", txtID.Text);
            command.Parameters.AddWithValue("name", txtName.Text);
            command.Parameters.AddWithValue("last", txtLast.Text);

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("ກະລຸນາໃສ່ລະຫັດພະນັກງານ");
                return;
            }
            InsertCheckOut();
            TextClear();
            txtID.Focus();
        }
    }
    
}
