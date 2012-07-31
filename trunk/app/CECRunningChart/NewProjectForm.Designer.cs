namespace CECRunningChart
{
    partial class NewProjectForm
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
            this.components = new System.ComponentModel.Container();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblProjectManager = new System.Windows.Forms.Label();
            this.lblProjectDescription = new System.Windows.Forms.Label();
            this.txtProjectManager = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtProjectDescription = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkDeactivate = new System.Windows.Forms.CheckBox();
            this.projectErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(12, 25);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(71, 13);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name";
            // 
            // lblProjectManager
            // 
            this.lblProjectManager.AutoSize = true;
            this.lblProjectManager.Location = new System.Drawing.Point(12, 74);
            this.lblProjectManager.Name = "lblProjectManager";
            this.lblProjectManager.Size = new System.Drawing.Size(85, 13);
            this.lblProjectManager.TabIndex = 1;
            this.lblProjectManager.Text = "Project Manager";
            // 
            // lblProjectDescription
            // 
            this.lblProjectDescription.AutoSize = true;
            this.lblProjectDescription.Location = new System.Drawing.Point(12, 128);
            this.lblProjectDescription.Name = "lblProjectDescription";
            this.lblProjectDescription.Size = new System.Drawing.Size(96, 13);
            this.lblProjectDescription.TabIndex = 2;
            this.lblProjectDescription.Text = "Project Description";
            // 
            // txtProjectManager
            // 
            this.txtProjectManager.Location = new System.Drawing.Point(122, 74);
            this.txtProjectManager.MaxLength = 100;
            this.txtProjectManager.Name = "txtProjectManager";
            this.txtProjectManager.Size = new System.Drawing.Size(226, 20);
            this.txtProjectManager.TabIndex = 1;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(122, 25);
            this.txtProjectName.MaxLength = 200;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(226, 20);
            this.txtProjectName.TabIndex = 0;
            // 
            // txtProjectDescription
            // 
            this.txtProjectDescription.Location = new System.Drawing.Point(122, 128);
            this.txtProjectDescription.Name = "txtProjectDescription";
            this.txtProjectDescription.Size = new System.Drawing.Size(226, 96);
            this.txtProjectDescription.TabIndex = 2;
            this.txtProjectDescription.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(123, 302);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Project";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(288, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkDeactivate
            // 
            this.chkDeactivate.AutoSize = true;
            this.chkDeactivate.Location = new System.Drawing.Point(122, 244);
            this.chkDeactivate.Name = "chkDeactivate";
            this.chkDeactivate.Size = new System.Drawing.Size(114, 17);
            this.chkDeactivate.TabIndex = 3;
            this.chkDeactivate.Text = "Deactivate Project";
            this.chkDeactivate.UseVisualStyleBackColor = true;
            // 
            // projectErrorProvider
            // 
            this.projectErrorProvider.ContainerControl = this;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(206, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 357);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkDeactivate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtProjectDescription);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.txtProjectManager);
            this.Controls.Add(this.lblProjectDescription);
            this.Controls.Add(this.lblProjectManager);
            this.Controls.Add(this.lblProjectName);
            this.Name = "NewProjectForm";
            this.Text = "New Project";
            ((System.ComponentModel.ISupportInitialize)(this.projectErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblProjectManager;
        private System.Windows.Forms.Label lblProjectDescription;
        private System.Windows.Forms.TextBox txtProjectManager;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.RichTextBox txtProjectDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkDeactivate;
        private System.Windows.Forms.ErrorProvider projectErrorProvider;
        private System.Windows.Forms.Button btnClear;
    }
}