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
    public partial class CautaProd : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;
        Caserie c;
        public CautaProd(Caserie ca)
        {
            cn = new SqlConnection(dbcon.Conexiune());
            InitializeComponent();
            c = ca;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void IncarcaProdus()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT p.pkey, p.codbare, b.firma, p.produs, c.categorie, p.cantitate, p.pret, c.tva FROM sqlproduse p LEFT JOIN sqlcategorie c ON c.[key] =p.categorii and c.[key] = p.tva LEFT JOIN sqlbrand b ON b.[key] = p.importator where p.produs like  '" + Searchprod.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void Searchprod_TextChanged(object sender, EventArgs e)
        {
            IncarcaProdus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cnume = dataGridView1.Columns[e.ColumnIndex].Name;
            if (cnume=="select")
            {
                cantitate can = new cantitate(c);
                can.Produsdet(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()), c.Tranznr.Text.ToString(), dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                can.ShowDialog();
            }
        }
    }
  
}
