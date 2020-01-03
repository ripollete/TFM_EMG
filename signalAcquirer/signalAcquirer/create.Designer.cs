namespace signalAcquirer
{
    partial class create
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_weight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_gender = new System.Windows.Forms.ComboBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.dt_birthday = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_surnames = new System.Windows.Forms.TextBox();
            this.lb_surnames = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_height);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_weight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_gender);
            this.groupBox1.Controls.Add(this.btn_create);
            this.groupBox1.Controls.Add(this.dt_birthday);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_surnames);
            this.groupBox1.Controls.Add(this.lb_surnames);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.lb_name);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal data";
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(399, 106);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(200, 26);
            this.txt_height.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Heigth (cm.)";
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(108, 106);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(168, 26);
            this.txt_weight.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 11;
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
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(489, 159);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(110, 29);
            this.btn_create.TabIndex = 9;
            this.btn_create.Text = "create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.Btn_create_Click);
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
            // create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 251);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "create";
            this.Text = "Create";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.DateTimePicker dt_birthday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_surnames;
        private System.Windows.Forms.Label lb_surnames;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.ComboBox cbo_gender;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_weight;
        private System.Windows.Forms.Label label3;
    }
}