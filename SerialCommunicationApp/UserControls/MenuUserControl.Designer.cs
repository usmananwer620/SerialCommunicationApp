namespace SerialCommunicationApp.UserControls
{
    partial class MenuUserControl
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
            this.btnUpdateConfiguration = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshService = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dataLbl = new DevExpress.XtraEditors.LabelControl();
            this.portResponseLbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateConfiguration
            // 
            this.btnUpdateConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateConfiguration.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdateConfiguration.Appearance.Options.UseFont = true;
            this.btnUpdateConfiguration.Location = new System.Drawing.Point(105, 146);
            this.btnUpdateConfiguration.Name = "btnUpdateConfiguration";
            this.btnUpdateConfiguration.Size = new System.Drawing.Size(226, 53);
            this.btnUpdateConfiguration.TabIndex = 2;
            this.btnUpdateConfiguration.Text = "Update Configuration";
            this.btnUpdateConfiguration.Click += new System.EventHandler(this.BtnUpdateConfigurationClick);
            // 
            // btnRefreshService
            // 
            this.btnRefreshService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshService.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefreshService.Appearance.Options.UseFont = true;
            this.btnRefreshService.Location = new System.Drawing.Point(105, 87);
            this.btnRefreshService.Name = "btnRefreshService";
            this.btnRefreshService.Size = new System.Drawing.Size(226, 53);
            this.btnRefreshService.TabIndex = 3;
            this.btnRefreshService.Text = "Refresh";
            this.btnRefreshService.Click += new System.EventHandler(this.BtnRefreshServiceClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.dataLbl);
            this.panelControl1.Controls.Add(this.portResponseLbl);
            this.panelControl1.Controls.Add(this.btnUpdateConfiguration);
            this.panelControl1.Controls.Add(this.btnRefreshService);
            this.panelControl1.Location = new System.Drawing.Point(3, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(419, 278);
            this.panelControl1.TabIndex = 4;
            // 
            // dataLbl
            // 
            this.dataLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.dataLbl.Appearance.Options.UseFont = true;
            this.dataLbl.Appearance.Options.UseTextOptions = true;
            this.dataLbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.dataLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataLbl.Location = new System.Drawing.Point(2, 2);
            this.dataLbl.Name = "dataLbl";
            this.dataLbl.Size = new System.Drawing.Size(415, 37);
            this.dataLbl.TabIndex = 5;
            this.dataLbl.Text = "Current Configuration Settings";
            // 
            // portResponseLbl
            // 
            this.portResponseLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.portResponseLbl.Appearance.Options.UseFont = true;
            this.portResponseLbl.Appearance.Options.UseTextOptions = true;
            this.portResponseLbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.portResponseLbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.portResponseLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.portResponseLbl.Location = new System.Drawing.Point(2, 241);
            this.portResponseLbl.Name = "portResponseLbl";
            this.portResponseLbl.Size = new System.Drawing.Size(415, 35);
            this.portResponseLbl.TabIndex = 4;
            // 
            // MenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "MenuUserControl";
            this.Size = new System.Drawing.Size(422, 281);
            this.Load += new System.EventHandler(this.MenuUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnUpdateConfiguration;
        private DevExpress.XtraEditors.SimpleButton btnRefreshService;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl portResponseLbl;
        public DevExpress.XtraEditors.LabelControl dataLbl;
    }
}
