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
            this.nextDayOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextDaysDeliveryRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextDaysDeliveriesAccordingToStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barkodCreaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagCreaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homepageToolStripMenuItem,
            this.editorListEditToolStripMenuItem,
            this.nextDayOrderToolStripMenuItem,
            this.warehouseProcessToolStripMenuItem});
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
            // nextDayOrderToolStripMenuItem
            // 
            this.nextDayOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextDaysDeliveryRequestToolStripMenuItem,
            this.nextDaysDeliveriesAccordingToStockToolStripMenuItem});
            this.nextDayOrderToolStripMenuItem.Name = "nextDayOrderToolStripMenuItem";
            this.nextDayOrderToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.nextDayOrderToolStripMenuItem.Text = "Next Day Order";
            // 
            // nextDaysDeliveryRequestToolStripMenuItem
            // 
            this.nextDaysDeliveryRequestToolStripMenuItem.Name = "nextDaysDeliveryRequestToolStripMenuItem";
            this.nextDaysDeliveryRequestToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.nextDaysDeliveryRequestToolStripMenuItem.Text = "Next Day\'s Delivery Request";
            this.nextDaysDeliveryRequestToolStripMenuItem.Click += new System.EventHandler(this.nextDaysDeliveryRequestToolStripMenuItem_Click);
            // 
            // nextDaysDeliveriesAccordingToStockToolStripMenuItem
            // 
            this.nextDaysDeliveriesAccordingToStockToolStripMenuItem.Name = "nextDaysDeliveriesAccordingToStockToolStripMenuItem";
            this.nextDaysDeliveriesAccordingToStockToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.nextDaysDeliveriesAccordingToStockToolStripMenuItem.Text = "Next Day\'s Deliveries According to Stock";
            this.nextDaysDeliveriesAccordingToStockToolStripMenuItem.Click += new System.EventHandler(this.nextDaysDeliveriesAccordingToStockToolStripMenuItem_Click);
            // 
            // warehouseProcessToolStripMenuItem
            // 
            this.warehouseProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilmToolStripMenuItem,
            this.barkodCreaterToolStripMenuItem,
            this.tagCreaterToolStripMenuItem});
            this.warehouseProcessToolStripMenuItem.Name = "warehouseProcessToolStripMenuItem";
            this.warehouseProcessToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.warehouseProcessToolStripMenuItem.Text = "Warehouse Process";
            // 
            // addFilmToolStripMenuItem
            // 
            this.addFilmToolStripMenuItem.Name = "addFilmToolStripMenuItem";
            this.addFilmToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addFilmToolStripMenuItem.Text = "Add Film";
            this.addFilmToolStripMenuItem.Click += new System.EventHandler(this.addFilmToolStripMenuItem_Click);
            // 
            // barkodCreaterToolStripMenuItem
            // 
            this.barkodCreaterToolStripMenuItem.Name = "barkodCreaterToolStripMenuItem";
            this.barkodCreaterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.barkodCreaterToolStripMenuItem.Text = "Barcode Creater";
            this.barkodCreaterToolStripMenuItem.Click += new System.EventHandler(this.barkodCreaterToolStripMenuItem_Click);
            // 
            // tagCreaterToolStripMenuItem
            // 
            this.tagCreaterToolStripMenuItem.Name = "tagCreaterToolStripMenuItem";
            this.tagCreaterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tagCreaterToolStripMenuItem.Text = "Tag Creater";
            this.tagCreaterToolStripMenuItem.Click += new System.EventHandler(this.tagCreaterToolStripMenuItem_Click);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorListEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextDayOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextDaysDeliveryRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextDaysDeliveriesAccordingToStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barkodCreaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagCreaterToolStripMenuItem;
    }
}