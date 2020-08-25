using AIBasedImageManager.Neural_Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBasedImageManager
{
    public struct ImageStruct{
        public Image image;
        public bool checkboxChecked;
    }

    public class ImageForm : Form
    {
        public List<Bitmap> imageList { get; set; }
        private NeuralNetworkMain NetMain;
        
        public ImageForm(List<Bitmap> imageList)
        {
            this.imageList = imageList;
            NetMain = new NeuralNetworkMain();
        }

        public ImageForm()
        {
        }

        //Creates the images inside a given container, alongside with a checkbox
        public void GenerateImages(Control container)
        {
            int x = 100;
            int y = 100;
            if (imageList.Count == 0)
                return;
            foreach (Bitmap image in imageList)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(240, 240),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(x, y),
                    Image = image
                };
                CheckBox cb = new CheckBox
                {
                    Anchor = AnchorStyles.Top,
                    AutoSize = true
                };
                pb.Controls.Add(cb);
                pb.Click += new System.EventHandler(pictureBox_Click);
                container.Controls.Add(pb);
                x = x>1000?100:x+340;
                y = x==100?y+340:y;

            }
        }

        //This shouldn't be called
        protected virtual void pictureBox_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DeleteImages(Control container, List<FileInfo> files = null /*if files is null it doesn't delete, just gets checked images*/) 
        {

            //Loop through images. The loop is reverse so it doesn't get messed up during deletion
            for (int i = container.Controls.Count - 1; i >= 0; i--)
            {
                //Get the image in an imageStruct and send it to NN to train
                bool checkboxValue = ((CheckBox)container.Controls[i].Controls[0]).Checked;
                var deletedImage = (Bitmap)((PictureBox)container.Controls[i]).Image;
                ImageStruct imgStruct = new ImageStruct() { image = deletedImage, checkboxChecked = checkboxValue };
                NetMain.Train(imgStruct);
                
                //If the image is marked for deletion, remove it from the list, then delete it if it's in a file
                if (checkboxValue)
                {    
                    container.Controls.RemoveAt(i); //Can remove this and refresh list at the end instead
                    deletedImage.Dispose(); //For whatever reason image deletion fails. My guess is it wasn't disposed of

                    if (files!=null)
                    {
                        try
                        {
                            files[i].Delete();
                            Console.WriteLine(files[i].Name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("File deletion failed: "+ e.Message);
                        }
                    }

                }
            }
            NetMain.UpdateWeights();

        }

    }
}
