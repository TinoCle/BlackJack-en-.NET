namespace BJ_Cliente
{
    partial class TableroJugador
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
			this.timerListen = new System.Windows.Forms.Timer(this.components);
			this.lblPuntos = new System.Windows.Forms.Label();
			this.lblPuntosRival = new System.Windows.Forms.Label();
			this.lblRival = new System.Windows.Forms.Label();
			this.lblYo = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panelPedirOtra = new System.Windows.Forms.Panel();
			this.panelPlantarse = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// timerListen
			// 
			this.timerListen.Interval = 1000;
			this.timerListen.Tick += new System.EventHandler(this.timerListen_Tick);
			// 
			// lblPuntos
			// 
			this.lblPuntos.AutoSize = true;
			this.lblPuntos.BackColor = System.Drawing.Color.White;
			this.lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.lblPuntos.Location = new System.Drawing.Point(226, 60);
			this.lblPuntos.Name = "lblPuntos";
			this.lblPuntos.Size = new System.Drawing.Size(19, 20);
			this.lblPuntos.TabIndex = 5;
			this.lblPuntos.Text = "0";
			// 
			// lblPuntosRival
			// 
			this.lblPuntosRival.AutoSize = true;
			this.lblPuntosRival.BackColor = System.Drawing.Color.White;
			this.lblPuntosRival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.lblPuntosRival.ForeColor = System.Drawing.Color.Black;
			this.lblPuntosRival.Location = new System.Drawing.Point(712, 60);
			this.lblPuntosRival.Name = "lblPuntosRival";
			this.lblPuntosRival.Size = new System.Drawing.Size(19, 20);
			this.lblPuntosRival.TabIndex = 8;
			this.lblPuntosRival.Text = "0";
			// 
			// lblRival
			// 
			this.lblRival.AutoSize = true;
			this.lblRival.BackColor = System.Drawing.Color.White;
			this.lblRival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.lblRival.ForeColor = System.Drawing.Color.Black;
			this.lblRival.Location = new System.Drawing.Point(712, 32);
			this.lblRival.Name = "lblRival";
			this.lblRival.Size = new System.Drawing.Size(62, 20);
			this.lblRival.TabIndex = 10;
			this.lblRival.Text = "RIVAL";
			// 
			// lblYo
			// 
			this.lblYo.AutoSize = true;
			this.lblYo.BackColor = System.Drawing.Color.White;
			this.lblYo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.lblYo.ForeColor = System.Drawing.Color.Black;
			this.lblYo.Location = new System.Drawing.Point(226, 32);
			this.lblYo.Name = "lblYo";
			this.lblYo.Size = new System.Drawing.Size(96, 20);
			this.lblYo.TabIndex = 11;
			this.lblYo.Text = "JUGADOR";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Image = global::BJ_Cliente.Properties.Resources.Tablero;
			this.pictureBox1.Location = new System.Drawing.Point(-2, 1);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(974, 507);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			// 
			// panelPedirOtra
			// 
			this.panelPedirOtra.BackColor = System.Drawing.Color.Transparent;
			this.panelPedirOtra.Location = new System.Drawing.Point(134, 439);
			this.panelPedirOtra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panelPedirOtra.Name = "panelPedirOtra";
			this.panelPedirOtra.Size = new System.Drawing.Size(263, 52);
			this.panelPedirOtra.TabIndex = 13;
			this.panelPedirOtra.Click += new System.EventHandler(this.btnOtra_Click);
			// 
			// panelPlantarse
			// 
			this.panelPlantarse.BackColor = System.Drawing.Color.Transparent;
			this.panelPlantarse.Location = new System.Drawing.Point(587, 439);
			this.panelPlantarse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panelPlantarse.Name = "panelPlantarse";
			this.panelPlantarse.Size = new System.Drawing.Size(263, 52);
			this.panelPlantarse.TabIndex = 14;
			this.panelPlantarse.Click += new System.EventHandler(this.btnPlantarse_Click);
			// 
			// TableroJugador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(837, 498);
			this.Controls.Add(this.panelPlantarse);
			this.Controls.Add(this.panelPedirOtra);
			this.Controls.Add(this.lblYo);
			this.Controls.Add(this.lblRival);
			this.Controls.Add(this.lblPuntosRival);
			this.Controls.Add(this.lblPuntos);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "TableroJugador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BlackJack club";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableroJugador_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerListen;
		private System.Windows.Forms.Label lblPuntos;
		private System.Windows.Forms.Label lblPuntosRival;
		private System.Windows.Forms.Label lblRival;
		private System.Windows.Forms.Label lblYo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelPedirOtra;
        private System.Windows.Forms.Panel panelPlantarse;
    }
}

