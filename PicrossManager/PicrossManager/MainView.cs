using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicrossManager
{
    public partial class MainView : Form
    {
        private GeneratorImage _generatorGray;

        internal GeneratorImage GeneratorGray
        {
            get { return _generatorGray; }
            set { _generatorGray = value; }
        }

        public MainView()
        {
            InitializeComponent();
            this.GeneratorGray = new GeneratorImage();
        }

        private void LoadImg_Click(object sender, EventArgs e)
        {
            if(ofdImage.ShowDialog() == DialogResult.OK)
            {
                this.GeneratorGray.LoadImage(ofdImage.FileName);
                pbxOriginalImg.Image = GeneratorGray.SourceImage;
            }
        }

        private void ConvertImg_Click(object sender, EventArgs e)
        {
            if(pbxOriginalImg.Image != null)
            {
                pbxGrayImage.Image = this.GeneratorGray.MakeGrayScale(this.GeneratorGray.SourceImage);
            }      
        }

        private void ConvertPicross_Click(object sender, EventArgs e)
        {
            if (pbxGrayImage.Image != null)
            {
                pbxPixel.Image = this.GeneratorGray.MakePicross(this.GeneratorGray.GrayImage, (int)nupSeuille.Value, (int)nupWidth.Value, (int)nupHeight.Value);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
