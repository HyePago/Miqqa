namespace Miqqa
{
    partial class Stage_1
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
            this.mirim = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.mirim)).BeginInit();
            this.SuspendLayout();
            // 
            // mirim
            // 
            this.mirim.BackColor = System.Drawing.Color.AntiqueWhite;
            this.mirim.BackgroundImage = global::Miqqa.Properties.Resources.캐릭터;
            this.mirim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mirim.Location = new System.Drawing.Point(17, 20);
            this.mirim.Name = "mirim";
            this.mirim.Size = new System.Drawing.Size(95, 114);
            this.mirim.TabIndex = 0;
            this.mirim.TabStop = false;
            // 
            // Stage_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Miqqa.Properties.Resources.game_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1210, 755);
            this.Controls.Add(this.mirim);
            this.DoubleBuffered = true;
            this.Name = "Stage_1";
            this.Text = "Stage_1";
            ((System.ComponentModel.ISupportInitialize)(this.mirim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mirim;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}