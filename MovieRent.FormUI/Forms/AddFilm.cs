using MovieRent.BLL.Repositories;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRent.FormUI
{
    public partial class AddFilm : Form
    {
        CategoryRepository cr = new CategoryRepository();
        MoviesRepository mr = new MoviesRepository();

        public AddFilm()
        {
            InitializeComponent();
        }

        private void txtMovieName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPictureSelect_Click(object sender, EventArgs e)
        {

            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select image to be upload.";
            //which type image format you want to upload in database. just add them.
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        
                        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }



        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string imagePathf;

            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid image.");
                }
                else
                {
                    //we already define our connection globaly. We are just calling the object of connection.
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    System.IO.File.Copy(openFileDialog1.FileName, "C:\\Users\\Berk.Coven\\source\\repos\\MovieRent\\WebApplication1\\Content\\images\\" + filename);
                    MessageBox.Show("Image uploaded successfully.");
                    imagePathf = @"/Content/images/" + filename;

                    var selectedCat = cr.SelectAll().Where(x => x.CategoryName == comboBox1.SelectedItem.ToString()).FirstOrDefault();


                    Movies movie = new Movies();
                    movie.MovieName = txtMovieName.Text;
                    movie.CrMovieName = txtMovieTrName.Text;
                    movie.Description = richTextBox1.Text;
                    movie.ImagePath = imagePathf;
                    movie.RelaiseDate = dateTimePicker1.Value;
                    movie.Stock = (short)nudStock.Value;
                    movie.CategoryID = selectedCat.CategoryID;
                    movie.Director = txtDirector.Text;
                    movie.Actors = txtActor.Text;
                    movie.Awards = txtAwards.Text;
                    movie.AudioProperty = cmbAudio.SelectedItem.ToString();
                    movie.Altyazi = txtSubtitles.Text;

                    mr.Add(movie);


                    


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Already exits /Change the name of the picture");
            }

           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AddFilm_Load(object sender, EventArgs e)
        {
            List<Categories> categories = cr.SelectAll();
            foreach (var item in categories)
            {
                comboBox1.Items.Add(item.CategoryName);
            }
            
        }
    }
}
