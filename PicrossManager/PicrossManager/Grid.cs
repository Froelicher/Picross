using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PicrossManager
{
    class Grid
    {
        private int _height;
        private int _width;
        private string _xmlFile;

        public string XmlFile
        {
            get { return _xmlFile; }
            set { _xmlFile = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xmlFile">content of xmlFile</param>
        public Grid(string xmlFile)
        {
            this.XmlFile = xmlFile;
            using (XmlReader reader = XmlReader.Create(new StringReader(this.XmlFile)))
            {
                reader.ReadToFollowing("Informations");
                reader.ReadToFollowing("NbLines");
                reader.MoveToFirstAttribute();
                string cValue = reader.Value;
                this.Height = Convert.ToInt32(cValue);

                reader.ReadToFollowing("NbRows");
                reader.MoveToFirstAttribute();
                cValue = reader.Value;
                this.Width = Convert.ToInt32(cValue);
            }
        }

        /// <summary>
        /// Draw grid
        /// </summary>
        /// <returns>array of lines to draw</returns>
        public string[] DrawGrid()
        {
            string[] arrayLines = new string[this.Height];

            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(new StringReader(this.XmlFile)))
            {
                for (int i = 0; i < this.Height; i++)
                {
                    reader.ReadToFollowing("flush");
                    string genre = reader.ReadElementContentAsString();
                    arrayLines[i] = genre;
                } 
            }
            return arrayLines;
            
        }

        /// <summary>
        /// Generate string lines
        /// </summary>
        /// <returns>array of string lines</returns>
        public string[] GenerateStringLines()
        {
            string[] arrayLinesString = new string[this.Height];

            using (XmlReader reader = XmlReader.Create(new StringReader(this.XmlFile)))
            {
                for (int i = 0; i < this.Height; i++)
                {
                    reader.ReadToFollowing("indices_string");
                    string genre = reader.ReadElementContentAsString();
                    arrayLinesString[i] = genre;
                }
            }

            return arrayLinesString;
        }

        /// <summary>
        /// Generate string rows
        /// </summary>
        /// <returns>array of string rows</returns>
        public string[] GenerateStringRows()
        {
            string[] arrayRowsString = new string[this.Height];

            using (XmlReader reader = XmlReader.Create(new StringReader(this.XmlFile)))
            {
                reader.ReadToFollowing("Rows");
                for (int i = 0; i < this.Height; i++)
                {
                    reader.ReadToFollowing("indices_string");
                    string genre = reader.ReadElementContentAsString();
                    arrayRowsString[i] = genre;
                }
            }

            return arrayRowsString;
        }
    }
}
