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
    public partial class RegistroActividades : Form
    {
//*****************************************************************************************************
        //CONEXION A LA BASE DE DATOS LOCAL

        //conexion de base de datos con base de datos en la computadora con MySql 
        static string CadenaParaConetarBD = "server = 127.0.0.1; database = poa; user id =  root; password =Elprofe-Programador6663";// integrated security = true";
        MySqlConnection conexionBD = new MySqlConnection(CadenaParaConetarBD);

        public RegistroActividades()
        {
            InitializeComponent();
        }

  //************************************************************************************************
        //CARGAR LOS DATOS EN EL DATAGRIDVIEW1
        private void AgregaDato_Click(object sender, EventArgs e)
        {

            string descripcionActividad = dataGridView1.Rows[0].Cells[0].Value.ToString(); //para guardar en1 BD actividad cargada en datagridview

            // Leer actividad previamente cargada (si existe)
            string descripcionActividad2 = string.Empty;
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[0].Cells[0].Value != null)
            {
                descripcionActividad = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }

            // Limpiar completamente el DataGridView (incluye filas y columnas)
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Crear columnas (siempre desde cero)
            dataGridView1.Columns.Add("DescripcionActividad", "Descripción actividad");
            dataGridView1.Columns.Add("UnidadResponsable", "Unidad responsable");
            dataGridView1.Columns.Add("NivelArea", "Nivel o área");
            dataGridView1.Columns.Add("Participantes", "Cantidad de participantes impactados");
            dataGridView1.Columns.Add("Involucrados", "Cantidad de involucrados e invitados");
            dataGridView1.Columns.Add("Trimestre", "Trimestre de ejecución");

            // Agregar una sola fila con todos los datos juntos
            dataGridView1.Rows.Add(
                descripcionActividad,
                comboBox1.Text,
                comboBox2.Text,
                textBoxParticipantes.Text,
                textBoxInvolucrados.Text,
                comboBox3.Text
            );

            // Ajustar columnas
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar 3 filas vacías
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows.Add();
            }


            label5.Visible = false;
            label6.Visible = false;


            //Abrir la base de datos
            conexionBD.Open();

            //GUARDAR LOS VALORES CAPTURADOS (CARGADO EN EL DATAGRIDVIEW) EN LA BASE DE DATOS


            string InsertaValoresBD = "INSERT INTO `actividadespoa` (`Id`, `DescripcionActividad`, `Unidad`, `Area`, `Participantes`, `Involucrados`, `Trimestre`) VALUES (NULL, '" + descripcionActividad + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + textBoxParticipantes.Text + "', '" + textBoxInvolucrados.Text + "', '" + comboBox3.Text + "')";

            MySqlCommand comandoInsertar = new MySqlCommand(InsertaValoresBD, conexionBD);

            comandoInsertar.ExecuteNonQuery();


            //Cerrar la base de datos
            conexionBD.Close();

            //limpiar las cajas de texto

            textBoxActividad.Clear();
            textBoxParticipantes.Clear();
            textBoxInvolucrados.Clear();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.SelectedIndex = 1;
            }
        }

