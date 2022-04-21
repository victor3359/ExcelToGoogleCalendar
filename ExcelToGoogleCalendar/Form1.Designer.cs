
namespace ExcelToGoogleCalendar
{
    partial class ShinAnBan
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShinAnBan));
            this.LoadFile = new System.Windows.Forms.Button();
            this.LoadMessage = new System.Windows.Forms.Label();
            this.SyncToGoogle = new System.Windows.Forms.Button();
            this.Image_Cute = new System.Windows.Forms.PictureBox();
            this.LoadExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.ModifyDoctor = new System.Windows.Forms.Button();
            this.Image_ShinAnBan = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image_Cute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_ShinAnBan)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadFile
            // 
            this.LoadFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadFile.Location = new System.Drawing.Point(12, 12);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(125, 40);
            this.LoadFile.TabIndex = 0;
            this.LoadFile.Text = "讀取 EXCEL";
            this.LoadFile.UseVisualStyleBackColor = true;
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // LoadMessage
            // 
            this.LoadMessage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LoadMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoadMessage.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadMessage.Location = new System.Drawing.Point(12, 421);
            this.LoadMessage.Name = "LoadMessage";
            this.LoadMessage.Size = new System.Drawing.Size(318, 24);
            this.LoadMessage.TabIndex = 1;
            this.LoadMessage.Text = "騷鳥凱翔蹦蹦蹦還可以尿尿";
            // 
            // SyncToGoogle
            // 
            this.SyncToGoogle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SyncToGoogle.Location = new System.Drawing.Point(197, 12);
            this.SyncToGoogle.Name = "SyncToGoogle";
            this.SyncToGoogle.Size = new System.Drawing.Size(133, 40);
            this.SyncToGoogle.TabIndex = 5;
            this.SyncToGoogle.Text = "同步至 GOOGLE";
            this.SyncToGoogle.UseVisualStyleBackColor = true;
            this.SyncToGoogle.Click += new System.EventHandler(this.SyncToGoogle_Click);
            // 
            // Image_Cute
            // 
            this.Image_Cute.Image = ((System.Drawing.Image)(resources.GetObject("Image_Cute.Image")));
            this.Image_Cute.InitialImage = ((System.Drawing.Image)(resources.GetObject("Image_Cute.InitialImage")));
            this.Image_Cute.Location = new System.Drawing.Point(12, 121);
            this.Image_Cute.Name = "Image_Cute";
            this.Image_Cute.Size = new System.Drawing.Size(221, 297);
            this.Image_Cute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image_Cute.TabIndex = 6;
            this.Image_Cute.TabStop = false;
            this.Image_Cute.WaitOnLoad = true;
            // 
            // LoadExcelDialog
            // 
            this.LoadExcelDialog.FileName = "LoadExcelDialog";
            this.LoadExcelDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            // 
            // ModifyDoctor
            // 
            this.ModifyDoctor.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModifyDoctor.Location = new System.Drawing.Point(12, 75);
            this.ModifyDoctor.Name = "ModifyDoctor";
            this.ModifyDoctor.Size = new System.Drawing.Size(125, 40);
            this.ModifyDoctor.TabIndex = 7;
            this.ModifyDoctor.Text = "治療師對應表";
            this.ModifyDoctor.UseVisualStyleBackColor = true;
            this.ModifyDoctor.Click += new System.EventHandler(this.ModifyDoctor_Click);
            // 
            // Image_ShinAnBan
            // 
            this.Image_ShinAnBan.Image = ((System.Drawing.Image)(resources.GetObject("Image_ShinAnBan.Image")));
            this.Image_ShinAnBan.InitialImage = ((System.Drawing.Image)(resources.GetObject("Image_ShinAnBan.InitialImage")));
            this.Image_ShinAnBan.Location = new System.Drawing.Point(212, 121);
            this.Image_ShinAnBan.Name = "Image_ShinAnBan";
            this.Image_ShinAnBan.Size = new System.Drawing.Size(118, 146);
            this.Image_ShinAnBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image_ShinAnBan.TabIndex = 8;
            this.Image_ShinAnBan.TabStop = false;
            this.Image_ShinAnBan.WaitOnLoad = true;
            // 
            // ShinAnBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(342, 452);
            this.Controls.Add(this.Image_ShinAnBan);
            this.Controls.Add(this.ModifyDoctor);
            this.Controls.Add(this.Image_Cute);
            this.Controls.Add(this.SyncToGoogle);
            this.Controls.Add(this.LoadMessage);
            this.Controls.Add(this.LoadFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShinAnBan";
            this.Text = "溫馨安邦驚弓之鳥";
            ((System.ComponentModel.ISupportInitialize)(this.Image_Cute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_ShinAnBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadFile;
        private System.Windows.Forms.Label LoadMessage;
        private System.Windows.Forms.Button SyncToGoogle;
        private System.Windows.Forms.PictureBox Image_Cute;
        private System.Windows.Forms.OpenFileDialog LoadExcelDialog;
        private System.Windows.Forms.Button ModifyDoctor;
        private System.Windows.Forms.PictureBox Image_ShinAnBan;
    }
}

