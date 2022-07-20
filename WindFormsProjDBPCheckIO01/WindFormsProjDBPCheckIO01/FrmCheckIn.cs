using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindFormsProjDBPCheckIO01
{
    public partial class FrmCheckIn : Form
    {
        public FrmCheckIn()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        public SqlCommand command;
        public DataSet data;
        public SqlDataAdapter adapter;
        public string sql;
        public BindingSource bindingsrc;
        private void FrmCheckIn_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";

            connection = new SqlConnection(constr);
            connection.Open();
            //MessageBox.Show(DateTime.Now.TimeOfDay.ToString());
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
        private void InsertCheckIn()
        {
            string da, ma, ya;
            string cidate, citime;
            da = DateTime.Now.Day.ToString();
            ma = DateTime.Now.Month.ToString();
            ya = DateTime.Now.Year.ToString();
            cidate = Convert.ToString(ya + '/' + ma + '/' + da);
            citime = DateTime.Now.TimeOfDay.ToString();


            sql = @"Insert into CheckIn(ciDate, ciTime, emID, emFirstName, emLastName)
                    Values(@date, @time, @id, @name, @last)";
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("date", cidate);
            command.Parameters.AddWithValue("time", citime);
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("ກະລຸນາໃສ່ລະຫັດພະນັກງານ");
                return;
            }
            InsertCheckIn();
            TextClear();
            txtID.Focus();
        }
    }
}
