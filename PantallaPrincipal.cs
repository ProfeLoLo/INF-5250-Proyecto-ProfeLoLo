using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SisPlan0401.Servicios; // INTEGRACION

namespace SisPlan0401
{
    public partial class PantallaPrincipal : Form
    {
      //  private readonly ServicioDeAutenticacion _authService = new ServicioDeAutenticacion(); //INTEGRACION
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RegistroActividades form = new RegistroActividades();
            form.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PresupuestoActividades form = new PresupuestoActividades();
            form.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ReportesActividades form = new ReportesActividades();
            form.Show();

        }




        //INTEGRACION
        //private async void PantallaPrincipal_Load(object sender, EventArgs e)
        //{
        //    // Mantiene tu formulario deshabilitado mientras valida
        //    this.Enabled = false;

        //    try
        //    {
        //        // Reemplaza con tus credenciales de prueba
        //        //"VJiG7dMxaGVipq71YeshTHJAFCpDR9Ik"

        //        string clientId = "Iz8RVmi515cjCm6sHN8awVEkfyxqo6U6";
        //        //"UN88BR8kAnKy97Jjp8A7hC2d0P_Z02N6SDYPgdJypy5nnoUqT0lsb6YviuFoP32X"
        //        string clientSecret = "z0uCRnxbtfFyhHH1icWh9MWxeQimDNGF05tP6a0q9tc15Ldcdc960OLHd08mOtlD";

        //        // Llamada asíncrona a la API externa
        //        string token = await _authService.ObtenerTokenAsync(clientId, clientSecret);

        //        // Mensaje de confirmación en tiempo de ejecución (Requerido para la prueba)
        //        MessageBox.Show(
        //            $"¡Conexión exitosa con Auth0!\n\nToken recibido:\n{token.Substring(0, 30)}...",
        //            "Verificación de Servicio Externo",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            $"Atención: No se pudo validar el servicio de autenticación.\nDetalle: {ex.Message}",
        //            "Error de Integración",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //    }
        //    finally
        //    {
        //        // Vuelve a habilitar la interfaz para el usuario
        //        this.Enabled = true;
        //    }
        //}


        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            // La pantalla principal ya abre habilitada y segura porque el usuario 
            // se autenticó previamente en el FormLogin.
        }


    }
}
