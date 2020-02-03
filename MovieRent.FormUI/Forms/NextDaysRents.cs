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
    public partial class NextDaysRents : Form
    {

        UserAppListRepository uap = new UserAppListRepository();
        public NextDaysRents()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NextDaysRents_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.AddDays(1);

            

            var userAppFilmLists = uap.SelectAll().Where(x =>x.KiralaTarihi!=null&&x.isActive==true&&x.KiralaTarihi.Value.Day==today.Day).ToList();
            
            dataGridView1.DataSource =userAppFilmLists;
        }
    }
}
