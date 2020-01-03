using System;
using System.Configuration;

namespace signalAcquirer
{
    partial class detail
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
            this.components = new System.ComponentModel.Container();
            this.btn_acquision = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_weight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_gender = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.dt_birthday = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_surnames = new System.Windows.Forms.TextBox();
            this.lb_surnames = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.dg_samples = new System.Windows.Forms.DataGridView();
            this.cb_signal_type = new System.Windows.Forms.ComboBox();
            this.bt_delete = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.bt_close_sp = new System.Windows.Forms.Button();
            this.bt_open_sp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_samples)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_acquision
            // 
            this.btn_acquision.Location = new System.Drawing.Point(12, 220);
            this.btn_acquision.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_acquision.Name = "btn_acquision";
            this.btn_acquision.Size = new System.Drawing.Size(252, 35);
            this.btn_acquision.TabIndex = 0;
            this.btn_acquision.Text = "Acquision signal";
            this.btn_acquision.UseVisualStyleBackColor = true;
            this.btn_acquision.Click += new System.EventHandler(this.Btn_acquision_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.ReadBufferSize = 1024;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_height);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_weight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_gender);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.dt_birthday);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_surnames);
            this.groupBox1.Controls.Add(this.lb_surnames);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.lb_name);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal data";
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(399, 106);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(200, 26);
            this.txt_height.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Heigth (cm.)";
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(108, 106);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(168, 26);
            this.txt_weight.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Weight (kg.)";
            // 
            // cbo_gender
            // 
            this.cbo_gender.FormattingEnabled = true;
            this.cbo_gender.Items.AddRange(new object[] {
            "Select one",
            "Male",
            "Female"});
            this.cbo_gender.Location = new System.Drawing.Point(76, 72);
            this.cbo_gender.Name = "cbo_gender";
            this.cbo_gender.Size = new System.Drawing.Size(200, 28);
            this.cbo_gender.TabIndex = 10;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(641, 154);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(110, 29);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // dt_birthday
            // 
            this.dt_birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_birthday.Location = new System.Drawing.Point(399, 71);
            this.dt_birthday.Name = "dt_birthday";
            this.dt_birthday.Size = new System.Drawing.Size(200, 26);
            this.dt_birthday.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Birthday";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gender";
            // 
            // txt_surnames
            // 
            this.txt_surnames.Location = new System.Drawing.Point(399, 39);
            this.txt_surnames.Name = "txt_surnames";
            this.txt_surnames.Size = new System.Drawing.Size(200, 26);
            this.txt_surnames.TabIndex = 3;
            // 
            // lb_surnames
            // 
            this.lb_surnames.AutoSize = true;
            this.lb_surnames.Location = new System.Drawing.Point(311, 42);
            this.lb_surnames.Name = "lb_surnames";
            this.lb_surnames.Size = new System.Drawing.Size(82, 20);
            this.lb_surnames.TabIndex = 2;
            this.lb_surnames.Text = "Surnames";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(76, 39);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(200, 26);
            this.txt_name.TabIndex = 1;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(18, 39);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(51, 20);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "Name";
            // 
            // dg_samples
            // 
            this.dg_samples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_samples.Location = new System.Drawing.Point(12, 310);
            this.dg_samples.Name = "dg_samples";
            this.dg_samples.RowHeadersWidth = 62;
            this.dg_samples.RowTemplate.Height = 28;
            this.dg_samples.Size = new System.Drawing.Size(1176, 409);
            this.dg_samples.TabIndex = 2;
            this.dg_samples.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dg_samples_CellDoubleClick_1);
            // 
            // cb_signal_type
            // 
            this.cb_signal_type.FormattingEnabled = true;
            this.cb_signal_type.Location = new System.Drawing.Point(271, 248);
            this.cb_signal_type.Name = "cb_signal_type";
            this.cb_signal_type.Size = new System.Drawing.Size(355, 28);
            this.cb_signal_type.TabIndex = 3;
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(983, 229);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(205, 36);
            this.bt_delete.TabIndex = 4;
            this.bt_delete.Text = "Delete selected signals";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.Bt_delete_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(1075, 187);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(113, 36);
            this.btn_refresh.TabIndex = 5;
            this.btn_refresh.Text = "refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // bt_close_sp
            // 
            this.bt_close_sp.Location = new System.Drawing.Point(632, 243);
            this.bt_close_sp.Name = "bt_close_sp";
            this.bt_close_sp.Size = new System.Drawing.Size(205, 36);
            this.bt_close_sp.TabIndex = 6;
            this.bt_close_sp.Text = "Close Serial Port";
            this.bt_close_sp.UseVisualStyleBackColor = true;
            this.bt_close_sp.Click += new System.EventHandler(this.bt_close_sp_Click);
            // 
            // bt_open_sp
            // 
            this.bt_open_sp.Location = new System.Drawing.Point(13, 265);
            this.bt_open_sp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_open_sp.Name = "bt_open_sp";
            this.bt_open_sp.Size = new System.Drawing.Size(252, 35);
            this.bt_open_sp.TabIndex = 7;
            this.bt_open_sp.Text = "Open Serial Port";
            this.bt_open_sp.UseVisualStyleBackColor = true;
            this.bt_open_sp.Click += new System.EventHandler(this.bt_open_sp_Click);
            // 
            // detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 731);
            this.Controls.Add(this.bt_open_sp);
            this.Controls.Add(this.bt_close_sp);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.cb_signal_type);
            this.Controls.Add(this.dg_samples);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_acquision);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "detail";
            this.Text = "detail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_samples)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_acquision;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DateTimePicker dt_birthday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_surnames;
        private System.Windows.Forms.Label lb_surnames;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.ComboBox cbo_gender;
        private System.Windows.Forms.DataGridView dg_samples;
        private System.Windows.Forms.ComboBox cb_signal_type;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_weight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_close_sp;
        private System.Windows.Forms.Button bt_open_sp;
    }
}