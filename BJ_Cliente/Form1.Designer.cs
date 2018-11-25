namespace BJ_Cliente
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // btnOtra
            // 
            this.btnOtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtra.Location = new System.Drawing.Point(125, 373);
            this.btnOtra.Name = "btnOtra";
            this.btnOtra.Size = new System.Drawing.Size(259, 112);
            this.btnOtra.TabIndex = 0;
            this.btnOtra.Text = "Pedir Otra";
            this.btnOtra.UseVisualStyleBackColor = true;
            this.btnOtra.Click += new System.EventHandler(this.btnOtra_Click);
            // 
            // btnPlantarse
            // 
            this.btnPlantarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlantarse.Location = new System.Drawing.Point(441, 373);
            this.btnPlantarse.Name = "btnPlantarse";
            this.btnPlantarse.Size = new System.Drawing.Size(259, 112);
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
            this.txtCartaRecibida.Location = new System.Drawing.Point(125, 170);
            this.txtCartaRecibida.Name = "txtCartaRecibida";
            this.txtCartaRecibida.Size = new System.Drawing.Size(575, 31);
            this.txtCartaRecibida.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Carta recibida";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 555);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCartaRecibida);
            this.Controls.Add(this.btnPlantarse);
            this.Controls.Add(this.btnOtra);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOtra;
        private System.Windows.Forms.Button btnPlantarse;
        private System.Windows.Forms.Timer timerListen;
        private System.Windows.Forms.TextBox txtCartaRecibida;
        private System.Windows.Forms.Label label1;
    }
}

