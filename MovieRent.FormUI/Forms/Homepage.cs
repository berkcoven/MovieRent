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

        public void FormKapa()
        {


            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i] != this)
                    Application.OpenForms[i].Close();
            }
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
    }
}
