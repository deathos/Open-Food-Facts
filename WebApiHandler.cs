
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Open_Food_Facts
{
    static class WebApiHandler
    {
        /*
         * Download Images
         * Serialize the API calls into an objects
         * Return ready to use collection
         
         */

        public static List<Products> GetProducts(string xmlurl)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 |
                                                   (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            var products = GetXmlRequest<Opt>(xmlurl).Products;

            foreach (var product in products)
            {
                

                using (MemoryStream ms = new MemoryStream())
                {
                    //b.Save(ms, ImageFormat.Png);

                    // use the memory stream to base64 encode..
                }
            }

            return products;
        }

        public static T GetXmlRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string xmlOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream() ?? throw new InvalidOperationException
                           {
                               HelpLink = null,
                               Source = null
                           }))
                        xmlOutput = sr.ReadToEnd();

                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));

                    var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

                    if (xmlResult != null)
                        return xmlResult;
                    else
                        return default;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception)
            {
                // Log error here.
                return default;
            }
        }

        public static void DownloadFile(string url)
        {
            using (var sr = new StreamReader(WebRequest.Create(url)
                       .GetResponse().GetResponseStream() ?? throw new InvalidOperationException
                   {
                       HelpLink = null,
                       Source = null
                   }))
            using (var sw = new StreamWriter(@"C:/Users/H399039/source/repos/Testing_app/bin/Debug/" + url.Substring(url.LastIndexOf('/'))))
            {

                sw.Write(sr.ReadToEnd());
            }
        }

        public static string GetConvertedPngFile(string imagename)
        {
            var bitmap = Bitmap.FromFile(imagename);
            bitmap.Save(Path.GetFileName(imagename) + ".png", ImageFormat.Png);
            return Path.GetFileName(imagename) + ".png";
        }


    }
    [XmlRoot(ElementName = "products")]
    public class Products
    {

        [XmlAttribute(AttributeName = "code")]
        public double Code { get; set; }

        [XmlAttribute(AttributeName = "image_small_url")]
        public string ImageSmallUrl { get; set; }

        [XmlAttribute(AttributeName = "nova_group")]
        public int NovaGroup { get; set; }

        [XmlAttribute(AttributeName = "nutriscore_grade")]
        public string NutriscoreGrade { get; set; }

        [XmlAttribute(AttributeName = "product_name")]
        public string ProductName { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
    }

    [XmlRoot(ElementName = "opt")]
    public class Opt
    {

        [XmlElement(ElementName = "product")]
        public object Product { get; set; }

        [XmlElement(ElementName = "products")]
        public List<Products> Products { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public int Count { get; set; }

        [XmlAttribute(AttributeName = "page")]
        public int Page { get; set; }

        [XmlAttribute(AttributeName = "page_count")]
        public int PageCount { get; set; }

        [XmlAttribute(AttributeName = "page_size")]
        public int PageSize { get; set; }

        [XmlAttribute(AttributeName = "skip")]
        public int Skip { get; set; }
    }
}
