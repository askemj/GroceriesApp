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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblServerStat = new System.Windows.Forms.Label();
            this.btnUpdServStat = new System.Windows.Forms.Button();
            this.btnUpdRec = new System.Windows.Forms.Button();
            this.lblRetHeader = new System.Windows.Forms.Label();
            this.lblRetTags = new System.Windows.Forms.Label();
            this.lblPrepTime = new System.Windows.Forms.Label();
            this.btnAddToShopList = new System.Windows.Forms.Button();
            this.btnGenShopList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNoRecOnShopList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbIngredienser
            // 
            this.rtbIngredienser.BackColor = System.Drawing.SystemColors.Control;
            this.rtbIngredienser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbIngredienser.Location = new System.Drawing.Point(383, 240);
            this.rtbIngredienser.Name = "rtbIngredienser";
            this.rtbIngredienser.ReadOnly = true;
            this.rtbIngredienser.Size = new System.Drawing.Size(345, 211);
            this.rtbIngredienser.TabIndex = 1;
            this.rtbIngredienser.Text = "";
            // 
            // lbRet
            // 
            this.lbRet.FormattingEnabled = true;
            this.lbRet.ItemHeight = 16;
            this.lbRet.Location = new System.Drawing.Point(42, 95);
            this.lbRet.Name = "lbRet";
            this.lbRet.Size = new System.Drawing.Size(287, 356);
            this.lbRet.TabIndex = 2;
            this.lbRet.SelectedIndexChanged += new System.EventHandler(this.lbRet_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(42, 40);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(467, 22);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(562, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Søg";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Søg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Du skal bruge:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "SQL server status:";
            // 
            // lblServerStat
            // 
            this.lblServerStat.AutoSize = true;
            this.lblServerStat.Location = new System.Drawing.Point(660, 539);
            this.lblServerStat.Name = "lblServerStat";
            this.lblServerStat.Size = new System.Drawing.Size(0, 17);
            this.lblServerStat.TabIndex = 9;
            // 
            // btnUpdServStat
            // 
            this.btnUpdServStat.Location = new System.Drawing.Point(451, 536);
            this.btnUpdServStat.Name = "btnUpdServStat";
            this.btnUpdServStat.Size = new System.Drawing.Size(75, 23);
            this.btnUpdServStat.TabIndex = 11;
            this.btnUpdServStat.Text = "Opdater Server Status";
            this.btnUpdServStat.UseVisualStyleBackColor = true;
            this.btnUpdServStat.Click += new System.EventHandler(this.btnUpdServStat_Click);
            // 
            // btnUpdRec
            // 
            this.btnUpdRec.Location = new System.Drawing.Point(128, 457);
            this.btnUpdRec.Name = "btnUpdRec";
            this.btnUpdRec.Size = new System.Drawing.Size(130, 23);
            this.btnUpdRec.TabIndex = 12;
            this.btnUpdRec.Text = "Opdater Retter";
            this.btnUpdRec.UseVisualStyleBackColor = true;
            this.btnUpdRec.Click += new System.EventHandler(this.btnUpdRec_Click);
            // 
            // lblRetHeader
            // 
            this.lblRetHeader.AutoSize = true;
            this.lblRetHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRetHeader.Location = new System.Drawing.Point(383, 102);
            this.lblRetHeader.Name = "lblRetHeader";
            this.lblRetHeader.Size = new System.Drawing.Size(0, 25);
            this.lblRetHeader.TabIndex = 14;
            // 
            // lblRetTags
            // 
            this.lblRetTags.AutoSize = true;
            this.lblRetTags.Location = new System.Drawing.Point(380, 136);
            this.lblRetTags.Name = "lblRetTags";
            this.lblRetTags.Size = new System.Drawing.Size(44, 17);
            this.lblRetTags.TabIndex = 15;
            this.lblRetTags.Text = "Tags:";
            // 
            // lblPrepTime
            // 
            this.lblPrepTime.AutoSize = true;
            this.lblPrepTime.Location = new System.Drawing.Point(380, 167);
            this.lblPrepTime.Name = "lblPrepTime";
            this.lblPrepTime.Size = new System.Drawing.Size(113, 17);
            this.lblPrepTime.TabIndex = 16;
            this.lblPrepTime.Text = "Tilberedningstid:";
            // 
            // btnAddToShopList
            // 
            this.btnAddToShopList.Location = new System.Drawing.Point(405, 467);
            this.btnAddToShopList.Name = "btnAddToShopList";
            this.btnAddToShopList.Size = new System.Drawing.Size(133, 23);
            this.btnAddToShopList.TabIndex = 17;
            this.btnAddToShopList.Text = "Føj til Indkøbsliste";
            this.btnAddToShopList.UseVisualStyleBackColor = true;
            this.btnAddToShopList.Click += new System.EventHandler(this.btnAddToShopList_Click);
            // 
            // btnGenShopList
            // 
            this.btnGenShopList.Location = new System.Drawing.Point(562, 466);
            this.btnGenShopList.Name = "btnGenShopList";
            this.btnGenShopList.Size = new System.Drawing.Size(149, 23);
            this.btnGenShopList.TabIndex = 18;
            this.btnGenShopList.Text = "Generer Indkøbsliste";
            this.btnGenShopList.UseVisualStyleBackColor = true;
            this.btnGenShopList.Click += new System.EventHandler(this.btnGenShopList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 536);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Retter på indkøbslisten:";
            // 
            // lblNoRecOnShopList
            // 
            this.lblNoRecOnShopList.AutoSize = true;
            this.lblNoRecOnShopList.Location = new System.Drawing.Point(202, 537);
            this.lblNoRecOnShopList.Name = "lblNoRecOnShopList";
            this.lblNoRecOnShopList.Size = new System.Drawing.Size(16, 17);
            this.lblNoRecOnShopList.TabIndex = 20;
            this.lblNoRecOnShopList.Text = "0";
            // 
            // groceriesGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 565);
            this.Controls.Add(this.lblNoRecOnShopList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenShopList);
            this.Controls.Add(this.btnAddToShopList);
            this.Controls.Add(this.lblPrepTime);
            this.Controls.Add(this.lblRetTags);
            this.Controls.Add(this.lblRetHeader);
            this.Controls.Add(this.btnUpdRec);
            this.Controls.Add(this.btnUpdServStat);
            this.Controls.Add(this.lblServerStat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbRet);
            this.Controls.Add(this.rtbIngredienser);
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblServerStat;
        private System.Windows.Forms.Button btnUpdServStat;
        private System.Windows.Forms.Button btnUpdRec;
        private System.Windows.Forms.Label lblRetHeader;
        private System.Windows.Forms.Label lblRetTags;
        private System.Windows.Forms.Label lblPrepTime;
        private System.Windows.Forms.Button btnAddToShopList;
        private System.Windows.Forms.Button btnGenShopList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNoRecOnShopList;
    }
}

