namespace CECRunningChart
{
    partial class NewPumpStationForm
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
            this.lblPumpStationName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPumpStationName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.btnAddPumpStation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPumpStationName
            // 
            this.lblPumpStationName.AutoSize = true;
            this.lblPumpStationName.Location = new System.Drawing.Point(21, 28);
            this.lblPumpStationName.Name = "lblPumpStationName";
            this.lblPumpStationName.Size = new System.Drawing.Size(101, 13);
            this.lblPumpStationName.TabIndex = 0;
            this.lblPumpStationName.Text = "Pump Station Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(21, 84);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // txtPumpStationName
            // 
            this.txtPumpStationName.Location = new System.Drawing.Point(128, 28);
            this.txtPumpStationName.Name = "txtPumpStationName";
            this.txtPumpStationName.Size = new System.Drawing.Size(264, 20);
            this.txtPumpStationName.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(128, 81);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(264, 96);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "";
            // 
            // btnAddPumpStation
            // 
            this.btnAddPumpStation.Location = new System.Drawing.Point(289, 205);
            this.btnAddPumpStation.Name = "btnAddPumpStation";
            this.btnAddPumpStation.Size = new System.Drawing.Size(103, 23);
            this.btnAddPumpStation.TabIndex = 4;
            this.btnAddPumpStation.Text = "Add Pump Station";
            this.btnAddPumpStation.UseVisualStyleBackColor = true;
            // 
            // NewPumpStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 266);
            this.Controls.Add(this.btnAddPumpStation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPumpStationName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPumpStationName);
            this.Name = "NewPumpStationForm";
            this.Text = "New Pump Station";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPumpStationName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtPumpStationName;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Button btnAddPumpStation;
    }
}