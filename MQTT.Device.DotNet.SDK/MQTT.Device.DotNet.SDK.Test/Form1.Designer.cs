namespace MQTT.Device.DotNet.SDK.Test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonUploadConfig = new System.Windows.Forms.Button();
            this.textBoxCloudProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCloudNode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGroupId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxSSL = new System.Windows.Forms.CheckBox();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.comboBoxComm = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numTTagCount = new System.Windows.Forms.NumericUpDown();
            this.lblTTagCount = new System.Windows.Forms.Label();
            this.numDTagCount = new System.Windows.Forms.NumericUpDown();
            this.lblDTagCount = new System.Windows.Forms.Label();
            this.numATagCount = new System.Windows.Forms.NumericUpDown();
            this.lblATagCount = new System.Windows.Forms.Label();
            this.lblDataFreq = new System.Windows.Forms.Label();
            this.numDataFreq = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numTTagCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDTagCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numATagCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDataFreq)).BeginInit();
            this.SuspendLayout();

            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 

            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonConnect.Location = new System.Drawing.Point(503, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(155, 57);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonUploadConfig
            // 
            this.buttonUploadConfig.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonUploadConfig.Location = new System.Drawing.Point(584, 79);
            this.buttonUploadConfig.Name = "buttonUploadConfig";
            this.buttonUploadConfig.Size = new System.Drawing.Size(155, 62);
            this.buttonUploadConfig.TabIndex = 1;
            this.buttonUploadConfig.Text = "Upload Config";
            this.buttonUploadConfig.UseVisualStyleBackColor = true;
            this.buttonUploadConfig.Click += new System.EventHandler(this.buttonUploadConfig_Click);
            // 
            // textBoxCloudProject
            // 
            this.textBoxCloudProject.Location = new System.Drawing.Point(216, 18);
            this.textBoxCloudProject.Name = "textBoxCloudProject";
            this.textBoxCloudProject.Size = new System.Drawing.Size(210, 25);
            this.textBoxCloudProject.TabIndex = 2;
            this.textBoxCloudProject.Text = "CloudProject";
            this.textBoxCloudProject.TextChanged += new System.EventHandler(this.textBoxCloudProject_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "雲端工程名稱:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "雲端節點名稱:";
            // 
            // textBoxCloudNode
            // 
            this.textBoxCloudNode.Location = new System.Drawing.Point(216, 59);
            this.textBoxCloudNode.Name = "textBoxCloudNode";
            this.textBoxCloudNode.Size = new System.Drawing.Size(210, 25);
            this.textBoxCloudNode.TabIndex = 5;
            this.textBoxCloudNode.Text = "CloudNode";
            this.textBoxCloudNode.TextChanged += new System.EventHandler(this.textBoxCloudNode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "IP 位址:";
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(216, 142);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(210, 25);
            this.textBoxIp.TabIndex = 9;
            this.textBoxIp.Text = "172.16.12.112";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "主要設備ID:";
            // 
            // textBoxGroupId
            // 
            this.textBoxGroupId.Location = new System.Drawing.Point(216, 101);
            this.textBoxGroupId.Name = "textBoxGroupId";
            this.textBoxGroupId.Size = new System.Drawing.Size(210, 25);
            this.textBoxGroupId.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(12, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(216, 182);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(210, 25);
            this.textBoxPort.TabIndex = 11;
            this.textBoxPort.Text = "1883";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(12, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "MQTT Broker User:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(216, 220);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(210, 25);
            this.textBoxUser.TabIndex = 13;
            this.textBoxUser.Text = "jeremy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(12, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "MQTT Broker Password:";
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(216, 260);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(210, 25);
            this.textBoxPwd.TabIndex = 15;
            this.textBoxPwd.Text = "34373437";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(12, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Use SSL/TLS:";
            // 
            // checkBoxSSL
            // 
            this.checkBoxSSL.AutoSize = true;
            this.checkBoxSSL.Location = new System.Drawing.Point(216, 301);
            this.checkBoxSSL.Name = "checkBoxSSL";
            this.checkBoxSSL.Size = new System.Drawing.Size(18, 17);
            this.checkBoxSSL.TabIndex = 19;
            this.checkBoxSSL.UseVisualStyleBackColor = true;
            // 
            // buttonSendData
            // 
            this.buttonSendData.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSendData.Location = new System.Drawing.Point(584, 147);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(155, 62);
            this.buttonSendData.TabIndex = 20;
            this.buttonSendData.Text = "Send Data";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.buttonSendData_Click);
            // 
            // comboBoxComm
            // 
            this.comboBoxComm.FormattingEnabled = true;
            this.comboBoxComm.Location = new System.Drawing.Point(216, 333);
            this.comboBoxComm.Name = "comboBoxComm";
            this.comboBoxComm.Size = new System.Drawing.Size(130, 23);
            this.comboBoxComm.TabIndex = 21;
            this.comboBoxComm.SelectedIndexChanged += new System.EventHandler(this.comboBoxComm_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(12, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "通訊方式:";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDisconnect.Location = new System.Drawing.Point(664, 12);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(155, 58);
            this.buttonDisconnect.TabIndex = 23;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Gray;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStatus.Location = new System.Drawing.Point(708, 407);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(186, 39);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "DISCONNECTED";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numTTagCount
            // 
            this.numTTagCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numTTagCount.Location = new System.Drawing.Point(396, 409);
            this.numTTagCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTTagCount.Name = "numTTagCount";
            this.numTTagCount.Size = new System.Drawing.Size(120, 34);
            this.numTTagCount.TabIndex = 56;
            this.numTTagCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblTTagCount
            // 
            this.lblTTagCount.AutoSize = true;
            this.lblTTagCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTTagCount.Location = new System.Drawing.Point(391, 381);
            this.lblTTagCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTTagCount.Name = "lblTTagCount";
            this.lblTTagCount.Size = new System.Drawing.Size(153, 25);
            this.lblTTagCount.TabIndex = 55;
            this.lblTTagCount.Text = "Text Tag Count";
            // 
            // numDTagCount
            // 
            this.numDTagCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numDTagCount.Location = new System.Drawing.Point(205, 407);
            this.numDTagCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numDTagCount.Name = "numDTagCount";
            this.numDTagCount.Size = new System.Drawing.Size(120, 34);
            this.numDTagCount.TabIndex = 54;
            this.numDTagCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblDTagCount
            // 
            this.lblDTagCount.AutoSize = true;
            this.lblDTagCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDTagCount.Location = new System.Drawing.Point(200, 381);
            this.lblDTagCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDTagCount.Name = "lblDTagCount";
            this.lblDTagCount.Size = new System.Drawing.Size(189, 25);
            this.lblDTagCount.TabIndex = 53;
            this.lblDTagCount.Text = "Discrete Tag Count";
            // 
            // numATagCount
            // 
            this.numATagCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numATagCount.Location = new System.Drawing.Point(19, 409);
            this.numATagCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numATagCount.Name = "numATagCount";
            this.numATagCount.Size = new System.Drawing.Size(120, 34);
            this.numATagCount.TabIndex = 52;
            this.numATagCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblATagCount
            // 
            this.lblATagCount.AutoSize = true;
            this.lblATagCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblATagCount.Location = new System.Drawing.Point(16, 381);
            this.lblATagCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblATagCount.Name = "lblATagCount";
            this.lblATagCount.Size = new System.Drawing.Size(182, 25);
            this.lblATagCount.TabIndex = 51;
            this.lblATagCount.Text = "Analog Tag Count";
            // 
            // lblDataFreq
            // 
            this.lblDataFreq.AutoSize = true;
            this.lblDataFreq.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDataFreq.Location = new System.Drawing.Point(555, 381);
            this.lblDataFreq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataFreq.Name = "lblDataFreq";
            this.lblDataFreq.Size = new System.Drawing.Size(158, 25);
            this.lblDataFreq.TabIndex = 57;
            this.lblDataFreq.Text = "Data Frequency";
            // 
            // numDataFreq
            // 
            this.numDataFreq.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numDataFreq.Location = new System.Drawing.Point(560, 409);
            this.numDataFreq.Name = "numDataFreq";
            this.numDataFreq.Size = new System.Drawing.Size(98, 34);
            this.numDataFreq.TabIndex = 58;
            this.numDataFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 450);
            this.Controls.Add(this.lblDataFreq);
            this.Controls.Add(this.numDataFreq);
            this.Controls.Add(this.numTTagCount);
            this.Controls.Add(this.lblTTagCount);
            this.Controls.Add(this.numDTagCount);
            this.Controls.Add(this.lblDTagCount);
            this.Controls.Add(this.numATagCount);
            this.Controls.Add(this.lblATagCount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxComm);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.checkBoxSSL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxGroupId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCloudNode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCloudProject);
            this.Controls.Add(this.buttonUploadConfig);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "MQTT Device SDK Sample";
            ((System.ComponentModel.ISupportInitialize)(this.numTTagCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDTagCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numATagCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDataFreq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonUploadConfig;
        private System.Windows.Forms.TextBox textBoxCloudProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCloudNode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGroupId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxSSL;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.ComboBox comboBoxComm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numTTagCount;
        private System.Windows.Forms.Label lblTTagCount;
        private System.Windows.Forms.NumericUpDown numDTagCount;
        private System.Windows.Forms.Label lblDTagCount;
        private System.Windows.Forms.NumericUpDown numATagCount;
        private System.Windows.Forms.Label lblATagCount;

        private System.Windows.Forms.Label lblDataFreq;
        private System.Windows.Forms.NumericUpDown numDataFreq;
        private System.Windows.Forms.Timer timer1;
    }
}

