using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Image_Property
{
    abstract class AbstractImageProperty
    {
        double maxValue, minValue;
        static readonly double maxNormalized = 1;
        static readonly double minNormalized = -1;
        public abstract double getValue(Image image);

        //Normalizes a value to be around -1 to 1 range for tanh transfer function to work well.
        public double normalizeValue(double value)
        {
            return minNormalized + (value - minValue) * (maxNormalized - minNormalized) / (maxValue - minValue);
        }

        protected AbstractImageProperty(double maxValue, double minValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }
    }
}
