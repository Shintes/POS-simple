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

namespace WindowsFormsApp1
{
    public partial class Caserie : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;


        public Caserie()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());
            DataNr.Text = DateTime.Now.ToLongDateString();
            KeyPreview = true;
            

        }

        private void Caserie_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cnume = dataGridView1.Columns[e.ColumnIndex].Name;
            if (cnume=="Delete")
            {
                if (MessageBox.Show("Esti sigur ca vrei sa stergi?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from sqlcaserie where cakey like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Done!");
                    Incarcacaseria();
                }
            }
        }


        private void IaTransNr()
        {
            try
            {
                string data = DateTime.Now.ToString("yyyyMMdd");
                string tranznr;
                int p;
                cn.Open();
                cm = new SqlCommand("select top 1 tranznr from sqlcaserie where tranznr like '" + data + "%' order by cakey desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    tranznr = dr[0].ToString();
                    p = int.Parse(tranznr.Substring(8 ,4));
                    Tranznr.Text = data + (p + 1); 
                }
                else
                {
                    tranznr = data + "1001";
                    Tranznr.Text = tranznr;
                }
                dr.Close();
                cn.Close();
                
         
            }
            catch(Exception)
            {
                cn.Close();
                MessageBox.Show("error");
            }
        }

        private void BtnCauta_Click(object sender, EventArgs e)
        {
            if (Tranznr.Text =="0")
            {
                return;
            }
            
                CautaProd cp = new CautaProd(this);
                cp.IncarcaProdus();
                cp.ShowDialog();
                
        }

        private void button18_Click(object sender, EventArgs e)
        {
            IaTransNr();
            Search.Enabled = true;
            Search.Focus();
            dataGridView1.Rows.Clear();
        }

        private void Search_Click(object sender, EventArgs e)
        {
         
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(Numerar1.Text=="0")
            {
                Numerar1.Text = "";
            }

            Button buton= (Button)sender;
            Numerar1.Text = Numerar1.Text + buton.Text;


           
        }

        private void bs_Click(object sender, EventArgs e)
        {
            Numerar1.Text = "0";
        }


        private void Rezultat_TextChanged(object sender, EventArgs e)
        {

        }

        private void bx_Click(object sender, EventArgs e)
        {
            Numerar1.Text = Numerar1.Text + ".";
        }

        private void BtnDecon_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Incarcacaseria()
        {
            try
            {
                double totalftva = 0;
                double totaltva = 0;
                double totalcutva = 0;
                double d = 100;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT ca.cakey, ca.pkey, p.produs, ca.cantitate, ca.pret, c.tva,ca.total from sqlcaserie as ca inner join sqlproduse as p on ca.pkey = p.pkey left join sqlcategorie as c on c.[key]=ca.tva where tranznr like'" + Tranznr.Text + "'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    totalftva += double.Parse(dr[6].ToString());
                    totaltva += (double.Parse(dr[5].ToString()) / d) * totalftva;
                    totalcutva += totalftva + totaltva;
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());

                }
                
                dr.Close();
                cn.Close();
                Totalftva.Text = totalftva.ToString();
                TotalTva.Text = totaltva.ToString();
                Total1.Text = totalcutva.ToString();
            }

            catch (Exception)
            {
                MessageBox.Show("error");
                cn.Close();
            }
        }


        private void Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Search.Text == String.Empty)
                {
                    return;
                }
                else
                {
                    cn.Open();
                    cm = new SqlCommand("select * from sqlproduse where codbare like '" + Search.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cantitate can = new cantitate(this);
                        can.Produsdet(dr["pkey"].ToString(), double.Parse(dr["pret"].ToString()),Tranznr.Text.ToString(), dr["tva"].ToString());
                        dr.Close();
                        cn.Close();
                        can.ShowDialog();
                    }

                    else
                    {
                        dr.Close();
                        cn.Close();
                    }
                    cn.Close();
                    dr.Close();
                }
            }
            catch (Exception)
            {
                cn.Close();
                MessageBox.Show("error");
            }
        }

        private void be_Click(object sender, EventArgs e)
        {
            double a, b, c;
            a = Convert.ToDouble(Total1.Text);
            b = Convert.ToDouble(Numerar1.Text);
            c = Convert.ToDouble(Rest1.Text);
            if (c <=0)
            {
                c = a - b;
                c = Math.Abs(c);
                Rest1.Text = c.ToString("0.##");
            }
        }
    }
}
