using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Image_Property
{

    class ImageAspectRatio : AbstractImageProperty
    {
        static readonly double maxValue = 6;
        static readonly double minValue = 0.1;

        public ImageAspectRatio() : base(maxValue, minValue)
        {
        }

        public override double getValue(Image image)
        {
            return normalizeValue((double)image.Width / image.Height);
        }
    }
}
