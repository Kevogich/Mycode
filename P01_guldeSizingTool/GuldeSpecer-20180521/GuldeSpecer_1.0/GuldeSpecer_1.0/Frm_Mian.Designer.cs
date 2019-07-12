namespace GuldeSpecer_1._0
{
    partial class Frm_Main
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
            this.Btn_SpecG = new System.Windows.Forms.Button();
            this.Btn_GetBOMNBR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_SpecG
            // 
            this.Btn_SpecG.Location = new System.Drawing.Point(44, 164);
            this.Btn_SpecG.Name = "Btn_SpecG";
            this.Btn_SpecG.Size = new System.Drawing.Size(144, 49);
            this.Btn_SpecG.TabIndex = 0;
            this.Btn_SpecG.Text = "Part I \r\nSpec Proccessing";
            this.Btn_SpecG.UseVisualStyleBackColor = true;
            this.Btn_SpecG.Click += new System.EventHandler(this.Btn_SpecG_Click);
            // 
            // Btn_GetBOMNBR
            // 
            this.Btn_GetBOMNBR.Location = new System.Drawing.Point(306, 164);
            this.Btn_GetBOMNBR.Name = "Btn_GetBOMNBR";
            this.Btn_GetBOMNBR.Size = new System.Drawing.Size(136, 49);
            this.Btn_GetBOMNBR.TabIndex = 1;
            this.Btn_GetBOMNBR.Text = "Part II \r\nGet Gulde BOM No";
            this.Btn_GetBOMNBR.UseVisualStyleBackColor = true;
            this.Btn_GetBOMNBR.Click += new System.EventHandler(this.Btn_GetBOMNBR_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 264);
            this.Controls.Add(this.Btn_GetBOMNBR);
            this.Controls.Add(this.Btn_SpecG);
            this.Name = "Frm_Main";
            this.Text = "Spec Processor";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_SpecG;
        private System.Windows.Forms.Button Btn_GetBOMNBR;
    }
}

