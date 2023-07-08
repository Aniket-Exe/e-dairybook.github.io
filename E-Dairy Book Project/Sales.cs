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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            populate();
            fillEmpId();
            populate();
           
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
        //to fill the combo box of milk Sales..
        private void fillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            EmpId.ValueMember = "EmpId";
            EmpId.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            String query = "select * from MilkSalesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
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

        private void label19_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void Quantity_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(Price.Text) * Convert.ToInt32(Quantity.Text);
            TotalSt.Text = "" + total;
        }
        private void clear()
        {
            CName.Text = "";
            Price.Text = "";
            PhoneSt.Text = "";
            Quantity.Text = "";
            TotalSt.Text = "";
        }
        //to save the milk sales data to finance Income Table
        private void SaveTransaction()
        {
            {
                try
                {
                    String sales="Milk Sales";
                    Con.Open();
                    String Query = "insert into IncomeTbl values('" + DateSt.Value.Date + "','" + sales + "', '" + TotalSt.Text + "','" + EmpId.SelectedValue.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpId.SelectedIndex == -1 || CName.Text == "" || Price.Text == "" || PhoneSt.Text == "" || Quantity.Text == "" || TotalSt.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into MilkSalesTbl values( '" + DateSt.Value.Date + "', '" + Price.Text + "','" + CName.Text + "', '" + PhoneSt.Text + "','" + EmpId.SelectedValue.ToString() + "', '" + Quantity.Text + "', '" + TotalSt.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Sold Successfully...Record Saved!");
                    Con.Close();
                    SaveTransaction();
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

        private void Quantity_MouseLeave(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Quantity_OnValueChanged(object sender, EventArgs e)
        {

        }
        
        private void SalesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpId.SelectedValue = SalesDGV.SelectedRows[0].Cells[5].Value.ToString();
            CName.Text = SalesDGV.SelectedRows[0].Cells[3].Value.ToString();
            DateSt.Text = SalesDGV.SelectedRows[0].Cells[1].Value.ToString();
            Price.Text = SalesDGV.SelectedRows[0].Cells[2].Value.ToString();
            Quantity.Text = SalesDGV.SelectedRows[0].Cells[6].Value.ToString();
            PhoneSt.Text = SalesDGV.SelectedRows[0].Cells[4].Value.ToString();
            TotalSt.Text = SalesDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void EmpId_SelectedIndexChanged(object sender, EventArgs e)
        {

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
