using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Dairy_Book_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UserCb.Text = "";
            PassCb.Text = "";
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (PassCb.Text == "" || UserCb.Text == "")
            {
                MessageBox.Show("Enter Name And Password!");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (UserCb.Text == "Admin" && PassCb.Text == "admin")
                        {
                            Employee emp = new Employee();
                            emp.Show();
                            this.Hide();
                        }
                    else
                    {
                        MessageBox.Show("If You Are Admin Then Insert correct Password!");
                    }
                    }
                    if (RoleCb.SelectedItem.ToString() == "Employee")
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTbl where EmpName = '" + UserCb.Text + "' and EmpPass ='" + PassCb.Text + "' ", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Cows cow = new Cows();
                            cow.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong User Name or Password");
                        }
                        Con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select Role!");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
