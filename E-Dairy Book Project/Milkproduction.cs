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
    public partial class Milkproduction : Form
    {
        public Milkproduction()
        {
            InitializeComponent();
            fillcCowId();
            populate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
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

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Cows ob = new Cows();
            ob.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Cowhealth ob = new Cowhealth();
            ob.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
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

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void Milkproduction_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lenovo\OneDrive\Documents\DairyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
       //to fill the combo box of milk production..
        private void fillcCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl",Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add ("CowId",typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            String query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void clear()
        {
            CownameCb.Text = "";
            Amt.Text = "";
            noonCb.Text = "";
            PmCb.Text = "";
            TotalCb.Text = "";
            key = 0;
        }
        //To display cow name by its id in combobox

        private void GetCowname()
        {
            Con.Open();
            string query = "select * from CowTbl where CowId="+CowIdCb .SelectedValue.ToString()+" ";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CownameCb.Text = dr["CowName"].ToString();

            }
            Con.Close();
        }

        //Save Data Of Milk production

        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CownameCb.Text == "" || Amt.Text == "" || noonCb.Text == "" || PmCb.Text == "" || TotalCb.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into MilkTbl values("+CowIdCb.SelectedValue.ToString()+",'" + CownameCb.Text + "', '" + Amt.Text + "', '" + noonCb.Text + "', '" + PmCb.Text + "', '" + TotalCb.Text + "', '" + DateCb.Value.Date  + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Data Saved Successfully...");
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

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowname();
        }

        private void PmCb_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
          //To display Total milk in Milk production
        private void PmCb_OnValueChanged(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(Amt.Text) + Convert.ToInt32(noonCb.Text) + Convert.ToInt32(PmCb.Text);
            TotalCb.Text = "" + total; 
           
        }
        int key = 0;
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CownameCb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            Amt.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            noonCb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmCb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalCb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateCb.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CownameCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The data To Delete!!!  ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from MilkTbl where Mld =" + key + ";";
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
        //edit Option milk Production form

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CownameCb.Text == "" || Amt.Text == "" || noonCb.Text == "" || PmCb.Text == "" || TotalCb.Text == "")
            {
                MessageBox.Show("Misssing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "update MilkTbl set CowName = '" + CownameCb.Text + "',AmMilk='" + Amt.Text + "',NoonMilk='" + noonCb.Text + "',PmMilk='" + PmCb.Text + "',Total='" + TotalCb.Text + "',Dateprod='" + DateCb.Value.Date + "' Where Mld=" + key + ";";
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









