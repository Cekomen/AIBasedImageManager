using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Image_Property
{
    class ImageResolution : AbstractImageProperty
    {
        static readonly double maxValue = 100000000; //100 million 
        static readonly double minValue = 10;

        public ImageResolution() : base(maxValue, minValue)
        {
        }

        public override double getValue(Image image)
        {
            return normalizeValue(image.Width * image.Height);
        }
    }
}
