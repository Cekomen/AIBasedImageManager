using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System.Web.WebSockets;

namespace AIBasedImageManager
{
    class WebSearch
    {
        //Takes a query and startIndex, and returns a list of 10 images that the API returns, starting from startIndex
        public List<Bitmap> getImages(string query, int start)
        {
            
            var client = new RestClient("https://www.googleapis.com/customsearch/v1?key=<KEY_HERE>&cx=<CX ID HERE>&q="+query+"&searchType=image&start="+start);
            var request = new RestRequest(Method.GET)
            {
                UseDefaultCredentials = true
            };

            IRestResponse response = client.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            var responseObject = deserial.Deserialize<JsonResponse>(response);

            if (responseObject.items == null)
            {
                //If there's no response, just return an empty list
                return new List<Bitmap>();
            }

            //Iinitialize a web client, fetch images EXCEPT GIFS (JIFS), put them to a list, and return them
            List<Bitmap> images = new List<Bitmap>();
            using (WebClient wc = new WebClient())
            {
                Stream s = null;
                foreach (var image in responseObject.items)
                {

                    if (image.mime!="image/gif")
                    {

                        try
                        {
                            s = wc.OpenRead(image.link);
                            images.Add(new Bitmap(s)); 
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Failed image link= "+image.link);
                        }
                        
                    }
                }
                s.Dispose();
            }

            return images;
        }
    }
}
