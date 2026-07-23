using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SisPlan0401
{
    public partial class FormActualizar : Form
    {
        string id;

        public FormActualizar(string id, string descripcion, string unidad, string area, string participantes, string involucrados, string trimestre)
        {
            InitializeComponent();
            this.id = id;
            txtDescripcion.Text = descripcion;
            cmbUnidad.Text = unidad;
            cmbArea.Text = area;
            txtParticipantes.Text = participantes;
            txtInvolucrados.Text = involucrados;
            cmbTrimestre.Text = trimestre;
        }

       // private void btnGuardar_Click(object sender, EventArgs e)
        
        private void FormActualizar_Load(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o inicializar algo aquí si deseas.
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string conexion = "server=127.0.0.1; database=poa; user id=root; password=Elprofe-Programador6663";
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                conn.Open();
                string consulta = @"UPDATE actividadespoa SET 
                DescripcionActividad=@desc, Unidad=@unidad, Area=@area, 
                Participantes=@part, Involucrados=@invo, Trimestre=@tri 
                WHERE Id=@id";

                MySqlCommand cmd = new MySqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@unidad", cmbUnidad.Text);
                cmd.Parameters.AddWithValue("@area", cmbArea.Text);
                cmd.Parameters.AddWithValue("@part", txtParticipantes.Text);
                cmd.Parameters.AddWithValue("@invo", txtInvolucrados.Text);
                cmd.Parameters.AddWithValue("@tri", cmbTrimestre.Text);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Actualización exitosa");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }

}
