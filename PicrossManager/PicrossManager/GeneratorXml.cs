/*
 * Author : JP. Froelicher
 * Date : 15.03.2015
 * Description : Generate xml file
 */ 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;

namespace PicrossManager
{
    class GeneratorXml
    {
        private XmlTextWriter writer;

        public XmlTextWriter Writer
        {
            get { return writer; }
            set { writer = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nameXml">name file</param>
        public GeneratorXml(string nameXml)
        {
            this.Writer = new XmlTextWriter(nameXml, System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// Generate the xml file
        /// </summary>
        /// <param name="img"></param>
        public void Generate(Bitmap img)
        {
            List<string> listSbRows = this.GenerateStringPixelRows(img);
            List<string> listSbLines = this.GenerateStringPixelLines(img);

            DateTime date = DateTime.Now;
            this.Writer.WriteStartDocument(true);
            this.Writer.Formatting = Formatting.Indented;
            this.Writer.Indentation = 2;
            this.Writer.WriteStartElement("PicrossPuzzle");
                this.Writer.WriteStartElement("Informations");
                    this.Writer.WriteStartElement("Name");
                        this.Writer.WriteString("Nom du puzzle");
                    this.Writer.WriteEndElement();

                    this.Writer.WriteStartElement("CreatedDate");
                        this.Writer.WriteAttributeString("date", date.ToString());
                        this.Writer.WriteString(date.ToString());
                    this.Writer.WriteEndElement();

                    this.Writer.WriteStartElement("CreatedBy");
                        this.Writer.WriteAttributeString("version", "1.0.0.0");
                        this.Writer.WriteAttributeString("name", "picross_manager");
                    this.Writer.WriteEndElement();
                    
                    this.Writer.WriteStartElement("NbLines");
                        this.Writer.WriteAttributeString("dim", img.Height.ToString());
                    this.Writer.WriteEndElement();

                    this.Writer.WriteStartElement("NbRows");
                        this.Writer.WriteAttributeString("dim", img.Width.ToString());
                    this.Writer.WriteEndElement();
                    
                this.Writer.WriteEndElement(); //Informations

                this.Writer.WriteStartElement("Puzzle");


                this.Writer.WriteStartElement("Lines");
                for (int i = 0; i < img.Height; i++)
                {
                    this.Writer.WriteStartElement("Line");
                    this.Writer.WriteAttributeString("index", i.ToString());
                    this.Writer.WriteStartElement("flush");
                    this.Writer.WriteString(listSbRows[i].ToString());
                    this.Writer.WriteEndElement(); //FLUSH 
                    this.Writer.WriteStartElement("indices_string");
                    this.Writer.WriteString(this.GenerateIndiceString(listSbRows[i].ToString()));
                    this.Writer.WriteEndElement();//indices_string
                    this.Writer.WriteStartElement("indices_string_separator");
                    this.Writer.WriteString(this.GenerateIndiceStringSep(listSbRows[i].ToString()));
                    this.Writer.WriteEndElement();//indices_string
                    this.GenerateIndicePos(this.GenerateIndiceString(listSbRows[i].ToString()));
                    this.Writer.WriteEndElement();  //Line
                }
                this.Writer.WriteEndElement(); //Lines


                this.Writer.WriteStartElement("Rows");
                for (int j = 0; j < img.Width; j++)
                {
                    this.Writer.WriteStartElement("Row");
                    this.Writer.WriteAttributeString("index", j.ToString());
                    this.Writer.WriteStartElement("flush");
                    this.Writer.WriteString(listSbLines[j].ToString());
                    this.Writer.WriteEndElement(); //FLUSH 
                    this.Writer.WriteStartElement("indices_string");
                    this.Writer.WriteString(this.GenerateIndiceString(listSbLines[j].ToString()));
                    this.Writer.WriteEndElement();//indices_string
                    this.Writer.WriteStartElement("indices_string_separator");
                    this.Writer.WriteString(this.GenerateIndiceStringSep(listSbLines[j].ToString()));
                    this.Writer.WriteEndElement();//indices_string
                    this.GenerateIndicePos(this.GenerateIndiceString(listSbLines[j].ToString()));
                    this.Writer.WriteEndElement();  //Row
                }
                this.Writer.WriteEndElement(); //Rows
                    
            this.Writer.WriteEndElement(); //Puzzle
            this.Writer.WriteEndElement(); //PicrossPuzzle

            this.Writer.Flush();
            this.Writer.Close();
        }

        /// <summary>
        /// Generate string pixel rows
        /// </summary>
        /// <param name="img"></param>
        /// <returns>list of pixel string</returns>
        public List<string> GenerateStringPixelRows(Bitmap img)
        {
            int width = img.Width;
            int height = img.Height;
            StringBuilder sb = new StringBuilder();
            List<string> listSb = new List<string>();

            for (int y = 0; y < width; y++ )
            {
                for(int x = 0; x < height; x++)
                {
                    if(img.GetPixel(y, x).R == 255)
                    {
                        sb.Append("0");
                    }
                    else
                    {
                        sb.Append("1");
                    }
                }
                listSb.Add(sb.ToString());
                sb.Clear();
             }
            return listSb;
        }

        /// <summary>
        /// Generate string pixel rows
        /// </summary>
        /// <param name="img"></param>
        /// <returns>list of pixel rows</returns>
        public List<string> GenerateStringPixelLines(Bitmap img)
        {
            int width = img.Width;
            int height = img.Height;
            StringBuilder sb = new StringBuilder();
            List<string> listSb = new List<string>();

            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    if (img.GetPixel(x, y).R == 255)
                    {
                        sb.Append("0");
                    }
                    else
                    {
                        sb.Append("1");
                    }
                }
                listSb.Add(sb.ToString());
                sb.Clear();
            }
            return listSb;
        }

        /// <summary>
        /// Generate indice string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>indice</returns>
        public string GenerateIndiceString(string str)
        {
            bool suite = false;
            int nb1 = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if(suite)
                {
                    if(str[i] == '1')
                    {
                        nb1++;
                        if(i == str.Length-1)
                        {
                            sb.Append(nb1.ToString() + " ");
                        }
                    }
                    else
                    {
                        sb.Append(nb1.ToString() + " ");
                        nb1 = 0;
                        suite = false;
                    }
                }
                else
                {
                    if(str[i] == '1')
                    {
                        suite = true;
                        nb1++;

                        if (i == str.Length - 1)
                        {
                            sb.Append(nb1.ToString() + " ");
                        }
                    }
                }
            }
            
            if(sb.ToString() != "")
            {
                sb.Remove(sb.Length - 1, 1);
            }
          
            return sb.ToString();
        }

        /// <summary>
        /// Generate indice string separator
        /// </summary>
        /// <param name="str"></param>
        /// <returns>indice separator</returns>
        public string GenerateIndiceStringSep(string str)
        {
            bool suite = false;
            int nb1 = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (suite)
                {
                    if (str[i] == '1')
                    {
                        nb1++;
                        if (i == str.Length - 1)
                        {
                            sb.Append(nb1.ToString() + ", ");
                        }
                    }
                    else
                    {
                        sb.Append(nb1.ToString() + ", ");
                        nb1 = 0;
                        suite = false;
                    }
                }
                else
                {
                    if (str[i] == '1')
                    {
                        suite = true;
                        nb1++;

                        if (i == str.Length - 1)
                        {
                            sb.Append(nb1.ToString() + ", ");
                        }
                    }
                }
            }

            if (sb.ToString() != "")
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generate indice position
        /// </summary>
        /// <param name="str"></param>
        public void GenerateIndicePos(string str)
        {
            int compteur = 0;
            for (int i = 0; i < str.Length; i++ )
            {
                if(str[i] != ' ')
                {
                    this.Writer.WriteStartElement("indice");
                    this.Writer.WriteAttributeString("position", compteur.ToString());
                    this.Writer.WriteString(str[i].ToString());
                    this.Writer.WriteEndElement();
                    compteur++;
                }
            }
        }
    }
}
