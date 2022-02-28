
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

        public static List<Products> GetProducts(string searchTerm)
        {
            List<Products> products = null;
            Opt apiResponse = new Opt();
            try
            {
                apiResponse = GetXmlRequest<Opt>(
                   $"https://world.openfoodfacts.org/cgi/search.pl?action=process&search_terms={searchTerm}&fields=code,product_name,image_small_url,quantity,code,nova_group,nutriscore_grade&xml=1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            foreach (var item in apiResponse.Products)
            {

                try
                {
                    Console.Write(
                                CheckString(item.Code) + "\t" +
                                CheckString(item.ProductName) + "\t" +
                                CheckString(item.NovaGroup) + "\t" +
                                CheckString(item.NutriscoreGrade) + "\t" +
                                CheckString(item.ImageSmallUrl) + "\t" +
                                CheckString(item.Quantity) + "\n");
                    if (item.ImageSmallUrl != "")
                    {
                        var request = WebRequest.Create(item.ImageSmallUrl);
                        var response = request.GetResponse();
                        var responseStream = response.GetResponseStream();
                        var img = Image.FromStream(responseStream);
                        img.Save("/home/user/images/temp" + item.Code + ".png", ImageFormat.Png);
                        item.ImageSmallUrl = item.Code + ".png";
                        var bitmap2 = new Bitmap(img);
                        bitmap2 = bitmap2.Clone(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height),
                            PixelFormat.Format1bppIndexed);
                        bitmap2.Save("/home/user/images/temp" + item.Code + "-1bit.png", ImageFormat.Png);
                        products = apiResponse.Products;
                    }
                    else
                    {
                        item.ImageSmallUrl = "/home/user/images/no-pic.png";
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine("A web Exception caught");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            GC.Collect();
            return products;
        }

        public static object CheckString(object s)
        {
            return s ?? "null";
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
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Log error here.
                return default;
            }
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
