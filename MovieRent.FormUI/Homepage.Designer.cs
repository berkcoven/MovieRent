namespace MovieRent.FormUI
{
    partial class Homepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorListEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextDaysDeliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextDaysDeliveriesAcordingToStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homepageToolStripMenuItem,
            this.editorListEditToolStripMenuItem,
            this.nextDaysDeliveryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.homepageToolStripMenuItem.Text = "Homepage";
            // 
            // editorListEditToolStripMenuItem
            // 
            this.editorListEditToolStripMenuItem.Name = "editorListEditToolStripMenuItem";
            this.editorListEditToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.editorListEditToolStripMenuItem.Text = "Editor List Edit";
            this.editorListEditToolStripMenuItem.Click += new System.EventHandler(this.editorListEditToolStripMenuItem_Click);
            // 
            // nextDaysDeliveryToolStripMenuItem
            // 
            this.nextDaysDeliveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextDaysDeliveriesAcordingToStockToolStripMenuItem});
            this.nextDaysDeliveryToolStripMenuItem.Name = "nextDaysDeliveryToolStripMenuItem";
            this.nextDaysDeliveryToolStripMenuItem.Size = new System.Drawing.Size(165, 20);
            this.nextDaysDeliveryToolStripMenuItem.Text = "Next Day\'s Delivery Request";
            this.nextDaysDeliveryToolStripMenuItem.Click += new System.EventHandler(this.nextDaysDeliveryToolStripMenuItem_Click);
            // 
            // nextDaysDeliveriesAcordingToStockToolStripMenuItem
            // 
            this.nextDaysDeliveriesAcordingToStockToolStripMenuItem.Name = "nextDaysDeliveriesAcordingToStockToolStripMenuItem";
            this.nextDaysDeliveriesAcordingToStockToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.nextDaysDeliveriesAcordingToStockToolStripMenuItem.Text = "Next Day\'s deliveries acording to Stock";
            this.nextDaysDeliveriesAcordingToStockToolStripMenuItem.Click += new System.EventHandler(this.nextDaysDeliveriesAcordingToStockToolStripMenuItem_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 384);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Homepage";
            this.Text = "Homepage";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorListEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextDaysDeliveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextDaysDeliveriesAcordingToStockToolStripMenuItem;
    }
}