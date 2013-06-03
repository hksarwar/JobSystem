namespace AccountManagerApp
{
    partial class EmailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectBX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.attachmentBX = new System.Windows.Forms.TextBox();
            this.senderLBL = new System.Windows.Forms.Label();
            this.recipientLBL = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.bodyBX = new System.Windows.Forms.TextBox();
            this.sendEmailBTN = new System.Windows.Forms.Button();
            this.messageEmail = new System.Windows.Forms.Label();
            this.closeEmailBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Subject:";
            // 
            // subjectBX
            // 
            this.subjectBX.Location = new System.Drawing.Point(87, 95);
            this.subjectBX.Name = "subjectBX";
            this.subjectBX.Size = new System.Drawing.Size(534, 20);
            this.subjectBX.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Attachments:";
            // 
            // attachmentBX
            // 
            this.attachmentBX.Location = new System.Drawing.Point(87, 123);
            this.attachmentBX.Name = "attachmentBX";
            this.attachmentBX.Size = new System.Drawing.Size(534, 20);
            this.attachmentBX.TabIndex = 7;
            // 
            // senderLBL
            // 
            this.senderLBL.AutoSize = true;
            this.senderLBL.Location = new System.Drawing.Point(84, 48);
            this.senderLBL.Name = "senderLBL";
            this.senderLBL.Size = new System.Drawing.Size(35, 13);
            this.senderLBL.TabIndex = 8;
            this.senderLBL.Text = "label5";
            // 
            // recipientLBL
            // 
            this.recipientLBL.AutoSize = true;
            this.recipientLBL.Location = new System.Drawing.Point(84, 70);
            this.recipientLBL.Name = "recipientLBL";
            this.recipientLBL.Size = new System.Drawing.Size(35, 13);
            this.recipientLBL.TabIndex = 9;
            this.recipientLBL.Text = "label5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label14.Location = new System.Drawing.Point(10, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 25);
            this.label14.TabIndex = 22;
            this.label14.Text = "Send Email";
            // 
            // bodyBX
            // 
            this.bodyBX.Location = new System.Drawing.Point(12, 149);
            this.bodyBX.Multiline = true;
            this.bodyBX.Name = "bodyBX";
            this.bodyBX.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bodyBX.Size = new System.Drawing.Size(609, 321);
            this.bodyBX.TabIndex = 23;
            // 
            // sendEmailBTN
            // 
            this.sendEmailBTN.Location = new System.Drawing.Point(546, 476);
            this.sendEmailBTN.Name = "sendEmailBTN";
            this.sendEmailBTN.Size = new System.Drawing.Size(75, 23);
            this.sendEmailBTN.TabIndex = 24;
            this.sendEmailBTN.Text = "Send";
            this.sendEmailBTN.UseVisualStyleBackColor = true;
            this.sendEmailBTN.Click += new System.EventHandler(this.sendEmailBTN_Click);
            // 
            // messageEmail
            // 
            this.messageEmail.AutoSize = true;
            this.messageEmail.Location = new System.Drawing.Point(12, 481);
            this.messageEmail.Name = "messageEmail";
            this.messageEmail.Size = new System.Drawing.Size(35, 13);
            this.messageEmail.TabIndex = 25;
            this.messageEmail.Text = "label5";
            // 
            // closeEmailBTN
            // 
            this.closeEmailBTN.Location = new System.Drawing.Point(546, 477);
            this.closeEmailBTN.Name = "closeEmailBTN";
            this.closeEmailBTN.Size = new System.Drawing.Size(75, 23);
            this.closeEmailBTN.TabIndex = 26;
            this.closeEmailBTN.Text = "Close";
            this.closeEmailBTN.UseVisualStyleBackColor = true;
            this.closeEmailBTN.Click += new System.EventHandler(this.closeEmailBTN_Click);
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 511);
            this.Controls.Add(this.closeEmailBTN);
            this.Controls.Add(this.messageEmail);
            this.Controls.Add(this.sendEmailBTN);
            this.Controls.Add(this.bodyBX);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.recipientLBL);
            this.Controls.Add(this.senderLBL);
            this.Controls.Add(this.attachmentBX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subjectBX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmailForm";
            this.Text = "Send Email";
            this.Load += new System.EventHandler(this.EmailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subjectBX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox attachmentBX;
        private System.Windows.Forms.Label senderLBL;
        private System.Windows.Forms.Label recipientLBL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox bodyBX;
        private System.Windows.Forms.Button sendEmailBTN;
        private System.Windows.Forms.Label messageEmail;
        private System.Windows.Forms.Button closeEmailBTN;
    }
}