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
    public partial class MeniuStoc1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;
        MeniuStoc mss;
        public MeniuStoc1(MeniuStoc ms)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());
            mss = ms;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void IncarcaStoc()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from sqlproduse where produs like '" + Searchprod.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[3].ToString(), dr[5].ToString());
            }
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string sele = dataGridView1.Columns[e.ColumnIndex].Name;
            if (sele == "Select")
            {
                if (mss.ref1.Text == string.Empty) { MessageBox.Show("Adauga referinta!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); mss.ref1.Focus(); return; }
                if (mss.nume2.Text == string.Empty) { MessageBox.Show("Adauga nume!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); mss.nume2.Focus(); return; }

                if (MessageBox.Show("Esti sigur ca vrei sa adaugi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();

                    cm = new SqlCommand("insert into sqlstoc (refnr, pkey, sdata, adaugat) values (@refnr, @pkey, @sdata, @adaugat)", cn);
                    cm.Parameters.AddWithValue("@refnr", mss.ref1.Text);
                    cm.Parameters.AddWithValue("@pkey", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cm.Parameters.AddWithValue("@sdata", mss.dat1.Value);
                    cm.Parameters.AddWithValue("@adaugat", mss.nume2.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Done!");
                    mss.IncarcaStoc1();
                }


            }
        }

        private void Searchprod_TextChanged(object sender, EventArgs e)
        {
            IncarcaStoc();
        }
    }
}
