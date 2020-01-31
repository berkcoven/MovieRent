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
    public partial class LogIn : Form
    {
        AdminRepository ar = new AdminRepository();
        UserAppRepository ur = new UserAppRepository();
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Admin admin = ar.SelectAll().Where(x =>x.AdminName == txtAdminName.Text.ToLower() && x.AdminSifre == txtAdminPass.Text).FirstOrDefault();
            if (admin != null)
            {
                Homepage form = new Homepage();

                form.Show();
                this.Hide();

            }

        }
    }
}
