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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            populate();
            populate1();
            fillEmpId();
            fillEmpId2();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            ExpId.ValueMember = "EmpId";
            ExpId.DataSource = dt;
            Con.Close();
        }
        private void fillEmpId2()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            ExpId2.ValueMember = "EmpId";
            ExpId2.DataSource = dt;
            Con.Close();
        }
        private void populate1()
        {
            Con.Open();
            String query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            String query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //To filter Data by the Date in income table
        private void FilterIncome()
        {
            Con.Open();
            String query = "select * from IncomeTbl where IncDate='"+FilterInc.Value.Date+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //To filter Data by the Date in Expenditure table
        private void Filterexp()
        {
            Con.Open();
            String query = "select * from ExpenditureTbl where ExpDate='" + FilterExp.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Cows ob = new Cows();
            ob.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Milkproduction ob = new Milkproduction();
            ob.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Cowhealth ob = new Cowhealth();
            ob.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Sales ob = new Sales();
            ob.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }
        private void clear()
        {
            Purpose.SelectedText  = "";
            AmountFt.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Purpose .SelectedIndex == -1 || AmountFt .Text =="")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into ExpenditureTbl values('" + ExpDate .Value .Date  + "','" + Purpose.Text + "', '" + AmountFt.Text + "','"+ExpId .Text +"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully...");
                    Con.Close();
                    populate1();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpIdFt_Click(object sender, EventArgs e)
        {

        }
        private void clearinc()
        {
            AmtFt.Text = "";
            TypeFt.SelectedText = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (TypeFt.SelectedIndex == -1 || AmtFt.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into IncomeTbl values('" + IncDate.Value.Date + "','" + TypeFt.Text + "', '" + AmtFt.Text + "','" + ExpId2.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully...");
                    Con.Close();
                    populate();
                    clearinc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Cows ob = new Cows();
            ob.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Cowhealth ob = new Cowhealth();
            ob.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Milkproduction ob = new Milkproduction();
            ob.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Sales ob = new Sales();
            ob.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            FilterIncome();
        }

        private void FilterExp_ValueChanged(object sender, EventArgs e)
        {
            Filterexp();
        }

        private void ExpId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            populate1();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            lo.Show();
            this.Hide();
        }
    }
}
