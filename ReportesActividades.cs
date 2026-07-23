using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Word = Microsoft.Office.Interop.Word;
//using Excel = Microsoft.Office.Interop.Excel;
using Xceed.Words.NET;
using Xceed.Document.NET;
using OfficeOpenXml;
using OfficeOpenXml.Style;
//using OfficeOpenXml.Style;
using System.IO;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using System.Data;
using System.Drawing;
//using System.IO;

namespace SisPlan0401
{
    public partial class ReportesActividades : Form
    {
//*****************************************************************************************************
        //CONEXION A LA BASE DE DATOS LOCAL

        //conexion de base de datos con base de datos en la computadora con MySql 
        static string CadenaParaConetarBD = "server = 127.0.0.1; database = poa; user id =  root; password =Elprofe-Programador6663";// integrated security = true";
        MySqlConnection conexionBD = new MySqlConnection(CadenaParaConetarBD);
        private object textBoxActividadModificar;

        public ReportesActividades()
        {
            InitializeComponent();
        }

 
     
        //**********************************************************************************************************

        //CONSULTA AL POA, CONSULTA GENERAL DEL SISTEMA QUE DEVUELVE TODA LA INFORMACION, TODAS LAS ACTIVIDADES DEL POA

        private void Consulta_Click(object sender, EventArgs e)
        {
            //  Eliminar columna "Actualizar" si existe
            if (dataGridView2.Columns.Contains("btnActualizar"))
                dataGridView2.Columns.Remove("btnActualizar");

            //  Eliminar columna "Eliminar" si existe
            if (dataGridView2.Columns.Contains("btnEliminar"))
                dataGridView2.Columns.Remove("btnEliminar");

            string consulta = "Select *from TablaPOAcompleto";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;

        }

       
//*************************************************************************************************************
  
        //ELIMINAR REGISTRO DE LA BASE DE DATOS 
        private void EliminarRegistro_Click(object sender, EventArgs e)
        {
            //ELIMINA UN REGISTRO DE LA BASE DE DATOS, LA ACTIVIDAD CON SU INFORMACION 

            conexionBD.Open();

            string IdEliminar = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string EliminaValoresBD = "delete from actividadespoa where Id = " + IdEliminar;

            MySqlCommand comandoEliminar = new MySqlCommand(EliminaValoresBD, conexionBD);
            comandoEliminar.ExecuteNonQuery();

            //Eliminar el registro del dataGridView (en la pantalla del sistema)

            if (dataGridView2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow EliminaFila in dataGridView2.SelectedRows)
                {

                    dataGridView2.Rows.Remove(EliminaFila);
                }
            }

            MessageBox.Show("La actividad fue eliminada");
            conexionBD.Close();
        }


//*********************************************************************************************************

    //CONSULTA GENERAL DEL SISTEMA QUE DEVUELVE TODAS LAS ACTIVIDADES DEL POA REPORTADAS COMO REALIZADAS

