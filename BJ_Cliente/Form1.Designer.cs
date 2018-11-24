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
            this.btnOtra = new System.Windows.Forms.Button();
            this.btnPlantarse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOtra
            // 
            this.btnOtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtra.Location = new System.Drawing.Point(129, 179);
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
            this.btnPlantarse.Location = new System.Drawing.Point(445, 179);
            this.btnPlantarse.Name = "btnPlantarse";
            this.btnPlantarse.Size = new System.Drawing.Size(259, 112);
            this.btnPlantarse.TabIndex = 1;
            this.btnPlantarse.Text = "Plantarse";
            this.btnPlantarse.UseVisualStyleBackColor = true;
            this.btnPlantarse.Click += new System.EventHandler(this.btnPlantarse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 482);
            this.Controls.Add(this.btnPlantarse);
            this.Controls.Add(this.btnOtra);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOtra;
        private System.Windows.Forms.Button btnPlantarse;
    }
}

