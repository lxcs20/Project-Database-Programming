using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WindFormsProjDBPCheckIO01
{
    public class ConnectDB
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\AttendanceRecord.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection Conn;
        public SqlDataAdapter Adapter;
        public DataSet ds;
        
        public void Query(String sql)
        {
            Conn = new SqlConnection(constr);
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            try
            {
                Adapter = new SqlDataAdapter(sql, Conn);
                ds = new DataSet();
                Adapter.Fill(ds, "data");
                Conn.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show("Error");
            }
        }
    }
}
