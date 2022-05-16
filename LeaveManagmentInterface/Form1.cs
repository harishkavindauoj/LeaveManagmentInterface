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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static string user = "";
        public static string pass = "";


      
        private void Sub_Click(object sender, EventArgs e)
        {
           

            string connetionString = null;
            connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connetionString);

            

            try
            {
                String querry = "SELECT * FROM UserData WHERE UserID='" + IDtxt.Text + "' AND PassWord= '" + Passtxt.Text + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(querry, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {

                    Form2 form = new Form2();
                    form.Show();
                    this.Hide();
                    user = IDtxt.Text;

                }
                else
                {
                    MessageBox.Show("Invalid Login Details");
                }
            }

            catch
            {
                MessageBox.Show("Error123");
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
