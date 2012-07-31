namespace CECRunningChart
{
    partial class EditProjectForm
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
            this.txtProjectDescription = new System.Windows.Forms.RichTextBox();
            this.txtProjectManager = new System.Windows.Forms.TextBox();
            this.lblProjectDescription = new System.Windows.Forms.Label();
            this.lblProjectManager = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.comProjects = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkDeactivate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtProjectDescription
            // 
            this.txtProjectDescription.Location = new System.Drawing.Point(126, 137);
            this.txtProjectDescription.Name = "txtProjectDescription";
            this.txtProjectDescription.Size = new System.Drawing.Size(226, 96);
            this.txtProjectDescription.TabIndex = 2;
            this.txtProjectDescription.Text = "";
            // 
            // txtProjectManager
            // 
            this.txtProjectManager.Location = new System.Drawing.Point(126, 83);
            this.txtProjectManager.MaxLength = 100;
            this.txtProjectManager.Name = "txtProjectManager";
            this.txtProjectManager.Size = new System.Drawing.Size(226, 20);
            this.txtProjectManager.TabIndex = 1;
            // 
            // lblProjectDescription
            // 
            this.lblProjectDescription.AutoSize = true;
            this.lblProjectDescription.Location = new System.Drawing.Point(16, 137);
            this.lblProjectDescription.Name = "lblProjectDescription";
            this.lblProjectDescription.Size = new System.Drawing.Size(96, 13);
            this.lblProjectDescription.TabIndex = 9;
            this.lblProjectDescription.Text = "Project Description";
            // 
            // lblProjectManager
            // 
            this.lblProjectManager.AutoSize = true;
            this.lblProjectManager.Location = new System.Drawing.Point(16, 83);
            this.lblProjectManager.Name = "lblProjectManager";
            this.lblProjectManager.Size = new System.Drawing.Size(85, 13);
            this.lblProjectManager.TabIndex = 8;
            this.lblProjectManager.Text = "Project Manager";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(16, 34);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(71, 13);
            this.lblProjectName.TabIndex = 7;
            this.lblProjectName.Text = "Project Name";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(19, 304);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Project";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(118, 304);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(93, 23);
            this.btnDeleteProject.TabIndex = 14;
            this.btnDeleteProject.Text = "Delete Project";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            // 
            // comProjects
            // 
            this.comProjects.FormattingEnabled = true;
            this.comProjects.Location = new System.Drawing.Point(126, 34);
            this.comProjects.Name = "comProjects";
            this.comProjects.Size = new System.Drawing.Size(226, 21);
            this.comProjects.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(217, 304);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(298, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // chkDeactivate
            // 
            this.chkDeactivate.AutoSize = true;
            this.chkDeactivate.Location = new System.Drawing.Point(126, 253);
            this.chkDeactivate.Name = "chkDeactivate";
            this.chkDeactivate.Size = new System.Drawing.Size(78, 17);
            this.chkDeactivate.TabIndex = 3;
            this.chkDeactivate.Text = "Deactivate";
            this.chkDeactivate.UseVisualStyleBackColor = true;
            // 
            // EditProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 350);
            this.Controls.Add(this.chkDeactivate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.comProjects);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtProjectDescription);
            this.Controls.Add(this.txtProjectManager);
            this.Controls.Add(this.lblProjectDescription);
            this.Controls.Add(this.lblProjectManager);
            this.Controls.Add(this.lblProjectName);
            this.Name = "EditProjectForm";
            this.Text = "EditProjectForm";
            this.Load += new System.EventHandler(this.EditProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtProjectDescription;
        private System.Windows.Forms.TextBox txtProjectManager;
        private System.Windows.Forms.Label lblProjectDescription;
        private System.Windows.Forms.Label lblProjectManager;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.ComboBox comProjects;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkDeactivate;
    }
}