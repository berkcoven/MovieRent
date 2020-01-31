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

namespace MovieRent.FormUI
{
    public partial class NextDayAlgorithm : Form
    {
        UserAppListRepository uap = new UserAppListRepository();
        public NextDayAlgorithm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.AddDays(1);
            var a= uap.SelectAll().Where(x => x.KiralaTarihi != null && x.isActive == true && x.KiralaTarihi.Value.Day == today.Day).ToList();

        }
    }
}
