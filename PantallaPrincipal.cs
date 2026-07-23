using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisPlan0401
{
    public partial class PantallaPrincipal : Form
    {
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
    }
}
