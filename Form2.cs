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

namespace Windows_proj
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            SqlDataAdapter sda;
            DataSet wnds;
            SqlConnection sdbcon = new SqlConnection("Server=ACER-PC;Database=Windows_data;Integrated Security=true");
            sdbcon.Open();
            string query = "SELECT CollegeName FROM dbo.CollegeData WHERE StateName='" + textBox1.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(query, sdbcon);
            sda = new SqlDataAdapter(sqlcmd);
            wnds = new DataSet();
            sda.Fill(wnds);
            comboBox1.Text = String.Empty;
            comboBox1.Items.Clear();
            
            for (int i = 0; i < wnds.Tables[0].Rows.Count; i++)

                comboBox1.Items.Add(wnds.Tables[0].Rows[i][0].ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sdbcon = new SqlConnection("Server=ACER-PC;Database=Windows_data;Integrated Security=true");
            sdbcon.Open();


            string dbquery = "SELECT UGCGPA, GREScore, TOEFLScore, SAFETYRev, ApplicationFee, AnnumFees, AcceptanceRate, Loc, RANKColl, GradRate FROM dbo.CollegeData WHERE CollegeName='" + comboBox1.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(dbquery, sdbcon);
            SqlDataReader sqlreader = sqlcmd.ExecuteReader();
            while (sqlreader.Read())
            {

                textBox2.Text = (sqlreader["UGCGPA"].ToString());
                textBox3.Text = (sqlreader["GREScore"].ToString());
                textBox4.Text = (sqlreader["TOEFLScore"].ToString());
                textBox5.Text = (sqlreader["SAFETYRev"].ToString());
                textBox6.Text = (sqlreader["ApplicationFee"].ToString());
                textBox7.Text = (sqlreader["AnnumFees"].ToString());
                textBox8.Text = (sqlreader["AcceptanceRate"].ToString());
                textBox9.Text = (sqlreader["Loc"].ToString());
                textBox10.Text = (sqlreader["RANKColl"].ToString());
                textBox11.Text = (sqlreader["GradRate"].ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            }
    }
}
