namespace MovieRent.FormUI.Forms
{
    partial class HomepageMessage
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalList = new System.Windows.Forms.Label();
            this.lblTotalRented = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(36, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(684, 108);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Movie # In User List :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Movie # Rented :";
            // 
            // lblTotalList
            // 
            this.lblTotalList.AutoSize = true;
            this.lblTotalList.Location = new System.Drawing.Point(175, 157);
            this.lblTotalList.Name = "lblTotalList";
            this.lblTotalList.Size = new System.Drawing.Size(0, 13);
            this.lblTotalList.TabIndex = 3;
            // 
            // lblTotalRented
            // 
            this.lblTotalRented.AutoSize = true;
            this.lblTotalRented.Location = new System.Drawing.Point(175, 182);
            this.lblTotalRented.Name = "lblTotalRented";
            this.lblTotalRented.Size = new System.Drawing.Size(0, 13);
            this.lblTotalRented.TabIndex = 3;
            // 
            // HomepageMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 214);
            this.Controls.Add(this.lblTotalRented);
            this.Controls.Add(this.lblTotalList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "HomepageMessage";
            this.Text = "HomepageMessage";
            this.Load += new System.EventHandler(this.HomepageMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalList;
        private System.Windows.Forms.Label lblTotalRented;
    }
}