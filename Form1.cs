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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection constr = new SqlConnection("Data Source=ACER-PC;Initial Catalog=Login_data;Integrated Security=True");
            constr.Open();
            string squery = "SELECT Password FROM dbo.Login_Info WHERE Username='" + textBox11.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(squery, constr);
            SqlDataReader sreader = sqlcmd.ExecuteReader();
            
            while (sreader.Read())
            {
                string passwordcheck = sreader["Password"].ToString();
                if (passwordcheck == textBox12.Text)
                {
                    if (textBox11.Text == "admin")
                    {
                        var form5 = new Form5();
                        form5.Show();
                        textBox11.Text = String.Empty;
                        textBox12.Text = String.Empty;

                    }
                    else
                    {
                        var form2 = new Form2();
                        form2.Show();
                        textBox11.Text = String.Empty;
                        textBox12.Text = String.Empty;
                        label13.Text = String.Empty;
                    }
                }
                else
                {
                    label13.Text = "WRONG PASSWORD!!!";
                    textBox12.Text = String.Empty;
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox13.Text)
            {
                textBox1.Text = String.Empty;
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
                textBox12.Text = String.Empty;
                textBox13.Text = String.Empty;
                var form4 = new Form4();
                form4.Show();
            }
            else
            {



                SqlConnection constr1 = new SqlConnection("Data Source=ACER-PC;Initial Catalog=Login_data;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.InsertCommand = new SqlCommand("INSERT INTO Login_Info VALUES(@Name, @Username, @Password, @Email, @DOB, @Address, @City, @State, @Zipcode, @Country)", constr1);
                sda.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text;
                sda.InsertCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox2.Text;
                sda.InsertCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = textBox3.Text;
                sda.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox4.Text;
                sda.InsertCommand.Parameters.Add("@DOB", SqlDbType.VarChar).Value = textBox5.Text;
                sda.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox6.Text;
                sda.InsertCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = textBox7.Text;
                sda.InsertCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = textBox8.Text;
                sda.InsertCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = textBox9.Text;
                sda.InsertCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = textBox10.Text;
                constr1.Open();
                sda.InsertCommand.ExecuteNonQuery();
                constr1.Close();
                textBox1.Text = String.Empty;
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
                textBox12.Text = String.Empty;
                textBox13.Text = String.Empty;
                var form3 = new Form3();
                form3.Show();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form8 = new Form8();
            form8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form9 = new Form9();
            form9.Show();
        }
    }
}
