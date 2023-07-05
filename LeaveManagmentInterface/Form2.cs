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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        public string name { get; set; }



        public DateTime[] GetAllDays(DateTime dt1, DateTime dt2)
        {
            List<DateTime> listDays = new List<DateTime>();
            DateTime dtDay = new DateTime();
            for (dtDay = dt1; dtDay.CompareTo(dt2) <= 0; dtDay = dtDay.AddDays(1))
            {
                listDays.Add(dtDay);
            }
            return listDays.ToArray();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            
            

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';Convert Zero Datetime=True";
            MySqlConnection conn = new MySqlConnection(connetionString);

            try
            {

                String querry = "SELECT LeaveFrom,LeaveTo FROM UserData WHERE UserID='" + name + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(querry, conn);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                foreach (DataRow row in ds.Rows)
                {
                    DateTime dateStart = row.Field<DateTime>(0);
                    DateTime dateEnd = row.Field<DateTime>(1);
                    DateTime[] dateRange = GetAllDays(dateStart, dateEnd);
                    foreach (DateTime item in dateRange)
                    {
                        monthCalendar1.AddBoldedDate(item);
                    }

                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            
                 conn.Open();
                MySqlCommand cmd  =new MySqlCommand("SELECT SUM(Annual) FROM UserData WHERE UserID='" + name + "'",conn);
                
               
                MySqlDataReader DR1 = cmd.ExecuteReader();
                if (DR1.Read())
                {
                    TxtAnTa.Text = DR1.GetValue(0).ToString();
                    int an = Convert.ToInt32(DR1.GetValue(0));
                    int anual = 14 - an;
                    TxtAnRe.Text = anual.ToString();
                }

            DR1.Close();

            MySqlCommand cmd1 = new MySqlCommand("SELECT SUM(Casual) FROM UserData WHERE UserID='" + name + "'", conn);
            MySqlDataReader DR2 = cmd1.ExecuteReader();
            if (DR2.Read())
            {
                TxtCasTa.Text = DR2.GetValue(0).ToString();
                int cas= Convert.ToInt32(DR2.GetValue(0));
                int casual = 7 - cas;
                TxtCasRe.Text = casual.ToString();
            }

            DR2.Close();

            MySqlCommand cmd2 = new MySqlCommand("SELECT SUM(Sick) FROM UserData WHERE UserID='" + name + "'", conn);
            MySqlDataReader DR3 = cmd2.ExecuteReader();
            if (DR3.Read())
            {
                TxtMedTa.Text = DR3.GetValue(0).ToString();
                int med= Convert.ToInt32(DR3.GetValue(0));
                int Med = 21 - med;
                TxtMedRe.Text = Med.ToString();
            }
            DR3.Close();

            MySqlCommand cmd3 = new MySqlCommand("SELECT DISTINCT(Name) FROM UserData WHERE UserID='" + name + "'", conn);
            MySqlDataReader DR4 = cmd3.ExecuteReader();
            if (DR4.Read())
            {
                nametxt.Text = DR4.GetValue(0).ToString();
            }
            DR4.Close();

            MySqlCommand cmd4 = new MySqlCommand("SELECT DISTINCT(UserID) FROM UserData WHERE UserID='" + name + "'", conn);
            MySqlDataReader DR5 = cmd4.ExecuteReader();
            if (DR5.Read())
            {
                usertxt.Text = DR5.GetValue(0).ToString();
            }
            DR5.Close();

            MySqlCommand cmd5 = new MySqlCommand("SELECT DISTINCT(Designation) FROM UserData WHERE UserID='" + name + "'", conn);
            MySqlDataReader DR6 = cmd5.ExecuteReader();
            if (DR6.Read())
            {
                 posttxt.Text = DR6.GetValue(0).ToString();
            }
            DR6.Close();
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void rqstbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 nxtform = new Form3();
            this.Hide();
            nxtform.name1 = name;
            nxtform.Show();
        }
    }
}


