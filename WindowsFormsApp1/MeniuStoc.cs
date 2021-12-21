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
    public partial class MeniuStoc : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        SqlDataReader dr;

        public MeniuStoc()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());
        }





        public void IncarcaStoc1()
        {
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwprodstoc where refnr like '" + Searchref.Text + "%' and status = 'Asteptare'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void incarcaistoric()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwprodstoc where cast (sdata as date) between'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and status = 'Gata'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[4].ToString()).ToShortDateString(),dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void MeniuStoc_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cnume = dataGridView2.Columns[e.ColumnIndex].Name;
            if (cnume == "sdelete")
            {
                if (MessageBox.Show("Esti sigur ca vrei stergi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from sqlstoc where skey = '" + dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("done!");
                   
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MeniuStoc1 ms1 = new MeniuStoc1(this);
            ms1.IncarcaStoc();
            ms1.ShowDialog();
        }


        public void clear()
        {
            ref1.Clear();
            nume2.Clear();
            dat1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    if (MessageBox.Show("Esti sigur ca vrei sa adaugi astest stoc?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            cn.Open();
                            cm = new SqlCommand("update sqlproduse set cantitate = cantitate + " + int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString()) + " where pkey like '" + dataGridView2.Rows[i].Cells[6].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            cn.Open();
                            cm = new SqlCommand("update sqlstoc set cantitate = cantitate + " + int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString()) + ", status = 'Gata' where skey like '" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        clear();
                        IncarcaStoc1();
                    }
                }
            }
            catch(Exception)
            {
                cn.Close();
                MessageBox.Show("eror","");
            }
        }

        private void Searchref_TextChanged(object sender, EventArgs e)
        {
            IncarcaStoc1();
        }

        private void AdaugaStoc_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            incarcaistoric();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
