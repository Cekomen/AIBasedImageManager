using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBasedImageManager
{
    class WebImage
    {
        public string link { get; set; }
        public string mime { get; set; }
    }
    class JsonResponse 
    {
        public List<WebImage> items { get; set; }

    }
}
