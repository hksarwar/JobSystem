namespace AccountManagerApp
{
    partial class ChangePwdForm
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
            this.cancelBTN = new System.Windows.Forms.Button();
            this.changePwdBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.txtBoxNewPass = new System.Windows.Forms.TextBox();
            this.txtBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(12, 131);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 0;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // changePwdBTN
            // 
            this.changePwdBTN.Location = new System.Drawing.Point(146, 131);
            this.changePwdBTN.Name = "changePwdBTN";
            this.changePwdBTN.Size = new System.Drawing.Size(143, 23);
            this.changePwdBTN.TabIndex = 1;
            this.changePwdBTN.Text = "Change Password";
            this.changePwdBTN.UseVisualStyleBackColor = true;
            this.changePwdBTN.Click += new System.EventHandler(this.changePwdBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter a new password below:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm new password:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(54, 112);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 13);
            this.lbl.TabIndex = 7;
            // 
            // txtBoxNewPass
            // 
            this.txtBoxNewPass.Location = new System.Drawing.Point(146, 41);
            this.txtBoxNewPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxNewPass.Name = "txtBoxNewPass";
            this.txtBoxNewPass.Size = new System.Drawing.Size(143, 20);
            this.txtBoxNewPass.TabIndex = 8;
            // 
            // txtBoxConfirmPass
            // 
            this.txtBoxConfirmPass.Location = new System.Drawing.Point(145, 85);
            this.txtBoxConfirmPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxConfirmPass.Name = "txtBoxConfirmPass";
            this.txtBoxConfirmPass.Size = new System.Drawing.Size(143, 20);
            this.txtBoxConfirmPass.TabIndex = 9;
            // 
            // ChangePwdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 168);
            this.Controls.Add(this.txtBoxConfirmPass);
            this.Controls.Add(this.txtBoxNewPass);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changePwdBTN);
            this.Controls.Add(this.cancelBTN);
            this.Name = "ChangePwdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgotten Password";
            this.Load += new System.EventHandler(this.ForgottenPwdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.Button changePwdBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtBoxNewPass;
        private System.Windows.Forms.TextBox txtBoxConfirmPass;
    }
}