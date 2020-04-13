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
namespace Kelime_Öğren
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblDogru.Visible = false;
            lblYanlis.Visible = false;
            lblKelime.Visible = false;
            button1.Visible = false;
        }
        private void toolIslemler_Click(object sender, EventArgs e)
        {
            KelimeCrud form = new KelimeCrud();
            form.Show();
        }
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\VisualProjects\\KelimeOgren\\Kelime Öğren\\bin\\Debug\\Kelimeler.mdf;Integrated Security=True");

        int sayi = 0;


        private int getSayi()
        {
            return this.sayi;
        }


        private int setSayi()
        {
            Random rastgele = new Random();
            this.sayi = rastgele.Next(10,15);
            return this.sayi;
        }

        private void YeniKelime()
        {
            int id = setSayi();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT kelime FROM Kelime where id ='" + id + "'", cnn);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader rd = null;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblKelime.Text = rd["kelime"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            cnn.Close();
        }

        //düzeltilebilir
        private void lblYanlis_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        { 
            int id = getSayi();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT anlam FROM Kelime where id ='" + id + "'", cnn);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader rd = null;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd["anlam"].ToString() == txtGelenKelime.Text)
                    {
                        lblYanlis.Visible = false;
                        lblDogru.Visible = true;
                        lblDogru.Text = "Doğru";

                        int id2 = setSayi();
                        SqlCommand cmd2 = new SqlCommand("SELECT kelime FROM Kelime where id ='" + id2 + "'", cnn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        rd.Close();
                        rd = cmd2.ExecuteReader();
                        while (rd.Read())
                        {
                            lblKelime.Text = rd["kelime"].ToString();
                        }
                    }
                    else
                    {
                        lblDogru.Visible = false;
                        lblYanlis.Visible = true;
                        lblYanlis.Text = "Yanlış";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            cnn.Close();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            btnStart.Visible = false;
            lblKelime.Visible = true;
            YeniKelime();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtGelenKelime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();


                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
