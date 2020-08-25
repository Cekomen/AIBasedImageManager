using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Neural_Network
{
    class NNetwork
    {
        private List<List<Neuron>> layers = new List<List<Neuron>>();
        private double error;
        private double recentAverageError;
        private static double recentAverageSmoothingFactor = 100.0;

        //This one assigns random weight values
        public NNetwork(List<UInt32> topology)
        {
            int numLayers = topology.Count;
            for (int layerNum = 0; layerNum < numLayers; layerNum++)
            {
                layers.Add(new List<Neuron>());
                uint numOutputs = layerNum == topology.Count - 1 ? 0 : topology[layerNum + 1];

                for (int neuronNum = 0; neuronNum <= topology[layerNum]; neuronNum++)
                {
                    layers[layers.Count - 1].Add(new Neuron(numOutputs, neuronNum));
                    Console.WriteLine("Made a neuron!");
                }
                layers[layers.Count - 1][layers[layers.Count - 1].Count - 1].setOutputVal(1.0);
            }
        }

        //This one takes the weights as an argument
        public NNetwork(List<UInt32> topology, List<double> weights)
        {
            using (var iterator = weights.GetEnumerator())
            {
                iterator.MoveNext(); //Initial MoveNext
                int numLayers = topology.Count;
                for (int layerNum = 0; layerNum < numLayers; layerNum++)
                {
                    layers.Add(new List<Neuron>());
                    uint numOutputs = layerNum == topology.Count - 1 ? 0 : topology[layerNum + 1];

                    //It's <= because we generate an additional bias neuron at each layer
                    for (int neuronNum = 0; neuronNum <= topology[layerNum]; neuronNum++)
                    {
                        //Generate connections, if we run out of weights it repeats the last weight
                        Connection[] connections = new Connection[numOutputs];
                        for (int i = 0; i < numOutputs; i++)
                        {
                            Connection c = new Connection();
                            c.weight = iterator.Current;
                            iterator.MoveNext();
                            c.deltaWeight = iterator.Current;
                            iterator.MoveNext();
                            connections[i] = c;
                        }

                        layers[layers.Count - 1].Add(new Neuron(neuronNum, connections));
                        Console.WriteLine("Made a neuron!");
                    }
                    layers[layers.Count - 1][layers[layers.Count - 1].Count - 1].setOutputVal(1.0); //Set output value of the last neuron (bias neuron) of the last layer (the one we just added) to 1
                }
            }

        }


        public void feedForward(List<double> inputVals) {
            for (int i = 0; i < inputVals.Count; i++)
            {
                layers[0][i].setOutputVal(inputVals[i]);
            }

            for (int layerNum = 1; layerNum < layers.Count; layerNum++)
            {
                List<Neuron> prevLayer = layers[layerNum - 1];
                for (int i = 0; i < layers[layerNum].Count - 1; i++)
                {
                    layers[layerNum][i].feedForward(prevLayer);
                }
            }
        }

        public void backProp(List<double> targetVals)
        {

            List<Neuron> outputLayer = layers[layers.Count - 1];
            error = 0.0;
            for (int i = 0; i < outputLayer.Count - 1; i++)
            {
                double delta = targetVals[i] - outputLayer[i].getOutputVal();
                error += delta * delta;
            }

            error /= outputLayer.Count - 1;
            error = Math.Sqrt(error);
            recentAverageError = (recentAverageError * recentAverageSmoothingFactor + error) / (recentAverageSmoothingFactor + 1.0);

            for (int i = 0; i < outputLayer.Count - 1; i++)
            {
                outputLayer[i].calcOutputGradients(targetVals[i]);
            }

            for (int layerNum = layers.Count - 2; layerNum > 0; layerNum--)
            {
                List<Neuron> hiddenLayer = layers[layerNum];
                List<Neuron> nextLayer = layers[layerNum + 1];

                for (int i = 0; i < hiddenLayer.Count; i++)
                {
                    hiddenLayer[i].calcHiddenGradients(nextLayer);
                }
            }

            for (int layerNum = layers.Count - 1; layerNum > 0; layerNum--)
            {
                List<Neuron> layer = layers[layerNum];
                List<Neuron> prevLayer = layers[layerNum - 1];

                for (int n = 0; n < layer.Count - 1; ++n)
                {
                    layer[n].updateInputWeights(prevLayer);
                }
            }

        }
        public void getResults(ref List<double> resultVals) {
            resultVals.Clear();
            for (int i = 0; i < layers[layers.Count - 1].Count - 1; i++)
            {
                resultVals.Add(layers[layers.Count - 1][i].getOutputVal());
            }
        }
        public double getRecentAverageError() { return recentAverageError; }


        //Get weights from network
        public List<string> GetWeights()
        {
            List<string> weights = new List<string>();
            foreach (var layer in layers)
            {
                foreach (var neuron in layer)
                {
                    var connections = neuron.getConnections();
                    for (int i = 0; i < connections.Length; i++)
                    {
                        weights.Add(connections[i].weight.ToString());
                        weights.Add(connections[i].deltaWeight.ToString());
                    }
                }
            }
            return weights;
        }


    }
}
