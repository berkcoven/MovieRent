﻿using MovieRent.BLL.Repositories;
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
    public partial class ReportPage : Form
    {
        UserAppListRepository uap = new UserAppListRepository();
        MoviesRepository mv = new MoviesRepository();
        UserAppRepository uar = new UserAppRepository();
        PremiumRepository pr = new PremiumRepository();

        public ReportPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            DateTime Mdate = DateTime.Now;
            var liste = from item in uar.SelectAll()
                        select new
                        {
                            Username = item.UserName,
                            PremiumId = item.PremiumID,
                            Premium = pr.SelectByID(item.PremiumID).PremiumName,
                            UyeTarihi = item.UyeOlmeTarihi,
                            Price = pr.SelectByID(item.PremiumID).Price,
                            MonthsUserFor = Math.Ceiling(((Mdate-item.UyeOlmeTarihi).TotalDays)/30),
                            NetIncomeFromUser = ((double)pr.SelectByID(item.PremiumID).Price * Math.Ceiling(((Mdate - item.UyeOlmeTarihi).TotalDays) / 30))

                        };

           
            
            dataGridView1.DataSource = liste.ToList();


            double total = liste.Sum(x => x.NetIncomeFromUser);
            int userSayi = liste.Count();
            lblTotalPrice.Text = total.ToString();
            lblTotalUser.Text = userSayi.ToString();

        }
    }
}
