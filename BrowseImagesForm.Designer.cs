namespace AIBasedImageManager
{
    partial class BrowseImagesForm
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ImageFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.largeImagePanel = new System.Windows.Forms.Panel();
            this.largePictureBox = new System.Windows.Forms.PictureBox();
            this.ButtonPanel.SuspendLayout();
            this.largeImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.largePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(104, 9);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(208, 54);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "Delete selected";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonPanel.Controls.Add(this.DeleteButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 445);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1098, 73);
            this.ButtonPanel.TabIndex = 1;
            // 
            // ImageFlowLayoutPanel
            // 
            this.ImageFlowLayoutPanel.AutoScroll = true;
            this.ImageFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ImageFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ImageFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ImageFlowLayoutPanel.Name = "ImageFlowLayoutPanel";
            this.ImageFlowLayoutPanel.Size = new System.Drawing.Size(768, 445);
            this.ImageFlowLayoutPanel.TabIndex = 2;
            // 
            // largeImagePanel
            // 
            this.largeImagePanel.Controls.Add(this.largePictureBox);
            this.largeImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.largeImagePanel.Location = new System.Drawing.Point(768, 0);
            this.largeImagePanel.Name = "largeImagePanel";
            this.largeImagePanel.Size = new System.Drawing.Size(330, 445);
            this.largeImagePanel.TabIndex = 3;
            // 
            // largePictureBox
            // 
            this.largePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.largePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.largePictureBox.Location = new System.Drawing.Point(0, 0);
            this.largePictureBox.Name = "largePictureBox";
            this.largePictureBox.Size = new System.Drawing.Size(330, 445);
            this.largePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.largePictureBox.TabIndex = 0;
            this.largePictureBox.TabStop = false;
            this.largePictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // BrowseImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1098, 518);
            this.Controls.Add(this.largeImagePanel);
            this.Controls.Add(this.ImageFlowLayoutPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BrowseImagesForm";
            this.Text = "Browse Images";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrowseImagesForm_FormClosed);
            this.ButtonPanel.ResumeLayout(false);
            this.largeImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.largePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.FlowLayoutPanel ImageFlowLayoutPanel;
        private System.Windows.Forms.Panel largeImagePanel;
        private System.Windows.Forms.PictureBox largePictureBox;
    }
}