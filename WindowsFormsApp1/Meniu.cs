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
    public partial class Meniu : Form
    
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        conBazeDeDate dbcon = new conBazeDeDate();

        public Meniu()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.Conexiune());
            cn.Open();
            MessageBox.Show("Conectat");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Caserie cas = new Caserie();
            cas.ShowDialog();
            Close();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void Meniu_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            BazaBrand firma = new BazaBrand();
            firma.TopLevel = false;
            panel3.Controls.Add(firma);
            firma.BringToFront();
            firma.Show();
            


        }

        private void button9_Click(object sender, EventArgs e)
        {
            MeniuCateg categorie = new MeniuCateg();
            categorie.TopLevel = false;
            panel3.Controls.Add(categorie);
            categorie.BringToFront();
            categorie.IncarcaCategorie();
            categorie.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MeniuProdus produs = new MeniuProdus();
            produs.TopLevel = false;
            panel3.Controls.Add(produs);
            produs.BringToFront();
            produs.IncarcaProdus();
            produs.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MeniuStoc stoc = new MeniuStoc();
           
            stoc.TopLevel = false;
            panel3.Controls.Add(stoc);
            stoc.BringToFront();
            stoc.IncarcaStoc1();
            stoc.Show();
        }
    }
}
  