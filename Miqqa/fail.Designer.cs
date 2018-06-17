namespace Miqqa
{
    partial class fail
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
            this.thetime = new System.Windows.Forms.Label();
            this.theitem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thetime
            // 
            this.thetime.AutoSize = true;
            this.thetime.Font = new System.Drawing.Font("휴먼둥근헤드라인", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.thetime.Location = new System.Drawing.Point(384, 245);
            this.thetime.Name = "thetime";
            this.thetime.Size = new System.Drawing.Size(263, 67);
            this.thetime.TabIndex = 0;
            this.thetime.Text = "label1";
            // 
            // theitem
            // 
            this.theitem.AutoSize = true;
            this.theitem.Font = new System.Drawing.Font("휴먼둥근헤드라인", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.theitem.Location = new System.Drawing.Point(384, 445);
            this.theitem.Name = "theitem";
            this.theitem.Size = new System.Drawing.Size(263, 67);
            this.theitem.TabIndex = 1;
            this.theitem.Text = "label1";
            // 
            // fail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Miqqa.Properties.Resources.fail;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1199, 721);
            this.Controls.Add(this.theitem);
            this.Controls.Add(this.thetime);
            this.DoubleBuffered = true;
            this.Name = "fail";
            this.Text = "fail";
            this.Load += new System.EventHandler(this.fail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label thetime;
        private System.Windows.Forms.Label theitem;
    }
}