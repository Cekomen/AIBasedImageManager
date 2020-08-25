using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Neural_Network
{
    class NeuralNetworkMain
    {
        //Put the Weights.txt folder inside Documents
        public static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Weights.txt";
        public ImageAnalyzer imgAnalyzer;
        private NNetwork net;
        private readonly double threshold = 0.85; //If the result value is above this, consider the image disliked

        public NeuralNetworkMain()
        {

            imgAnalyzer = new ImageAnalyzer();
            List<uint> topology = new List<uint>{ imgAnalyzer.getPropertyCount(), 4, 1 }; //Number of input neurons should be equal to the amount of properties
            //If a Weights file exists, use those values, otherwise create random weight values
            List<double> weights;
            if (ReadWeights(out weights))
            {
                net = new NNetwork(topology, weights);
            }
            else
            {
                net = new NNetwork(topology);
            }


        }

        //From network to file
        public void UpdateWeights()
        {
            var weights = net.GetWeights();
            File.WriteAllLines(path, weights);
        }

        //Get weights from the file. Returns true and outs the values if the file exists and contains only doubles, returns false and creates the file if it doesn't exist or contains a non-double value or NAN.
        public static bool ReadWeights(out List<double> weights)
        {

            bool isValid = true;
            weights = new List<double>();
            if (File.Exists(NeuralNetworkMain.path))
            {
                var fileWeights = File.ReadAllLines(NeuralNetworkMain.path);
                foreach (string s in fileWeights)
                {
                    double weight;
                    if (Double.TryParse(s, out weight) && !s.Equals("NaN"))
                    {
                        weights.Add(weight);

                    }
                    else
                    {
                        isValid = false;
                        break;

                    }
                }

            }
            else
            {
                File.CreateText(NeuralNetworkMain.path);
                isValid = false;
            }

            return isValid;
        }

        //Train the NN based on the imageStruct
        public void Train(ImageStruct imgStruct)
        {
            List<Double> inputVals = new List<double>((int)imgAnalyzer.getPropertyCount());
            List<Double> targetVals = new List<double>(1);
            List<Double> resultVals = new List<double>(1);

            inputVals.AddRange(imgAnalyzer.getProperties(imgStruct.image));
            targetVals.Add(imgStruct.checkboxChecked ? 1.0 : 0.0);
            net.feedForward(inputVals);
            net.getResults(ref resultVals);
            net.backProp(targetVals);


        }

        //Get image, feed forward it, then add it to container with checkbox already checked based on this
        //Takes an image argument and returns if the user would've disliked it
        public bool getResult(Image img)
        {
            List<Double> inputVals = new List<double>((int)imgAnalyzer.getPropertyCount());
            List<Double> resultVals = new List<double>(1);

            inputVals.AddRange(imgAnalyzer.getProperties(img));
            net.feedForward(inputVals);
            net.getResults(ref resultVals);
            Console.WriteLine(resultVals[0]);
            return resultVals[0] >= threshold ? true : false;

        }

    }
}
