namespace BJ_Cliente
{
    partial class AcercaDe
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
            this.panelSalir = new System.Windows.Forms.Panel();
            this.fondoAcercaDe = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fondoAcercaDe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSalir
            // 
            this.panelSalir.Location = new System.Drawing.Point(27, 753);
            this.panelSalir.Margin = new System.Windows.Forms.Padding(4);
            this.panelSalir.Name = "panelSalir";
            this.panelSalir.Size = new System.Drawing.Size(100, 100);
            this.panelSalir.TabIndex = 7;
            this.panelSalir.Click += new System.EventHandler(this.panelSalir_Click);
            // 
            // fondoAcercaDe
            // 
            this.fondoAcercaDe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fondoAcercaDe.Image = global::BJ_Cliente.Properties.Resources.AcercaDe;
            this.fondoAcercaDe.Location = new System.Drawing.Point(3, -13);
            this.fondoAcercaDe.Margin = new System.Windows.Forms.Padding(4);
            this.fondoAcercaDe.Name = "fondoAcercaDe";
            this.fondoAcercaDe.Size = new System.Drawing.Size(942, 935);
            this.fondoAcercaDe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fondoAcercaDe.TabIndex = 6;
            this.fondoAcercaDe.TabStop = false;
            this.fondoAcercaDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fondoLogin_MouseDown);
            this.fondoAcercaDe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fondoLogin_MouseMove);
            this.fondoAcercaDe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fondoLogin_MouseUp);
            // 
            // AcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(981, 955);
            this.Controls.Add(this.panelSalir);
            this.Controls.Add(this.fondoAcercaDe);
            this.Name = "AcercaDe";
            this.Text = "AcercaDe";
            ((System.ComponentModel.ISupportInitialize)(this.fondoAcercaDe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSalir;
        private System.Windows.Forms.PictureBox fondoAcercaDe;
    }
}