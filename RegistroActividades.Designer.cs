
namespace SisPlan0401
{
    partial class RegistroActividades
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
            dataGridView1 = new DataGridView();
            actividad = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            Nivel = new DataGridViewTextBoxColumn();
            Participantes = new DataGridViewTextBoxColumn();
            involucrados = new DataGridViewTextBoxColumn();
            trimestre = new DataGridViewTextBoxColumn();
            AgregaDato = new Button();
            textBoxActividad = new TextBox();
            textBoxParticipantes = new TextBox();
            textBoxInvolucrados = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            BuscaActividadRealizada = new Button();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { actividad, Unidad, Nivel, Participantes, involucrados, trimestre });
            dataGridView1.Location = new Point(11, 184);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1372, 159);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // actividad
            // 
            actividad.HeaderText = "Descripcion Actividad";
            actividad.MinimumWidth = 12;
            actividad.Name = "actividad";
            actividad.Width = 500;
            // 
            // Unidad
            // 
            Unidad.HeaderText = "Unidad responsable";
            Unidad.MinimumWidth = 6;
            Unidad.Name = "Unidad";
            Unidad.Width = 160;
            // 
            // Nivel
            // 
            Nivel.HeaderText = "Nivel o area";
            Nivel.MinimumWidth = 6;
            Nivel.Name = "Nivel";
            Nivel.Width = 160;
            // 
            // Participantes
            // 
            Participantes.HeaderText = "Cantidad de Participantes Impactados";
            Participantes.MinimumWidth = 6;
            Participantes.Name = "Participantes";
            Participantes.Width = 140;
            // 
            // involucrados
            // 
            involucrados.HeaderText = "Cantidad de invitados e involucrados";
            involucrados.MinimumWidth = 6;
            involucrados.Name = "involucrados";
            involucrados.Width = 140;
            // 
            // trimestre
            // 
            trimestre.HeaderText = "Trimestre de ejecucion";
            trimestre.MinimumWidth = 6;
            trimestre.Name = "trimestre";
            trimestre.Width = 160;
            // 
            // AgregaDato
            // 
            AgregaDato.Location = new Point(11, 348);
            AgregaDato.Name = "AgregaDato";
            AgregaDato.Size = new Size(227, 41);
            AgregaDato.TabIndex = 1;
            AgregaDato.Text = "Guardar actividad del trimestre";
            AgregaDato.UseVisualStyleBackColor = true;
            AgregaDato.Click += AgregaDato_Click;
            // 
            // textBoxActividad
            // 
            textBoxActividad.Location = new Point(205, 149);
            textBoxActividad.Name = "textBoxActividad";
            textBoxActividad.Size = new Size(344, 27);
            textBoxActividad.TabIndex = 2;
            // 
            // textBoxParticipantes
            // 
            textBoxParticipantes.Location = new Point(890, 151);
            textBoxParticipantes.Name = "textBoxParticipantes";
            textBoxParticipantes.Size = new Size(134, 27);
            textBoxParticipantes.TabIndex = 5;
            // 
            // textBoxInvolucrados
            // 
            textBoxInvolucrados.Location = new Point(1028, 152);
            textBoxInvolucrados.Name = "textBoxInvolucrados";
            textBoxInvolucrados.Size = new Size(135, 27);
            textBoxInvolucrados.TabIndex = 6;
            textBoxInvolucrados.TextChanged += textBoxInvolucrados_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Curricular", "Planificacion", "Descentralizacion", "Supervision", "Administrativo" });
            comboBox1.Location = new Point(563, 152);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 13;
            comboBox1.Text = "ELEGIR UNIDAD";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.AutoCompleteSource = AutoCompleteSource.FileSystem;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(725, 152);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(162, 28);
            comboBox2.TabIndex = 14;
            comboBox2.Text = "ELEGIR NIVEL/AREA";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Enero-Marzo", "Abril-Junio", "Julio-Septiembre", "Octubre-Diciembre" });
            comboBox3.Location = new Point(1165, 152);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 15;
            comboBox3.Text = "ELEGIR TRIMESTRE";
            // 
            // BuscaActividadRealizada
            // 
            BuscaActividadRealizada.Location = new Point(12, 149);
            BuscaActividadRealizada.Name = "BuscaActividadRealizada";
            BuscaActividadRealizada.Size = new Size(187, 29);
            BuscaActividadRealizada.TabIndex = 30;
            BuscaActividadRealizada.Text = "Buscar actividad del POA";
            BuscaActividadRealizada.UseVisualStyleBackColor = true;
            BuscaActividadRealizada.Click += BuscaActividadRealizada_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(890, 88);
            label5.Name = "label5";
            label5.Size = new Size(110, 60);
            label5.TabIndex = 31;
            label5.Text = "CANTIDAD DE \r\nParticipantes   \r\nImpactodos";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1038, 88);
            label6.Name = "label6";
            label6.Size = new Size(114, 60);
            label6.TabIndex = 32;
            label6.Text = "CANTIDAD DE  \r\n Invitados e \r\nInvolucrados\r\n";
            label6.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Info;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 107);
            label3.Name = "label3";
            label3.Size = new Size(638, 33);
            label3.TabIndex = 37;
            label3.Text = "REGISTRAR LAS ACTIVIDADES REALIZADAS EN EL TRIMESTRE";
            // 
            // RegistroActividades
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1396, 762);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(BuscaActividadRealizada);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBoxInvolucrados);
            Controls.Add(textBoxParticipantes);
            Controls.Add(textBoxActividad);
            Controls.Add(AgregaDato);
            Controls.Add(dataGridView1);
            Name = "RegistroActividades";
            Text = "SISTEMA PARA INFORME TRIMESTRAL DSITRITAL / UNIDAD DE PLANIFICACION 04-01";
            //Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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

        private DataGridView dataGridView1;
        private Button AgregaDato;
        private TextBox textBoxActividad;
        private TextBox textBoxParticipantes;
        private TextBox textBoxInvolucrados;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button BuscaActividadRealizada;
        private DataGridViewTextBoxColumn actividad;
        private DataGridViewTextBoxColumn Unidad;
        private DataGridViewTextBoxColumn Nivel;
        private DataGridViewTextBoxColumn Participantes;
        private DataGridViewTextBoxColumn involucrados;
        private DataGridViewTextBoxColumn trimestre;
        private Label label5;
        private Label label6;
        private Label label3;
    }
}
