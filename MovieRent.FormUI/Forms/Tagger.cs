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
            List<UserApp> users = uap.SelectAll();

            foreach (var item in users)
            {
                comboBox1.Items.Add(item.UserName);
              
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMovieName.Text = String.Empty;
            lblCarrier.Text = String.Empty;
            txtCarrier.Text = String.Empty;
            UserApp userApp = uap.SelectAll().Where(x => x.UserName == comboBox1.SelectedItem.ToString()).FirstOrDefault();
            List<UserAppFilmList> filmLists = ualp.SelectAll().Where(x => x.UserID == userApp.UserID && x.isSent == true).ToList();
            foreach (var item in filmLists)
            {
                lblMovieName.Text += item.MovieName + "/";
            }
            lblUserName.Text = userApp.UserName;
            lblUserAdress.Text = userApp.Adres;
            if (userApp.NotDeliverTimes != 0)
            {
                lblUserError.Text = "Bu Kullanıcı " + userApp.NotDeliverTimes + " kez film iadesi yapmadı. Lütfen bir sonraki teslim zamanında iade işleminizi yapınız";

            }
            else
            {
                lblUserError.Text = "Kullanıcının iade işlemleri yapılmıştır";
            }


            #region deneme
            //UserAppFilmList appFilmList = ualp.SelectByID(Int32.Parse(comboBox1.SelectedItem.ToString()));
            //UserApp ua = uap.SelectByID(appFilmList.UserID);
            
            //lblMovieName.Text = appFilmList.MovieName;
            //lblUserName.Text = ua.UserName;
            //lblUserAdress.Text = ua.Adres;
            //if (ua.NotDeliverTimes != 0)
            //{
            //    lblUserError.Text = "Bu Kullanıcı " + ua.NotDeliverTimes + " kez film iadesi yapmadı. Lütfen bir sonraki teslim zamanında iade işleminizi yapınız";


            //}
            //else
            //{
            //    lblUserError.Text = "Kullanıcının iade işlemleri yapılmıştır";
            //}
            #endregion deneme
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserApp userApp = uap.SelectAll().Where(x => x.UserName == comboBox1.SelectedItem.ToString()).FirstOrDefault();
            List<UserAppFilmList> filmLists = ualp.SelectAll().Where(x => x.UserID == userApp.UserID && x.isSent == true).ToList();
            foreach (var item in filmLists)
            {
                item.CarrierName = txtCarrier.Text;
                ualp.Update(item.ListID, item);
                lblCarrier.Text = item.CarrierName;
            }




            //UserAppFilmList appFilmList = ualp.SelectByID(Int32.Parse(comboBox1.SelectedItem.ToString()));
            //appFilmList.CarrierName = txtCarrier.Text;
            //ualp.Update(appFilmList.ListID, appFilmList);
            //lblCarrier.Text = appFilmList.CarrierName;


        }
    }
}
