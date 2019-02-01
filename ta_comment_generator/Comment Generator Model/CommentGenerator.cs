using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Comment_Generator_Model
{
    public class CommentGenerator
    {
        private Comments comments;
        private static string VERSION = "1.0";

        /// <summary>
        /// The number of comments in this CommentGenerator.
        /// </summary>
        public int Count
        {
            get { return comments.Count; }
        }


        public CommentGenerator()
        {
            comments = new Comments();
        }

        public bool AddComment(string display, string hidden)
        {
            return comments.Add(display, hidden);
        }

        /// <summary>
        /// Updates a comment's hidden value or display.
        /// </summary>
        /// <param name="oldDisplay">old string being displayed</param>
        /// <param name="newDisplay">new string being displayed</param>
        /// <param name="hidden">new content for the comment.</param>
        /// <returns></returns>
        public bool UpdateComment(string oldDisplay, string newDisplay, string hidden)
        {
            if (comments.Contains(newDisplay))
            {
                //bad news! A comment with this display value already exists!
                throw new ArgumentException("A comment with this display value alread exists!");
            }
            else
            {
                comments.Remove(oldDisplay);
                return comments.Add(newDisplay, hidden);
            }
        }

        /// <summary>
        /// Returns a collection of all display value comments. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> getAllCommentDisplays()
        {
            return comments.getAllCommentDisplays();
        }

        /// <summary>
        /// Returns the hidden comment associated with the display value. 
        /// If it does not exist, an exception is throw?
        /// </summary>
        public string GetComment(string display)
        {
            return comments.Get(display);
        }

        /// <summary>
        /// Writes the state of this CommentGenerator to and Xml File. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public void WriteXml(string filePath)
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
                    writer.WriteStartElement("CommentGenerator"); //<First>
                    writer.WriteAttributeString("version", VERSION);

                    comments.WriteAllcommentsXml(writer);

                    //writer.WriteEndAttribute(); // Ends the spreadsheet block TODO: will this say </spreadsheet> ?
                    writer.WriteEndDocument();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Reads an Xml file and returns a new CommentGenerator containing the 
        /// appropriate state. 
        /// </summary>
        /// <param name="filePath"></param>
        public CommentGenerator ReadXml(string filePath)
        {
            CommentGenerator ret = new CommentGenerator();
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                for(int i = 0; i<1; i++)
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "CommentGenerator":
                                break;
                            default:
                                throw new Exception("Not a valid Xml file!");
                        }
                    }
                    reader.Read();
                }
                ret.comments = comments.ReadCommentsXml(reader);
                return ret;
            }
        }

    }
}
