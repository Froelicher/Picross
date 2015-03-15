namespace PicrossManager
{
    partial class GameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxGrid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxGrid
            // 
            this.pbxGrid.Location = new System.Drawing.Point(12, 12);
            this.pbxGrid.Name = "pbxGrid";
            this.pbxGrid.Size = new System.Drawing.Size(737, 574);
            this.pbxGrid.TabIndex = 0;
            this.pbxGrid.TabStop = false;
            this.pbxGrid.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pbxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 598);
            this.Controls.Add(this.pbxGrid);
            this.Name = "GameView";
            this.Text = "GameView";
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxGrid;

    }
}