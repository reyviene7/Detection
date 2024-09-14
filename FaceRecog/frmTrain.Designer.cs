namespace FaceRecog
{
    partial class frmTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrain));
            this.txtID = new System.Windows.Forms.TextBox();
            this.processImg = new System.Windows.Forms.PictureBox();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.bntWebCamera = new DevExpress.XtraEditors.SimpleButton();
            this.bntHdCamera = new DevExpress.XtraEditors.SimpleButton();
            this.bntIpCamera = new DevExpress.XtraEditors.SimpleButton();
            this.bntTrain = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.processImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(1572, 12);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(349, 26);
            this.txtID.TabIndex = 11;
            this.txtID.Text = "0";
            // 
            // processImg
            // 
            this.processImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processImg.Image = global::FaceRecog.Properties.Resources.who;
            this.processImg.Location = new System.Drawing.Point(1573, 97);
            this.processImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.processImg.Name = "processImg";
            this.processImg.Size = new System.Drawing.Size(348, 406);
            this.processImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.processImg.TabIndex = 15;
            this.processImg.TabStop = false;
            // 
            // imgBox
            // 
            this.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox.Location = new System.Drawing.Point(11, 11);
            this.imgBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(1559, 932);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox.TabIndex = 10;
            this.imgBox.TabStop = false;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(1572, 508);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(348, 276);
            this.outputBox.TabIndex = 16;
            this.outputBox.Text = "";
            // 
            // bntWebCamera
            // 
            this.bntWebCamera.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntWebCamera.Appearance.Options.UseFont = true;
            this.bntWebCamera.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntWebCamera.Enabled = false;
            this.bntWebCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntWebCamera.ImageOptions.Image")));
            this.bntWebCamera.Location = new System.Drawing.Point(1572, 894);
            this.bntWebCamera.Name = "bntWebCamera";
            this.bntWebCamera.Size = new System.Drawing.Size(349, 49);
            this.bntWebCamera.TabIndex = 20;
            this.bntWebCamera.Text = "WEB Camera";
    
            // 
            // bntHdCamera
            // 
            this.bntHdCamera.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntHdCamera.Appearance.Options.UseFont = true;
            this.bntHdCamera.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntHdCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntHdCamera.ImageOptions.Image")));
            this.bntHdCamera.Location = new System.Drawing.Point(1572, 842);
            this.bntHdCamera.Name = "bntHdCamera";
            this.bntHdCamera.Size = new System.Drawing.Size(349, 49);
            this.bntHdCamera.TabIndex = 19;
            this.bntHdCamera.Text = "HD Camera";
 
            // 
            // bntIpCamera
            // 
            this.bntIpCamera.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntIpCamera.Appearance.Options.UseFont = true;
            this.bntIpCamera.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntIpCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntIpCamera.ImageOptions.Image")));
            this.bntIpCamera.Location = new System.Drawing.Point(1572, 790);
            this.bntIpCamera.Name = "bntIpCamera";
            this.bntIpCamera.Size = new System.Drawing.Size(349, 49);
            this.bntIpCamera.TabIndex = 18;
            this.bntIpCamera.Text = "IP Camera";
           
            // 
            // bntTrain
            // 
            this.bntTrain.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntTrain.Appearance.Options.UseFont = true;
            this.bntTrain.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.bntTrain.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntTrain.ImageOptions.Image")));
            this.bntTrain.Location = new System.Drawing.Point(1572, 43);
            this.bntTrain.Name = "bntTrain";
            this.bntTrain.Size = new System.Drawing.Size(349, 49);
            this.bntTrain.TabIndex = 28;
            this.bntTrain.Text = "Train Faces";
            this.bntTrain.Click += new System.EventHandler(this.bntTrain_Click);
            // 
            // frmTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 983);
            this.Controls.Add(this.bntTrain);
            this.Controls.Add(this.bntWebCamera);
            this.Controls.Add(this.bntHdCamera);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.bntIpCamera);
            this.Controls.Add(this.processImg);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.imgBox);
            this.Name = "frmTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      
            this.Load += new System.EventHandler(this.frmTrain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.processImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.PictureBox processImg;
        private System.Windows.Forms.RichTextBox outputBox;
        private DevExpress.XtraEditors.SimpleButton bntWebCamera;
        private DevExpress.XtraEditors.SimpleButton bntHdCamera;
        private DevExpress.XtraEditors.SimpleButton bntIpCamera;
        private DevExpress.XtraEditors.SimpleButton bntTrain;
    }
}