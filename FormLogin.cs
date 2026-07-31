using System;
using System.Windows.Forms;
using Auth0.OidcClient; // Asegúrate de instalar el paquete NuGet Auth0.OidcClient.WinForms
//using Auth0.OidcClient;using Auth0.OidcClient;
namespace SisPlan0401
{
    public partial class FormLogin : Form
    {
        private Auth0Client _auth0Client;

        // Propiedades públicas para pasar la información del usuario autenticado a la pantalla principal
        public string UsuarioNombre { get; private set; }
        public string AccessToken { get; private set; }

        public FormLogin()
        {
            InitializeComponent();

            // Configuración con tu App de tipo NATIVE en Auth0
            var options = new Auth0ClientOptions
            {
                Domain = "ingenieria-software-2.us.auth0.com",
                ClientId = "Iz8RVmi515cjCm6sHN8awVEkfyxqo6U6" // Client ID de tu App Native
            };

            _auth0Client = new Auth0Client(options);
        }

        //private async void btnLogin_Click(object sender, EventArgs e)
        //{
        //    btnLogin.Enabled = false;

        //    try
        //    {
        //        // Abre el navegador predeterminado para el Universal Login de Auth0
        //        var loginResult = await _auth0Client.LoginAsync();

        //        if (loginResult.IsError)
        //        {
        //            MessageBox.Show(
        //                $"Error al iniciar sesión: {loginResult.ErrorDescription}",
        //                "Error de Autenticación",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //            btnLogin.Enabled = true;
        //            return;
        //        }

        //        // Guardamos los datos de la sesión
        //        UsuarioNombre = loginResult.User.Identity.Name;
        //        AccessToken = loginResult.AccessToken;

        //        MessageBox.Show(
        //            $"¡Bienvenido {UsuarioNombre}!",
        //            "Inicio de Sesión Exitoso",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);

        //        // Marcamos que el Login fue OK para cerrar esta ventana y abrir PantallaPrincipal
        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Excepción al conectar: {ex.Message}");
        //        btnLogin.Enabled = true;
        //    }
        //}

        // private void btnLogin_Click_1(object sender, EventArgs e)
        // {
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;

            try
            {
                var options = new Auth0ClientOptions
                {
                    Domain = "ingenieria-software-2.us.auth0.com",
                    ClientId = "Iz8RVmi515cjCm6sHN8awVEkfyxqo6U6",
                    // Agregamos explícitamente la Callback URL registrada en Auth0:
                    /* // RedirectUri = "http://localhost/callback" */
                    RedirectUri = "http://127.0.0.1:7001/callback",
                    Scope = "openid profile email",
                    // ASIGNAR NAVEGADOR DEL SISTEMA PARA CAPTURAR LA RESPUESTA
                    //Browser = new Auth0.OidcClient.SystemBrowser()
                    //Browser = new AutoSelectBrowser()
                };

                var client = new Auth0Client(options);

                var loginResult = await client.LoginAsync();

                if (loginResult.IsError)
                {
                    MessageBox.Show($"Error: {loginResult.ErrorDescription}", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = true;
                    return;
                }

                MessageBox.Show($"¡Bienvenido {loginResult.User.Identity.Name}!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}");
                btnLogin.Enabled = true;
            }
        }
    }
    }
