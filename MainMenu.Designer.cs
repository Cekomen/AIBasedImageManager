namespace AIBasedImageManager
{
    partial class MainMenu
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
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.BrowseImagesButton = new System.Windows.Forms.Button();
            this.GetSuggestionsButton = new System.Windows.Forms.Button();
            this.OnlineSearchButton = new System.Windows.Forms.Button();
            this.ImportSaveButton = new System.Windows.Forms.Button();
            this.ExportSaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MainMenuLabel.Location = new System.Drawing.Point(139, 27);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(110, 39);
            this.MainMenuLabel.TabIndex = 0;
            this.MainMenuLabel.Text = "Main Menu";
            // 
            // BrowseImagesButton
            // 
            this.BrowseImagesButton.Location = new System.Drawing.Point(98, 118);
            this.BrowseImagesButton.Name = "BrowseImagesButton";
            this.BrowseImagesButton.Size = new System.Drawing.Size(183, 37);
            this.BrowseImagesButton.TabIndex = 1;
            this.BrowseImagesButton.Text = "Browse Images";
            this.BrowseImagesButton.UseVisualStyleBackColor = true;
            this.BrowseImagesButton.Click += new System.EventHandler(this.BrowseImagesButton_Click);
            // 
            // GetSuggestionsButton
            // 
            this.GetSuggestionsButton.Location = new System.Drawing.Point(98, 193);
            this.GetSuggestionsButton.Name = "GetSuggestionsButton";
            this.GetSuggestionsButton.Size = new System.Drawing.Size(183, 37);
            this.GetSuggestionsButton.TabIndex = 2;
            this.GetSuggestionsButton.Text = "Get Suggestions";
            this.GetSuggestionsButton.UseVisualStyleBackColor = true;
            this.GetSuggestionsButton.Click += new System.EventHandler(this.GetSuggestionsButton_Click);
            // 
            // OnlineSearchButton
            // 
            this.OnlineSearchButton.Location = new System.Drawing.Point(98, 266);
            this.OnlineSearchButton.Name = "OnlineSearchButton";
            this.OnlineSearchButton.Size = new System.Drawing.Size(183, 37);
            this.OnlineSearchButton.TabIndex = 3;
            this.OnlineSearchButton.Text = "Online Search";
            this.OnlineSearchButton.UseVisualStyleBackColor = true;
            this.OnlineSearchButton.Click += new System.EventHandler(this.OnlineSearchButton_Click);
            // 
            // ImportSaveButton
            // 
            this.ImportSaveButton.Location = new System.Drawing.Point(98, 338);
            this.ImportSaveButton.Name = "ImportSaveButton";
            this.ImportSaveButton.Size = new System.Drawing.Size(183, 37);
            this.ImportSaveButton.TabIndex = 4;
            this.ImportSaveButton.Text = "Import Save";
            this.ImportSaveButton.UseVisualStyleBackColor = true;
            this.ImportSaveButton.Click += new System.EventHandler(this.ImportSaveButton_Click);
            // 
            // ExportSaveButton
            // 
            this.ExportSaveButton.Location = new System.Drawing.Point(98, 410);
            this.ExportSaveButton.Name = "ExportSaveButton";
            this.ExportSaveButton.Size = new System.Drawing.Size(183, 37);
            this.ExportSaveButton.TabIndex = 5;
            this.ExportSaveButton.Text = "Export Save";
            this.ExportSaveButton.UseVisualStyleBackColor = true;
            this.ExportSaveButton.Click += new System.EventHandler(this.ExportSaveButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 486);
            this.Controls.Add(this.ExportSaveButton);
            this.Controls.Add(this.ImportSaveButton);
            this.Controls.Add(this.OnlineSearchButton);
            this.Controls.Add(this.GetSuggestionsButton);
            this.Controls.Add(this.BrowseImagesButton);
            this.Controls.Add(this.MainMenuLabel);
            this.Name = "MainMenu";
            this.Text = "Artificial Intelligence Based Image Manager";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MainMenuLabel;
        private System.Windows.Forms.Button BrowseImagesButton;
        private System.Windows.Forms.Button GetSuggestionsButton;
        private System.Windows.Forms.Button OnlineSearchButton;
        private System.Windows.Forms.Button ImportSaveButton;
        private System.Windows.Forms.Button ExportSaveButton;
    }
}

