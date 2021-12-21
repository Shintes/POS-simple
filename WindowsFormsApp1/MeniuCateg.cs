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
    public partial class MeniuCateg : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;

        public MeniuCateg()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colNume = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colNume == "Edit")
            {
                PopUpCateg puc = new PopUpCateg(this);
                puc.lblID.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                puc.Txt1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                puc.Salveaza.Enabled = false;
                puc.Actualizati.Enabled = true;
                puc.ShowDialog();

            }
            else if (colNume == "Delete")
            {
                if (MessageBox.Show("Esti sigur ca vrei sa stergi acesta categorie?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from sqlcategorie where categorie like '" + dataGridView1[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("done,");
                    IncarcaCategorie();

                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PopUpCateg pop = new PopUpCateg(this);
            pop.Salveaza.Enabled = true;
            pop.Actualizati.Enabled = false;
            pop.ShowDialog();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void IncarcaCategorie()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from sqlcategorie order by categorie", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[1].ToString(), dr[2].ToString());

            }
            dr.Close();
            cn.Close();
        }
    }
}