        private void button1_Click(object sender, EventArgs e)
        {

            //  Eliminar columna "Actualizar" si existe
            if (dataGridView2.Columns.Contains("btnActualizar"))
                dataGridView2.Columns.Remove("btnActualizar");

            //  Eliminar columna "Eliminar" si existe
            if (dataGridView2.Columns.Contains("btnEliminar"))
                dataGridView2.Columns.Remove("btnEliminar");

            string consulta = "Select *from actividadespoa";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;

            //Esta porcion de codigo es para que coloque la palabra actualizar al final de cada registro

            // Verificar que no se haya agregado ya
            if (!dataGridView2.Columns.Contains("btnActualizar"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnActualizar";
                btnCol.HeaderText = "";
                btnCol.Text = "Actualizar";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns.Add(btnCol);
            }

            //Esta porcion de codigo es para que coloque la palabra eliminar al final de cada registro

            // Verificar que no se haya agregado ya

            if (!dataGridView2.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnEliminar";
                btnCol.HeaderText = "";
                btnCol.Text = "Eliminar";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns.Add(btnCol);
            }
        }

        //Consulta del sistema que devuelve solo las actividades que coincidan con un criterio de busqueda
        private void BuscarActividadRealizada_Click(object sender, EventArgs e)
        {
            conexionBD.Open();
            string cadena = "%" + ConsultaActividadRealizada.Text + "%";
            string consulta = "SELECT * FROM poa.actividadespoa WHERE `DescripcionActividad` LIKE  '" + cadena + "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
            conexionBD.Close();
        }
//*********************************************************************************************************

         //ACTUALIZAR UNA ACTIVIDAD DE LAS ACTIVIDADES REGISTRADAS
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "btnActualizar")
            {
                // Obtener valores actuales
                string id = dataGridView2.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                string descripcion = dataGridView2.Rows[e.RowIndex].Cells["DescripcionActividad"].Value.ToString();
                string unidad = dataGridView2.Rows[e.RowIndex].Cells["Unidad"].Value.ToString();
                string area = dataGridView2.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                string participantes = dataGridView2.Rows[e.RowIndex].Cells["Participantes"].Value.ToString();
                string involucrados = dataGridView2.Rows[e.RowIndex].Cells["Involucrados"].Value.ToString();
                string trimestre = dataGridView2.Rows[e.RowIndex].Cells["Trimestre"].Value.ToString();

                // Mostrar un formulario de edición
                using (var form = new FormActualizar(id, descripcion, unidad, area, participantes, involucrados, trimestre))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Reconsultar base de datos
                        button1.PerformClick(); // Recargar los datos
                    }
                }

            }

 //*******************************************************************************************************

            //ELIMINAR UNA ACTIVIDAD DE LAS ACTIVIDADES REGISTRADAS

            if (e.RowIndex < 0) return;

            string nombreColumna = dataGridView2.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "btnActualizar")
            {
                // Ya lo tienes: código para abrir FormActualizar
                string id = dataGridView2.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                string descripcion = dataGridView2.Rows[e.RowIndex].Cells["DescripcionActividad"].Value.ToString();
                string unidad = dataGridView2.Rows[e.RowIndex].Cells["Unidad"].Value.ToString();
                string area = dataGridView2.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                string participantes = dataGridView2.Rows[e.RowIndex].Cells["Participantes"].Value.ToString();
                string involucrados = dataGridView2.Rows[e.RowIndex].Cells["Involucrados"].Value.ToString();
                string trimestre = dataGridView2.Rows[e.RowIndex].Cells["Trimestre"].Value.ToString();

                using (var form = new FormActualizar(id, descripcion, unidad, area, participantes, involucrados, trimestre))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        button1.PerformClick(); // Recargar
                    }
                }
            }
            else if (nombreColumna == "btnEliminar")
            {
                // Confirmación
                DialogResult confirm = MessageBox.Show("¿Está seguro que desea eliminar esta actividad?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string idEliminar = dataGridView2.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                    try
                    {
                        string conexion = "server=127.0.0.1; database=poa; user id=root; password=Elprofe-Programador6663";
                        using (MySqlConnection conn = new MySqlConnection(conexion))
                        {
                            conn.Open();
                            string eliminarSQL = "DELETE FROM actividadespoa WHERE Id = @id";
                            MySqlCommand cmd = new MySqlCommand(eliminarSQL, conn);
                            cmd.Parameters.AddWithValue("@id", idEliminar);
                            int filas = cmd.ExecuteNonQuery();

                            if (filas > 0)
                            {
                                MessageBox.Show("Actividad eliminada correctamente.");
                                dataGridView2.Rows.RemoveAt(e.RowIndex); // Eliminar de vista
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar la actividad.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }



        //***********************************************************************************************************

        //CONSULTAS MENU PRINCIPAL POR UNIDADES, NIVELES Y AREAS/CONSULTA A LAS ACTIVIDADES REGISTRADAS

        //********************************************************************************************************


        private void DiversasConsultas_Click(object sender, EventArgs e)
        {
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES' from actividadespoa where `Trimestre`= 'Abril-Junio' && `unidad`= 'Planificacion'";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void informeTrimestralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' && `Trimestre`= 'Enero-Marzo' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }


        // PARA DESCARGAR INFORMES
        private void ReportesActividades_Load(object sender, EventArgs e)
        {

            InicializarControlesExportacion();

        }

        private void tRIMESTREToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' && `Trimestre`= 'Enero-Marzo' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //REPORTE GENERAL DE TODAS LAS UNIDADES, TODA LA INFORMACION DESDE ENERO HASTA DICIEMBRE 
            string consulta = "Select *from actividadespoa";
            //"SELECT * FROM 'actividadespoa'"
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void primerTrimestreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //REPORTE UNIDAD CURRICULAR PRIMER TRIMESTRE ENERO-MARZO

            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' && `Trimestre`= 'Enero-Marzo' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;

        }

        private void eneroDiciembreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR 
            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;

        }

        private void eneroMarzoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //REPORTE GENERAL DE TODAS LAS UNIDADES, INFORMACION DE ENERO-MARZO 

            string consulta = "Select *from actividadespoa where `Trimestre`= 'Enero-Marzo' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroMarzoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE ACTIVIDADES DE LA UNIDAD CURRICULAR EN EL TRIMESTRE ENERO-MARZO
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES CURRICULAR ENERO-MARZO' from actividadespoa where `Trimestre`= 'Enero-Marzo' && `Unidad`= 'Curricular' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;

        }

        private void eneroMarzoToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE ACTIVIDADES DE TODAS LAS UNIDADES EN EL TRIMESTRE ENERO-MARZO
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES DEL DISTRITO ENERO-MARZO' from actividadespoa where `Trimestre`= 'Enero-Marzo' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE ACTIVIDADES DEL DISTRITO, TODAS LAS UNIDADES EN EL AÑO COMPLETO
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES DEL DISTRITO ENERO-DICIEMBRE' from actividadespoa ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem3_Click(object sender, EventArgs e)
        {// CANTIDAD TOTAL DE ACTIVIDADES DE LA UNIDAD CURRICULAR (TODOS LOS TRIMESTRES)
            string consulta = "SELECT COUNT(*) AS 'CANTIDAD TOTAL DE ACTIVIDADES CURRICULAR' " +
                              "FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void segundoTrimestreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //REPORTE UNIDAD CURRICULAR SEGUNDO TRIMESTRE ABRIL-JUNIO

            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' && `Trimestre`= 'Abril-Junio' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void tercerTrimestreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //REPORTE UNIDAD CURRICULAR TERCER TRIMESTRE JULIO-SEPTIEMBRE

            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' && `Trimestre`= 'Julio-Septiembre' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void cuartoTrimestreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //REPORTE UNIDAD CURRICULAR CUARTO TRIMESTRE OCTUBRE-DICIEMBRE

            string consulta = "Select *from actividadespoa where `Unidad`= 'Curricular' && `Trimestre`= 'Octubre-Diciembre' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO)

            string consulta = "SELECT * FROM actividadespoa WHERE `Unidad` = 'Curricular' AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio')";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA INICIAL

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Inicial'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA PRIMARIO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Primario'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA SECUNDARIO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Secundario'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA SUB SISTEMA DE ADULTOS

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Subsistema de adultos'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), area Orientacion y Psicologia

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Orientacion y psicologia'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA EQUIDAD DE GENERO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Equidad de genero'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA GESTION DE RIESGO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Gestion de riesgo'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA Depto. TIC

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Depto. TIC'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA HUERTOS ESCOLARES

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Huertos escolares'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE (ENERO-JUNIO), ÁREA ATENCION A LA DIVERSIDAD

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio') " +
                              "AND `Area` = 'Atencion a la diversidad'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE

            string consulta = "SELECT * FROM actividadespoa WHERE `Unidad` = 'Curricular' AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre')";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }


        private void julioDiciembreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA INICIAL

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Inicial'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA PRIMARIO 

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Primario'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA SECUNDARIO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Secundario'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA SUBSISTEMA DE ADULTOS

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Subsistema de adultos'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA ORIENTACION Y PSICOLOGIA

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Orientacion y psicologia'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA EQUIDAD DE GENERO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Equidad de genero'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA GESTION DE RIESGO

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Gestion de riesgo'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA DEPARTAMENTO TIC

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Depto. TIC'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA HUERTOS ESCOLARES

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Huertos escolares'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            // REPORTE UNIDAD CURRICULAR PRIMER Y SEGUNDO TRIMESTRE JULIO-DICIEMBRE, ÁREA ATENCION A LA DIVERSIDAD

            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre') " +
                              "AND `Area` = 'Atencion a la diversidad'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA INICIAL
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Inicial'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA PRIMARIO
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Primario'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA SECUNDARIO
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Secundario'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA SUBSISTEMA DE ADULTOS
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Subsistema de adultos'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA ORIENTACION Y PSICOLOGIA
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Orientacion y psicologia'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA EQUIDAD DE GENERO
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Equidad de genero'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA GESTION DE RIESGO
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Gestion de riesgo'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA Depto. TIC
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Dpto. TIC'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA HUERTOS ESCOLARES
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Huertos escolares'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroDiciembreToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            // INFORME GENERAL DEL AÑO ENERO-DICIEMBRE UNIDAD CURRICULAR, ÁREA ATENCION A LA DIVERSIDAD
            string consulta = "SELECT * FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Area` = 'Atencion a la diversidad'";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void abrilJunioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE ACTIVIDADES DE LA UNIDAD CURRICULAR EN EL TRIMESTRE ENERO-MARZO
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES CURRICULAR ABRIL-JUNIO' from actividadespoa where `Trimestre`= 'Abril-Junio' && `Unidad`= 'Curricular' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioSeptiembreToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE ACTIVIDADES DE LA UNIDAD CURRICULAR EN EL TRIMESTRE JULIO-SEPTIEMBRE
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES CURRICULAR JULIO-SEPTIEMBRE' from actividadespoa where `Trimestre`= 'Julio-Septiembre' && `Unidad`= 'Curricular' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void octubreDiciembreToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE ACTIVIDADES DE LA UNIDAD CURRICULAR EN EL TRIMESTRE OCTUBRE-DICIEMBRE
            string consulta = "Select COUNT(*) 'CANTIDAD DE ACTIVIDADES CURRICULAR OCTUBRE-DICIEMBRE' from actividadespoa where `Trimestre`= 'Octubre-Diciembre' && `Unidad`= 'Curricular' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void eneroJunioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // CANTIDAD DE ACTIVIDADES DE LA UNIDAD CURRICULAR EN LOS TRIMESTRES ENERO-MARZO Y ABRIL-JUNIO
            string consulta = "SELECT COUNT(*) AS 'CANTIDAD DE ACTIVIDADES CURRICULAR ENERO-JUNIO' " +
                              "FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Enero-Marzo', 'Abril-Junio')";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }

        private void julioDiciembreToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // CANTIDAD DE ACTIVIDADES DE LA UNIDAD CURRICULAR SEMESTRE JULIO - DICIEMBRE
            string consulta = "SELECT COUNT(*) AS 'CANTIDAD DE ACTIVIDADES CURRICULAR JULIO-DICIEMBRE' " +
                              "FROM actividadespoa " +
                              "WHERE `Unidad` = 'Curricular' " +
                              "AND `Trimestre` IN ('Julio-Septiembre', 'Octubre-Diciembre')";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
        }


 
