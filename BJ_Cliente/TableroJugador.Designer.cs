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
			this.btnOtra = new System.Windows.Forms.Button();
			this.btnPlantarse = new System.Windows.Forms.Button();
			this.timerListen = new System.Windows.Forms.Timer(this.components);
			this.txtCartaRecibida = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblPuntos = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblPuntosRival = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOtra
			// 
			this.btnOtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOtra.Location = new System.Drawing.Point(67, 381);
			this.btnOtra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnOtra.Name = "btnOtra";
			this.btnOtra.Size = new System.Drawing.Size(130, 58);
			this.btnOtra.TabIndex = 0;
			this.btnOtra.Text = "Pedir Otra";
			this.btnOtra.UseVisualStyleBackColor = true;
			this.btnOtra.Click += new System.EventHandler(this.btnOtra_Click);
			// 
			// btnPlantarse
			// 
			this.btnPlantarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPlantarse.Location = new System.Drawing.Point(225, 381);
			this.btnPlantarse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnPlantarse.Name = "btnPlantarse";
			this.btnPlantarse.Size = new System.Drawing.Size(130, 58);
			this.btnPlantarse.TabIndex = 1;
			this.btnPlantarse.Text = "Plantarse";
			this.btnPlantarse.UseVisualStyleBackColor = true;
			this.btnPlantarse.Click += new System.EventHandler(this.btnPlantarse_Click);
			// 
			// timerListen
			// 
			this.timerListen.Interval = 1000;
			this.timerListen.Tick += new System.EventHandler(this.timerListen_Tick);
			// 
			// txtCartaRecibida
			// 
			this.txtCartaRecibida.Location = new System.Drawing.Point(67, 357);
			this.txtCartaRecibida.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtCartaRecibida.Name = "txtCartaRecibida";
			this.txtCartaRecibida.Size = new System.Drawing.Size(290, 20);
			this.txtCartaRecibida.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(67, 341);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Carta recibida";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(63, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Puntos:";
			// 
			// lblPuntos
			// 
			this.lblPuntos.AutoSize = true;
			this.lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPuntos.Location = new System.Drawing.Point(121, 24);
			this.lblPuntos.Name = "lblPuntos";
			this.lblPuntos.Size = new System.Drawing.Size(18, 20);
			this.lblPuntos.TabIndex = 5;
			this.lblPuntos.Text = "0";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(571, 166);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(108, 156);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// lblPuntosRival
			// 
			this.lblPuntosRival.AutoSize = true;
			this.lblPuntosRival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPuntosRival.Location = new System.Drawing.Point(625, 24);
			this.lblPuntosRival.Name = "lblPuntosRival";
			this.lblPuntosRival.Size = new System.Drawing.Size(18, 20);
			this.lblPuntosRival.TabIndex = 8;
			this.lblPuntosRival.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(567, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Puntos:";
			// 
			// TableroJugador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(920, 439);
			this.Controls.Add(this.lblPuntosRival);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblPuntos);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCartaRecibida);
			this.Controls.Add(this.btnPlantarse);
			this.Controls.Add(this.btnOtra);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "TableroJugador";
			this.Text = "BlackJack club";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOtra;
        private System.Windows.Forms.Button btnPlantarse;
        private System.Windows.Forms.Timer timerListen;
        private System.Windows.Forms.TextBox txtCartaRecibida;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblPuntos;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblPuntosRival;
		private System.Windows.Forms.Label label4;
	}
}

