using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;
using AppEncoder = Microsoft.Security.Application.Encoder;

namespace JAMM.Model
{
    internal static class XmlHelpers
    {
        public static T FromXml<T>(this string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static TValue GetElementValue<TValue>(this XmlDocument doc, string xpath)
        {
            XmlNode node = doc.SelectSingleNode(xpath);

            if (node != null)
            {
                return (TValue)System.Convert.ChangeType(node.InnerText, typeof(TValue));
            }

            return default(TValue);
        }

        public static TValue GetElementValue<TValue>(this XmlDocument doc, string xpath, TValue defaultValue)
        {
            XmlNode node = doc.SelectSingleNode(xpath);

            if (node != null)
            {
                return (TValue)System.Convert.ChangeType(node.InnerText, typeof(TValue));
            }

            return defaultValue;
        }

        public static string ToXml(this object @object)
        {
            XmlSerializer serializer = new XmlSerializer(@object.GetType());

            using (StringWriter writer = new StringWriter())
            {
                XmlWriter xml = XmlWriter.Create(writer, new XmlWriterSettings { OmitXmlDeclaration = true, Encoding = Encoding.UTF8 });

                serializer.Serialize(xml, @object);

                return writer.ToString();
            }
        }

        public static string ToXml(this DataTable table)
        {
            StringBuilder xml = new StringBuilder();

            using (StringWriter tw = new StringWriter(xml))
            {
                XmlWriter writer = XmlWriter.Create(tw, new XmlWriterSettings() { OmitXmlDeclaration = true, Encoding = Encoding.UTF8 });

                table.WriteXml(writer);
            }

            return xml.ToString();
        }

        public static string XmlEncode(this string str)
        {
            StringBuilder sb = new StringBuilder(AppEncoder.XmlEncode(str));

            return sb.ToString();
        }

        public static string TransformXml(this XDocument xml, XDocument xslt)
        {
            using (StringReader srt = new StringReader(xslt.ToString()))
            using (StringReader sri = new StringReader(xml.ToString()))
            {
                using (XmlReader xrt = XmlReader.Create(srt))
                using (XmlReader xri = XmlReader.Create(sri))
                {
                    XslCompiledTransform xslt2 = new XslCompiledTransform();
                    xslt2.Load(xrt);

                    using (StringWriter sw = new StringWriter())
                    using (XmlWriter xwo = XmlWriter.Create(sw, xslt2.OutputSettings))
                    {
                        xslt2.Transform(xri, xwo);
                        return sw.ToString();
                    }
                }
            }
        }
    }
}
