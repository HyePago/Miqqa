﻿namespace Miqqa
{
    partial class Stage_3
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
            this.components = new System.ComponentModel.Container();
            this.mirim = new System.Windows.Forms.PictureBox();
            this.key_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mirim)).BeginInit();
            this.SuspendLayout();
            // 
            // mirim
            // 
            this.mirim.BackColor = System.Drawing.Color.AntiqueWhite;
            this.mirim.BackgroundImage = global::Miqqa.Properties.Resources.캐릭터;
            this.mirim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mirim.Location = new System.Drawing.Point(20, 20);
            this.mirim.Name = "mirim";
            this.mirim.Size = new System.Drawing.Size(80, 84);
            this.mirim.TabIndex = 1;
            this.mirim.TabStop = false;
            // 
            // key_timer
            // 
            this.key_timer.Tick += new System.EventHandler(this.key_timer_Tick);
            // 
            // Stage_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Miqqa.Properties.Resources.stage_3_background;
            this.ClientSize = new System.Drawing.Size(1199, 721);
            this.Controls.Add(this.mirim);
            this.Name = "Stage_3";
            this.Text = "Stage_3";
            ((System.ComponentModel.ISupportInitialize)(this.mirim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mirim;
        private System.Windows.Forms.Timer key_timer;
    }
}