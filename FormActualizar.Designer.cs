namespace SisPlan0401
{
    partial class FormActualizar
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
            txtDescripcion = new TextBox();
            txtParticipantes = new TextBox();
            txtInvolucrados = new TextBox();
            cmbUnidad = new ComboBox();
            cmbArea = new ComboBox();
            cmbTrimestre = new ComboBox();
            btnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(266, 28);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(125, 27);
            txtDescripcion.TabIndex = 0;
            // 
            // txtParticipantes
            // 
            txtParticipantes.Location = new Point(266, 180);
            txtParticipantes.Name = "txtParticipantes";
            txtParticipantes.Size = new Size(125, 27);
            txtParticipantes.TabIndex = 1;
            // 
            // txtInvolucrados
            // 
            txtInvolucrados.Location = new Point(266, 224);
            txtInvolucrados.Name = "txtInvolucrados";
            txtInvolucrados.Size = new Size(125, 27);
            txtInvolucrados.TabIndex = 2;
            // 
            // cmbUnidad
            // 
            cmbUnidad.FormattingEnabled = true;
            cmbUnidad.Location = new Point(240, 79);
            cmbUnidad.Name = "cmbUnidad";
            cmbUnidad.Size = new Size(151, 28);
            cmbUnidad.TabIndex = 3;
            // 
            // cmbArea
            // 
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(240, 128);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(151, 28);
            cmbArea.TabIndex = 4;
            // 
            // cmbTrimestre
            // 
            cmbTrimestre.FormattingEnabled = true;
            cmbTrimestre.Location = new Point(240, 273);
            cmbTrimestre.Name = "cmbTrimestre";
            cmbTrimestre.Size = new Size(151, 28);
            cmbTrimestre.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(214, 382);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 42);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 31);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 7;
            label1.Text = "Descripcion de la Actividad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 79);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 8;
            label2.Text = "Unidad ejecutora";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 131);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 9;
            label3.Text = "Area responsable";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 180);
            label4.Name = "label4";
            label4.Size = new Size(178, 20);
            label4.TabIndex = 10;
            label4.Text = "Cantidad de Participantes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 227);
            label5.Name = "label5";
            label5.Size = new Size(178, 20);
            label5.TabIndex = 11;
            label5.Text = "Cantidad de involucrados";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 273);
            label6.Name = "label6";
            label6.Size = new Size(158, 20);
            label6.TabIndex = 12;
            label6.Text = "Trimestre de ejecucion";
            // 
            // FormActualizar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(cmbTrimestre);
            Controls.Add(cmbArea);
            Controls.Add(cmbUnidad);
            Controls.Add(txtInvolucrados);
            Controls.Add(txtParticipantes);
            Controls.Add(txtDescripcion);
            Name = "FormActualizar";
            Text = "FormActualizar";
            Load += FormActualizar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescripcion;
        private TextBox txtParticipantes;
        private TextBox txtInvolucrados;
        private ComboBox cmbUnidad;
        private ComboBox cmbArea;
        private ComboBox cmbTrimestre;
        private Button btnGuardar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}