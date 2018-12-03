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
            this.fondoLogin = new System.Windows.Forms.PictureBox();
            this.panelRanking = new System.Windows.Forms.Panel();
            this.panelSalir = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fondoLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.DarkViolet;
            this.txtUser.Location = new System.Drawing.Point(140, 369);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(266, 40);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // fondoLogin
            // 
            this.fondoLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fondoLogin.Image = global::BJ_Cliente.Properties.Resources.FondoLadrillos;
            this.fondoLogin.Location = new System.Drawing.Point(-1, -6);
            this.fondoLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fondoLogin.Name = "fondoLogin";
            this.fondoLogin.Size = new System.Drawing.Size(471, 486);
            this.fondoLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fondoLogin.TabIndex = 0;
            this.fondoLogin.TabStop = false;
            this.fondoLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fondoLogin_MouseDown);
            this.fondoLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fondoLogin_MouseMove);
            this.fondoLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fondoLogin_MouseUp);
            // 
            // panelRanking
            // 
            this.panelRanking.Location = new System.Drawing.Point(10, 22);
            this.panelRanking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRanking.Name = "panelRanking";
            this.panelRanking.Size = new System.Drawing.Size(50, 52);
            this.panelRanking.TabIndex = 4;
            this.panelRanking.Click += new System.EventHandler(this.btRanking_Click);
            // 
            // panelSalir
            // 
            this.panelSalir.Location = new System.Drawing.Point(11, 392);
            this.panelSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSalir.Name = "panelSalir";
            this.panelSalir.Size = new System.Drawing.Size(50, 52);
            this.panelSalir.TabIndex = 5;
            this.panelSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(470, 456);
            this.Controls.Add(this.panelSalir);
            this.Controls.Add(this.panelRanking);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.fondoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.fondoLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fondoLogin;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panelRanking;
        private System.Windows.Forms.Panel panelSalir;
    }
}