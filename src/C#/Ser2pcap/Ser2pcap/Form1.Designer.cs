namespace Ser2pcap
{
    partial class FormSer2pcap
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
            this.Combox_Pro_Sel = new System.Windows.Forms.ComboBox();
            this.BthHelp = new System.Windows.Forms.Button();
            this.BtnConvert = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Combox_Pro_Sel
            // 
            this.Combox_Pro_Sel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combox_Pro_Sel.FormattingEnabled = true;
            this.Combox_Pro_Sel.Items.AddRange(new object[] {
            "DNP 3.0 @20000",
            "IEC 104 @2404",
            "IEC 61850  @102",
            "Modbus TCP @502",
            "IEC 101 @22401",
            "IEC 103 @22403"});
            this.Combox_Pro_Sel.Location = new System.Drawing.Point(37, 52);
            this.Combox_Pro_Sel.Name = "Combox_Pro_Sel";
            this.Combox_Pro_Sel.Size = new System.Drawing.Size(244, 23);
            this.Combox_Pro_Sel.TabIndex = 0;
            // 
            // BthHelp
            // 
            this.BthHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BthHelp.Location = new System.Drawing.Point(37, 130);
            this.BthHelp.Name = "BthHelp";
            this.BthHelp.Size = new System.Drawing.Size(109, 32);
            this.BthHelp.TabIndex = 1;
            this.BthHelp.Text = "Help";
            this.BthHelp.UseVisualStyleBackColor = true;
            // 
            // BtnConvert
            // 
            this.BtnConvert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConvert.Location = new System.Drawing.Point(172, 130);
            this.BtnConvert.Name = "BtnConvert";
            this.BtnConvert.Size = new System.Drawing.Size(109, 32);
            this.BtnConvert.TabIndex = 2;
            this.BtnConvert.Text = "Convert";
            this.BtnConvert.UseVisualStyleBackColor = true;
            this.BtnConvert.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 183);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(325, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "Waiting for selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please select protocol or enter a port number:";
            // 
            // FormSer2pcap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnConvert);
            this.Controls.Add(this.BthHelp);
            this.Controls.Add(this.Combox_Pro_Sel);
            this.Name = "FormSer2pcap";
            this.Text = "Ser2pcap";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Combox_Pro_Sel;
        private System.Windows.Forms.Button BthHelp;
        private System.Windows.Forms.Button BtnConvert;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
    }
}

