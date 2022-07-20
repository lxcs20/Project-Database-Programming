using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindFormsProjDBPCheckIO01
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        public SqlCommand command;
        public DataSet data;
        public SqlDataAdapter adapter;
        public string sql;
        public BindingSource bindingsrc;

        private void UpdateBinding()
        {
            txtID.DataBindings.Clear();
            txtUname.DataBindings.Clear();
            txtPword.DataBindings.Clear(); ;
            txtPosition.DataBindings.Clear();

            sql = "Select * from tbAdmin";
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            data = new DataSet();
            adapter.Fill(data, "admin");

            dtgAddmin.DataSource = data.Tables["admin"];

            bindingsrc = new BindingSource();
            bindingsrc.DataSource = data.Tables["admin"];
            txtID.DataBindings.Add("Text", bindingsrc, "adId");
            txtUname.DataBindings.Add("Text", bindingsrc, "userName");
            txtPword.DataBindings.Add("Text", bindingsrc, "userPin");
            txtPosition.DataBindings.Add("Text", bindingsrc, "position");
            UpdatePosition();

        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";
            
            connection = new SqlConnection(constr);
            connection.Open();

            UpdateBinding();

        }

        private void UpdatePosition()
        {
            lblPosition.Text = (bindingsrc.Position + 1) + "/" + bindingsrc.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bindingsrc.MoveFirst();
            UpdatePosition();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            bindingsrc.MovePrevious();
            UpdatePosition();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bindingsrc.MoveNext();
            UpdatePosition();
        }

        private void bntLast_Click(object sender, EventArgs e)
        {
            bindingsrc.MoveLast();
            UpdatePosition();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtUname.Text = "";
            txtPword.Text = "";
            txtPosition.Text = "";

            if(btnAdd.Text == "ເພີ່ມໃຫມ່")
            {
                btnAdd.Text = "ຍົກເລີກ";
                btnSave.Enabled = true;
            }
            else if(btnAdd.Text == "ຍົກເລີກ")
            {
                btnAdd.Text = "ເພີ່ມໃຫມ່";
                //btnSave.Enabled = false;
                UpdateBinding();
            }
        }

        private void Insert()
        {            
            sql = @"INSERT INTO tbAdmin(userName, userPin, position) VALUES(@uName, @pWord, @position)";
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("uName", txtUname.Text);
            command.Parameters.AddWithValue("pWord", txtPword.Text);
            command.Parameters.AddWithValue("position", txtPosition.Text);

            int result = command.ExecuteNonQuery();
            if (result == -1)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ", "ຜົນລັບ");
                btnFirst.PerformClick();
            }
            else
            {
                MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ", "ຜົນລັບ");
                UpdateBinding();
            }
        }

        private void Updatedb()
        {
            sql = "UPDATE tbAdmin SET userName = @txtUname, userPin = @txtPword, position = @txtPosition WHERE adId = @txtadID";
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("txtUname", txtUname.Text);
            command.Parameters.AddWithValue("txtPword", txtPword.Text);
            command.Parameters.AddWithValue("txtPosition", txtPosition.Text);
            command.Parameters.AddWithValue("txtadID", txtID.Text);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("ບັນທຶກການປ່ຽນແປງ", "ຜົນລັບ");
                UpdateBinding();
            }
            else
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ", "ຜົນລັບ");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataComplete() == false)
            {
                return;
            }

            if(txtID.Text == "")
            {
                Insert();
            }
            else{
                Updatedb();
            }
        }

        private bool DataComplete()
        {
            txtUname.Text.Trim();
            txtPword.Text.Trim();
            txtPosition.Text.Trim();

            if((txtUname.Text == "") || (txtPword.Text == "") || (txtPosition.Text == ""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມຸນໃຫ້ຄົບ", "ແຈ້ງເຕືອນ");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}