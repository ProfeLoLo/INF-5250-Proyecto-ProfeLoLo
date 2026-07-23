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
    public partial class PresupuestoActividades : Form
    {
//*****************************************************************************************************
        //CONEXION A LA BASE DE DATOS LOCAL

        //conexion de base de datos con base de datos en la computadora con MySql 
        static string CadenaParaConetarBD = "server = 127.0.0.1; database = poa; user id =  root; password =Elprofe-Programador6663";// integrated security = true";
        MySqlConnection conexionBD = new MySqlConnection(CadenaParaConetarBD);

        public PresupuestoActividades()
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

//**********************************************************************************************************

      //BUSCAR UNA ACTIVIDAD EN EL POA

        //Este metodo se llama asi porque se uso originalmente para otro proceso. 
        private void BuscarActividadModificar_Click(object sender, EventArgs e)
        {
            //  Eliminar columna "Actualizar" si existe
            if (dataGridView2.Columns.Contains("btnActualizar"))
                dataGridView2.Columns.Remove("btnActualizar");

            //  Eliminar columna "Eliminar" si existe
            if (dataGridView2.Columns.Contains("btnEliminar"))
                dataGridView2.Columns.Remove("btnEliminar");


            conexionBD.Open();

         
            string cadena = "%" + textBoxActividadModificar.Text + "%";
            string consulta = "SELECT * FROM poa.TablaPOAcompleto WHERE `ACTIVIDADES-POA` LIKE  '" + cadena + "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView2.DataSource = tabla;
            conexionBD.Close();

        }

//*********************************************************************************************************

        //REGISTRAR MONTO INVERTIDO EN UNA ACTIVIDAD, PRESUPUESTO DE LA ACTIVIDAD
        private void GuardarMontoEjecutado_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila de la tabla primero.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id"].Value);

                // Validar entrada del usuario
                if (!decimal.TryParse(texboxMontoEjecutado.Text, out decimal montoUsado))
                {
                    MessageBox.Show("Ingrese un monto ejecutado válido.");
                    return;
                }

                // Obtener los valores actuales de la fila
                decimal montoEjecutadoActual = Convert.ToDecimal(dataGridView2.CurrentRow.Cells["MontoEjecutado"].Value);
                decimal montoRestanteActual = Convert.ToDecimal(dataGridView2.CurrentRow.Cells["MontoRestante"].Value);

                // Validar que no se use más de lo que queda
                if (montoUsado > montoRestanteActual)
                {
                    MessageBox.Show("El monto ejecutado excede el monto restante.");
                    return;
                }

                // Calcular nuevos valores
                decimal nuevoMontoEjecutado = montoEjecutadoActual + montoUsado;
                decimal nuevoMontoRestante = montoRestanteActual - montoUsado;

                // Actualizar en base de datos
                string updateQuery = @"UPDATE TablaPOAcompleto 
                           SET MontoEjecutado = @MontoEjecutado, 
                               MontoRestante = @MontoRestante 
                           WHERE Id = @Id";

                conexionBD.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, conexionBD);
                cmd.Parameters.AddWithValue("@MontoEjecutado", nuevoMontoEjecutado);
                cmd.Parameters.AddWithValue("@MontoRestante", nuevoMontoRestante);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                conexionBD.Close();

                MessageBox.Show("Monto actualizado correctamente.");

                // Recargar los datos actualizados
                BuscarActividadModificar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
                conexionBD.Close();
            }

        }


//*******************************************************************************************************

        //CONSULTAR EL PREPUPUESTO DE UNA ACTIVIDAD, CONSULTAR EL POA COMPLETO
        private void ConsultaPOApresupuesto_Click(object sender, EventArgs e)
        {
            // Eliminar columna "Actualizar" si existe
            if (dataGridView2.Columns.Contains("btnActualizar"))
                dataGridView2.Columns.Remove("btnActualizar");

            // Eliminar columna "Eliminar" si existe
            if (dataGridView2.Columns.Contains("btnEliminar"))
                dataGridView2.Columns.Remove("btnEliminar");

            conexionBD.Open();

            string textoBusqueda = textBoxActividadModificar.Text.Trim();
            string consulta;

            bool esNumero = int.TryParse(textoBusqueda, out int idBuscado);

            if (esNumero)
            {
                // Buscar solo por ID exacto
                consulta = @"SELECT * FROM poa.TablaPOAcompleto 
                 WHERE MontoEjecutado > 0 
                   AND Id = @id";
            }
            else
            {
                // Buscar por coincidencia parcial con LIKE
                consulta = @"SELECT * FROM poa.TablaPOAcompleto 
                 WHERE MontoEjecutado > 0 
                   AND `ACTIVIDADES-POA` LIKE @texto";
            }


            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);

            // Parámetros según tipo
            if (esNumero)
            {
                comando.Parameters.AddWithValue("@id", idBuscado);
            }
            else
            {
                comando.Parameters.AddWithValue("@texto", "%" + textoBusqueda + "%");

            }

            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            dataGridView2.DataSource = tabla;
            conexionBD.Close();


        }

        //CONSULTA PRESUPUESTO EJECUTADO BUSCAR UNA ACTIVIDAD ESPECIFICA
        private void MostrarReportadasPresupuesto_Click(object sender, EventArgs e)
        {
            // CONSULTA DE ACTIVIDADES CON MontoEjecutado > 0

            // Eliminar columna "Actualizar" si existe
            if (dataGridView2.Columns.Contains("btnActualizar"))
                dataGridView2.Columns.Remove("btnActualizar");

            // Eliminar columna "Eliminar" si existe
            if (dataGridView2.Columns.Contains("btnEliminar"))
                dataGridView2.Columns.Remove("btnEliminar");

            // Consulta modificada: solo registros con MontoEjecutado > 0
            string consulta = "SELECT * FROM TablaPOAcompleto WHERE MontoEjecutado > 0";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            // Mostrar resultados en el DataGridView
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

