using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.ModelBinding;

namespace AIBasedImageManager.Neural_Network
{
    struct Connection {
        public double weight { get; set; }
        public double deltaWeight { get; set; }
    }
    class Neuron
    {
        public Connection[] getConnections() { return outputWeights; }
        private static Random rand = new Random();


        public void setOutputVal(double val) { outputVal = val; }
        public double getOutputVal() { return outputVal; }
        public void feedForward(List<Neuron> prevLayer) {
            double sum = 0.0;
            for (int i = 0; i < prevLayer.Count; i++)
            {
                sum += prevLayer[i].getOutputVal() * 
                    prevLayer[i].outputWeights[myIndex].weight;
            }
            outputVal = transferFunction(sum);
        }

        public void calcOutputGradients(double targetVal) {
            double delta = targetVal - outputVal;
            gradient = delta * transferFunctionDerivative(outputVal);
        }

        public void calcHiddenGradients(List<Neuron> nextLayer) {
            double dow = sumDOW(nextLayer);
            gradient = dow * transferFunctionDerivative(outputVal);
        }
        public void updateInputWeights(List<Neuron> prevLayer) {

            for (int i = 0; i < prevLayer.Count; i++)
            {
                Neuron n = prevLayer[i];
                double oldDeltaWeight = n.outputWeights[myIndex].deltaWeight;

                double newDeltaWeight = eta * n.getOutputVal() * gradient + alpha * oldDeltaWeight;
                n.outputWeights[myIndex].deltaWeight = newDeltaWeight;
                n.outputWeights[myIndex].weight += newDeltaWeight;
            }

        }

        private static double eta = 0.15;
        private static double alpha = 0.5;
        private static double transferFunction(double x) { return Math.Tanh(x); }
        private static double transferFunctionDerivative(double x) { return 1.0 - x * x;}
        private static double randomWeight() { 
            return rand.NextDouble();
        }
        private double sumDOW(List<Neuron> nextLayer) {
            double sum = 0.0;
            for (int i = 0; i < nextLayer.Count-1; i++)
            {
                sum += outputWeights[i].weight * nextLayer[i].gradient;
            }
            return sum;
        }
        private double outputVal;
        private Connection[] outputWeights;
        private int myIndex;
        private double gradient;

        //This one takes the number of output connections and assigns random values
        public Neuron(uint numOutputs, int myIndex)
        {
            outputWeights = new Connection[numOutputs];
            for (int i = 0; i < numOutputs; i++)
            {
                outputWeights[i] = new Connection
                {
                    weight = randomWeight()
                };
            }
            this.myIndex = myIndex;
        }

        //This one straight up takes the connection array
        public Neuron(int myIndex, Connection[] connections)
        {
            outputWeights = connections;
            this.myIndex = myIndex;
        }

    }
}