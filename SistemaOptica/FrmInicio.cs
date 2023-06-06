using SistemaOptica.PRESENTACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOptica
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtusuario.Clear();
            txtclave.Clear();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == "Gerente" && txtclave.Text == "admin")
            {
                PRODUCTOS frmInicio = new PRODUCTOS();
                this.Hide();
                frmInicio.Show();
            }
            else
            {
                MessageBox.Show("Los datos ingresados son incorrectos.");
                txtusuario.Clear();
                txtclave.Clear();
            }
        }
    }
}
