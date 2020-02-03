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

namespace MovieRent.FormUI
{
    public partial class Barcoder : Form
    {
        MoviesRepository mr = new MoviesRepository();
        public Barcoder()
        {
            InitializeComponent();
        }

        private void Barcoder_Load(object sender, EventArgs e)
        {
            foreach (var item in mr.SelectAll())
            {
                comboBox1.Items.Add(item.MovieName);
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movies movie =  mr.SelectMovieByName(comboBox1.SelectedItem.ToString());
            string barkod = movie.MovieID + "00" + movie.CategoryID;
            movie.Barkodno = Int32.Parse(barkod);
            
            mr.Update(movie.MovieID, movie);
            lblBarcode.Text = movie.Barkodno.ToString();
            lblBarkodAcik.Text = movie.MovieName + " isimli filmi " + movie.CategoryID + ". raf, " + movie.MovieID + ". sıraya koyunuz.";
        }
    }
}
