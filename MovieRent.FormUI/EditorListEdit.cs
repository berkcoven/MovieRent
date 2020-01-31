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
    

    public partial class EditorListEdit : Form
    {
        MoviesRepository movies = new MoviesRepository();
        public EditorListEdit()
        {
            InitializeComponent();
        }

        private void EditorListEdit_Load(object sender, EventArgs e)
        {
            List<Movies> mnb = movies.SelectAll().Where(x => x.AdminID == null).ToList();
            foreach (var item in mnb)
            {
                listNotInc.Items.Add(item.MovieName);
            }
            

            List<Movies> mb = movies.SelectAll().Where(x => x.AdminID != null).ToList();
            foreach (var item in mb)
            {
                listEditorpick.Items.Add(item.MovieName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = listNotInc.SelectedItem;
            listNotInc.Items.Remove(selected);
            listEditorpick.Items.Add(selected);

            Movies mv=  movies.SelectMovieByName(selected.ToString());
            movies.AddtoEditorList(mv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selected = listEditorpick.SelectedItem;
            listNotInc.Items.Add(selected);
            listEditorpick.Items.Remove(selected);

            Movies mv = movies.SelectMovieByName(selected.ToString());
            movies.RemoveFromEditorList(mv);

        }
    }
}
