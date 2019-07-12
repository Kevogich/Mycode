namespace GuldeSpecer_1._0
{
    partial class Frm_GetBOMNO
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Col_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Tags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_BOMNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_NetPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog_NewBOM = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFileDialog_NewBOM = new System.Windows.Forms.OpenFileDialog();
            this.Btn_OpenFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Item,
            this.Col_Tags,
            this.Col_BOMNo,
            this.Col_Qty,
            this.Col_ListPrice,
            this.Col_NetPrice,
            this.Col_Cost});
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(961, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // Col_Item
            // 
            this.Col_Item.HeaderText = "Item";
            this.Col_Item.Name = "Col_Item";
            this.Col_Item.Width = 40;
            // 
            // Col_Tags
            // 
            this.Col_Tags.HeaderText = "Tags";
            this.Col_Tags.Name = "Col_Tags";
            this.Col_Tags.Width = 40;
            // 
            // Col_BOMNo
            // 
            this.Col_BOMNo.HeaderText = "BOM Number";
            this.Col_BOMNo.Name = "Col_BOMNo";
            // 
            // Col_Qty
            // 
            this.Col_Qty.HeaderText = "Qty";
            this.Col_Qty.Name = "Col_Qty";
            this.Col_Qty.Width = 40;
            // 
            // Col_ListPrice
            // 
            this.Col_ListPrice.HeaderText = "List Price";
            this.Col_ListPrice.Name = "Col_ListPrice";
            // 
            // Col_NetPrice
            // 
            this.Col_NetPrice.HeaderText = "Net Price";
            this.Col_NetPrice.Name = "Col_NetPrice";
            // 
            // Col_Cost
            // 
            this.Col_Cost.HeaderText = " BOM Cost";
            this.Col_Cost.Name = "Col_Cost";
            // 
            // OpenFileDialog_NewBOM
            // 
            this.OpenFileDialog_NewBOM.FileName = "openFileDialog_NewBOM";
            // 
            // Btn_OpenFile
            // 
            this.Btn_OpenFile.Location = new System.Drawing.Point(527, 13);
            this.Btn_OpenFile.Name = "Btn_OpenFile";
            this.Btn_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenFile.TabIndex = 1;
            this.Btn_OpenFile.Text = "OpenFile";
            this.Btn_OpenFile.UseVisualStyleBackColor = true;
            this.Btn_OpenFile.Click += new System.EventHandler(this.Btn_OpenFile_Click);
            // 
            // Frm_GetBOMNO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 587);
            this.Controls.Add(this.Btn_OpenFile);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm_GetBOMNO";
            this.Text = "Gulde BOM Number";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Tags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_BOMNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_ListPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_NetPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Cost;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_NewBOM;
        public System.Windows.Forms.OpenFileDialog OpenFileDialog_NewBOM;
        public System.Windows.Forms.Button Btn_OpenFile;
    }
}