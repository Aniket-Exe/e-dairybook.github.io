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

namespace E_Dairy_Book_Project
{
    public partial class Cowhealth : Form
    {
        public Cowhealth()
        {
            InitializeComponent();
            fillcCowId();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
        //to fill the combo box of Cow Health Form page.
        private void fillcCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdHb.ValueMember = "CowId";
            CowIdHb.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            String query = "select * from HealthTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HealthDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void GetCowname()
        {
            Con.Open();
            string query = "select * from CowTbl where CowId=" + CowIdHb.SelectedValue.ToString() + " ";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameHb.Text = dr["cowname"].ToString();

            }
            Con.Close();
        }
        private void Cowhealth_Load(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            Milkproduction ob = new Milkproduction();
            ob.Show();
            this.Hide();
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
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

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {
            Cows ob = new Cows();
            ob.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Sales ob = new Sales();
            ob.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void CowIdHb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowname();
        }
        private void clear()
        {
            CowNameHb.Text = "";
            EventHb.Text = "";
            CostHb.Text = "";
            VetNameHb.Text = "";
            DiangnosisHb.Text = "";
            TreatmentHb.Text = "";
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdHb.SelectedIndex == -1 || CowNameHb.Text == "" || EventHb.Text == "" || CostHb.Text == "" || VetNameHb.Text == "" || DiangnosisHb.Text == "" || TreatmentHb.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into HealthTbl values(" + CowIdHb.SelectedValue.ToString() + ",'" + CowNameHb.Text + "', '" + DateHb.Value.Date + "', '" + EventHb.Text + "',  '" + DiangnosisHb.Text + "', '" + TreatmentHb.Text + "','" + CostHb.Text + "', '" + VetNameHb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health Record Saved Successfully...");
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
        private void HealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdHb.SelectedValue = HealthDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameHb.Text = HealthDGV.SelectedRows[0].Cells[2].Value.ToString();
            DateHb.Text = HealthDGV.SelectedRows[0].Cells[3].Value.ToString();
            EventHb.Text = HealthDGV.SelectedRows[0].Cells[4].Value.ToString();
            DiangnosisHb.Text = HealthDGV.SelectedRows[0].Cells[5].Value.ToString();
            TreatmentHb.Text = HealthDGV.SelectedRows[0].Cells[6].Value.ToString();
            CostHb.Text = HealthDGV.SelectedRows[0].Cells[7].Value.ToString();
            VetNameHb.Text = HealthDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (CowNameHb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HealthDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Health Report To Delete!!!  ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from HealthTbl where RepId =" + key + ";";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdHb.SelectedIndex == -1 || CowNameHb.Text == "" || EventHb.Text == "" || CostHb.Text == "" || VetNameHb.Text == "" || DiangnosisHb.Text == "" || TreatmentHb.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "update HealthTbl set CowId=" + CowIdHb.SelectedValue.ToString() + ",cowname = '" + CowNameHb.Text + "',RepDate='" + DateHb.Value.Date + "',Event='" + EventHb.Text + "',Diagnosis='" + DiangnosisHb.Text + "',Cost='" + CostHb.Text + "',VetName='" + VetNameHb + "',Treatment='" + TreatmentHb.Text + "' Where RepId=" + key + ";";
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
