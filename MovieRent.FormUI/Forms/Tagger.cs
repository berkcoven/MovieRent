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
    public partial class Tagger : Form
    {
        UserAppListRepository ualp = new UserAppListRepository();
        UserAppRepository uap = new UserAppRepository();

        public Tagger()
        {
            InitializeComponent();
        }

        private void Tagger_Load(object sender, EventArgs e)
        {
            List<UserAppFilmList> userAppFilmLists = ualp.SelectAll();

            foreach (var item in userAppFilmLists)
            {
                comboBox1.Items.Add(item.ListID);
              
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserAppFilmList appFilmList = ualp.SelectByID(Int32.Parse(comboBox1.SelectedItem.ToString()));

            UserApp ua = uap.SelectByID(appFilmList.UserID);
            
            lblMovieName.Text = appFilmList.MovieName;
            lblUserName.Text = ua.UserName;
            lblUserAdress.Text = ua.Adres;
            if (ua.NotDeliverTimes != 0)
            {
                lblUserError.Text = "Bu Kullanıcı " + ua.NotDeliverTimes + " kez film iadesi yapmadı. Lütfen bir sonraki teslim zamanında iade işleminizi yapınız";


            }
            else
            {
                lblUserError.Text = "Kullanıcının iade işlemleri yapılmıştır";
            }

        }
    }
}
