namespace Groceries_App
{
    partial class AddEditRecipe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbRecipeTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPreparationTime = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTotalTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumberOfServings = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveToDatabase = new System.Windows.Forms.Button();
            this.btnAnnul = new System.Windows.Forms.Button();
            this.rtbHUD = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TwistsDgw = new System.Windows.Forms.DataGridView();
            this.TwistsTbAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwistsTbUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwistsTbGroceryItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwistsCbGroceryItemCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TwistsCbBasicItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbTag = new System.Windows.Forms.TextBox();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.lbTags = new System.Windows.Forms.ListBox();
            this.IngredientsDgw = new System.Windows.Forms.DataGridView();
            this.IngredientsTbAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsTbUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsTbGroceryItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsCbGroceryItemCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IngredientsCbBasicItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgwProducesLeftovers = new System.Windows.Forms.DataGridView();
            this.dgwcolProducesLeftovers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwUsesLeftovers = new System.Windows.Forms.DataGridView();
            this.dgwcolUsesLeftovers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TwistsDgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsDgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProducesLeftovers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUsesLeftovers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRecipeTitle
            // 
            this.tbRecipeTitle.Location = new System.Drawing.Point(60, 58);
            this.tbRecipeTitle.Name = "tbRecipeTitle";
            this.tbRecipeTitle.Size = new System.Drawing.Size(877, 22);
            this.tbRecipeTitle.TabIndex = 0;
            this.tbRecipeTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbRecipeTitle.Validating += new System.ComponentModel.CancelEventHandler(this.tbRecipeTitle_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tilføj / rediger opskrift";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Titel";
            // 
            // cbPreparationTime
            // 
            this.cbPreparationTime.FormattingEnabled = true;
            this.cbPreparationTime.Location = new System.Drawing.Point(87, 95);
            this.cbPreparationTime.Name = "cbPreparationTime";
            this.cbPreparationTime.Size = new System.Drawing.Size(121, 24);
            this.cbPreparationTime.TabIndex = 4;
            this.cbPreparationTime.SelectedIndexChanged += new System.EventHandler(this.cbPreparationTime_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arbejdstid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tilberedningstid";
            // 
            // cbTotalTime
            // 
            this.cbTotalTime.FormattingEnabled = true;
            this.cbTotalTime.Location = new System.Drawing.Point(383, 95);
            this.cbTotalTime.Name = "cbTotalTime";
            this.cbTotalTime.Size = new System.Drawing.Size(121, 24);
            this.cbTotalTime.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(783, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Antal portioner";
            // 
            // tbNumberOfServings
            // 
            this.tbNumberOfServings.Location = new System.Drawing.Point(890, 95);
            this.tbNumberOfServings.Name = "tbNumberOfServings";
            this.tbNumberOfServings.Size = new System.Drawing.Size(47, 22);
            this.tbNumberOfServings.TabIndex = 10;
            this.tbNumberOfServings.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(977, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Noter";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(980, 38);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(405, 222);
            this.rtbNotes.TabIndex = 14;
            this.rtbNotes.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(602, 95);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(156, 24);
            this.cbType.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Ingredienser";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(986, 607);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tags";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.Location = new System.Drawing.Point(1241, 688);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(144, 23);
            this.btnSaveToDatabase.TabIndex = 23;
            this.btnSaveToDatabase.Text = "Gem i database";
            this.btnSaveToDatabase.UseVisualStyleBackColor = true;
            this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
            // 
            // btnAnnul
            // 
            this.btnAnnul.Location = new System.Drawing.Point(1241, 726);
            this.btnAnnul.Name = "btnAnnul";
            this.btnAnnul.Size = new System.Drawing.Size(144, 23);
            this.btnAnnul.TabIndex = 24;
            this.btnAnnul.Text = "Anuller";
            this.btnAnnul.UseVisualStyleBackColor = true;
            this.btnAnnul.Click += new System.EventHandler(this.btnAnnul_Click);
            // 
            // rtbHUD
            // 
            this.rtbHUD.Location = new System.Drawing.Point(980, 305);
            this.rtbHUD.Name = "rtbHUD";
            this.rtbHUD.Size = new System.Drawing.Size(405, 291);
            this.rtbHUD.TabIndex = 25;
            this.rtbHUD.Text = "";
            this.rtbHUD.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 508);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Twists";
            // 
            // TwistsDgw
            // 
            this.TwistsDgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TwistsDgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TwistsTbAmount,
            this.TwistsTbUnit,
            this.TwistsTbGroceryItem,
            this.TwistsCbGroceryItemCategory,
            this.TwistsCbBasicItem});
            this.TwistsDgw.Location = new System.Drawing.Point(12, 528);
            this.TwistsDgw.Name = "TwistsDgw";
            this.TwistsDgw.RowHeadersWidth = 51;
            this.TwistsDgw.RowTemplate.Height = 24;
            this.TwistsDgw.Size = new System.Drawing.Size(935, 153);
            this.TwistsDgw.TabIndex = 26;
            // 
            // TwistsTbAmount
            // 
            this.TwistsTbAmount.HeaderText = "Mængde";
            this.TwistsTbAmount.MinimumWidth = 6;
            this.TwistsTbAmount.Name = "TwistsTbAmount";
            this.TwistsTbAmount.Width = 125;
            // 
            // TwistsTbUnit
            // 
            this.TwistsTbUnit.HeaderText = "Enhed";
            this.TwistsTbUnit.MinimumWidth = 6;
            this.TwistsTbUnit.Name = "TwistsTbUnit";
            this.TwistsTbUnit.Width = 125;
            // 
            // TwistsTbGroceryItem
            // 
            this.TwistsTbGroceryItem.HeaderText = "Vare";
            this.TwistsTbGroceryItem.MinimumWidth = 6;
            this.TwistsTbGroceryItem.Name = "TwistsTbGroceryItem";
            this.TwistsTbGroceryItem.Width = 125;
            // 
            // TwistsCbGroceryItemCategory
            // 
            this.TwistsCbGroceryItemCategory.HeaderText = "Varetype";
            this.TwistsCbGroceryItemCategory.MinimumWidth = 6;
            this.TwistsCbGroceryItemCategory.Name = "TwistsCbGroceryItemCategory";
            this.TwistsCbGroceryItemCategory.Width = 125;
            // 
            // TwistsCbBasicItem
            // 
            this.TwistsCbBasicItem.HeaderText = "Basisvare";
            this.TwistsCbBasicItem.MinimumWidth = 6;
            this.TwistsCbBasicItem.Name = "TwistsCbBasicItem";
            this.TwistsCbBasicItem.Width = 125;
            // 
            // tbTag
            // 
            this.tbTag.Location = new System.Drawing.Point(989, 767);
            this.tbTag.Name = "tbTag";
            this.tbTag.Size = new System.Drawing.Size(161, 22);
            this.tbTag.TabIndex = 28;
            this.tbTag.Click += new System.EventHandler(this.tbTag_Click);
            this.tbTag.TextChanged += new System.EventHandler(this.tbTag_TextChanged);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(1157, 765);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(26, 23);
            this.btnAddTag.TabIndex = 29;
            this.btnAddTag.Text = "+";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.Location = new System.Drawing.Point(1189, 765);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(26, 23);
            this.btnDeleteTag.TabIndex = 30;
            this.btnDeleteTag.Text = "-";
            this.btnDeleteTag.UseVisualStyleBackColor = true;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);
            // 
            // lbTags
            // 
            this.lbTags.FormattingEnabled = true;
            this.lbTags.ItemHeight = 16;
            this.lbTags.Location = new System.Drawing.Point(989, 636);
            this.lbTags.Name = "lbTags";
            this.lbTags.Size = new System.Drawing.Size(226, 116);
            this.lbTags.TabIndex = 31;
            // 
            // IngredientsDgw
            // 
            this.IngredientsDgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientsDgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IngredientsTbAmount,
            this.IngredientsTbUnit,
            this.IngredientsTbGroceryItem,
            this.IngredientsCbGroceryItemCategory,
            this.IngredientsCbBasicItem});
            this.IngredientsDgw.Location = new System.Drawing.Point(12, 148);
            this.IngredientsDgw.Name = "IngredientsDgw";
            this.IngredientsDgw.RowHeadersWidth = 51;
            this.IngredientsDgw.RowTemplate.Height = 24;
            this.IngredientsDgw.Size = new System.Drawing.Size(935, 345);
            this.IngredientsDgw.TabIndex = 32;
            this.IngredientsDgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.IngredientsDgw.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.IngredientsDgw_DataError);
            // 
            // IngredientsTbAmount
            // 
            this.IngredientsTbAmount.HeaderText = "Mængde";
            this.IngredientsTbAmount.MinimumWidth = 6;
            this.IngredientsTbAmount.Name = "IngredientsTbAmount";
            this.IngredientsTbAmount.Width = 125;
            // 
            // IngredientsTbUnit
            // 
            this.IngredientsTbUnit.HeaderText = "Enhed";
            this.IngredientsTbUnit.MinimumWidth = 6;
            this.IngredientsTbUnit.Name = "IngredientsTbUnit";
            this.IngredientsTbUnit.Width = 125;
            // 
            // IngredientsTbGroceryItem
            // 
            this.IngredientsTbGroceryItem.HeaderText = "Vare";
            this.IngredientsTbGroceryItem.MinimumWidth = 6;
            this.IngredientsTbGroceryItem.Name = "IngredientsTbGroceryItem";
            this.IngredientsTbGroceryItem.Width = 125;
            // 
            // IngredientsCbGroceryItemCategory
            // 
            this.IngredientsCbGroceryItemCategory.HeaderText = "Varetype";
            this.IngredientsCbGroceryItemCategory.MinimumWidth = 6;
            this.IngredientsCbGroceryItemCategory.Name = "IngredientsCbGroceryItemCategory";
            this.IngredientsCbGroceryItemCategory.Width = 125;
            // 
            // IngredientsCbBasicItem
            // 
            this.IngredientsCbBasicItem.HeaderText = "Basisvare";
            this.IngredientsCbBasicItem.MinimumWidth = 6;
            this.IngredientsCbBasicItem.Name = "IngredientsCbBasicItem";
            this.IngredientsCbBasicItem.Width = 125;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 688);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Laver rest";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(543, 684);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 36;
            this.label12.Text = "Bruger rest";
            // 
            // dgwProducesLeftovers
            // 
            this.dgwProducesLeftovers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProducesLeftovers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwcolProducesLeftovers});
            this.dgwProducesLeftovers.Location = new System.Drawing.Point(18, 708);
            this.dgwProducesLeftovers.Name = "dgwProducesLeftovers";
            this.dgwProducesLeftovers.RowHeadersWidth = 51;
            this.dgwProducesLeftovers.RowTemplate.Height = 24;
            this.dgwProducesLeftovers.Size = new System.Drawing.Size(389, 81);
            this.dgwProducesLeftovers.TabIndex = 37;
            // 
            // dgwcolProducesLeftovers
            // 
            this.dgwcolProducesLeftovers.HeaderText = "Laver rest";
            this.dgwcolProducesLeftovers.MinimumWidth = 6;
            this.dgwcolProducesLeftovers.Name = "dgwcolProducesLeftovers";
            this.dgwcolProducesLeftovers.Width = 125;
            // 
            // dgwUsesLeftovers
            // 
            this.dgwUsesLeftovers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwUsesLeftovers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwcolUsesLeftovers});
            this.dgwUsesLeftovers.Location = new System.Drawing.Point(546, 708);
            this.dgwUsesLeftovers.Name = "dgwUsesLeftovers";
            this.dgwUsesLeftovers.RowHeadersWidth = 51;
            this.dgwUsesLeftovers.RowTemplate.Height = 24;
            this.dgwUsesLeftovers.Size = new System.Drawing.Size(401, 81);
            this.dgwUsesLeftovers.TabIndex = 38;
            // 
            // dgwcolUsesLeftovers
            // 
            this.dgwcolUsesLeftovers.HeaderText = "Bruger rest";
            this.dgwcolUsesLeftovers.MinimumWidth = 6;
            this.dgwcolUsesLeftovers.Name = "dgwcolUsesLeftovers";
            this.dgwcolUsesLeftovers.Width = 125;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddEditRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 801);
            this.Controls.Add(this.dgwUsesLeftovers);
            this.Controls.Add(this.dgwProducesLeftovers);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.IngredientsDgw);
            this.Controls.Add(this.lbTags);
            this.Controls.Add(this.btnDeleteTag);
            this.Controls.Add(this.btnAddTag);
            this.Controls.Add(this.tbTag);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TwistsDgw);
            this.Controls.Add(this.rtbHUD);
            this.Controls.Add(this.btnAnnul);
            this.Controls.Add(this.btnSaveToDatabase);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbNumberOfServings);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTotalTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPreparationTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRecipeTitle);
            this.Name = "AddEditRecipe";
            this.Load += new System.EventHandler(this.AddEditRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TwistsDgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsDgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProducesLeftovers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUsesLeftovers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRecipeTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPreparationTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTotalTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumberOfServings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSaveToDatabase;
        private System.Windows.Forms.Button btnAnnul;
        private System.Windows.Forms.RichTextBox rtbHUD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView TwistsDgw;
        private System.Windows.Forms.TextBox tbTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnDeleteTag;
        private System.Windows.Forms.ListBox lbTags;
        private System.Windows.Forms.DataGridView IngredientsDgw;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgwProducesLeftovers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwcolProducesLeftovers;
        private System.Windows.Forms.DataGridView dgwUsesLeftovers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwcolUsesLeftovers;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsTbAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsTbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsTbGroceryItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn IngredientsCbGroceryItemCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IngredientsCbBasicItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwistsTbAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwistsTbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwistsTbGroceryItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn TwistsCbGroceryItemCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TwistsCbBasicItem;
    }
}
