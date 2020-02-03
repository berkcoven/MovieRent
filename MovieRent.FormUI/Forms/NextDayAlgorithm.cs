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
    public partial class NextDayAlgorithm : Form
    {
        UserAppListRepository uap = new UserAppListRepository();
        MoviesRepository mv = new MoviesRepository();
        public NextDayAlgorithm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime today = DateTime.Now.AddDays(1);
            List<UserAppFilmList> lists= uap.SelectAll().Where(x => x.KiralaTarihi != null && x.isActive == true && x.KiralaTarihi.Value.Day == today.Day).ToList();
            List<Movies> moies = mv.SelectAll();
            List<UserAppFilmList> a = uap.NextDayAlgo(lists, moies);
            foreach (var item in a)
            {
                item.isSent = true;
                uap.Update(item.ListID, item);
            }
            dataGridView1.DataSource = a;

        }
    }
}
