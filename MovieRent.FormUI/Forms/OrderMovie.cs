using MovieRent.BLL.Repositories;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRent.FormUI.Forms
{
    public partial class OrderMovie : Form
    {
        MoviesRepository mv = new MoviesRepository();
        SupplierRepository sr = new SupplierRepository();

        public OrderMovie()
        {
            InitializeComponent();
        }

        private void OrderMovie_Load(object sender, EventArgs e)
        {
            var movies = mv.SelectAll();
            foreach (var item in movies)
            {
                comboBox1.Items.Add(item.MovieName);
            }
            var supp = sr.SelectAll();
            foreach (var item in supp)
            {
                cmbSup.Items.Add(item.SupplierName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Movies movie = mv.SelectMovieByName(comboBox1.SelectedItem.ToString());
                movie.Stock +=(short) numericUpDown1.Value;
                movie.SupplierID = sr.SelectAll().Where(x=>x.SupplierName==cmbSup.SelectedItem.ToString()).FirstOrDefault().SupplierID;
                mv.Update(movie.MovieID, movie);
                MessageBox.Show("İşleminiz Başarıyla Gerçekleşmiştir");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Hata Oluştu");
                MessageBox.Show(ex.Message);
            }
            comboBox1.SelectedItem = null;
            cmbSup.SelectedItem = null;
        }
    }
}
