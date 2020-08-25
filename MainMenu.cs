using AIBasedImageManager.Neural_Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBasedImageManager
{
    public partial class MainMenu : Form
    {
        readonly List<String> validExtensions = new List<String> { ".jpeg",".jpg",".png" };
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        //Takes a directory and returns all the images inside it. Also outs them as FileInfo
        private List<Bitmap> getImagesFromDirectory(DirectoryInfo dir, out List<FileInfo> imageFiles)
        {
            imageFiles = new List<FileInfo>(); //FileInfo of the images
            List<FileInfo> files = dir.GetFiles().ToList(); //ALL the files in directory, including non-images
            List<Bitmap> imageList = new List<Bitmap>(); //Image list
            foreach (FileInfo file in files)
            {
                if (validExtensions.Contains(file.Extension.ToLower())) //Weed out the non-image files
                {
                    imageList.Add(new Bitmap(file.FullName));
                    imageFiles.Add(file); //it works, but at what cost
                }
            }

            return imageList;

        }

        private void BrowseImagesButton_Click(object sender, EventArgs e)
        {
            //Ask for a directory
            string folderPath;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
                else { return; }
            }
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            List<FileInfo> imageFiles;
            var imageList = getImagesFromDirectory(dir, out imageFiles);
            BrowseImagesForm imageForm = new BrowseImagesForm(imageList, imageFiles, false);
            imageForm.Show();

        }

        private void GetSuggestionsButton_Click(object sender, EventArgs e)
        {
            //Ask for a directory
            string folderPath;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
                else { return; }
            }
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            List<FileInfo> imageFiles;
            var imageList = getImagesFromDirectory(dir, out imageFiles);
            BrowseImagesForm imageForm = new BrowseImagesForm(imageList, imageFiles, true); //GetSuggestions also uses the BrowseImagesForm, with a different "suggest" argument
            imageForm.Show();

        }

        private void OnlineSearchButton_Click(object sender, EventArgs e)
        {
            OnlineSearchImageForm searchForm = new OnlineSearchImageForm();
            searchForm.Show();
        }

        //Take a .txt file to be the Weights.txt file
        private void ImportSaveButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openFileDialog.FileName, NeuralNetworkMain.path, true);
                }
            }
        }

        //Copy Weights.txt file to a directory
        private void ExportSaveButton_Click(object sender, EventArgs e)
        {
            //Ask for a directory - I should probably make this into a function
            string folderPath;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
                else { return; }
            }

            //Generate the new file if it doesn't exist, then copy out weights file to it.
            if (!File.Exists(folderPath + "\\Weights.txt"))
            {
                var stream = File.CreateText(folderPath + "\\Weights.txt");
                stream.Dispose(); //Needed for copy to work
            }
            File.Copy(NeuralNetworkMain.path, folderPath+"\\Weights.txt", true);
        }
    }
}
