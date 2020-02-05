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
    public partial class SupplierReport : Form
    {
        SupplierRepository sr = new SupplierRepository();
        MoviesRepository mr = new MoviesRepository();
        public SupplierReport()
        {
            InitializeComponent();
        }

        private void SupplierReport_Load(object sender, EventArgs e)
        {
            var suppliers = sr.SelectAll();
            foreach (var item in suppliers)
            {
                comboBox1.Items.Add(item.SupplierName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suppliers sup = sr.SelectAll().Where(x => x.SupplierName == comboBox1.SelectedItem.ToString()).FirstOrDefault();
            List<Movies> mov = mr.SelectAll().Where(x=>x.SupplierID==sup.SupplierID).ToList();
            var liste = from item in mov
                        select new
                        {
                            Supplier = sup.SupplierName,
                            MovieName = item.MovieName,
                            OrderAmount = item.Stock
                        };

            lblSupName.Text = sup.SupplierName;
            lblSupTotalMovie.Text = liste.Sum(x => x.OrderAmount).ToString();
            dataGridView1.DataSource = liste.ToList();
        }

       
    }
}
