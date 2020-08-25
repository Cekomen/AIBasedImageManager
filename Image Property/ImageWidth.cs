using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Image_Property
{
    class ImageWidth : AbstractImageProperty
    {
        static readonly double maxValue = 10000;
        static readonly double minValue = 1;

        public ImageWidth() : base(maxValue, minValue)
        {
        }

        public override double getValue(Image image)
        {
            return normalizeValue(image.Width);
        }
    }
}
