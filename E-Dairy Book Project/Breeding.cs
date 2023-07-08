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
    public partial class Breeding : Form
    {
        public Breeding()
        {
            InitializeComponent();
            populate();
            fillcCowId();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
        //to fill the combo box of Cow Breeding Form page.
        private void fillcCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdBt.ValueMember = "CowId";
            CowIdBt.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            String query = "select * from BreedTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void GetCowname()
        {
            Con.Open();
            string query = "select * from CowTbl where CowId=" + CowIdBt.SelectedValue.ToString() + " ";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameBt.Text = dr["cowname"].ToString();
                AgeBt.Text = dr["Age"].ToString();
            }
            Con.Close();
        }

        private void Breeding_Load(object sender, EventArgs e)
        {

        }

        private void CowIdBt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowname();
        }
        private void clear()
        {
            CowNameBt.Text = "";
            RemarksBt.Text = "";
            AgeBt.Text = "";
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdBt.SelectedIndex == -1 || CowNameBt.Text == "" || RemarksBt.Text == "" || AgeBt.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into BreedTbl values('" + HeatDate.Value.Date + "', '" + BreedDate.Value.Date + "', " + CowIdBt.SelectedValue.ToString() + ",'" + CowNameBt.Text + "', '" + PregDate.Value.Date + "', '" + ExpDate.Value.Date + "',  '" + DateCalved.Value.Date + "', '" + AgeBt.Text + "','" + RemarksBt.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdBt.SelectedIndex == -1 || CowNameBt.Text == "" || RemarksBt.Text == "" || AgeBt.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "update BreedTbl set HeatDate='"+ HeatDate.Value.Date+"',BreedDate = '" + BreedDate.Value.Date + "', CowId=" + CowIdBt.SelectedValue.ToString() + ",CowName='" + CowNameBt.Text + "',PregDate='" + PregDate.Value.Date + "',ExpDateCalve='" + ExpDate.Value.Date + "',DateCalved='" + DateCalved.Value.Date + "',CowAge='" + AgeBt.Text + "',Remarks='" + RemarksBt.Text + "' Where BrId=" + key + ";";
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
        int key = 0;
        private void BreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HeatDate.Text = BreedDGV.SelectedRows[0].Cells[1].Value.ToString();
            BreedDate.Text = BreedDGV.SelectedRows[0].Cells[2].Value.ToString();
            CowIdBt.SelectedValue = BreedDGV.SelectedRows[0].Cells[3].Value.ToString();
            CowNameBt.Text = BreedDGV.SelectedRows[0].Cells[4].Value.ToString();
            PregDate.Text = BreedDGV.SelectedRows[0].Cells[5].Value.ToString();
            ExpDate.Text = BreedDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateCalved.Text = BreedDGV.SelectedRows[0].Cells[7].Value.ToString();
            AgeBt.Text = BreedDGV.SelectedRows[0].Cells[8].Value.ToString();
            RemarksBt.Text = BreedDGV.SelectedRows[0].Cells[9].Value.ToString();
            if (CowNameBt.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BreedDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

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
                    String Query = "delete from BreedTbl where BrId =" + key + ";";
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
