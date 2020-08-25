using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AIBasedImageManager
{
    public partial class OnlineSearchImageForm : ImageForm
    {

        //USEEEEEEE ASYNNNNCCCCCC
        public string query { get; set; }
        private int start = 1;
        public OnlineSearchImageForm(): base(new List<Bitmap>())
        {
            InitializeComponent();
            GenerateImages(imageFLP);
        }
        protected override void pictureBox_Click(object sender, EventArgs e)
        {
            var checkBox = ((CheckBox)((PictureBox)sender).Controls[0]);
            checkBox.Checked = !checkBox.Checked;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.query = searchTextBox.Text;
            query = HttpUtility.UrlEncode(query);
            WebSearch ws = new WebSearch();
            base.imageList = ws.getImages(query, start);
            imageFLP.Controls.Clear();
            GenerateImages(imageFLP);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            DeleteImages(imageFLP);
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            //I know you can get the nextPage start index from the json response, but I can't be arsed to do it right now
            if (start < 90)
                start += 10;
            imageFLP.Controls.Clear();
            searchButton_Click(this, EventArgs.Empty);
        }
    }
}
