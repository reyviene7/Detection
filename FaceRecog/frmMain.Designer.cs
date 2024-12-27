using DevExpress.XtraEditors;

namespace FaceRecog
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtID = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.processImg = new System.Windows.Forms.PictureBox();
            this.bntDelete = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDelete = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bntWebCamera = new DevExpress.XtraEditors.SimpleButton();
            this.bntHdCamera = new DevExpress.XtraEditors.SimpleButton();
            this.bntIpCamera = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bntClear = new DevExpress.XtraEditors.SimpleButton();
            this.bntRegister = new DevExpress.XtraEditors.SimpleButton();
            this.bntLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.splashManager = new DevExpress.XtraSplashScreen.SplashScreenManager();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(1167, 6);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(181, 22);
            this.txtID.TabIndex = 4;
            this.txtID.Text = "0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(70, 17);
            this.tslStatus.Text = "Initializing...";
            // 
            // imgBox
            // 
            this.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox.Location = new System.Drawing.Point(9, 6);
            this.imgBox.Margin = new System.Windows.Forms.Padding(2);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(1070, 578);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox.TabIndex = 9;
            this.imgBox.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(1021, -24);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(8, 26);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "Jame Bond";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1086, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Person Id:";
            // 
            // processImg
            // 
            this.processImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processImg.Image = global::FaceRecog.Properties.Resources.who;
            this.processImg.Location = new System.Drawing.Point(1081, 299);
            this.processImg.Margin = new System.Windows.Forms.Padding(2);
            this.processImg.Name = "processImg";
            this.processImg.Size = new System.Drawing.Size(267, 224);
            this.processImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.processImg.TabIndex = 14;
            this.processImg.TabStop = false;
            // 
            // bntDelete
            // 
            this.bntDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDelete.Location = new System.Drawing.Point(13, 35);
            this.bntDelete.Margin = new System.Windows.Forms.Padding(2);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(237, 31);
            this.bntDelete.TabIndex = 20;
            this.bntDelete.Text = "Delete User";
            this.bntDelete.UseVisualStyleBackColor = true;
            this.bntDelete.Click += new System.EventHandler(this.bntDelete_Click);
            // 
            // outputBox
            // 
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.Location = new System.Drawing.Point(9, 589);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(683, 65);
            this.outputBox.TabIndex = 13;
            this.outputBox.Text = "";
            // 
            // panelControl
            // 
            this.panelControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl.Location = new System.Drawing.Point(1081, 33);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(267, 224);
            this.panelControl.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.cmbDelete);
            this.panel1.Controls.Add(this.bntDelete);
            this.panel1.Location = new System.Drawing.Point(1080, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 70);
            this.panel1.TabIndex = 24;
            // 
            // cmbDelete
            // 
            this.cmbDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelete.FormattingEnabled = true;
            this.cmbDelete.Location = new System.Drawing.Point(13, 3);
            this.cmbDelete.Name = "cmbDelete";
            this.cmbDelete.Size = new System.Drawing.Size(237, 32);
            this.cmbDelete.TabIndex = 21;
            this.cmbDelete.SelectedIndexChanged += new System.EventHandler(this.cmbDelete_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.bntWebCamera);
            this.panel2.Controls.Add(this.bntHdCamera);
            this.panel2.Controls.Add(this.bntIpCamera);
            this.panel2.Location = new System.Drawing.Point(694, 589);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 65);
            this.panel2.TabIndex = 26;
            // 
            // bntWebCamera
            // 
            this.bntWebCamera.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntWebCamera.Appearance.Options.UseFont = true;
            this.bntWebCamera.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntWebCamera.Enabled = false;
            this.bntWebCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntWebCamera.ImageOptions.Image")));
            this.bntWebCamera.Location = new System.Drawing.Point(237, 12);
            this.bntWebCamera.Name = "bntWebCamera";
            this.bntWebCamera.Size = new System.Drawing.Size(128, 40);
            this.bntWebCamera.TabIndex = 20;
            this.bntWebCamera.Text = "WEB Camera";
            this.bntWebCamera.Click += new System.EventHandler(this.bntWebCamera_Click);
            // 
            // bntHdCamera
            // 
            this.bntHdCamera.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHdCamera.Appearance.Options.UseFont = true;
            this.bntHdCamera.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntHdCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntHdCamera.ImageOptions.Image")));
            this.bntHdCamera.Location = new System.Drawing.Point(123, 12);
            this.bntHdCamera.Name = "bntHdCamera";
            this.bntHdCamera.Size = new System.Drawing.Size(108, 40);
            this.bntHdCamera.TabIndex = 19;
            this.bntHdCamera.Text = "HD Camera";
            this.bntHdCamera.Click += new System.EventHandler(this.bntHdCamera_Click);
            // 
            // bntIpCamera
            // 
            this.bntIpCamera.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntIpCamera.Appearance.Options.UseFont = true;
            this.bntIpCamera.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntIpCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntIpCamera.ImageOptions.Image")));
            this.bntIpCamera.Location = new System.Drawing.Point(9, 12);
            this.bntIpCamera.Name = "bntIpCamera";
            this.bntIpCamera.Size = new System.Drawing.Size(108, 40);
            this.bntIpCamera.TabIndex = 18;
            this.bntIpCamera.Text = "IP Camera";
            this.bntIpCamera.Click += new System.EventHandler(this.bntIpCamera_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Controls.Add(this.bntClear);
            this.panel3.Controls.Add(this.bntRegister);
            this.panel3.Location = new System.Drawing.Point(1080, 592);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 77);
            this.panel3.TabIndex = 27;
            // 
            // bntClear
            // 
            this.bntClear.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntClear.Appearance.Options.UseFont = true;
            this.bntClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntClear.Location = new System.Drawing.Point(13, 36);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(237, 30);
            this.bntClear.TabIndex = 30;
            this.bntClear.Text = "Clear Entries";
            this.bntClear.Click += new System.EventHandler(this.bntClear_Click);
            // 
            // bntRegister
            // 
            this.bntRegister.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntRegister.Appearance.Options.UseFont = true;
            this.bntRegister.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntRegister.Location = new System.Drawing.Point(13, 4);
            this.bntRegister.Name = "bntRegister";
            this.bntRegister.Size = new System.Drawing.Size(237, 30);
            this.bntRegister.TabIndex = 29;
            this.bntRegister.Text = "Register Face";
            this.bntRegister.Click += new System.EventHandler(this.bntRegister_Click);
            // 
            // bntLoadData
            // 
            this.bntLoadData.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntLoadData.Appearance.Options.UseFont = true;
            this.bntLoadData.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntLoadData.Location = new System.Drawing.Point(1081, 258);
            this.bntLoadData.Name = "bntLoadData";
            this.bntLoadData.Size = new System.Drawing.Size(267, 40);
            this.bntLoadData.TabIndex = 28;
            this.bntLoadData.Text = "Load Data";
            this.bntLoadData.Click += new System.EventHandler(this.bntLoadData_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton1.Location = new System.Drawing.Point(13, 4);
            this.simpleButton1.Name = "bntRegister";
            this.simpleButton1.Size = new System.Drawing.Size(326, 49);
            this.simpleButton1.TabIndex = 29;
            this.simpleButton1.Text = "Register Face";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1350, 681);
            this.Controls.Add(this.bntLoadData);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.processImg);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtID);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox processImg;
        private System.Windows.Forms.Button bntDelete;
        private System.Windows.Forms.RichTextBox outputBox;
        private DevExpress.XtraEditors.PanelControl panelControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private SimpleButton bntIpCamera;
        private DevExpress.XtraSplashScreen.SplashScreenManager splash;
        private SimpleButton bntWebCamera;
        private SimpleButton bntHdCamera;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbDelete;
        private SimpleButton bntLoadData;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashManager;
        private SimpleButton bntRegister;
        private SimpleButton bntClear;
        private SimpleButton simpleButton1;
    }
}

