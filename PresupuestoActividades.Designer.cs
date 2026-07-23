
namespace SisPlan0401
{
    partial class PresupuestoActividades
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
            dataGridView2 = new DataGridView();
            label1 = new Label();
            BuscarActividadModificar = new Button();
            textBoxActividadModificar = new TextBox();
            label4 = new Label();
            label8 = new Label();
            ConsultaPOApresupuesto = new Button();
            textBox1 = new TextBox();
            MostrarReportadasPresupuesto = new Button();
            label9 = new Label();
            label11 = new Label();
            GuardarMontoEjecutado = new Button();
            texboxMontoEjecutado = new TextBox();
            label12 = new Label();
            btnExportarReporte = new Button();
            cmbFormatoExportar = new ComboBox();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 258);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1372, 193);
            dataGridView2.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 222);
            label1.Name = "label1";
            label1.Size = new Size(370, 33);
            label1.TabIndex = 21;
            label1.Text = "INFORMACION ACTIVIDADES POA ";
            // 
            // BuscarActividadModificar
            // 
            BuscarActividadModificar.Location = new Point(411, 70);
            BuscarActividadModificar.Name = "BuscarActividadModificar";
            BuscarActividadModificar.Size = new Size(129, 35);
            BuscarActividadModificar.TabIndex = 26;
            BuscarActividadModificar.Text = "Click para Buscar";
            BuscarActividadModificar.UseVisualStyleBackColor = true;
            BuscarActividadModificar.Click += BuscarActividadModificar_Click;
            // 
            // textBoxActividadModificar
            // 
            textBoxActividadModificar.Location = new Point(277, 74);
            textBoxActividadModificar.Name = "textBoxActividadModificar";
            textBoxActividadModificar.Size = new Size(129, 27);
            textBoxActividadModificar.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 77);
            label4.Name = "label4";
            label4.Size = new Size(255, 20);
            label4.TabIndex = 29;
            label4.Text = "Consultar una actividad del POA aqui";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Info;
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(21, 37);
            label8.Name = "label8";
            label8.Size = new Size(524, 30);
            label8.TabIndex = 38;
            label8.Text = "REGISTRAR EL MONTO DE LAS ACTIVIDADES EJECUTADAS";
            // 
            // ConsultaPOApresupuesto
            // 
            ConsultaPOApresupuesto.Location = new Point(1081, 73);
            ConsultaPOApresupuesto.Name = "ConsultaPOApresupuesto";
            ConsultaPOApresupuesto.Size = new Size(129, 29);
            ConsultaPOApresupuesto.TabIndex = 39;
            ConsultaPOApresupuesto.Text = "Clic para buscar";
            ConsultaPOApresupuesto.UseVisualStyleBackColor = true;
            ConsultaPOApresupuesto.Click += ConsultaPOApresupuesto_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(950, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(129, 27);
            textBox1.TabIndex = 40;
            // 
            // MostrarReportadasPresupuesto
            // 
            MostrarReportadasPresupuesto.Location = new Point(859, 108);
            MostrarReportadasPresupuesto.Name = "MostrarReportadasPresupuesto";
            MostrarReportadasPresupuesto.Size = new Size(187, 29);
            MostrarReportadasPresupuesto.TabIndex = 41;
            MostrarReportadasPresupuesto.Text = "Ver todas las reportadas";
            MostrarReportadasPresupuesto.UseVisualStyleBackColor = true;
            MostrarReportadasPresupuesto.Click += MostrarReportadasPresupuesto_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(710, 78);
            label9.Name = "label9";
            label9.Size = new Size(234, 20);
            label9.TabIndex = 42;
            label9.Text = "Consultar una actividad reportada";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Info;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(710, 37);
            label11.Name = "label11";
            label11.Size = new Size(506, 30);
            label11.TabIndex = 44;
            label11.Text = "CONSULTAR PRESUPUESTO DE ACTIVIDAD REGISTRADA";
            // 
            // GuardarMontoEjecutado
            // 
            GuardarMontoEjecutado.Location = new Point(337, 120);
            GuardarMontoEjecutado.Name = "GuardarMontoEjecutado";
            GuardarMontoEjecutado.Size = new Size(202, 29);
            GuardarMontoEjecutado.TabIndex = 45;
            GuardarMontoEjecutado.Text = "Guardar Monto Ejecutado";
            GuardarMontoEjecutado.UseVisualStyleBackColor = true;
            GuardarMontoEjecutado.Click += GuardarMontoEjecutado_Click;
            // 
            // texboxMontoEjecutado
            // 
            texboxMontoEjecutado.Location = new Point(200, 123);
            texboxMontoEjecutado.Name = "texboxMontoEjecutado";
            texboxMontoEjecutado.Size = new Size(131, 27);
            texboxMontoEjecutado.TabIndex = 46;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 128);
            label12.Name = "label12";
            label12.Size = new Size(173, 20);
            label12.TabIndex = 47;
            label12.Text = "Digitar monto ejecutado";
            // 
            // btnExportarReporte
            // 
            btnExportarReporte.Location = new Point(19, 538);
            btnExportarReporte.Name = "btnExportarReporte";
            btnExportarReporte.Size = new Size(158, 29);
            btnExportarReporte.TabIndex = 48;
            btnExportarReporte.Text = "Clic para descargar";
            btnExportarReporte.UseVisualStyleBackColor = true;
            btnExportarReporte.Click += btnExportarReporte_Click;
            // 
            // cmbFormatoExportar
            // 
            cmbFormatoExportar.FormattingEnabled = true;
            cmbFormatoExportar.Location = new Point(21, 509);
            cmbFormatoExportar.Name = "cmbFormatoExportar";
            cmbFormatoExportar.Size = new Size(151, 28);
            cmbFormatoExportar.TabIndex = 49;
            cmbFormatoExportar.Text = "Formato reporte";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 486);
            label13.Name = "label13";
            label13.Size = new Size(140, 20);
            label13.TabIndex = 50;
            label13.Text = "Descaga de reporte";
            // 
            // PresupuestoActividades
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1396, 762);
            Controls.Add(label13);
            Controls.Add(cmbFormatoExportar);
            Controls.Add(btnExportarReporte);
            Controls.Add(label12);
            Controls.Add(texboxMontoEjecutado);
            Controls.Add(GuardarMontoEjecutado);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(MostrarReportadasPresupuesto);
            Controls.Add(textBox1);
            Controls.Add(ConsultaPOApresupuesto);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(textBoxActividadModificar);
            Controls.Add(BuscarActividadModificar);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Name = "PresupuestoActividades";
            Text = "SISTEMA PARA INFORME TRIMESTRAL DSITRITAL / UNIDAD DE PLANIFICACION 04-01";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void julioOctubreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void huertosEscolaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void eneroMarzoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void sEMESTREToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cURRICULARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textBoxInvolucrados_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private DataGridView dataGridView2;
        private Label label1;
        private Button BuscarActividadModificar;
        private TextBox textBoxActividadModificar;
        private Label label4;
        private Label label8;
        private Button ConsultaPOApresupuesto;
        private TextBox textBox1;
        private Button MostrarReportadasPresupuesto;
        private Label label9;
        private Label label11;
        private Button GuardarMontoEjecutado;
        private TextBox texboxMontoEjecutado;
        private Label label12;
        private Button btnExportarReporte;
        private ComboBox cmbFormatoExportar;
        private Label label13;
    }
}
