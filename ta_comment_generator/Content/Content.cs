using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeneratorUtils
{
    public abstract class Content<T>
    {
        /// <summary>
        /// (First> param-name of the first block comment. Ie. <CommentGenerator).
        /// </summary>
        public String Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Version saved in the file. ie. 1.0
        /// </summary>
        public String Version
        {
            get;
            private set;
        }

        public Content(String version, String type)
        {
            this.Version = version;
            this.Type = type;
        }

        /// <summary>
        /// Writes the xml for all components to the given writer. 
        /// </summary>
        /// <param name="writer"></param>
        public abstract void WriteComponentsXml(XmlWriter writer);

        public abstract void ReadComponentsXml(XmlReader reader);

        /// <summary>
        /// Adds this element to the content collection.
        /// </summary>
        /// <param name="element"> Element to be added. </param>
        /// <returns>true if added, false otherwise</returns>
        //public abstract bool Add(T element);
        //public abstract bool Contains(T element);
        //public abstract bool Remove(T element);
    }
}
