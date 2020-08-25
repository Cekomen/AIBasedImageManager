using AIBasedImageManager.Image_Property;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager
{
    class ImageAnalyzer
    {
        //Get list of properties, return list of doubles
        List<AbstractImageProperty> properties = new List<AbstractImageProperty>();

        public ImageAnalyzer()
        {
            //All properties should be added here
            properties.Add(new ImageHeight());
            properties.Add(new ImageWidth());
            properties.Add(new ImageAspectRatio());
            properties.Add(new ImagePixelDepth());
            properties.Add(new ImageResolution());
        }

        public uint getPropertyCount()
        {
            return (uint)properties.Count();
        }

        //Takes an image and returns the normalized property values of it.
        public List<double> getProperties(Image img)
        {
            List<double> values = new List<double>();

            foreach (var property in properties)
            {
                values.Add(property.getValue(img));
            }
            return values;
        }

    }
}
