namespace signalAcquirer
{
    partial class Form2
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
            this.lb_prueba = new System.Windows.Forms.Label();
            this.lb_action = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_prueba
            // 
            this.lb_prueba.AutoSize = true;
            this.lb_prueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prueba.Location = new System.Drawing.Point(228, 65);
            this.lb_prueba.Name = "lb_prueba";
            this.lb_prueba.Size = new System.Drawing.Size(249, 91);
            this.lb_prueba.TabIndex = 0;
            this.lb_prueba.Text = "label1";
            // 
            // lb_action
            // 
            this.lb_action.AutoSize = true;
            this.lb_action.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_action.Location = new System.Drawing.Point(228, 202);
            this.lb_action.Name = "lb_action";
            this.lb_action.Size = new System.Drawing.Size(249, 91);
            this.lb_action.TabIndex = 1;
            this.lb_action.Text = "label1";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(703, 332);
            this.Controls.Add(this.lb_action);
            this.Controls.Add(this.lb_prueba);
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lb_prueba;
        public System.Windows.Forms.Label lb_action;
    }
}
