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
            this.Enabled = true;
            Form1 frm = new Form1();
            string name;
            name = Form1.user;
            string connetionString = null;
            connetionString = "server=localhost;database=LeaveManagementSystem;uid=root;pwd='';";
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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}

    
