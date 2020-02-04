using MovieRent.BLL.Repositories;
using MovieRent.COMMON.Helpers;
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
        UserAppRepository uar = new UserAppRepository();
        public NextDayAlgorithm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime today = DateTime.Now.AddDays(1);
            List<UserAppFilmList> lists= uap.SelectAll().Where(x => x.KiralaTarihi != null && x.isActive == true && x.KiralaTarihi.Value.Day == today.Day&&x.isSent==false).ToList();
            List<Movies> moies = mv.SelectAll();
            List<UserAppFilmList> a = uap.NextDayAlgo(lists, moies);
            dataGridView1.DataSource = a;
            foreach (var item in a)
            {
                item.isActive = false;
                uap.Update(item.ListID, item);
            }

           
            //select UserID from UserAppFilmList where isSent = 1 group by UserID
            var list = a.GroupBy(x => x.UserID).Select(x=>new { x=x.Key});
            foreach (var item in list)
            {
                
                UserApp app = uar.SelectByID(item.x);
                List<UserAppFilmList> userlst = uap.SelectAll().Where(x => x.UserID == app.UserID && x.isSent == true&&x.isActive==false&&x.KiralaTarihi.Value.Day==today.Day).ToList();
                string body = "Sayın"+app.UserName+" MovieRent üzerinden vermiş olduğunuz: ";
                foreach (var item1 in userlst)
                {
                    body += item1.MovieName + " / ";
                }
                body += today + " tarihinde elinizde olacaktır. Bizi tercih ettiğiniz için ty";
                //Mailer.Send(app.Email, body, "MovieRent Kiralama");
            }

            foreach (var item in a)
            {
                Movies movi = mv.SelectByID(item.MovieID);
                movi.Stock -= 1;
                mv.Update(movi.MovieID, movi);
            }


        }

        private void NextDayAlgorithm_Load(object sender, EventArgs e)
        {

        }
    }
}
