namespace WindowsFormsApp
{

    partial class frmMain
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
            this.cmdTxt = new System.Windows.Forms.Button();
            this.cmdCsv = new System.Windows.Forms.Button();
            this.cmdXml = new System.Windows.Forms.Button();
            this.cmdRtf = new System.Windows.Forms.Button();
            this.cmdCrear = new System.Windows.Forms.Button();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdTxt
            // 
            this.cmdTxt.Location = new System.Drawing.Point(108, 264);
            this.cmdTxt.Name = "cmdTxt";
            this.cmdTxt.Size = new System.Drawing.Size(75, 23);
            this.cmdTxt.TabIndex = 1;
            this.cmdTxt.Text = "TXT";
            this.cmdTxt.UseVisualStyleBackColor = true;
            this.cmdTxt.Click += new System.EventHandler(this.cmdTxt_Click);
            // 
            // cmdCsv
            // 
            this.cmdCsv.Location = new System.Drawing.Point(246, 264);
            this.cmdCsv.Name = "cmdCsv";
            this.cmdCsv.Size = new System.Drawing.Size(75, 23);
            this.cmdCsv.TabIndex = 2;
            this.cmdCsv.Text = "CSV";
            this.cmdCsv.UseVisualStyleBackColor = true;
            this.cmdCsv.Click += new System.EventHandler(this.cmdCsv_Click);
            // 
            // cmdXml
            // 
            this.cmdXml.Location = new System.Drawing.Point(388, 264);
            this.cmdXml.Name = "cmdXml";
            this.cmdXml.Size = new System.Drawing.Size(75, 23);
            this.cmdXml.TabIndex = 3;
            this.cmdXml.Text = "XML";
            this.cmdXml.UseVisualStyleBackColor = true;
            this.cmdXml.Click += new System.EventHandler(this.cmdXml_Click);
            // 
            // cmdRtf
            // 
            this.cmdRtf.Location = new System.Drawing.Point(528, 264);
            this.cmdRtf.Name = "cmdRtf";
            this.cmdRtf.Size = new System.Drawing.Size(75, 23);
            this.cmdRtf.TabIndex = 4;
            this.cmdRtf.Text = "RTF";
            this.cmdRtf.UseVisualStyleBackColor = true;
            this.cmdRtf.Click += new System.EventHandler(this.cmdRtf_Click);
            // 
            // cmdCrear
            // 
            this.cmdCrear.Location = new System.Drawing.Point(205, 323);
            this.cmdCrear.Name = "cmdCrear";
            this.cmdCrear.Size = new System.Drawing.Size(75, 23);
            this.cmdCrear.TabIndex = 5;
            this.cmdCrear.Text = "CREAR";
            this.cmdCrear.UseVisualStyleBackColor = true;
            this.cmdCrear.Click += new System.EventHandler(this.cmdCrear_Click);
            // 
            // cmdEditar
            // 
            this.cmdEditar.Location = new System.Drawing.Point(318, 323);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(75, 23);
            this.cmdEditar.TabIndex = 6;
            this.cmdEditar.Text = "EDITAR";
            this.cmdEditar.UseVisualStyleBackColor = true;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Location = new System.Drawing.Point(442, 323);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(75, 23);
            this.cmdBorrar.TabIndex = 7;
            this.cmdBorrar.Text = "BORRAR";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(304, 166);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 8;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(183, 9);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(362, 137);
            this.dataGridView.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdCrear);
            this.Controls.Add(this.cmdRtf);
            this.Controls.Add(this.cmdXml);
            this.Controls.Add(this.cmdCsv);
            this.Controls.Add(this.cmdTxt);
            this.Name = "frmMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdTxt;
        private System.Windows.Forms.Button cmdCsv;
        private System.Windows.Forms.Button cmdXml;
        private System.Windows.Forms.Button cmdRtf;
        private System.Windows.Forms.Button cmdCrear;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dataGridView;
    }


}

