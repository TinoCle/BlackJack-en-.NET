namespace BJ_Cliente
{
    partial class Instrucciones
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
            this.fondoInstrucciones = new System.Windows.Forms.PictureBox();
            this.txtInstrucciones = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fondoInstrucciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSalir
            // 
            this.panelSalir.Location = new System.Drawing.Point(26, 759);
            this.panelSalir.Margin = new System.Windows.Forms.Padding(4);
            this.panelSalir.Name = "panelSalir";
            this.panelSalir.Size = new System.Drawing.Size(100, 100);
            this.panelSalir.TabIndex = 7;
            this.panelSalir.Click += new System.EventHandler(this.panelSalir_Click);
            // 
            // fondoInstrucciones
            // 
            this.fondoInstrucciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fondoInstrucciones.Image = global::BJ_Cliente.Properties.Resources.Instrucciones;
            this.fondoInstrucciones.Location = new System.Drawing.Point(2, -7);
            this.fondoInstrucciones.Margin = new System.Windows.Forms.Padding(4);
            this.fondoInstrucciones.Name = "fondoInstrucciones";
            this.fondoInstrucciones.Size = new System.Drawing.Size(942, 935);
            this.fondoInstrucciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fondoInstrucciones.TabIndex = 6;
            this.fondoInstrucciones.TabStop = false;
            this.fondoInstrucciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fondoInstrucciones_MouseDown);
            this.fondoInstrucciones.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fondoInstrucciones_MouseMove);
            this.fondoInstrucciones.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fondoInstrucciones_MouseUp);
            // 
            // txtInstrucciones
            // 
            this.txtInstrucciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstrucciones.Location = new System.Drawing.Point(276, 468);
            this.txtInstrucciones.Multiline = true;
            this.txtInstrucciones.Name = "txtInstrucciones";
            this.txtInstrucciones.ReadOnly = true;
            this.txtInstrucciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInstrucciones.Size = new System.Drawing.Size(532, 347);
            this.txtInstrucciones.TabIndex = 8;
            this.txtInstrucciones.TabStop = false;
            this.txtInstrucciones.Text = "Texto de las instrucciones";
            // 
            // Instrucciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1006, 970);
            this.Controls.Add(this.txtInstrucciones);
            this.Controls.Add(this.panelSalir);
            this.Controls.Add(this.fondoInstrucciones);
            this.Name = "Instrucciones";
            this.Text = "Instrucciones";
            ((System.ComponentModel.ISupportInitialize)(this.fondoInstrucciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSalir;
        private System.Windows.Forms.PictureBox fondoInstrucciones;
        private System.Windows.Forms.TextBox txtInstrucciones;
    }
}