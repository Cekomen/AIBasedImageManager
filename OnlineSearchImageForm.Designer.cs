namespace AIBasedImageManager
{
    partial class OnlineSearchImageForm
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.imageFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.searchFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bottomPanel.SuspendLayout();
            this.searchFLP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(1053, 20);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(1111, 3);
            this.searchButton.Margin = new System.Windows.Forms.Padding(52, 3, 3, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // imageFLP
            // 
            this.imageFLP.AutoScroll = true;
            this.imageFLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageFLP.Location = new System.Drawing.Point(0, 0);
            this.imageFLP.Name = "imageFLP";
            this.imageFLP.Size = new System.Drawing.Size(1255, 487);
            this.imageFLP.TabIndex = 2;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bottomPanel.Controls.Add(this.nextPageButton);
            this.bottomPanel.Controls.Add(this.confirmButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 540);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1255, 74);
            this.bottomPanel.TabIndex = 1;
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(895, 14);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(107, 43);
            this.nextPageButton.TabIndex = 1;
            this.nextPageButton.Text = "Next Page";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(83, 14);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(105, 43);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // searchFLP
            // 
            this.searchFLP.Controls.Add(this.searchTextBox);
            this.searchFLP.Controls.Add(this.searchButton);
            this.searchFLP.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchFLP.Location = new System.Drawing.Point(0, 0);
            this.searchFLP.Margin = new System.Windows.Forms.Padding(2);
            this.searchFLP.Name = "searchFLP";
            this.searchFLP.Size = new System.Drawing.Size(1255, 53);
            this.searchFLP.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageFLP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1255, 487);
            this.panel1.TabIndex = 3;
            // 
            // OnlineSearchImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1255, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchFLP);
            this.Controls.Add(this.bottomPanel);
            this.Name = "OnlineSearchImageForm";
            this.Text = "Online Search";
            this.bottomPanel.ResumeLayout(false);
            this.searchFLP.ResumeLayout(false);
            this.searchFLP.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.FlowLayoutPanel imageFLP;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.FlowLayoutPanel searchFLP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nextPageButton;
    }
}