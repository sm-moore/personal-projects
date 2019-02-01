using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Comment_Generator_Model;

namespace GeneratorUtils
{
    public class XMLHandler
    {
        string FileName;
        public XMLHandler()
        {
            FileName = "Comment";
        }

        public void WriteXML(string filePath, CommentGenerator content)
        {
            string fileName = Path.GetFileName(filePath);
            // We want some non-default settings for our XML writer.
            // Specifically, use indentation to make it more readable.
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("  ");

            // Create an XmlWriter inside this block, and automatically Dispose() it at the end.
            try
            {
                using (XmlWriter writer = XmlWriter.Create(filePath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(content.Type); //<First>
                    writer.WriteAttributeString("version", content.Version);

                    content.WriteAllcommentsXml(writer);

                    //writer.WriteEndAttribute(); // Ends the spreadsheet block TODO: will this say </spreadsheet> ?
                    writer.WriteEndDocument();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public CommentGenerator ReadXml(string filePath, CommentGenerator content)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                return content.ReadComponentsXml(reader);
            }
        }

        //public void ReadXml(string filePath)
        //{
        //    string name = "";
        //    string content = "";

        //    // Create an XmlReader inside this block, and automatically Dispose() it at the end.
        //    using (XmlReader reader = XmlReader.Create(filePath))
        //    {
        //        while (reader.Read())
        //        {
        //            if (reader.IsStartElement())
        //            {
        //                switch (reader.Name)
        //                {
        //                    case "spreadsheet":
        //                        break;
        //                    case "cell":
        //                        break;
        //                    case "name":
        //                        if (reader.Read())
        //                            name = reader.Value;
        //                        break;
        //                    case "contents":
        //                        if (reader.Read())
        //                            content = reader.Value;
        //                        SetContentsOfCell(name, content);
        //                        break;

        //                    default:
        //                        throw new SpreadsheetReadWriteException("Invalid file.");

        //                }
        //            }
        //        }
        //    }
        //}
    }
}
