using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager.Image_Property
{
    class ImagePixelDepth : AbstractImageProperty
    {
        static readonly double maxValue = 48;
        static readonly double minValue = 1;

        public ImagePixelDepth(): base(maxValue,minValue)
        {
        }
        public override double getValue(Image image)
        {
            return normalizeValue(Image.GetPixelFormatSize(image.PixelFormat));
        }
    }
}
