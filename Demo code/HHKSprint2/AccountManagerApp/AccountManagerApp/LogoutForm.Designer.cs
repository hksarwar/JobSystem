namespace AccountManagerApp
{
    partial class LogoutForm
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
            this.yesBTN = new System.Windows.Forms.Button();
            this.NoBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesBTN
            // 
            this.yesBTN.Location = new System.Drawing.Point(51, 97);
            this.yesBTN.Name = "yesBTN";
            this.yesBTN.Size = new System.Drawing.Size(75, 23);
            this.yesBTN.TabIndex = 0;
            this.yesBTN.Text = "Yes";
            this.yesBTN.UseVisualStyleBackColor = true;
            this.yesBTN.Click += new System.EventHandler(this.YesBTN_Click);
            // 
            // NoBTN
            // 
            this.NoBTN.Location = new System.Drawing.Point(200, 97);
            this.NoBTN.Name = "NoBTN";
            this.NoBTN.Size = new System.Drawing.Size(75, 23);
            this.NoBTN.TabIndex = 1;
            this.NoBTN.Text = "No";
            this.NoBTN.UseVisualStyleBackColor = true;
            this.NoBTN.Click += new System.EventHandler(this.NoBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Are you sure you want to logout?";
            // 
            // LogoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 162);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoBTN);
            this.Controls.Add(this.yesBTN);
            this.Name = "LogoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logout";
            this.Load += new System.EventHandler(this.LogoutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesBTN;
        private System.Windows.Forms.Button NoBTN;
        private System.Windows.Forms.Label label2;
    }
}