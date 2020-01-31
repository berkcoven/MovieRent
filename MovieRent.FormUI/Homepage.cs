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
            EditorListEdit editorListEdit = new EditorListEdit();
            editorListEdit.MdiParent = this;
            editorListEdit.Show();
           
        }

        private void nextDaysDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextDaysRents nextDaysRents = new NextDaysRents();
            nextDaysRents.MdiParent = this;
            nextDaysRents.Show();
        }

        private void nextDaysDeliveriesAcordingToStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextDayAlgorithm nextDaysalgo = new NextDayAlgorithm();
            nextDaysalgo.MdiParent = this;
            nextDaysalgo.Show();
        }
    }
}
