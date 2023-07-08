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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Finance();
            Logistic();
            highest();
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

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Cows ob = new Cows();
            ob.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void Finance()
        {
            //calculate finance realated analytics for dashboard screen
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(IncAmt) from IncomeTbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditureTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc, exp;
            double bal;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            IncL1.Text = "Rs: " + dt.Rows[0][0].ToString() + "₹";
            //for expenditure
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            bal = inc - exp;
            IncL2.Text = "Rs: " + dt1.Rows[0][0].ToString() + "₹";
            BalDt.Text = "Rs: " + bal + "₹";
            Con.Close();
        }
        //calculate finance realated analytics for dashboard screen of logistic
        private void Logistic()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(CowId) from CowTbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(EmpId) from EmployeeTbl", Con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(Total) from MilkTbl", Con);
            SqlDataAdapter sda3 = new SqlDataAdapter("select sum(Quantity) from MilkSalesTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc,total,quantity;
            double stock;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            CowDt.Text = "Total Cow: " + dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            EmpDt.Text = "Total Emp : " + dt1.Rows[0][0].ToString();
            //for Milk Stock
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            total = Convert.ToInt32(dt2.Rows[0][0].ToString());
            //quantity
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            quantity = Convert.ToInt32(dt3.Rows[0][0].ToString());
            stock = total - quantity;
            StockDt.Text =stock+ " Litters";
            Con.Close();
        }
        //to calculate highest expenditure and sales of dashboard
        private void highest()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(ExpAmount) from ExpenditureTbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select max(Amount) from MilkSalesTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int exp, sale;
            exp = Convert.ToInt32(dt.Rows[0][0].ToString());
            HighExp.Text = "RS: " + dt.Rows[0][0].ToString()+"₹";
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            sale = Convert.ToInt32(dt1.Rows[0][0].ToString());
            HighSale.Text = "RS: " + dt1.Rows[0][0].ToString() + "₹"; 
            Con.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
        
        private void EmpDt_Click(object sender, EventArgs e)
        {

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
