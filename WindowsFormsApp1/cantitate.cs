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
    public partial class cantitate : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();
        Caserie cas;
        public cantitate(Caserie cass)
        {
            cn = new SqlConnection(dbcon.Conexiune());
            InitializeComponent();
            cas = cass;
        }

        private void cantitate1_TextChanged(object sender, EventArgs e)
        {

        }
        private string pkey;
        private double pret;
        private string tva;
        private string tranznr;

        public void Produsdet(String pkey, double pret, String tranznr, String tva)
        {
            this.pkey = pkey;
            this.pret = pret;
            this.tva = tva;
            this.tranznr = tranznr;
            
        }


        private void cantitate_Load(object sender, EventArgs e)
        {
           
        }

        private void cantitate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (cantitate1.Text != string.Empty))
            {
                cn.Open();
                cm = new SqlCommand("insert into sqlcaserie (tranznr, pkey, pret, cantitate ,cdata, tva) values (@tranznr, @pkey, @pret, @cantitate, @cdata, @tva)", cn);
                cm.Parameters.AddWithValue("@tranznr", tranznr);
                cm.Parameters.AddWithValue("@pkey", pkey);
                cm.Parameters.AddWithValue("@pret", pret);
                cm.Parameters.AddWithValue("@tva", tva);
                cm.Parameters.AddWithValue("@cantitate", int.Parse(cantitate1.Text));
                cm.Parameters.AddWithValue("@cdata", DateTime.Now);
                cm.ExecuteNonQuery();
                cn.Close();

                cas.Search.Clear();
                cas.Search.Focus();
                cas.Incarcacaseria();
                Dispose();
                
            }
        }
    }
}
