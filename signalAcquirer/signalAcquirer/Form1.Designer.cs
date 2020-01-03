namespace signalAcquirer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_create = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.btn_export_to_csv = new System.Windows.Forms.Button();
            this.cb_signal_type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 171);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1164, 503);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // bt_create
            // 
            this.bt_create.Location = new System.Drawing.Point(18, 134);
            this.bt_create.Name = "bt_create";
            this.bt_create.Size = new System.Drawing.Size(125, 29);
            this.bt_create.TabIndex = 1;
            this.bt_create.Text = "Create person";
            this.bt_create.UseVisualStyleBackColor = true;
            this.bt_create.Click += new System.EventHandler(this.Bt_create_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(982, 131);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(200, 34);
            this.bt_delete.TabIndex = 2;
            this.bt_delete.Text = "Delete selected registers";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.Bt_delete_Click);
            // 
            // btn_export_to_csv
            // 
            this.btn_export_to_csv.Location = new System.Drawing.Point(1017, 72);
            this.btn_export_to_csv.Name = "btn_export_to_csv";
            this.btn_export_to_csv.Size = new System.Drawing.Size(165, 34);
            this.btn_export_to_csv.TabIndex = 3;
            this.btn_export_to_csv.Text = "Export to CSV";
            this.btn_export_to_csv.UseVisualStyleBackColor = true;
            this.btn_export_to_csv.Click += new System.EventHandler(this.Btn_export_to_csv_Click);
            // 
            // cb_signal_type
            // 
            this.cb_signal_type.FormattingEnabled = true;
            this.cb_signal_type.Location = new System.Drawing.Point(827, 23);
            this.cb_signal_type.Name = "cb_signal_type";
            this.cb_signal_type.Size = new System.Drawing.Size(355, 28);
            this.cb_signal_type.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.cb_signal_type);
            this.Controls.Add(this.btn_export_to_csv);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_create);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Acquisition Signal Olimex Shield EKG-EMG";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_create;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button btn_export_to_csv;
        private System.Windows.Forms.ComboBox cb_signal_type;
    }
}

