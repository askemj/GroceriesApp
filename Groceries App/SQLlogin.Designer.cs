namespace Groceries_App
{
    partial class SQLlogin
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
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.btnServerLoginOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(33, 74);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(266, 22);
            this.tbUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login på SQL serveren";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brugernavn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kodeord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Server IP";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(33, 139);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(266, 22);
            this.tbPass.TabIndex = 5;
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(33, 204);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(266, 22);
            this.tbServerIP.TabIndex = 6;
            this.tbServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIP_KeyPress);
            // 
            // btnServerLoginOK
            // 
            this.btnServerLoginOK.Location = new System.Drawing.Point(140, 256);
            this.btnServerLoginOK.Name = "btnServerLoginOK";
            this.btnServerLoginOK.Size = new System.Drawing.Size(75, 23);
            this.btnServerLoginOK.TabIndex = 7;
            this.btnServerLoginOK.Text = "OK";
            this.btnServerLoginOK.UseVisualStyleBackColor = true;
            this.btnServerLoginOK.Click += new System.EventHandler(this.btnServerLoginOK_Click);
            // 
            // SQLlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 291);
            this.Controls.Add(this.btnServerLoginOK);
            this.Controls.Add(this.tbServerIP);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUser);
            this.Name = "SQLlogin";
            this.Text = "SQLlogin";
            this.Load += new System.EventHandler(this.SQLlogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.Button btnServerLoginOK;
    }
}