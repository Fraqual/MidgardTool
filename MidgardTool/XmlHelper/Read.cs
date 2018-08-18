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

        public static string ReadFirstContentOfTag(string xmlPath, string tagName)
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

        public static List<string> GetContentOfTagInTagWithValue(string xmlPath, string PrimaryTag, string PrimaryValue, string SubTag)
        {
            List<string> contents = new List<string>();

            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                reader.MoveToContent();
                while (reader.ReadToFollowing(PrimaryTag))
                {                    
                    if (reader.ReadState != ReadState.EndOfFile)
                    {
                        string elementContent = reader.ReadElementContentAsString();
                        if (elementContent == PrimaryValue)
                        {
                            reader.ReadToFollowing(SubTag);
                            if (reader.ReadState != ReadState.EndOfFile)
                            {
                                while (reader.Read() && !(reader.NodeType == XmlNodeType.EndElement && reader.Name == SubTag))
                                {
                                    if (reader.ReadState != ReadState.EndOfFile && reader.NodeType == XmlNodeType.Element)
                                    {
                                        contents.Add(reader.ReadElementContentAsString());
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return contents;
        }

        public static List<string> ReadAllContentsOfTag(string xmlPath, string tagName)
        {
            List<string> contents = new List<string>();

            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    reader.ReadToFollowing(tagName);
                    if (reader.ReadState != ReadState.EndOfFile)
                    {
                        contents.Add(reader.ReadElementContentAsString());
                    }
                }
            }

            return contents;
        }


    }
}
