namespace Groceries_App
{
    partial class groceriesGUI
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
            this.rtbIngredienser = new System.Windows.Forms.RichTextBox();
            this.lbRet = new System.Windows.Forms.ListBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.btnUpdRec = new System.Windows.Forms.Button();
            this.lblRetHeader = new System.Windows.Forms.Label();
            this.lblRetTags = new System.Windows.Forms.Label();
            this.lblPrepTime = new System.Windows.Forms.Label();
            this.btnAddToShopList = new System.Windows.Forms.Button();
            this.btnGenShopList = new System.Windows.Forms.Button();
            this.btnAddEditDish = new System.Windows.Forms.Button();
            this.rtbNoter = new System.Windows.Forms.RichTextBox();
            this.btnEditDish = new System.Windows.Forms.Button();
            this.btnAddLooseItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbIngredienser
            // 
            this.rtbIngredienser.BackColor = System.Drawing.SystemColors.Control;
            this.rtbIngredienser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbIngredienser.Location = new System.Drawing.Point(638, 287);
            this.rtbIngredienser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbIngredienser.Name = "rtbIngredienser";
            this.rtbIngredienser.ReadOnly = true;
            this.rtbIngredienser.Size = new System.Drawing.Size(600, 387);
            this.rtbIngredienser.TabIndex = 1;
            this.rtbIngredienser.Text = "";
            this.rtbIngredienser.TextChanged += new System.EventHandler(this.rtbIngredienser_TextChanged);
            // 
            // lbRet
            // 
            this.lbRet.FormattingEnabled = true;
            this.lbRet.ItemHeight = 16;
            this.lbRet.Location = new System.Drawing.Point(17, 63);
            this.lbRet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRet.Name = "lbRet";
            this.lbRet.Size = new System.Drawing.Size(569, 564);
            this.lbRet.TabIndex = 2;
            this.lbRet.SelectedIndexChanged += new System.EventHandler(this.lbRet_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(17, 652);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(569, 22);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.Text = "   søg ...";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(1126, 9);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(156, 17);
            this.lblServerStatus.TabIndex = 8;
            this.lblServerStatus.Text = "SQL server unavailable";
            this.lblServerStatus.Click += new System.EventHandler(this.labelServerStatus_Click);
            // 
            // btnUpdRec
            // 
            this.btnUpdRec.Location = new System.Drawing.Point(156, 11);
            this.btnUpdRec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdRec.Name = "btnUpdRec";
            this.btnUpdRec.Size = new System.Drawing.Size(71, 23);
            this.btnUpdRec.TabIndex = 12;
            this.btnUpdRec.Text = "Opdater";
            this.btnUpdRec.UseVisualStyleBackColor = true;
            this.btnUpdRec.Click += new System.EventHandler(this.btnUpdRec_Click);
            // 
            // lblRetHeader
            // 
            this.lblRetHeader.AutoSize = true;
            this.lblRetHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRetHeader.Location = new System.Drawing.Point(633, 63);
            this.lblRetHeader.Name = "lblRetHeader";
            this.lblRetHeader.Size = new System.Drawing.Size(0, 25);
            this.lblRetHeader.TabIndex = 14;
            // 
            // lblRetTags
            // 
            this.lblRetTags.AutoSize = true;
            this.lblRetTags.Location = new System.Drawing.Point(625, 98);
            this.lblRetTags.Name = "lblRetTags";
            this.lblRetTags.Size = new System.Drawing.Size(0, 17);
            this.lblRetTags.TabIndex = 15;
            // 
            // lblPrepTime
            // 
            this.lblPrepTime.AutoSize = true;
            this.lblPrepTime.Location = new System.Drawing.Point(625, 118);
            this.lblPrepTime.Name = "lblPrepTime";
            this.lblPrepTime.Size = new System.Drawing.Size(36, 17);
            this.lblPrepTime.TabIndex = 16;
            this.lblPrepTime.Text = "   /   ";
            // 
            // btnAddToShopList
            // 
            this.btnAddToShopList.Location = new System.Drawing.Point(701, 689);
            this.btnAddToShopList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddToShopList.Name = "btnAddToShopList";
            this.btnAddToShopList.Size = new System.Drawing.Size(166, 42);
            this.btnAddToShopList.TabIndex = 17;
            this.btnAddToShopList.Text = "Føj til Indkøbsliste";
            this.btnAddToShopList.UseVisualStyleBackColor = true;
            this.btnAddToShopList.Click += new System.EventHandler(this.btnAddToShopList_Click);
            // 
            // btnGenShopList
            // 
            this.btnGenShopList.Location = new System.Drawing.Point(529, 689);
            this.btnGenShopList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenShopList.Name = "btnGenShopList";
            this.btnGenShopList.Size = new System.Drawing.Size(166, 42);
            this.btnGenShopList.TabIndex = 18;
            this.btnGenShopList.Text = "Vis Indkøbsliste";
            this.btnGenShopList.UseVisualStyleBackColor = true;
            this.btnGenShopList.Click += new System.EventHandler(this.btnGenShopList_Click);
            // 
            // btnAddEditDish
            // 
            this.btnAddEditDish.Location = new System.Drawing.Point(82, 11);
            this.btnAddEditDish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddEditDish.Name = "btnAddEditDish";
            this.btnAddEditDish.Size = new System.Drawing.Size(68, 23);
            this.btnAddEditDish.TabIndex = 21;
            this.btnAddEditDish.Text = "Ny Ret";
            this.btnAddEditDish.UseMnemonic = false;
            this.btnAddEditDish.UseVisualStyleBackColor = true;
            this.btnAddEditDish.Click += new System.EventHandler(this.btnAddEditDish_Click);
            // 
            // rtbNoter
            // 
            this.rtbNoter.BackColor = System.Drawing.SystemColors.Control;
            this.rtbNoter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNoter.Location = new System.Drawing.Point(628, 150);
            this.rtbNoter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbNoter.Name = "rtbNoter";
            this.rtbNoter.ReadOnly = true;
            this.rtbNoter.Size = new System.Drawing.Size(643, 106);
            this.rtbNoter.TabIndex = 22;
            this.rtbNoter.Text = "";
            this.rtbNoter.TextChanged += new System.EventHandler(this.rtbNoter_TextChanged);
            // 
            // btnEditDish
            // 
            this.btnEditDish.Location = new System.Drawing.Point(6, 11);
            this.btnEditDish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Size = new System.Drawing.Size(70, 23);
            this.btnEditDish.TabIndex = 23;
            this.btnEditDish.Text = "Rediger";
            this.btnEditDish.UseMnemonic = false;
            this.btnEditDish.UseVisualStyleBackColor = true;
            this.btnEditDish.Click += new System.EventHandler(this.btnEditDish_Click);
            // 
            // btnAddLooseItems
            // 
            this.btnAddLooseItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLooseItems.Location = new System.Drawing.Point(357, 689);
            this.btnAddLooseItems.Name = "btnAddLooseItems";
            this.btnAddLooseItems.Size = new System.Drawing.Size(166, 42);
            this.btnAddLooseItems.TabIndex = 24;
            this.btnAddLooseItems.Text = "Tilføj varer";
            this.btnAddLooseItems.UseVisualStyleBackColor = true;
            this.btnAddLooseItems.Click += new System.EventHandler(this.btnAddLooseItems_Click);
            // 
            // groceriesGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 742);
            this.Controls.Add(this.btnAddLooseItems);
            this.Controls.Add(this.btnEditDish);
            this.Controls.Add(this.rtbNoter);
            this.Controls.Add(this.btnAddEditDish);
            this.Controls.Add(this.btnGenShopList);
            this.Controls.Add(this.btnAddToShopList);
            this.Controls.Add(this.lblPrepTime);
            this.Controls.Add(this.lblRetTags);
            this.Controls.Add(this.lblRetHeader);
            this.Controls.Add(this.btnUpdRec);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbRet);
            this.Controls.Add(this.rtbIngredienser);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "groceriesGUI";
            this.RightToLeftLayout = true;
            this.Text = "Groceries App";
            this.Load += new System.EventHandler(this.groceriesGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbIngredienser;
        private System.Windows.Forms.ListBox lbRet;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Button btnUpdRec;
        private System.Windows.Forms.Label lblRetHeader;
        private System.Windows.Forms.Label lblRetTags;
        private System.Windows.Forms.Label lblPrepTime;
        private System.Windows.Forms.Button btnAddToShopList;
        private System.Windows.Forms.Button btnGenShopList;
        private System.Windows.Forms.Button btnAddEditDish;
        private System.Windows.Forms.RichTextBox rtbNoter;
        private System.Windows.Forms.Button btnEditDish;
        private System.Windows.Forms.Button btnAddLooseItems;
    }
}

