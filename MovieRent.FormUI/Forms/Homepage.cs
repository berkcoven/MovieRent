using MovieRent.FormUI.Forms;
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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void editorListEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();


            EditorListEdit editorListEdit = new EditorListEdit();
            editorListEdit.MdiParent = this;
            editorListEdit.Show();

        }

        

      

        private void nextDaysDeliveriesAcordingToStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void nextDaysDeliveryRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            NextDaysRents nextDaysRents = new NextDaysRents();
            nextDaysRents.MdiParent = this;
            nextDaysRents.Show();
        }

        private void nextDaysDeliveriesAccordingToStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            NextDayAlgorithm nextDaysalgo = new NextDayAlgorithm();
            nextDaysalgo.MdiParent = this;
            nextDaysalgo.Show();

        }

        private void addFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            AddFilm addFilm = new AddFilm();
            addFilm.MdiParent = this;
            addFilm.Show();
        }

        private void barkodCreaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            Barcoder barcoder = new Barcoder();
            barcoder.MdiParent = this;
            barcoder.Show();
        }

        private void tagCreaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            Tagger tagger = new Tagger();
            tagger.MdiParent = this;
            tagger.Show();
        }

        private void premiumReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            ReportPage report = new ReportPage();
            report.MdiParent = this;
            report.Show();

        }

        private void categoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormKapa();
            CategoryReport report = new CategoryReport();
            report.MdiParent = this;
            report.Show();
            
        }

        private void dateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            DateReport report = new DateReport();
            report.MdiParent = this;
            report.Show();


            
        }

        private void orderMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            OrderMovie order = new OrderMovie();
            order.MdiParent = this;
            order.Show();

        }

        private void reportBrokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            BrokenMovie bm = new BrokenMovie();
            bm.MdiParent = this;
            bm.Show();

        }

        private void supplierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormKapa();
            SupplierReport sreport = new SupplierReport();
            sreport.MdiParent = this;
            sreport.Show();
            
        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKapa();
            HomepageMessage hpm = new HomepageMessage();
            hpm.MdiParent = this;
            hpm.Show();
            
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            FormKapa();
            HomepageMessage hpm = new HomepageMessage();
            hpm.MdiParent = this;
            hpm.Show();
        }

        public void FormKapa()
        {


            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i] != this)
                    Application.OpenForms[i].Close();
            }
        }
    }
}
