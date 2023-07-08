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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            String query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            EmpNameEt.Text = "";
            GenderEt.SelectedIndex = -1;
            PhoneEt.Text = "" ;
            AddEt.Text = "";
            EmpPassCb.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpNameEt.Text =="" || GenderEt.SelectedIndex ==-1 || AddEt.Text =="" || PhoneEt .Text =="" ||EmpPassCb .Text =="")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into EmployeeTbl values('" + EmpNameEt.Text + "', '" + DobEt.Value.Date + "', '" + GenderEt.SelectedItem.ToString() + "', '" + PhoneEt.Text + "','" + AddEt.Text + "','" + EmpPassCb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully...");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        int key = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Report To Delete!!!  ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from EmployeeTbl where EmpId =" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted Successfully...");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameEt.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            DobEt.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderEt.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneEt.Text = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddEt.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpPassCb.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameEt.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpNameEt.Text == "" || GenderEt.SelectedIndex == -1 || AddEt.Text == "" || PhoneEt.Text == ""||EmpPassCb .Text=="")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "update EmployeeTbl set EmpName='" + EmpNameEt.Text + "',EmpDob = '" + DobEt.Value.Date + "', Gender='" + GenderEt.SelectedItem.ToString() + "',Phone='" + PhoneEt.Text + "',Address='" + AddEt.Text + "',EmpPass='" + EmpPassCb.Text + "' Where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully...");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            lo.Show();
            this.Hide();
        }
    }
}
