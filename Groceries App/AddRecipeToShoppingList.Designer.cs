namespace Groceries_App
{
    partial class AddRecipeToShoppingList
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
            this.dgwIngredients = new System.Windows.Forms.DataGridView();
            this.dgwIngredientsTbQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwIngredientsTbUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwIngredientsTbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwIngredientsCbWillAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgwTwists = new System.Windows.Forms.DataGridView();
            this.dgwTwistTbQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwTwistTbUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwTwistTbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwTwistCbWillAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgwExtras = new System.Windows.Forms.DataGridView();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.btnAnnull = new System.Windows.Forms.Button();
            this.dgwExtrasTbQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwExtrasTbUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwExtrasTbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwExtrasCbCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTwists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwExtras)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwIngredients
            // 
            this.dgwIngredients.AllowUserToAddRows = false;
            this.dgwIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwIngredientsTbQuantity,
            this.dgwIngredientsTbUnit,
            this.dgwIngredientsTbName,
            this.dgwIngredientsCbWillAdd});
            this.dgwIngredients.Location = new System.Drawing.Point(12, 56);
            this.dgwIngredients.Name = "dgwIngredients";
            this.dgwIngredients.RowHeadersWidth = 51;
            this.dgwIngredients.RowTemplate.Height = 24;
            this.dgwIngredients.Size = new System.Drawing.Size(689, 240);
            this.dgwIngredients.TabIndex = 0;
            this.dgwIngredients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwIngredients_CellContentClick);
            this.dgwIngredients.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwIngredients_CellValueChanged);
            // 
            // dgwIngredientsTbQuantity
            // 
            this.dgwIngredientsTbQuantity.HeaderText = "Mængde";
            this.dgwIngredientsTbQuantity.MinimumWidth = 6;
            this.dgwIngredientsTbQuantity.Name = "dgwIngredientsTbQuantity";
            this.dgwIngredientsTbQuantity.Width = 125;
            // 
            // dgwIngredientsTbUnit
            // 
            this.dgwIngredientsTbUnit.HeaderText = "Enhed";
            this.dgwIngredientsTbUnit.MinimumWidth = 6;
            this.dgwIngredientsTbUnit.Name = "dgwIngredientsTbUnit";
            this.dgwIngredientsTbUnit.ReadOnly = true;
            this.dgwIngredientsTbUnit.Width = 125;
            // 
            // dgwIngredientsTbName
            // 
            this.dgwIngredientsTbName.HeaderText = "Vare";
            this.dgwIngredientsTbName.MinimumWidth = 6;
            this.dgwIngredientsTbName.Name = "dgwIngredientsTbName";
            this.dgwIngredientsTbName.ReadOnly = true;
            this.dgwIngredientsTbName.Width = 125;
            // 
            // dgwIngredientsCbWillAdd
            // 
            this.dgwIngredientsCbWillAdd.HeaderText = "Inkluder";
            this.dgwIngredientsCbWillAdd.MinimumWidth = 6;
            this.dgwIngredientsCbWillAdd.Name = "dgwIngredientsCbWillAdd";
            this.dgwIngredientsCbWillAdd.Width = 125;
            // 
            // dgwTwists
            // 
            this.dgwTwists.AllowUserToAddRows = false;
            this.dgwTwists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTwists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwTwistTbQuantity,
            this.dgwTwistTbUnit,
            this.dgwTwistTbName,
            this.dgwTwistCbWillAdd});
            this.dgwTwists.Location = new System.Drawing.Point(12, 327);
            this.dgwTwists.Name = "dgwTwists";
            this.dgwTwists.RowHeadersWidth = 51;
            this.dgwTwists.RowTemplate.Height = 24;
            this.dgwTwists.Size = new System.Drawing.Size(689, 148);
            this.dgwTwists.TabIndex = 1;
            this.dgwTwists.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTwists_CellValueChanged);
            // 
            // dgwTwistTbQuantity
            // 
            this.dgwTwistTbQuantity.HeaderText = "Mængde";
            this.dgwTwistTbQuantity.MinimumWidth = 6;
            this.dgwTwistTbQuantity.Name = "dgwTwistTbQuantity";
            this.dgwTwistTbQuantity.Width = 125;
            // 
            // dgwTwistTbUnit
            // 
            this.dgwTwistTbUnit.HeaderText = "Enhed";
            this.dgwTwistTbUnit.MinimumWidth = 6;
            this.dgwTwistTbUnit.Name = "dgwTwistTbUnit";
            this.dgwTwistTbUnit.ReadOnly = true;
            this.dgwTwistTbUnit.Width = 125;
            // 
            // dgwTwistTbName
            // 
            this.dgwTwistTbName.HeaderText = "Vare";
            this.dgwTwistTbName.MinimumWidth = 6;
            this.dgwTwistTbName.Name = "dgwTwistTbName";
            this.dgwTwistTbName.ReadOnly = true;
            this.dgwTwistTbName.Width = 125;
            // 
            // dgwTwistCbWillAdd
            // 
            this.dgwTwistCbWillAdd.HeaderText = "Inkluder";
            this.dgwTwistCbWillAdd.MinimumWidth = 6;
            this.dgwTwistCbWillAdd.Name = "dgwTwistCbWillAdd";
            this.dgwTwistCbWillAdd.Width = 125;
            // 
            // dgwExtras
            // 
            this.dgwExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwExtras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwExtrasTbQuantity,
            this.dgwExtrasTbUnit,
            this.dgwExtrasTbName,
            this.dgwExtrasCbCategory});
            this.dgwExtras.Location = new System.Drawing.Point(12, 504);
            this.dgwExtras.Name = "dgwExtras";
            this.dgwExtras.RowHeadersWidth = 51;
            this.dgwExtras.RowTemplate.Height = 24;
            this.dgwExtras.Size = new System.Drawing.Size(689, 134);
            this.dgwExtras.TabIndex = 2;
            this.dgwExtras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(763, 577);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnAddRecipe.TabIndex = 3;
            this.btnAddRecipe.Text = "OK";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // btnAnnull
            // 
            this.btnAnnull.Location = new System.Drawing.Point(763, 615);
            this.btnAnnull.Name = "btnAnnull";
            this.btnAnnull.Size = new System.Drawing.Size(75, 23);
            this.btnAnnull.TabIndex = 4;
            this.btnAnnull.Text = "Annuller";
            this.btnAnnull.UseVisualStyleBackColor = true;
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
            // AddRecipeToShoppingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 664);
            this.Controls.Add(this.btnAnnull);
            this.Controls.Add(this.btnAddRecipe);
            this.Controls.Add(this.dgwExtras);
            this.Controls.Add(this.dgwTwists);
            this.Controls.Add(this.dgwIngredients);
            this.Name = "AddRecipeToShoppingList";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AddRecipeToShoppingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTwists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwExtras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwIngredients;
        private System.Windows.Forms.DataGridView dgwTwists;
        private System.Windows.Forms.DataGridView dgwExtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwTwistTbQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwTwistTbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwTwistTbName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgwTwistCbWillAdd;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Button btnAnnull;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwIngredientsTbQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwIngredientsTbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwIngredientsTbName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgwIngredientsCbWillAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwExtrasTbQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwExtrasTbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwExtrasTbName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgwExtrasCbCategory;
    }
}