namespace AccountManagerApp
{
    partial class EditSkillsForm
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
            this.addedSkillsLBL = new System.Windows.Forms.Label();
            this.existingSkillsLBL = new System.Windows.Forms.Label();
            this.DbSkillsLBX = new System.Windows.Forms.ListBox();
            this.removeSkillsBtn = new System.Windows.Forms.Button();
            this.addSkillsBtn = new System.Windows.Forms.Button();
            this.jobSkillsLBX = new System.Windows.Forms.ListBox();
            this.editAddSkillBTN = new System.Windows.Forms.Button();
            this.otherLBL = new System.Windows.Forms.Label();
            this.newSkilltxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.skillUpdateBtn = new System.Windows.Forms.Button();
            this.skillCloseBtn = new System.Windows.Forms.Button();
            this.editSkillErrorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addedSkillsLBL
            // 
            this.addedSkillsLBL.AutoSize = true;
            this.addedSkillsLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addedSkillsLBL.Location = new System.Drawing.Point(508, 109);
            this.addedSkillsLBL.Name = "addedSkillsLBL";
            this.addedSkillsLBL.Size = new System.Drawing.Size(68, 13);
            this.addedSkillsLBL.TabIndex = 43;
            this.addedSkillsLBL.Text = "Added Skills:";
            this.addedSkillsLBL.Click += new System.EventHandler(this.addedSkillsLBL_Click);
            // 
            // existingSkillsLBL
            // 
            this.existingSkillsLBL.AutoSize = true;
            this.existingSkillsLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.existingSkillsLBL.Location = new System.Drawing.Point(73, 108);
            this.existingSkillsLBL.Name = "existingSkillsLBL";
            this.existingSkillsLBL.Size = new System.Drawing.Size(73, 13);
            this.existingSkillsLBL.TabIndex = 42;
            this.existingSkillsLBL.Text = "Existing Skills:";
            this.existingSkillsLBL.Click += new System.EventHandler(this.existingSkillsLBL_Click);
            // 
            // DbSkillsLBX
            // 
            this.DbSkillsLBX.FormattingEnabled = true;
            this.DbSkillsLBX.Location = new System.Drawing.Point(76, 135);
            this.DbSkillsLBX.Name = "DbSkillsLBX";
            this.DbSkillsLBX.Size = new System.Drawing.Size(335, 134);
            this.DbSkillsLBX.TabIndex = 41;
            this.DbSkillsLBX.SelectedIndexChanged += new System.EventHandler(this.DbSkillsLBX_SelectedIndexChanged);
            // 
            // removeSkillsBtn
            // 
            this.removeSkillsBtn.Location = new System.Drawing.Point(418, 236);
            this.removeSkillsBtn.Name = "removeSkillsBtn";
            this.removeSkillsBtn.Size = new System.Drawing.Size(84, 23);
            this.removeSkillsBtn.TabIndex = 40;
            this.removeSkillsBtn.Text = "<< Remove";
            this.removeSkillsBtn.UseVisualStyleBackColor = true;
            this.removeSkillsBtn.Click += new System.EventHandler(this.removeSkillsBtn_Click);
            // 
            // addSkillsBtn
            // 
            this.addSkillsBtn.Location = new System.Drawing.Point(418, 147);
            this.addSkillsBtn.Name = "addSkillsBtn";
            this.addSkillsBtn.Size = new System.Drawing.Size(84, 23);
            this.addSkillsBtn.TabIndex = 39;
            this.addSkillsBtn.Text = "Add >>";
            this.addSkillsBtn.UseVisualStyleBackColor = true;
            this.addSkillsBtn.Click += new System.EventHandler(this.addSkillsBtn_Click);
            // 
            // jobSkillsLBX
            // 
            this.jobSkillsLBX.FormattingEnabled = true;
            this.jobSkillsLBX.Location = new System.Drawing.Point(508, 136);
            this.jobSkillsLBX.Name = "jobSkillsLBX";
            this.jobSkillsLBX.Size = new System.Drawing.Size(236, 134);
            this.jobSkillsLBX.TabIndex = 38;
            this.jobSkillsLBX.SelectedIndexChanged += new System.EventHandler(this.jobSkillsLBX_SelectedIndexChanged);
            // 
            // editAddSkillBTN
            // 
            this.editAddSkillBTN.Location = new System.Drawing.Point(336, 284);
            this.editAddSkillBTN.Name = "editAddSkillBTN";
            this.editAddSkillBTN.Size = new System.Drawing.Size(75, 23);
            this.editAddSkillBTN.TabIndex = 37;
            this.editAddSkillBTN.Text = "Add Skill";
            this.editAddSkillBTN.UseVisualStyleBackColor = true;
            this.editAddSkillBTN.Click += new System.EventHandler(this.editAddSkillBTN_Click);
            // 
            // otherLBL
            // 
            this.otherLBL.AutoSize = true;
            this.otherLBL.Location = new System.Drawing.Point(73, 287);
            this.otherLBL.Name = "otherLBL";
            this.otherLBL.Size = new System.Drawing.Size(72, 13);
            this.otherLBL.TabIndex = 36;
            this.otherLBL.Text = "Add new skill:";
            this.otherLBL.Click += new System.EventHandler(this.otherLBL_Click);
            // 
            // newSkilltxtBox
            // 
            this.newSkilltxtBox.Location = new System.Drawing.Point(157, 284);
            this.newSkilltxtBox.Name = "newSkilltxtBox";
            this.newSkilltxtBox.Size = new System.Drawing.Size(173, 20);
            this.newSkilltxtBox.TabIndex = 35;
            this.newSkilltxtBox.TextChanged += new System.EventHandler(this.newSkilltxtBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Skills";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(12, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 24);
            this.label13.TabIndex = 44;
            this.label13.Text = "Edit the Skills Below";
            // 
            // skillUpdateBtn
            // 
            this.skillUpdateBtn.Location = new System.Drawing.Point(508, 334);
            this.skillUpdateBtn.Name = "skillUpdateBtn";
            this.skillUpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.skillUpdateBtn.TabIndex = 45;
            this.skillUpdateBtn.Text = "Update";
            this.skillUpdateBtn.UseVisualStyleBackColor = true;
            this.skillUpdateBtn.Click += new System.EventHandler(this.skillUpdateBtn_Click);
            // 
            // skillCloseBtn
            // 
            this.skillCloseBtn.Location = new System.Drawing.Point(613, 333);
            this.skillCloseBtn.Name = "skillCloseBtn";
            this.skillCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.skillCloseBtn.TabIndex = 46;
            this.skillCloseBtn.Text = "Close";
            this.skillCloseBtn.UseVisualStyleBackColor = true;
            this.skillCloseBtn.Click += new System.EventHandler(this.skillCloseBtn_Click);
            // 
            // editSkillErrorLbl
            // 
            this.editSkillErrorLbl.AutoSize = true;
            this.editSkillErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.editSkillErrorLbl.Location = new System.Drawing.Point(76, 322);
            this.editSkillErrorLbl.Name = "editSkillErrorLbl";
            this.editSkillErrorLbl.Size = new System.Drawing.Size(101, 13);
            this.editSkillErrorLbl.TabIndex = 47;
            this.editSkillErrorLbl.Text = "updating skills failed";
            this.editSkillErrorLbl.Visible = false;
            this.editSkillErrorLbl.Click += new System.EventHandler(this.editSkillErrorLbl_Click);
            // 
            // EditSkillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(764, 372);
            this.Controls.Add(this.editSkillErrorLbl);
            this.Controls.Add(this.skillCloseBtn);
            this.Controls.Add(this.skillUpdateBtn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.addedSkillsLBL);
            this.Controls.Add(this.existingSkillsLBL);
            this.Controls.Add(this.DbSkillsLBX);
            this.Controls.Add(this.removeSkillsBtn);
            this.Controls.Add(this.addSkillsBtn);
            this.Controls.Add(this.jobSkillsLBX);
            this.Controls.Add(this.editAddSkillBTN);
            this.Controls.Add(this.otherLBL);
            this.Controls.Add(this.newSkilltxtBox);
            this.Controls.Add(this.label8);
            this.Name = "EditSkillsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSkillsform";
            this.Load += new System.EventHandler(this.EditSkillsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addedSkillsLBL;
        private System.Windows.Forms.Label existingSkillsLBL;
        private System.Windows.Forms.ListBox DbSkillsLBX;
        private System.Windows.Forms.Button removeSkillsBtn;
        private System.Windows.Forms.Button addSkillsBtn;
        private System.Windows.Forms.ListBox jobSkillsLBX;
        private System.Windows.Forms.Button editAddSkillBTN;
        private System.Windows.Forms.Label otherLBL;
        private System.Windows.Forms.TextBox newSkilltxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button skillUpdateBtn;
        private System.Windows.Forms.Button skillCloseBtn;
        private System.Windows.Forms.Label editSkillErrorLbl;
    }
}