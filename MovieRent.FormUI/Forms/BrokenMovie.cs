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
    public partial class BrokenMovie : Form
    {
        MoviesRepository mv = new MoviesRepository();
        public BrokenMovie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Movies movie = mv.SelectMovieByName(comboBox1.SelectedItem.ToString());
                movie.isBroken = true;
                movie.BrokenDetails = richTextBox1.Text;
                mv.Update(movie.MovieID, movie);
                MessageBox.Show(movie.MovieName + " isimli film 'Bozuk' olarak güncellendi");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Hata oluştu");
                MessageBox.Show(ex.Message);
            }
            comboBox1.SelectedItem = null;
            richTextBox1.Text = String.Empty;
        }

        private void BrokenMovie_Load(object sender, EventArgs e)
        {
            var movies = mv.SelectAll();
            foreach (var item in movies)
            {
                comboBox1.Items.Add(item.MovieName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Movies movie = mv.SelectMovieByName(comboBox1.SelectedItem.ToString());
                if (movie.isBroken == true)
                {
                    richTextBox1.Text = movie.BrokenDetails;
                    button1.Visible = false;
                    btnFixed.Visible = true;
                }
                else
                {
                    richTextBox1.Text = String.Empty;
                    btnFixed.Visible = false;
                    button1.Visible = true;
                }
            }

        }

        private void btnFixed_Click(object sender, EventArgs e)
        {
            try
            {
                Movies movie = mv.SelectMovieByName(comboBox1.SelectedItem.ToString());
                movie.isBroken = false;
                movie.BrokenDetails = null;
                mv.Update(movie.MovieID, movie);
                richTextBox1.Text = String.Empty;
                MessageBox.Show(movie.MovieName + " isimli film 'tamir edildi' olarak güncellendi");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Hata oluştu");
                MessageBox.Show(ex.Message);
            }
            comboBox1.SelectedItem = null;
            richTextBox1.Text = String.Empty;
        }
    }
}
