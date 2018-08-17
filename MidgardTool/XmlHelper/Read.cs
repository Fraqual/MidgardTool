using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlHelper
{
    public static class Read
    {

        public static string ReadContentOfTag(string xmlPath, string tagName)
        {
            string content = "";
            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element)
                    {
                        if(reader.Name == tagName)
                        {
                            content = reader.ReadElementContentAsString();
                            break;
                        }
                    }
                }
            }

            return content;
        }
    }
}
