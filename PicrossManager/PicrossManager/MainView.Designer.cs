namespace PicrossManager
{
    partial class MainView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxOriginalImg = new System.Windows.Forms.PictureBox();
            this.pbxGrayImage = new System.Windows.Forms.PictureBox();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.BtnConvertImg = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.btnConvertPixel = new System.Windows.Forms.Button();
            this.nupWidth = new System.Windows.Forms.NumericUpDown();
            this.nupHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nupSeuille = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pbxPixel = new PicrossManager.MyPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOriginalImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrayImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSeuille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPixel)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxOriginalImg
            // 
            this.pbxOriginalImg.Location = new System.Drawing.Point(12, 12);
            this.pbxOriginalImg.Name = "pbxOriginalImg";
            this.pbxOriginalImg.Size = new System.Drawing.Size(300, 300);
            this.pbxOriginalImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxOriginalImg.TabIndex = 0;
            this.pbxOriginalImg.TabStop = false;
            // 
            // pbxGrayImage
            // 
            this.pbxGrayImage.Location = new System.Drawing.Point(318, 12);
            this.pbxGrayImage.Name = "pbxGrayImage";
            this.pbxGrayImage.Size = new System.Drawing.Size(300, 300);
            this.pbxGrayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGrayImage.TabIndex = 1;
            this.pbxGrayImage.TabStop = false;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(13, 319);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(299, 23);
            this.btnLoadImg.TabIndex = 2;
            this.btnLoadImg.Text = "Load image";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.LoadImg_Click);
            // 
            // BtnConvertImg
            // 
            this.BtnConvertImg.Location = new System.Drawing.Point(13, 349);
            this.BtnConvertImg.Name = "BtnConvertImg";
            this.BtnConvertImg.Size = new System.Drawing.Size(299, 23);
            this.BtnConvertImg.TabIndex = 3;
            this.BtnConvertImg.Text = "Convert image to gray scale";
            this.BtnConvertImg.UseVisualStyleBackColor = true;
            this.BtnConvertImg.Click += new System.EventHandler(this.ConvertImg_Click);
            // 
            // btnConvertPixel
            // 
            this.btnConvertPixel.Location = new System.Drawing.Point(318, 319);
            this.btnConvertPixel.Name = "btnConvertPixel";
            this.btnConvertPixel.Size = new System.Drawing.Size(300, 53);
            this.btnConvertPixel.TabIndex = 5;
            this.btnConvertPixel.Text = "Convert to Picross";
            this.btnConvertPixel.UseVisualStyleBackColor = true;
            this.btnConvertPixel.Click += new System.EventHandler(this.ConvertPicross_Click);
            // 
            // nupWidth
            // 
            this.nupWidth.Location = new System.Drawing.Point(673, 318);
            this.nupWidth.Name = "nupWidth";
            this.nupWidth.Size = new System.Drawing.Size(52, 20);
            this.nupWidth.TabIndex = 7;
            this.nupWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nupHeight
            // 
            this.nupHeight.Location = new System.Drawing.Point(673, 344);
            this.nupHeight.Name = "nupHeight";
            this.nupHeight.Size = new System.Drawing.Size(52, 20);
            this.nupHeight.TabIndex = 8;
            this.nupHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(624, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Width :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Height :";
            // 
            // nupSeuille
            // 
            this.nupSeuille.Location = new System.Drawing.Point(798, 334);
            this.nupSeuille.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nupSeuille.Name = "nupSeuille";
            this.nupSeuille.Size = new System.Drawing.Size(56, 20);
            this.nupSeuille.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(750, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Seuille :";
            // 
            // pbxPixel
            // 
            this.pbxPixel.Location = new System.Drawing.Point(624, 12);
            this.pbxPixel.Name = "pbxPixel";
            this.pbxPixel.Size = new System.Drawing.Size(300, 300);
            this.pbxPixel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPixel.TabIndex = 6;
            this.pbxPixel.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 379);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nupSeuille);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupHeight);
            this.Controls.Add(this.nupWidth);
            this.Controls.Add(this.pbxPixel);
            this.Controls.Add(this.btnConvertPixel);
            this.Controls.Add(this.BtnConvertImg);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.pbxGrayImage);
            this.Controls.Add(this.pbxOriginalImg);
            this.Name = "MainView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxOriginalImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrayImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSeuille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPixel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxOriginalImg;
        private System.Windows.Forms.PictureBox pbxGrayImage;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button BtnConvertImg;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.Button btnConvertPixel;
        private MyPictureBox pbxPixel;
        private System.Windows.Forms.NumericUpDown nupWidth;
        private System.Windows.Forms.NumericUpDown nupHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupSeuille;
        private System.Windows.Forms.Label label3;
    }
}

