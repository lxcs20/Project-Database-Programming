using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindFormsProjDBPCheckIO01
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
        private SqlConnection connection;
        public SqlCommand command;
        public DataSet data;
        public SqlDataAdapter adapter;
        public string sql;
        public BindingSource bindingsrc;

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";

            connection = new SqlConnection(constr);
            connection.Open();

            listboxEmployees();
            DisplayData();
        }

        private void listboxEmployees()
        {
            sql = "Select * from tbEmployees";
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            data = new DataSet();
            adapter.Fill(data, "emp");
            listEmployees.DataSource = data.Tables["emp"];
            listEmployees.DisplayMember = "emFirstname";
        }
        private void DisplayData()
        {
            txtID.DataBindings.Clear();
            txtFirstname.DataBindings.Clear();
            txtLastname.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            datBD.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPosition.DataBindings.Clear();
            datStart.DataBindings.Clear();
            picbox.DataBindings.Clear();

            sql = "Select * from tbEmployees";
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            data = new DataSet();
            adapter.Fill(data, "emp");
            bindingsrc = new BindingSource();
            bindingsrc.DataSource = data.Tables["emp"];
            
            txtID.DataBindings.Add("Text", bindingsrc, "emID");
            txtFirstname.DataBindings.Add("Text", bindingsrc, "emFirstName");
            txtLastname.DataBindings.Add("Text", bindingsrc, "emLastName");
            txtPhone.DataBindings.Add("Text", bindingsrc, "emPhone");
            txtEmail.DataBindings.Add("Text", bindingsrc, "email");
            datBD.DataBindings.Add("Value", bindingsrc, "BirthDay");
            txtAddress.DataBindings.Add("Text", bindingsrc, "emAddress");
            txtPosition.DataBindings.Add("Text", bindingsrc, "position");
            datStart.DataBindings.Add("Value", bindingsrc, "startWork");
            picbox.DataBindings.Add("Image", bindingsrc, "photo", true);
        }
        private void listEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bindingsrc == null)
            {
                return;
            }
            bindingsrc.Position = listEmployees.SelectedIndex;
            
        }
        private void Insert()
        {
            sql = @"INSERT INTO tbEmployees(emFirstname, emLastname, emPhone, email, birthDay, emAddress, position, startWork, photo)
                    VALUES(@Name, @Last, @phone, @mail, @Bd, N'@Addre', @position, @Stwork, @pic)";

            string db, mb, yb, ds, ms, ys;
            string birth, start;
            db = datBD.Value.Day.ToString();
            mb = datBD.Value.Month.ToString();
            yb = datBD.Value.Year.ToString();
            birth = Convert.ToString(yb +'/'+ mb +'/'+ db);
            ds = datStart.Value.Day.ToString();
            ms = datStart.Value.Month.ToString();
            ys = datStart.Value.Year.ToString();
            start = Convert.ToString(yb +'/'+ mb +'/'+ db);
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("Name", txtFirstname.Text);
            command.Parameters.AddWithValue("Last", txtLastname.Text);
            command.Parameters.AddWithValue("phone", txtPhone.Text);
            command.Parameters.AddWithValue("mail", txtEmail.Text);
            command.Parameters.AddWithValue("Bd", birth);
            command.Parameters.AddWithValue("Addre", txtAddress.Text);
            command.Parameters.AddWithValue("position", txtPosition.Text);
            command.Parameters.AddWithValue("Stwork", start);
            command.Parameters.AddWithValue("pic", ConPictoAr(picbox.Image));

            int result = command.ExecuteNonQuery();
            if (result == -1)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ", "ຜົນລັບ");
                ClearText();
            }
            else
            {
                MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ", "ຜົນລັບ");
            }
        }
        private void ClearText()
        {
            txtID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            datBD.Text = "";
            txtAddress.Text = "";
            txtPosition.Text = "";
            datStart.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            txtID.Enabled = false;
            if (btnAdd.Text == "ເພີ່ມໃຫມ່")
            {
                btnAdd.Text = "ຍົກເລີກ";
                btnSave.Enabled = true;
                
            }
            else if (btnAdd.Text == "ຍົກເລີກ")
            {
                btnAdd.Text = "ເພີ່ມໃຫມ່";
                //btnSave.Enabled = false;
                DisplayData();
            }
        }

        private bool DataComplete()
        {
            txtFirstname.Text.Trim();
            txtLastname.Text.Trim();
            txtPhone.Text.Trim();
            txtEmail.Text.Trim();
            datBD.Text.Trim();
            txtAddress.Text.Trim();
            txtPosition.Text.Trim();
            datStart.Text.Trim();

            if ((datStart.Text == "") || (txtAddress.Text == "") || (datBD.Text == "") || (txtEmail.Text == "") || (txtFirstname.Text == "") || (txtPhone.Text == "") ||(txtLastname.Text == "") || (txtPosition.Text == ""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມຸນໃຫ້ຄົບ", "ແຈ້ງເຕືອນ");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Updatedb()
        {
            sql = @"UPDATE tbEmployees SET emFirstname = @name, emLastname = @last, emPhone = @phone, 
            email = @mail, birthDay = @bd, emAddress = @Addr, position = @posit, startWork = @start, photo = @pic
            where emID = @ID";

            int db, mb, yb, ds, ms, ys;
            string birth, start;
            db = datBD.Value.Day;
            mb = datBD.Value.Month;
            yb = datBD.Value.Year;
            birth = Convert.ToString(yb + mb + db);
            ds = datStart.Value.Day;
            ms = datStart.Value.Month;
            ys = datStart.Value.Year;
            start = Convert.ToString(yb + mb + db);
            command.Parameters.Clear();
            command.CommandText = sql;
            command.Parameters.AddWithValue("ID", txtID.Text);
            command.Parameters.AddWithValue("name", txtFirstname.Text);
            command.Parameters.AddWithValue("last", txtLastname.Text);
            command.Parameters.AddWithValue("phone", txtPhone.Text);
            command.Parameters.AddWithValue("mail", txtEmail.Text);
            command.Parameters.AddWithValue("bd", birth);
            command.Parameters.AddWithValue("Addr", txtAddress.Text);
            command.Parameters.AddWithValue("posit", txtPosition.Text);
            command.Parameters.AddWithValue("start", start);
            command.Parameters.AddWithValue("pic", ConPictoAr(picbox.Image));



            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("ບັນທຶກການປ່ຽນແປງ", "ຜົນລັບ");
                
            }
            else
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ", "ຜົນລັບ");
                ClearText();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataComplete() == false)
            {
                return;
            }

            if (txtID.Text == "")
            {
                Insert();
                listboxEmployees();
                btnAdd.Text = "ເພີ່ມໃຫມ່";
            }
            else
            {
                Updatedb();
            }
        }

        private void FrmEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void linkSelectPic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog() { Filter = "Image file(*.jpg; *.jpeg; *.png)|*jpg;*.jpeg; *.png", Multiselect = false };
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picbox.Image = Image.FromFile(opf.FileName);
            }
        }
        byte[] ConPictoAr(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