//**********************************************************************************************************

        //DESCARGAR REPORTES DE LAS ACTIVIDADES QUE FUERON REGISTRADAS COMO REALIZADAS. DESCARGA A UN ARCHIVO EN PDF O WORD

        //Descarga un archivo en formato PDF
        private void ExportarPDF(DataTable tabla, string path)
        {
            //Document doc = new Document();
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            PdfPTable pdfTable = new PdfPTable(tabla.Columns.Count);

            foreach (DataColumn column in tabla.Columns)
                pdfTable.AddCell(new Phrase(column.ColumnName));

            foreach (DataRow row in tabla.Rows)
            {
                foreach (var cell in row.ItemArray)
                    pdfTable.AddCell(new Phrase(cell?.ToString()));
            }

            doc.Add(pdfTable);
            doc.Close();
        }



//Descarga un archivo en formato de texto

private void ExportarWord(DataTable tabla, string path)
    {
        using (var doc = DocX.Create(path))
        {
            // Agrega un título opcional
            doc.InsertParagraph("REPORTE DE ACTIVIDADES").FontSize(14).Bold().Alignment = Alignment.center;
            doc.InsertParagraph(Environment.NewLine);

            // Crear tabla
            int filas = tabla.Rows.Count + 1;
            int columnas = tabla.Columns.Count;

            var wordTable = doc.AddTable(filas, columnas);
            wordTable.Design = TableDesign.MediumShading1Accent1;

            // Encabezados
            for (int c = 0; c < columnas; c++)
            {
                wordTable.Rows[0].Cells[c].Paragraphs[0].Append(tabla.Columns[c].ColumnName).Bold();
            }

            // Datos
            for (int r = 0; r < tabla.Rows.Count; r++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    string valor = tabla.Rows[r][c]?.ToString() ?? "";
                    wordTable.Rows[r + 1].Cells[c].Paragraphs[0].Append(valor);
                }
            }

            doc.InsertTable(wordTable);
            doc.Save();
        }
    }


        //Permite elegir del comboxBox la opcion de formato deseada para descargar el archivo con el reporte
    private void btnExportarReporte_Click(object sender, EventArgs e)
        {
    
            string formato = cmbFormatoExportar.SelectedItem.ToString();
            DataTable tabla = (DataTable)dataGridView2.DataSource;

            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para descargar.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = $"{formato} files|*.{formato.ToLower()}";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (formato)
                    {
                        case "PDF":
                            ExportarPDF(tabla, sfd.FileName);
                            break;
                        case "Word":
                            ExportarWord(tabla, sfd.FileName);
                            break;
                        //case "Excel":
                        //    ExportarExcel(tabla, sfd.FileName);
                        //    break;
                    }
                    MessageBox.Show("Informe descargado.");
                }
            }
        }



        //Agrega los elementos al ComboxBox para elegir el formato (Word o pdf) y coloca un texto permanente

        private void InicializarControlesExportacion()
        {
            btnExportarReporte.Text = "Clic para Descargar";
            btnExportarReporte.Click += btnExportarReporte_Click;

            cmbFormatoExportar.Items.AddRange(new string[] { "PDF", "Word" });
            cmbFormatoExportar.SelectedIndex = 0;


        }



        }

}

