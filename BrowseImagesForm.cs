using AIBasedImageManager.Neural_Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBasedImageManager
{
    public partial class BrowseImagesForm : ImageForm
    {
        List<FileInfo> files;
        public BrowseImagesForm(List<Bitmap> imageList, List<FileInfo> files, bool suggest = false) : base(imageList)
        {
            //Store the fileinfos
            this.files = files;
            InitializeComponent();
            GenerateImages(ImageFlowLayoutPanel);
            if (suggest)
            {
                SuggestImages(ImageFlowLayoutPanel);
            }
        }

        public void SuggestImages(Control container)
        {
            NeuralNetworkMain NetMain = new NeuralNetworkMain();
            for (int i = imageList.Count-1; i >= 0; i--)
            {
                if (NetMain.getResult((Bitmap)((PictureBox)container.Controls[i]).Image))
                {
                    var checkBox = ((CheckBox)container.Controls[i].Controls[0]);
                    checkBox.Checked = !checkBox.Checked;
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteImages(ImageFlowLayoutPanel, files);
        }

        protected override void pictureBox_Click(object sender, EventArgs e)
        {
            largePictureBox.Image = ((PictureBox)sender).Image;
        }

        //We have to dispose of bitmaps when we close the form
        private void BrowseImagesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (object pictureBox in ImageFlowLayoutPanel.Controls)
            {
                //Try casting to bitmap and disposing, if it fails it's no biggie
                try
                {
                    ((PictureBox)pictureBox).Image.Dispose();
                }
                catch(Exception exception)
                {
                    Console.WriteLine("uh oh: "+exception.Message);
                }
            }
        }
    }
}
