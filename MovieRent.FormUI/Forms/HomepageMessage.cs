using MovieRent.BLL.Repositories;
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
    public partial class HomepageMessage : Form
    {
        UserAppListRepository ualp = new UserAppListRepository();
        MoviesRepository mr = new MoviesRepository();
        public HomepageMessage()
        {
            InitializeComponent();
        }

        private void HomepageMessage_Load(object sender, EventArgs e)
        {
            var movieBilgi = mr.SelectAll().Where(x => x.Stock <= 10).ToList();
            foreach (var item in movieBilgi)
            {
                string msj = item.MovieName + " filminden stokta " + item.Stock + " ürün kalmıştır. Lütfen sipariş verin. Sipariş vermek için tıklayınız";
                listBox1.Items.Add(msj);
            }
            listBox1.ForeColor = Color.Red;

            lblTotalList.Text = ualp.SelectAll().Where(x => x.isActive == true).Count().ToString();
            lblTotalRented.Text = ualp.SelectAll().Where(x => x.isSent == true).Count().ToString();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            OrderMovie order = new OrderMovie();
            order.Show();
        }
    }
}
