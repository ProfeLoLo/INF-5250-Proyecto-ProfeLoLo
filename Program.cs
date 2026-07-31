using System;
using System.Windows.Forms;

namespace SisPlan0401
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Instanciar y mostrar la pantalla de Login
            FormLogin loginForm = new FormLogin();

            // 2. Si el login fue exitoso (DialogResult.OK), abrimos PantallaPrincipal
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new PantallaPrincipal());
            }
            else
            {
                // Si cerró la pantalla sin loguearse, la aplicación termina.
                Application.Exit();
            }
        }
    }
}