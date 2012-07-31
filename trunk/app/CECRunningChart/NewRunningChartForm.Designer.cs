namespace CECRunningChart
{
    partial class NewRunningChartForm
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
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVehicleNumber = new System.Windows.Forms.Label();
            this.lblFuelLeft = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.comVehicleNumber = new System.Windows.Forms.ComboBox();
            this.txtFuelLeft = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.comProject = new System.Windows.Forms.ComboBox();
            this.comDriver = new System.Windows.Forms.ComboBox();
            this.lblDriver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Location = new System.Drawing.Point(8, 9);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(60, 13);
            this.lblBillNumber.TabIndex = 0;
            this.lblBillNumber.Text = "Bill Number";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(8, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // lblVehicleNumber
            // 
            this.lblVehicleNumber.AutoSize = true;
            this.lblVehicleNumber.Location = new System.Drawing.Point(259, 97);
            this.lblVehicleNumber.Name = "lblVehicleNumber";
            this.lblVehicleNumber.Size = new System.Drawing.Size(82, 13);
            this.lblVehicleNumber.TabIndex = 2;
            this.lblVehicleNumber.Text = "Vehicle Number";
            // 
            // lblFuelLeft
            // 
            this.lblFuelLeft.AutoSize = true;
            this.lblFuelLeft.Location = new System.Drawing.Point(37, 223);
            this.lblFuelLeft.Name = "lblFuelLeft";
            this.lblFuelLeft.Size = new System.Drawing.Size(48, 13);
            this.lblFuelLeft.TabIndex = 3;
            this.lblFuelLeft.Text = "Fuel Left";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.AutoSize = true;
            this.txtBillNumber.Location = new System.Drawing.Point(109, 9);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(35, 13);
            this.txtBillNumber.TabIndex = 4;
            this.txtBillNumber.Text = "label1";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Location = new System.Drawing.Point(109, 35);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(35, 13);
            this.txtDate.TabIndex = 5;
            this.txtDate.Text = "label2";
            // 
            // comVehicleNumber
            // 
            this.comVehicleNumber.FormattingEnabled = true;
            this.comVehicleNumber.Location = new System.Drawing.Point(363, 94);
            this.comVehicleNumber.Name = "comVehicleNumber";
            this.comVehicleNumber.Size = new System.Drawing.Size(121, 21);
            this.comVehicleNumber.TabIndex = 6;
            // 
            // txtFuelLeft
            // 
            this.txtFuelLeft.Location = new System.Drawing.Point(141, 223);
            this.txtFuelLeft.Name = "txtFuelLeft";
            this.txtFuelLeft.Size = new System.Drawing.Size(121, 20);
            this.txtFuelLeft.TabIndex = 7;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(306, 9);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 8;
            this.lblProject.Text = "Project";
            // 
            // comProject
            // 
            this.comProject.FormattingEnabled = true;
            this.comProject.Location = new System.Drawing.Point(361, 9);
            this.comProject.Name = "comProject";
            this.comProject.Size = new System.Drawing.Size(121, 21);
            this.comProject.TabIndex = 9;
            // 
            // comDriver
            // 
            this.comDriver.FormattingEnabled = true;
            this.comDriver.Location = new System.Drawing.Point(361, 52);
            this.comDriver.Name = "comDriver";
            this.comDriver.Size = new System.Drawing.Size(121, 21);
            this.comDriver.TabIndex = 10;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(306, 57);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(35, 13);
            this.lblDriver.TabIndex = 11;
            this.lblDriver.Text = "Driver";
            // 
            // NewRunningChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 447);
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.comDriver);
            this.Controls.Add(this.comProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.txtFuelLeft);
            this.Controls.Add(this.comVehicleNumber);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtBillNumber);
            this.Controls.Add(this.lblFuelLeft);
            this.Controls.Add(this.lblVehicleNumber);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblBillNumber);
            this.Name = "NewRunningChartForm";
            this.Text = "Daily Running Chart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVehicleNumber;
        private System.Windows.Forms.Label lblFuelLeft;
        private System.Windows.Forms.Label txtBillNumber;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.ComboBox comVehicleNumber;
        private System.Windows.Forms.TextBox txtFuelLeft;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox comProject;
        private System.Windows.Forms.ComboBox comDriver;
        private System.Windows.Forms.Label lblDriver;
    }
}