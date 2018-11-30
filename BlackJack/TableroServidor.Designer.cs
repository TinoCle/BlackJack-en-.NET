namespace BlackJack
{
    partial class TableroServidor
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
            this.timerCheckBuffer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listLog = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerCheckBuffer
            // 
            this.timerCheckBuffer.Interval = 1000;
            this.timerCheckBuffer.Tick += new System.EventHandler(this.timerCheckBuffer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::BlackJack.Properties.Resources.Server;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1932, 967);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listLog
            // 
            this.listLog.BackColor = System.Drawing.Color.Black;
            this.listLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLog.ForeColor = System.Drawing.Color.Lime;
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 31;
            this.listLog.Location = new System.Drawing.Point(1148, 265);
            this.listLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listLog.Name = "listLog";
            this.listLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listLog.Size = new System.Drawing.Size(564, 465);
            this.listLog.TabIndex = 1;
            this.listLog.TabStop = false;
            this.listLog.UseTabStops = false;
            // 
            // TableroServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "TableroServidor";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "BlackJack club - Servidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableroServidor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerCheckBuffer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listLog;
    }
}

