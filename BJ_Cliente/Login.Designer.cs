namespace BJ_Cliente
{
    partial class Login
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
			this.txtUser = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtFichas = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtUser
			// 
			this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUser.ForeColor = System.Drawing.Color.DarkViolet;
			this.txtUser.Location = new System.Drawing.Point(105, 379);
			this.txtUser.Margin = new System.Windows.Forms.Padding(2);
			this.txtUser.Multiline = true;
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(266, 40);
			this.txtUser.TabIndex = 1;
			this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Image = global::BJ_Cliente.Properties.Resources.FondoLadrillos;
			this.pictureBox1.Location = new System.Drawing.Point(-1, 2);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(471, 486);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// txtFichas
			// 
			this.txtFichas.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFichas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFichas.ForeColor = System.Drawing.Color.DarkViolet;
			this.txtFichas.Location = new System.Drawing.Point(105, 296);
			this.txtFichas.Margin = new System.Windows.Forms.Padding(2);
			this.txtFichas.Name = "txtFichas";
			this.txtFichas.Size = new System.Drawing.Size(266, 23);
			this.txtFichas.TabIndex = 0;
			this.txtFichas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtFichas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFichas_KeyPress);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(503, 494);
			this.Controls.Add(this.txtFichas);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtFichas;
	}
}