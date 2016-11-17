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
            this.BtnConvert = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_select_protocol = new System.Windows.Forms.Label();
            this.Label_text2pcap = new System.Windows.Forms.Label();
            this.TextBox_Text2pcap = new System.Windows.Forms.TextBox();
            this.Btn_Select_text2pcap = new System.Windows.Forms.Button();
            this.Btn_Select_capture = new System.Windows.Forms.Button();
            this.TextBox_file = new System.Windows.Forms.TextBox();
            this.Label_select_file = new System.Windows.Forms.Label();
            this.Label_arrow_text2pcap = new System.Windows.Forms.Label();
            this.Label_arror_select_file = new System.Windows.Forms.Label();
            this.Label_arrow_select_protocol = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Combox_Pro_Sel
            // 
            this.Combox_Pro_Sel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combox_Pro_Sel.FormattingEnabled = true;
            this.Combox_Pro_Sel.Items.AddRange(new object[] {
            "DNP3.0 @20000",
            "IEC101 @22401",
            "IEC103 @22403",
            "IEC104 @2404",
            "IEC61850  @102",
            "Modbus TCP @502",
            "SEL Cmd@22423",
            "SEL FM@23"});
            this.Combox_Pro_Sel.Location = new System.Drawing.Point(37, 184);
            this.Combox_Pro_Sel.Name = "Combox_Pro_Sel";
            this.Combox_Pro_Sel.Size = new System.Drawing.Size(244, 23);
            this.Combox_Pro_Sel.TabIndex = 4;
            // 
            // BtnConvert
            // 
            this.BtnConvert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConvert.Location = new System.Drawing.Point(239, 248);
            this.BtnConvert.Name = "BtnConvert";
            this.BtnConvert.Size = new System.Drawing.Size(109, 32);
            this.BtnConvert.TabIndex = 5;
            this.BtnConvert.Text = "Convert";
            this.BtnConvert.UseVisualStyleBackColor = true;
            this.BtnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(371, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "Waiting for selection";
            // 
            // Label_select_protocol
            // 
            this.Label_select_protocol.AutoSize = true;
            this.Label_select_protocol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_select_protocol.Location = new System.Drawing.Point(34, 165);
            this.Label_select_protocol.Name = "Label_select_protocol";
            this.Label_select_protocol.Size = new System.Drawing.Size(247, 15);
            this.Label_select_protocol.TabIndex = 4;
            this.Label_select_protocol.Text = "Please select protocol or enter a port number:";
            // 
            // Label_text2pcap
            // 
            this.Label_text2pcap.AutoSize = true;
            this.Label_text2pcap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_text2pcap.Location = new System.Drawing.Point(34, 40);
            this.Label_text2pcap.Name = "Label_text2pcap";
            this.Label_text2pcap.Size = new System.Drawing.Size(135, 15);
            this.Label_text2pcap.TabIndex = 5;
            this.Label_text2pcap.Text = "Looking for Text2pcap:";
            // 
            // TextBox_Text2pcap
            // 
            this.TextBox_Text2pcap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Text2pcap.Location = new System.Drawing.Point(37, 58);
            this.TextBox_Text2pcap.Name = "TextBox_Text2pcap";
            this.TextBox_Text2pcap.Size = new System.Drawing.Size(244, 23);
            this.TextBox_Text2pcap.TabIndex = 0;
            // 
            // Btn_Select_text2pcap
            // 
            this.Btn_Select_text2pcap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Select_text2pcap.Location = new System.Drawing.Point(290, 56);
            this.Btn_Select_text2pcap.Name = "Btn_Select_text2pcap";
            this.Btn_Select_text2pcap.Size = new System.Drawing.Size(58, 27);
            this.Btn_Select_text2pcap.TabIndex = 1;
            this.Btn_Select_text2pcap.Text = "Choose";
            this.Btn_Select_text2pcap.UseVisualStyleBackColor = true;
            this.Btn_Select_text2pcap.Click += new System.EventHandler(this.Btn_Select_text2pcap_Click);
            // 
            // Btn_Select_capture
            // 
            this.Btn_Select_capture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Select_capture.Location = new System.Drawing.Point(290, 114);
            this.Btn_Select_capture.Name = "Btn_Select_capture";
            this.Btn_Select_capture.Size = new System.Drawing.Size(58, 27);
            this.Btn_Select_capture.TabIndex = 3;
            this.Btn_Select_capture.Text = "Choose";
            this.Btn_Select_capture.UseVisualStyleBackColor = true;
            this.Btn_Select_capture.Click += new System.EventHandler(this.Btn_Select_capture_Click);
            // 
            // TextBox_file
            // 
            this.TextBox_file.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_file.Location = new System.Drawing.Point(37, 116);
            this.TextBox_file.Name = "TextBox_file";
            this.TextBox_file.Size = new System.Drawing.Size(244, 23);
            this.TextBox_file.TabIndex = 2;
            // 
            // Label_select_file
            // 
            this.Label_select_file.AutoSize = true;
            this.Label_select_file.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_select_file.Location = new System.Drawing.Point(34, 98);
            this.Label_select_file.Name = "Label_select_file";
            this.Label_select_file.Size = new System.Drawing.Size(103, 15);
            this.Label_select_file.TabIndex = 8;
            this.Label_select_file.Text = "Select capture file:";
            // 
            // Label_arrow_text2pcap
            // 
            this.Label_arrow_text2pcap.AutoSize = true;
            this.Label_arrow_text2pcap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_arrow_text2pcap.Location = new System.Drawing.Point(13, 40);
            this.Label_arrow_text2pcap.Name = "Label_arrow_text2pcap";
            this.Label_arrow_text2pcap.Size = new System.Drawing.Size(20, 15);
            this.Label_arrow_text2pcap.TabIndex = 11;
            this.Label_arrow_text2pcap.Text = "->";
            // 
            // Label_arror_select_file
            // 
            this.Label_arror_select_file.AutoSize = true;
            this.Label_arror_select_file.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_arror_select_file.Location = new System.Drawing.Point(13, 98);
            this.Label_arror_select_file.Name = "Label_arror_select_file";
            this.Label_arror_select_file.Size = new System.Drawing.Size(20, 15);
            this.Label_arror_select_file.TabIndex = 12;
            this.Label_arror_select_file.Text = "->";
            this.Label_arror_select_file.Visible = false;
            // 
            // Label_arrow_select_protocol
            // 
            this.Label_arrow_select_protocol.AutoSize = true;
            this.Label_arrow_select_protocol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_arrow_select_protocol.Location = new System.Drawing.Point(13, 165);
            this.Label_arrow_select_protocol.Name = "Label_arrow_select_protocol";
            this.Label_arrow_select_protocol.Size = new System.Drawing.Size(20, 15);
            this.Label_arrow_select_protocol.TabIndex = 13;
            this.Label_arrow_select_protocol.Text = "->";
            this.Label_arrow_select_protocol.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(36, 222);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Delete temporary file";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormSer2pcap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 315);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Label_arrow_select_protocol);
            this.Controls.Add(this.Label_arror_select_file);
            this.Controls.Add(this.Label_arrow_text2pcap);
            this.Controls.Add(this.Btn_Select_capture);
            this.Controls.Add(this.TextBox_file);
            this.Controls.Add(this.Label_select_file);
            this.Controls.Add(this.Btn_Select_text2pcap);
            this.Controls.Add(this.TextBox_Text2pcap);
            this.Controls.Add(this.Label_text2pcap);
            this.Controls.Add(this.Label_select_protocol);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnConvert);
            this.Controls.Add(this.Combox_Pro_Sel);
            this.Name = "FormSer2pcap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ser2pcap";
            this.Load += new System.EventHandler(this.FormSer2pcap_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Combox_Pro_Sel;
        private System.Windows.Forms.Button BtnConvert;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label Label_select_protocol;
        private System.Windows.Forms.Label Label_text2pcap;
        private System.Windows.Forms.TextBox TextBox_Text2pcap;
        private System.Windows.Forms.Button Btn_Select_text2pcap;
        private System.Windows.Forms.Button Btn_Select_capture;
        private System.Windows.Forms.TextBox TextBox_file;
        private System.Windows.Forms.Label Label_select_file;
        private System.Windows.Forms.Label Label_arrow_text2pcap;
        private System.Windows.Forms.Label Label_arror_select_file;
        private System.Windows.Forms.Label Label_arrow_select_protocol;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

