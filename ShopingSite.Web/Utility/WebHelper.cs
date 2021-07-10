using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ShopingSite.Web.Utility
{
    public class WebHelper
    {
        public static String ToXMLGeneric<T>(T data)
        {

            string xml = null;
            using (StringWriter sw = new StringWriter())
            {
                XmlRootAttribute root = new XmlRootAttribute("Root");


                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T), root);

                    var xmlns = new XmlSerializerNamespaces();
                    xmlns.Add(string.Empty, string.Empty);

                    var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings()
                    {
                        Encoding = Encoding.Unicode,
                        OmitXmlDeclaration = true,
                        // ConformanceLevel = ConformanceLevel.Fragment,
                        Indent = true,
                        NewLineOnAttributes = false
                    });


                    //xs.Serialize(sw, data,xmlns);

                    xs.Serialize(xmlWriter, data, xmlns);

                    xml = sw.ToString();

                }
                catch (Exception e)
                {
                    return xml;
                    //throw e;
                }
            }
            return xml;
        }

    }
}