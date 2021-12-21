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
    public partial class MeniuProdus : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;


        public MeniuProdus()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colNume = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colNume == "Edit")
            {
                PopUpProdus pup = new PopUpProdus(this);
                pup.Categorie();
                pup.Importator();
                pup.Tcod.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                pup.Tprodus.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                pup.Tcantitate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                pup.TPret.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                pup.CategorieCbox.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                pup.ImportatorCBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                pup.pkey.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                pup.Salveaza.Enabled = false;
                pup.Actualizati.Enabled = true;
                pup.ShowDialog();

            }
            else if (colNume == "Delete")
            {
                if (MessageBox.Show("Esti sigur ca vrei sa stergi acesta categorie?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from sqlproduse where pkey like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("done,");
                    IncarcaProdus();

                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PopUpProdus pop = new PopUpProdus(this);
            pop.Salveaza.Enabled = true;
            pop.Actualizati.Enabled = false;
            pop.Categorie();
            pop.Importator();
            pop.ShowDialog();
        }


        public void IncarcaProdus()
        {  
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT p.pkey, p.codbare, b.firma, p.produs, c.categorie, p.cantitate, p.pret, c.tva FROM sqlproduse p LEFT JOIN sqlcategorie c ON c.[key] =p.categorii and c.[key] = p.tva LEFT JOIN sqlbrand b ON b.[key] = p.importator where p.produs like  '" +Search.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            IncarcaProdus();
        }

        private void Search_Click(object sender, EventArgs e)
        {

        }
    }
}
