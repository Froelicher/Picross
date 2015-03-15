/*
 * Author : JP. Froelicher
 * Date : 15.03.2015
 * Description : View of Picross grid
 */ 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace PicrossManager
{
    public partial class GameView : Form
    {
        private Grid _gridModel;
        internal Grid GridModel
        {
            get { return _gridModel; }
            set { _gridModel = value; }
        }

        public GameView()
        {
            InitializeComponent();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("testxml.xml");
            this.GridModel = new Grid(xmlDoc.InnerXml);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Paint the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {     
            string[] arrayLines = this.GridModel.DrawGrid();
            string[] arrayLinesString = this.GridModel.GenerateStringLines();
            string[] arrayRowsString = this.GridModel.GenerateStringRows();

            Graphics g = e.Graphics;
            int numOfCells = arrayLinesString.Length+1;
            int cellSize = 20;
            Pen p = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);
            System.Drawing.Font font = new Font("Arial", 10f);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);

            for (int y = 0; y < numOfCells; ++y)
            {
                if (y < numOfCells-1)
                {
                    g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
                    g.DrawString(arrayRowsString[y], font, b, new Point(numOfCells * cellSize, y * cellSize));

                    for (int x = 0; x < numOfCells; ++x)
                    {
                        if (x < numOfCells-1)
                        {
                            g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
                            if (arrayLines[y][x] == '1')
                                g.FillRectangle(b, y * cellSize, x * cellSize, cellSize, cellSize);
                        }
                    }
                    g.DrawString(arrayLinesString[y], font, b, new Point(y * cellSize, numOfCells * cellSize), drawFormat);
                }

            }
        }
    }
}
