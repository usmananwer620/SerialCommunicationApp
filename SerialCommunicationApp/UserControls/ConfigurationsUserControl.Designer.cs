namespace SerialCommunicationApp.UserControls
{
    partial class ConfigurationsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbRefreshTime = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveConfiguration = new DevExpress.XtraEditors.SimpleButton();
            this.lblUpdateSerialConfigurations = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmbBaudRates = new System.Windows.Forms.ComboBox();
            this.cmbAvailablePorts = new System.Windows.Forms.ComboBox();
            this.lblBaudRates = new DevExpress.XtraEditors.LabelControl();
            this.lblRefreshTime = new DevExpress.XtraEditors.LabelControl();
            this.lblComPorts = new DevExpress.XtraEditors.LabelControl();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbRefreshTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRefreshTime
            // 
            this.tbRefreshTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRefreshTime.Location = new System.Drawing.Point(178, 163);
            this.tbRefreshTime.Name = "tbRefreshTime";
            this.tbRefreshTime.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.tbRefreshTime.Properties.Appearance.Options.UseBackColor = true;
            this.tbRefreshTime.Properties.AutoHeight = false;
            this.tbRefreshTime.Size = new System.Drawing.Size(249, 21);
            this.tbRefreshTime.TabIndex = 2;
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveConfiguration.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveConfiguration.Appearance.Options.UseFont = true;
            this.btnSaveConfiguration.Location = new System.Drawing.Point(178, 210);
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.Size = new System.Drawing.Size(126, 33);
            this.btnSaveConfiguration.TabIndex = 3;
            this.btnSaveConfiguration.Text = "Save Configuration";
            this.btnSaveConfiguration.Click += new System.EventHandler(this.BtnSaveConfigurationClick);
            // 
            // lblUpdateSerialConfigurations
            // 
            this.lblUpdateSerialConfigurations.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblUpdateSerialConfigurations.Appearance.Options.UseFont = true;
            this.lblUpdateSerialConfigurations.Appearance.Options.UseTextOptions = true;
            this.lblUpdateSerialConfigurations.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUpdateSerialConfigurations.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblUpdateSerialConfigurations.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUpdateSerialConfigurations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpdateSerialConfigurations.Location = new System.Drawing.Point(2, 2);
            this.lblUpdateSerialConfigurations.Name = "lblUpdateSerialConfigurations";
            this.lblUpdateSerialConfigurations.Size = new System.Drawing.Size(559, 52);
            this.lblUpdateSerialConfigurations.TabIndex = 4;
            this.lblUpdateSerialConfigurations.Text = "Serial Configurations";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.cmbBaudRates);
            this.panelControl1.Controls.Add(this.cmbAvailablePorts);
            this.panelControl1.Controls.Add(this.lblBaudRates);
            this.panelControl1.Controls.Add(this.lblRefreshTime);
            this.panelControl1.Controls.Add(this.lblComPorts);
            this.panelControl1.Controls.Add(this.btnSaveConfiguration);
            this.panelControl1.Controls.Add(this.lblUpdateSerialConfigurations);
            this.panelControl1.Controls.Add(this.tbRefreshTime);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(563, 358);
            this.panelControl1.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(310, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // cmbBaudRates
            // 
            this.cmbBaudRates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaudRates.FormattingEnabled = true;
            this.cmbBaudRates.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.cmbBaudRates.Location = new System.Drawing.Point(178, 124);
            this.cmbBaudRates.Name = "cmbBaudRates";
            this.cmbBaudRates.Size = new System.Drawing.Size(249, 21);
            this.cmbBaudRates.TabIndex = 8;
            // 
            // cmbAvailablePorts
            // 
            this.cmbAvailablePorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAvailablePorts.FormattingEnabled = true;
            this.cmbAvailablePorts.Location = new System.Drawing.Point(178, 81);
            this.cmbAvailablePorts.Name = "cmbAvailablePorts";
            this.cmbAvailablePorts.Size = new System.Drawing.Size(249, 21);
            this.cmbAvailablePorts.TabIndex = 7;
            // 
            // lblBaudRates
            // 
            this.lblBaudRates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaudRates.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBaudRates.Appearance.Options.UseFont = true;
            this.lblBaudRates.Appearance.Options.UseTextOptions = true;
            this.lblBaudRates.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaudRates.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBaudRates.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblBaudRates.Location = new System.Drawing.Point(81, 127);
            this.lblBaudRates.Name = "lblBaudRates";
            this.lblBaudRates.Size = new System.Drawing.Size(67, 13);
            this.lblBaudRates.TabIndex = 6;
            this.lblBaudRates.Text = "Baud Rates:";
            // 
            // lblRefreshTime
            // 
            this.lblRefreshTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefreshTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRefreshTime.Appearance.Options.UseFont = true;
            this.lblRefreshTime.Appearance.Options.UseTextOptions = true;
            this.lblRefreshTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblRefreshTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblRefreshTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblRefreshTime.Location = new System.Drawing.Point(73, 166);
            this.lblRefreshTime.Name = "lblRefreshTime";
            this.lblRefreshTime.Size = new System.Drawing.Size(78, 13);
            this.lblRefreshTime.TabIndex = 6;
            this.lblRefreshTime.Text = "Refresh Time:";
            // 
            // lblComPorts
            // 
            this.lblComPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComPorts.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblComPorts.Appearance.Options.UseFont = true;
            this.lblComPorts.Appearance.Options.UseTextOptions = true;
            this.lblComPorts.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblComPorts.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblComPorts.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblComPorts.Location = new System.Drawing.Point(65, 84);
            this.lblComPorts.Name = "lblComPorts";
            this.lblComPorts.Size = new System.Drawing.Size(88, 13);
            this.lblComPorts.TabIndex = 5;
            this.lblComPorts.Text = "Available Ports:";
            // 
            // ConfigurationsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ConfigurationsUserControl";
            this.Size = new System.Drawing.Size(563, 358);
            this.Load += new System.EventHandler(this.MenuUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRefreshTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit tbRefreshTime;
        private DevExpress.XtraEditors.SimpleButton btnSaveConfiguration;
        private DevExpress.XtraEditors.LabelControl lblUpdateSerialConfigurations;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblBaudRates;
        private DevExpress.XtraEditors.LabelControl lblRefreshTime;
        private DevExpress.XtraEditors.LabelControl lblComPorts;
        private System.Windows.Forms.ComboBox cmbBaudRates;
        private System.Windows.Forms.ComboBox cmbAvailablePorts;
        private System.IO.Ports.SerialPort serialPort1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
