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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string name1 { get; set; }

        private void BindData()
        {
            DataTable dt = new DataTable();
            string connectionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM userdata WHERE APPROVAL IS NULL AND UserID='" + name1 + "'", cn); ;
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                }
            }
        }


        private void Leavecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            MySqlConnection conn = new MySqlConnection(connetionString);
            conn.Open();

            MySqlCommand cmd3 = new MySqlCommand("SELECT DISTINCT(PassWord) FROM UserData WHERE UserID='" + name1 + "'", conn);
            MySqlDataReader DR4 = cmd3.ExecuteReader();
            DR4.Read();
            string pass = DR4.GetValue(0).ToString();

            DR4.Close();

            MySqlCommand cmd4 = new MySqlCommand("SELECT DISTINCT(Name) FROM UserData WHERE UserID='" + name1 + "'", conn);
            MySqlDataReader DR5 = cmd4.ExecuteReader();
            DR5.Read();
            string name = DR5.GetValue(0).ToString();

            DR5.Close();

            MySqlCommand cmd5 = new MySqlCommand("SELECT DISTINCT(Designation) FROM UserData WHERE UserID='" + name1 + "'", conn);
            MySqlDataReader DR6 = cmd5.ExecuteReader();
            DR6.Read();
            string desig = DR6.GetValue(0).ToString();

            DR6.Close();

            MySqlCommand cmd6 = new MySqlCommand("SELECT DISTINCT(LeaveFrom) FROM UserData WHERE UserID='" + name1 + "'", conn);
            MySqlDataReader DR7 = cmd6.ExecuteReader();
            DR7.Read();
            string datefrom = DR7.GetValue(0).ToString();

            DR7.Close();

            MySqlCommand cmd7 = new MySqlCommand("SELECT DISTINCT(LeaveTo) FROM UserData WHERE UserID='" + name1 + "'", conn);
            MySqlDataReader DR8 = cmd7.ExecuteReader();
            DR8.Read();
            string dateto = DR8.GetValue(0).ToString();

            DR8.Close();



            if (comboBox1.Text == "Annual")
            {



                connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(connetionString);
                con.Open();
                MySqlCommand camd = conn.CreateCommand();
                camd.CommandType = CommandType.Text;
                camd.CommandText = ("INSERT INTO UserData(UserID,Password,Name,Designation,Date,LeaveFrom,LeaveTo,Annual,Casual,Sick,Remarks) values('" + name1 + "','" + pass + "','" + name + "','" + desig + "','" + DateTime.Now + "','" + datefrom + "','" + dateto + "',1,0,0,'" + remarktxt.Text + "')");
                camd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("Requested!", "Done", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    button1.Enabled = false;
                }
                con.Close();
                

            }
            else if (comboBox1.Text == "Casual")
            {
                connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(connetionString);
                con.Open();
                MySqlCommand camd = conn.CreateCommand();
                camd.CommandType = CommandType.Text;
                camd.CommandText = ("INSERT INTO UserData(UserID,Password,Name,Designation,Date,LeaveFrom,LeaveTo,Annual,Casual,Sick,Remarks) values('" + name1 + "','" + pass + "','" + name + "','" + desig + "','" + DateTime.Now + "','" + datefrom + "','" + dateto + "',0,1,0,'" + remarktxt.Text + "')");
                camd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("Requested!", "Done", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    button1.Enabled = false;
                }
                con.Close();
            }
            else if (comboBox1.Text == "Medical")
            {
                connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(connetionString);
                con.Open();
                MySqlCommand camd = conn.CreateCommand();
                camd.CommandType = CommandType.Text;
                camd.CommandText = ("INSERT INTO UserData(UserID,Password,Name,Designation,Date,LeaveFrom,LeaveTo,Annual,Casual,Sick,Remarks) values('" + name1 + "','" + pass + "','" + name + "','" + desig + "','" + DateTime.Now + "','" + datefrom + "','" + dateto + "',0,0,1,'" + remarktxt.Text + "')");
                camd.ExecuteNonQuery();
                
                DialogResult result = MessageBox.Show("Requested!", "Done", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    button1.Enabled = false;
                }
                con.Close();
                string today=Convert.ToString(DateTime.Now);
                Form4 fr = new Form4();
                fr.user = name1;
                fr.name = name;
                fr.desig = desig;
                fr.today = today;
                fr.datefr = datefrom;
                fr.dateto = dateto;

            }


           
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Annual");
            comboBox1.Items.Add("Casual");
            comboBox1.Items.Add("Medical");

           

            DataTable dt1 = new DataTable();
            string connectionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM userdata WHERE APPROVAL IS NULL AND UserID='" + name1 + "'", cnn);
                cnn.Open();
                MySqlDataReader reader = cmd1.ExecuteReader();
                dt1.Load(reader);

                if (dt1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt1;
                    

                }
            }

            if (dataGridView1.Rows.Count > 0)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
                dataGridView1.Refresh();
                BindData();
                button1.Enabled = false;



        }
    }
}
