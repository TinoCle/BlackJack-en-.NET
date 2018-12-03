namespace BJ_Cliente
{
    partial class Resultados
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
            this.fondoResultados = new System.Windows.Forms.PictureBox();
            this.lblPuntos1 = new System.Windows.Forms.Label();
            this.lblJugador1 = new System.Windows.Forms.Label();
            this.lblPuntos2 = new System.Windows.Forms.Label();
            this.lblJugador2 = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fondoResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSalir
            // 
            this.panelSalir.Location = new System.Drawing.Point(36, 894);
            this.panelSalir.Margin = new System.Windows.Forms.Padding(4);
            this.panelSalir.Name = "panelSalir";
            this.panelSalir.Size = new System.Drawing.Size(116, 117);
            this.panelSalir.TabIndex = 24;
            this.panelSalir.Click += new System.EventHandler(this.panelSalir_Click);
            // 
            // fondoResultados
            // 
            this.fondoResultados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fondoResultados.Image = global::BJ_Cliente.Properties.Resources.Resultados;
            this.fondoResultados.Location = new System.Drawing.Point(3, 2);
            this.fondoResultados.Margin = new System.Windows.Forms.Padding(4);
            this.fondoResultados.Name = "fondoResultados";
            this.fondoResultados.Size = new System.Drawing.Size(1620, 1070);
            this.fondoResultados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fondoResultados.TabIndex = 23;
            this.fondoResultados.TabStop = false;
            this.fondoResultados.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fondoResultados_MouseDown);
            this.fondoResultados.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fondoResultados_MouseMove);
            this.fondoResultados.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fondoResultados_MouseUp);
            // 
            // lblPuntos1
            // 
            this.lblPuntos1.BackColor = System.Drawing.Color.White;
            this.lblPuntos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos1.Location = new System.Drawing.Point(980, 429);
            this.lblPuntos1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuntos1.Name = "lblPuntos1";
            this.lblPuntos1.Size = new System.Drawing.Size(389, 93);
            this.lblPuntos1.TabIndex = 14;
            this.lblPuntos1.Text = "label2";
            this.lblPuntos1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJugador1
            // 
            this.lblJugador1.BackColor = System.Drawing.Color.White;
            this.lblJugador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugador1.Location = new System.Drawing.Point(497, 429);
            this.lblJugador1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJugador1.Name = "lblJugador1";
            this.lblJugador1.Size = new System.Drawing.Size(389, 93);
            this.lblJugador1.TabIndex = 13;
            this.lblJugador1.Text = "label2";
            this.lblJugador1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPuntos2
            // 
            this.lblPuntos2.BackColor = System.Drawing.Color.White;
            this.lblPuntos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos2.Location = new System.Drawing.Point(980, 571);
            this.lblPuntos2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuntos2.Name = "lblPuntos2";
            this.lblPuntos2.Size = new System.Drawing.Size(389, 93);
            this.lblPuntos2.TabIndex = 26;
            this.lblPuntos2.Text = "label2";
            this.lblPuntos2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJugador2
            // 
            this.lblJugador2.BackColor = System.Drawing.Color.White;
            this.lblJugador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugador2.Location = new System.Drawing.Point(497, 571);
            this.lblJugador2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJugador2.Name = "lblJugador2";
            this.lblJugador2.Size = new System.Drawing.Size(389, 93);
            this.lblJugador2.TabIndex = 25;
            this.lblJugador2.Text = "label2";
            this.lblJugador2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.Color.White;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(528, 808);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(811, 95);
            this.lblResultado.TabIndex = 27;
            this.lblResultado.Text = "label2";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1625, 1085);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblPuntos2);
            this.Controls.Add(this.lblJugador2);
            this.Controls.Add(this.lblPuntos1);
            this.Controls.Add(this.lblJugador1);
            this.Controls.Add(this.panelSalir);
            this.Controls.Add(this.fondoResultados);
            this.Name = "Resultados";
            this.Text = "Resultados";
            ((System.ComponentModel.ISupportInitialize)(this.fondoResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSalir;
        private System.Windows.Forms.PictureBox fondoResultados;
        private System.Windows.Forms.Label lblPuntos1;
        private System.Windows.Forms.Label lblJugador1;
        private System.Windows.Forms.Label lblPuntos2;
        private System.Windows.Forms.Label lblJugador2;
        private System.Windows.Forms.Label lblResultado;
    }
}