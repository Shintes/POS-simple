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
//Cn = connection
//cm = command
//dbcon= data base conectare
{
    public partial class BazaBrand : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;
        public BazaBrand()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());
            IncarcaBrands();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colNume = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colNume == "Edit")
            {
                PopUpAdauga pua = new PopUpAdauga(this);
                pua.lblID.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                pua.Txt1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                pua.Salveaza.Enabled = false;
                pua.Actualizati.Enabled = true;
                pua.ShowDialog();

            }
            else if (colNume == "Delete")
            {
                if (MessageBox.Show("Esti sigur ca vrei sa stergi acest firma?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from sqlbrand where Firma like '" + dataGridView1[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("done,");
                    IncarcaBrands();

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PopUpAdauga frm = new PopUpAdauga(this);
            frm.Salveaza.Enabled = true;
            frm.Actualizati.Enabled = false;
            frm.ShowDialog();

        }
        public void IncarcaBrands()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from sqlbrand order by firma", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["firma"].ToString());

            }
            dr.Close();
            cn.Close();

        }
    }
}
