namespace Groceries_App
{
    partial class AddLooseItems
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
            this.clbBasicItems = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnull = new System.Windows.Forms.Button();
            this.dgwExtras = new System.Windows.Forms.DataGridView();
            this.dgwExtrasTbQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwExtrasTbUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwExtrasTbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwExtrasCbCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAddBasicItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwExtras)).BeginInit();
            this.SuspendLayout();
            // 
            // clbBasicItems
            // 
            this.clbBasicItems.FormattingEnabled = true;
            this.clbBasicItems.Location = new System.Drawing.Point(21, 12);
            this.clbBasicItems.Name = "clbBasicItems";
            this.clbBasicItems.Size = new System.Drawing.Size(767, 259);
            this.clbBasicItems.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(632, 679);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAnnull
            // 
            this.btnAnnull.Location = new System.Drawing.Point(713, 679);
            this.btnAnnull.Name = "btnAnnull";
            this.btnAnnull.Size = new System.Drawing.Size(75, 23);
            this.btnAnnull.TabIndex = 3;
            this.btnAnnull.Text = "Annuller";
            this.btnAnnull.UseVisualStyleBackColor = true;
            this.btnAnnull.Click += new System.EventHandler(this.btnAnnull_Click);
            // 
            // dgwExtras
            // 
            this.dgwExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwExtras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwExtrasTbQuantity,
            this.dgwExtrasTbUnit,
            this.dgwExtrasTbName,
            this.dgwExtrasCbCategory});
            this.dgwExtras.Location = new System.Drawing.Point(21, 314);
            this.dgwExtras.Name = "dgwExtras";
            this.dgwExtras.RowHeadersWidth = 51;
            this.dgwExtras.RowTemplate.Height = 24;
            this.dgwExtras.Size = new System.Drawing.Size(767, 354);
            this.dgwExtras.TabIndex = 4;
            this.dgwExtras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwExtras_CellContentClick);
            // 
            // dgwExtrasTbQuantity
            // 
            this.dgwExtrasTbQuantity.HeaderText = "Mængde";
            this.dgwExtrasTbQuantity.MinimumWidth = 6;
            this.dgwExtrasTbQuantity.Name = "dgwExtrasTbQuantity";
            this.dgwExtrasTbQuantity.Width = 125;
            // 
            // dgwExtrasTbUnit
            // 
            this.dgwExtrasTbUnit.HeaderText = "Enhed";
            this.dgwExtrasTbUnit.MinimumWidth = 6;
            this.dgwExtrasTbUnit.Name = "dgwExtrasTbUnit";
            this.dgwExtrasTbUnit.Width = 125;
            // 
            // dgwExtrasTbName
            // 
            this.dgwExtrasTbName.HeaderText = "Vare";
            this.dgwExtrasTbName.MinimumWidth = 6;
            this.dgwExtrasTbName.Name = "dgwExtrasTbName";
            this.dgwExtrasTbName.Width = 125;
            // 
            // dgwExtrasCbCategory
            // 
            this.dgwExtrasCbCategory.HeaderText = "Kategori";
            this.dgwExtrasCbCategory.MinimumWidth = 6;
            this.dgwExtrasCbCategory.Name = "dgwExtrasCbCategory";
            this.dgwExtrasCbCategory.Width = 125;
            // 
            // btnAddBasicItems
            // 
            this.btnAddBasicItems.Location = new System.Drawing.Point(51, 277);
            this.btnAddBasicItems.Name = "btnAddBasicItems";
            this.btnAddBasicItems.Size = new System.Drawing.Size(693, 23);
            this.btnAddBasicItems.TabIndex = 5;
            this.btnAddBasicItems.Text = "Tilføj daglivarer";
            this.btnAddBasicItems.UseVisualStyleBackColor = true;
            this.btnAddBasicItems.Click += new System.EventHandler(this.btnAddBasicItems_Click);
            // 
            // AddLooseItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 714);
            this.Controls.Add(this.btnAddBasicItems);
            this.Controls.Add(this.dgwExtras);
            this.Controls.Add(this.btnAnnull);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clbBasicItems);
            this.Name = "AddLooseItems";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AddLooseItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwExtras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbBasicItems;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnull;
        private System.Windows.Forms.DataGridView dgwExtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwExtrasTbQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwExtrasTbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwExtrasTbName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgwExtrasCbCategory;
        private System.Windows.Forms.Button btnAddBasicItems;
    }
}