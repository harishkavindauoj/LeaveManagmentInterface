using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LeaveManagmentInterface
{
    public partial class Form4 : Form

    {
       

        public Form4()
        {
            InitializeComponent();
        }

        public string name { get; set; }
        public string user { get; set; }
        public string desig { get; set; }
        public string today { get; set; }
        public string datefr { get; set; }
        public string dateto { get; set; }


        private void Form4_Load(object sender, EventArgs e)
        {
            

            BindData();
            Approve();
        }
        
        
        private void BindData()
        {
            DataTable dt = new DataTable();
            string connectionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT UserID,Name,Designation,Date,LeaveFrom,LeaveTo,Annual,Casual,Sick,Remarks,Approval FROM userdata", cn);
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                }
            }
        }



        public void Approve()
        {
            DataTable dt1 = new DataTable();
            string connectionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd1 = new MySqlCommand("SELECT UserID,Name,Designation,Date,LeaveFrom,LeaveTo,Annual,Casual,Sick,Remarks,Approval FROM userdata WHERE APPROVAL IS NULL", cnn);
                cnn.Open();
                MySqlDataReader reader = cmd1.ExecuteReader();
                dt1.Load(reader);

                if (dt1.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt1;

                }
            }
            
        }
        public void Approve2()
        {
            DataTable dt1 = new DataTable();
            string connectionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd1 = new MySqlCommand("SELECT UserID,Name,Designation,Date,LeaveFrom,LeaveTo,Annual,Casual,Sick,Remarks,Approval FROM userdata WHERE (Approval<>'Approved') OR (Approval<>'Declined')", cnn);
                cnn.Open();
                MySqlDataReader reader = cmd1.ExecuteReader();
                dt1.Load(reader);

                if (dt1.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt1;

                }
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usertxt.Text == "")
            {
                MessageBox.Show("Enter UserID!");
            }
            else
            {
                

                String connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
                MySqlConnection conn = new MySqlConnection(connetionString);
                conn.Open();
                MySqlCommand camd = conn.CreateCommand();
                camd.CommandType = CommandType.Text;
                camd.CommandText = ("UPDATE USERDATA SET Approval='Approved' WHERE UserID='" + usertxt.Text + "'");
                camd.ExecuteNonQuery();
                conn.Close();
                
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usertxt.Text == "")
            {
                MessageBox.Show("Enter UserID!");
            }
            else
            {
                
                String connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
                MySqlConnection conn = new MySqlConnection(connetionString);
                conn.Open();
                MySqlCommand camd = conn.CreateCommand();
                camd.CommandType = CommandType.Text;
                camd.CommandText = ("UPDATE USERDATA SET Approval='Declined' WHERE UserID='" + usertxt.Text + "'");
                camd.ExecuteNonQuery();
                conn.Close();






            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            BindData();
            
            Approve();
            dataGridView2.Refresh();


        }
    }
}
