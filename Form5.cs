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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            label11.Text = String.Empty;
            SqlDataAdapter sda;
            DataSet sds;
            SqlConnection sqlcon = new SqlConnection("Server=ACER-PC;Database=Login_data;Integrated Security=true");
            sqlcon.Open();
            string query = "SELECT Username FROM dbo.Login_Info";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sda = new SqlDataAdapter(sqlcmd);
            sds = new DataSet();
            sda.Fill(sds);
            comboBox1.Text = String.Empty;
            comboBox1.Items.Clear();
            for (int i = 0; i < sds.Tables[0].Rows.Count; i++)

                comboBox1.Items.Add(sds.Tables[0].Rows[i][0].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "admin")
            {
                this.Close();
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection("Server=ACER-PC;Database=Login_data;Integrated Security=true");
                sqlcon.Open();


                string query = "SELECT Name, Password , Email, DOB, Address, City, State, ZipCode, Country FROM dbo.Login_Info WHERE Username='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                while (sqlreader.Read())
                {

                    textBox1.Text = (sqlreader["Name"].ToString());
                    textBox2.Text = (sqlreader["Password"].ToString());
                    textBox3.Text = (sqlreader["Email"].ToString());
                    textBox4.Text = (sqlreader["DOB"].ToString());
                    textBox5.Text = (sqlreader["Address"].ToString());
                    textBox6.Text = (sqlreader["City"].ToString());
                    textBox7.Text = (sqlreader["State"].ToString());
                    textBox8.Text = (sqlreader["ZipCode"].ToString());
                    textBox9.Text = (sqlreader["Country"].ToString());


                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "admin")
            {
                label11.Text = "Admin can not be deleted";
                comboBox1.Text = String.Empty;
            }
            else
            {
                label11.Text = String.Empty;
                SqlConnection sqlcon = new SqlConnection("Server=ACER-PC;Database=Login_data;Integrated Security=true");
                sqlcon.Open();
                string sqlquery = "DELETE FROM dbo.Login_Info WHERE Username='" + comboBox1.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                SqlDataReader sqlreader = sqlcmd.ExecuteReader();
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                textBox7.Text = String.Empty;
                textBox8.Text = String.Empty;
                textBox9.Text = String.Empty;
                var form7 = new Form7();
                form7.Show();
                comboBox1.Text = String.Empty;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "admin")
            {
                label11.Text = "Admin details can not be edited";
                comboBox1.Text = String.Empty;
            }
            else
            {
                label11.Text = String.Empty;
                SqlConnection sqlcon = new SqlConnection("Server=ACER-PC;Database=Login_data;Integrated Security=true");
                sqlcon.Open();


                string sqlquery = "UPDATE dbo.Login_Info SET Name ='" + textBox1.Text + "', Password='" + textBox2.Text + "', Email='" + textBox3.Text + "', DOB='" + textBox4.Text + "', Address='" + textBox5.Text + "', City='" + textBox6.Text + "', State='" + textBox7.Text + "', ZipCode='" + textBox8.Text + "', Country='" + textBox9.Text + "' WHERE Username='" + comboBox1.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                SqlDataReader sqlreader = sqlcmd.ExecuteReader();
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                textBox7.Text = String.Empty;
                textBox8.Text = String.Empty;
                textBox9.Text = String.Empty;
                var form6 = new Form6();
                form6.Show();
                comboBox1.Text = String.Empty;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }
    }
}
