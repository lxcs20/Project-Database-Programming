using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindFormsProjDBPCheckIO01
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public string sql;
        public static string userName, passWord;
        private void Connectdb()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";

            connection = new SqlConnection(constr);
            connection.Open();
        }

        private void Login()
        {
            
            userName = txtUname.Text;
            passWord = txtPword.Text;
            try
            {
                sql = "Select userName, userPin from tbAdmin where userName = '" + userName + "' and userPin = '" + passWord + "'";

                command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                DataTable dtAd = new DataTable();
                adapter.Fill(dtAd);
                if (dtAd.Rows.Count > 0)
                {
                    this.Hide();
                    FrmMain frMain = new FrmMain();
                    userName = txtUname.Text;
                    passWord = txtPword.Text;
                    frMain.Show();
                }
                else
                {
                    MessageBox.Show("ຊື່ຜູ້ມໃຊ້ ຫຼື ລະຫັດຜ່ານບໍ່ຖືກຕ້ອງ");
                    txtUname.Clear();
                    txtPword.Clear();
                    txtUname.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
                          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Connectdb();
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Login();
        }
    }
}
