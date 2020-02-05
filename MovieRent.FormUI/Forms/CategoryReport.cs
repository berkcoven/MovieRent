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
    public partial class CategoryReport : Form
    {
        UserAppListRepository uap = new UserAppListRepository();
        MoviesRepository mv = new MoviesRepository();
        UserAppRepository uar = new UserAppRepository();
        PremiumRepository pr = new PremiumRepository();
        CategoryRepository cr = new CategoryRepository();

        public CategoryReport()
        {
            InitializeComponent();
        }

        private void CategoryReport_Load(object sender, EventArgs e)
        {

            List<Categories> cat = cr.SelectAll();

            foreach (var item in cat)
            {
                comboBox1.Items.Add(item.CategoryName);
            }
            List<Movies> mov = mv.SelectAll();
            var liste = from item in mov
                        select new
                        {
                            MovieName = item.MovieName,
                            Category = cr.SelectByID(item.CategoryID).CategoryName,
                            TimesRented = uap.SelectAll().Where(x => x.isSent == true && x.MovieID ==item.MovieID).Count(),
                            TimesListed = uap.SelectAll().Where(x =>(x.isSent==true ||x.isActive == true )&& x.MovieID == item.MovieID).Count()



                        };
            dataGridView1.DataSource = liste.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catID = cr.SelectAll().Where(x=>x.CategoryName==comboBox1.SelectedItem.ToString()).FirstOrDefault().CategoryID;
            lblNoCatMov.Text = mv.SelectAll().Where(x => x.CategoryID == catID).Count().ToString();
            
        }
    }
}