//***************************************************************************************************

        //ELEGIR NIVELES Y AREAS AL MOMENTO DE REGISTRAR UNA ACTIVIDAD REALIZADA
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // DATOS PARA UNIDAD CURRICULAR AL ELEGIR UNA OPCION EN EL COMBOBOX
            DataTable Curricular = new DataTable();
            Curricular.Columns.Add("Niveles");

            DataRow dato = Curricular.NewRow();
            dato["Niveles"] = "Inicial";
            Curricular.Rows.Add(dato);

            DataRow dato2 = Curricular.NewRow();
            dato2["Niveles"] = "Primario";
            Curricular.Rows.Add(dato2);


            DataRow dato3 = Curricular.NewRow();
            dato3["Niveles"] = "Secundario";
            Curricular.Rows.Add(dato3);

            DataRow dato4 = Curricular.NewRow();
            dato4["Niveles"] = "Subsistema de adultos";
            Curricular.Rows.Add(dato4);

            DataRow dato5 = Curricular.NewRow();
            dato5["Niveles"] = "Orientación y psicología";
            Curricular.Rows.Add(dato5);

            DataRow dato6 = Curricular.NewRow();
            dato6["Niveles"] = "Equidad de genero";
            Curricular.Rows.Add(dato6);

            DataRow dato7 = Curricular.NewRow();
            dato7["Niveles"] = "Gestión de riesgo";
            Curricular.Rows.Add(dato7);

            DataRow dato8 = Curricular.NewRow();
            dato8["Niveles"] = "Depto. TIC";
            Curricular.Rows.Add(dato8);

            DataRow dato9 = Curricular.NewRow();
            dato9["Niveles"] = "Huertos escolares";
            Curricular.Rows.Add(dato9);

            DataRow dato10 = Curricular.NewRow();
            dato10["Niveles"] = "Atención a la diversidad";
            Curricular.Rows.Add(dato10);



            // DATOS PARA UNIDAD DE PLANIFICACION
            DataTable Planificacion = new DataTable();
            Planificacion.Columns.Add("Areas1");
            DataRow datoPlani = Planificacion.NewRow();
            datoPlani["Areas1"] = "Analistas/Encargado";
            Planificacion.Rows.Add(datoPlani);

            DataRow datoPlani2 = Planificacion.NewRow();
            datoPlani2["Areas1"] = "SIGERD";
            Planificacion.Rows.Add(datoPlani2);


            // DATOS PARA UNIDAD DE DESCENTRALIZACION
            DataTable Descentralizacion = new DataTable();
            Descentralizacion.Columns.Add("Areas1");
            DataRow datoDescentra = Descentralizacion.NewRow();
            datoDescentra["Areas1"] = "Participacion Comunitaria";
            Descentralizacion.Rows.Add(datoDescentra);

            DataRow datoDescentra2 = Descentralizacion.NewRow();
            datoDescentra2["Areas1"] = "Descentralizacion";
            Descentralizacion.Rows.Add(datoDescentra2);


            // DATOS PARA UNIDAD ADMINISTRATIVA
            DataTable Administrativa = new DataTable();
            Administrativa.Columns.Add("Areas1");

            DataRow DatoAdministra1 = Administrativa.NewRow();
            DatoAdministra1["Areas1"] = "Recursos Humanos";
            Administrativa.Rows.Add(DatoAdministra1);

            DataRow DatoAdministra2 = Administrativa.NewRow();
            DatoAdministra2["Areas1"] = "Contabilidad";
            Administrativa.Rows.Add(DatoAdministra2);

            DataRow DatoAdministra3 = Administrativa.NewRow();
            DatoAdministra3["Areas1"] = "Compras y eventos";
            Administrativa.Rows.Add(DatoAdministra3);

            DataRow DatoAdministra4 = Administrativa.NewRow();
            DatoAdministra4["Areas1"] = "Director distrital";
            Administrativa.Rows.Add(DatoAdministra4);

            DataRow DatoAdministra5 = Administrativa.NewRow();
            DatoAdministra5["Areas1"] = "Director adjunto";
            Administrativa.Rows.Add(DatoAdministra5);


            // DATOS PARA UNIDAD DE SUPERVISIÓN
            DataTable Supervision = new DataTable();
            Supervision.Columns.Add("Areas1");

            DataRow DatoSupervision1 = Supervision.NewRow();
            DatoSupervision1["Areas1"] = "REDIC";
            Supervision.Rows.Add(DatoSupervision1);

            DataRow DatoSupervision2 = Supervision.NewRow();
            DatoSupervision2["Areas1"] = "CAF-PRECE";
            Supervision.Rows.Add(DatoSupervision2);

            DataRow DatoSupervision3 = Supervision.NewRow();
            DatoSupervision3["Areas1"] = "SISMAP";
            Supervision.Rows.Add(DatoSupervision3);

            DataRow DatoSupervision4 = Supervision.NewRow();
            DatoSupervision4["Areas1"] = "Colegios Privados";
            Supervision.Rows.Add(DatoSupervision4);

            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.DataSource = Curricular;
                comboBox2.DisplayMember = "Niveles";
            }
            else

               if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.DataSource = Planificacion;
                comboBox2.DisplayMember = "Areas1";
            }

            else

               if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = Descentralizacion;
                comboBox2.DisplayMember = "Areas1";
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.DataSource = Supervision;
                comboBox2.DisplayMember = "Areas1";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.DataSource = Administrativa;
                comboBox2.DisplayMember = "Areas1";
            }
        }

     

    
//********************************************************************************************************

        //BUSCAR UNA ACTIVIDAD EN EL POA CUANDO SE VA A REGISTRAR COMO REALIZADA Y CARGARLA AL DATAGRIDVIEW1

        //Se esta reutilizando este metodo, deberia tener otro nombre porque este busca en la tabla del POA no en la tabla de actividades realizadas
        private void BuscaActividadRealizada_Click(object sender, EventArgs e)
        {
            conexionBD.Open();

            string cadena = "%" + textBoxActividad.Text + "%";
            string consulta = "SELECT `ACTIVIDADES-POA` AS `Descripción Actividad` FROM poa.TablaPOAcompleto WHERE `ACTIVIDADES-POA` LIKE @actividad";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
            comando.Parameters.AddWithValue("@actividad", cadena);

            MySqlDataAdapter data = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            // Mostrar en el primer DataGridView
            dataGridView1.DataSource = tabla;

            // Ajustar automáticamente el ancho de la(s) columna(s) al contenido
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            conexionBD.Close();
        }

        //PROCESO PARA ELEGIR UNA ACTIVIDAD DE LA CARGADAS AL DATAGRIDVIEW1 DE ACUERDO A LA BUSQUEDA DEL CODIGO ANTERIOR
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
          {
                // Obtener el valor de la celda seleccionada
                object valorSeleccionado = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Desvincular el DataSource si estaba enlazado
                dataGridView1.DataSource = null;

                // Limpiar columnas y filas
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Definir encabezados personalizados
                string[] encabezados = new string[]
                {
            "Descripción actividad",
            "Unidad responsable",
            "Nivel o área",
            "Cantidad de participantes impactados",
            "Cantidad de involucrados e invitados",
            "Trimestre de ejecución"
                };

                // Crear columnas con encabezados
                dataGridView1.ColumnCount = encabezados.Length;
                for (int i = 0; i < encabezados.Length; i++)
                {
                    dataGridView1.Columns[i].Name = encabezados[i];
                }


                // Colocar el valor seleccionado en la primera celda [0,0]
                dataGridView1.Rows[0].Cells[0].Value = valorSeleccionado?.ToString();

                label5.Visible = true;
                label6.Visible = true;
          }
        }

//*********************************************************************************************************


        }

}

