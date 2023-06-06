using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaOptica.DATOS;

namespace SistemaOptica.PRESENTACION
{
    public partial class PRODUCTOS : Form
    {
        public PRODUCTOS()
        {
            InitializeComponent();
        }

        ClsProductos objProducto = new ClsProductos(); //Para mostrar los datos es necesario instanciar la clase productos en cada metodo para actualizar la vista cada vez que ocurre un cambio
        //Para agregar y editar un registro solo se utilizara un boton, por lo que se creara una variable para gaurdar que operacion se esta realizando
        string Operacion = "Insertar";
        string idprod;
        private void PRODUCTOS_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarOrden();
            ListarProductos();
        }

        private void ListarCategorias() //Metodo vacio para listar categorias
        { //Instanciamos a la clase producto de la capa de datos
            ClsProductos objProd = new ClsProductos();
            cmbCategoria.DataSource = objProd.ListarCategorias();
            cmbCategoria.DisplayMember = "CATEGORIA"; //El displaymember del combobox sera igual a la columna categoria de la base de datos 
            cmbCategoria.ValueMember = "IDCATEG"; //El valuemember del combobox sera igual a la columna "IDCATEG". La propiedad valuemember es el valor real que tendra el combobox
        }
        private void ListarOrden()
        {
            ClsProductos objPro = new ClsProductos();
            cmbOrden.DataSource = objPro.ListarOrden();
            cmbOrden.DisplayMember = "ORDEN";
            cmbOrden.ValueMember = "IDORDEN";
        }
        private void ListarProductos() //Creamos un metodo para listar los productos
        {
            ClsProductos objPro = new ClsProductos();
            dataGridView1.DataSource = objPro.ListarProductos(); //Para mostrar los datos es necesario instanciar en el mismo metodo, esto para actualizar la vista en cada cambio 
        }
        private void LimpiarFormulario()
        {
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Para sentencias insert, delete, y update se recomienda instanciar una vez.
            if (Operacion == "Insertar")
            {
                objProducto.InsertarProductos(Convert.ToInt32(cmbCategoria.SelectedValue), 
                    Convert.ToInt32(cmbOrden.SelectedValue), 
                    txtDescripcion.Text, 
                    Convert.ToDouble(txtPrecio.Text));//Se necesita convertir el combobox a entero ya que el tipo de dato en la clase producto y en la base es entero
                MessageBox.Show("Insertado correctamente");
            }
        
            ListarProductos(); //Llamamos desde el evento del boton agregar para actualizar la vista cada vez que se agregue un registro
            LimpiarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                cmbOrden.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                idprod = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();  //Asignamos a "idprod" el valor de la columna "idproducto"
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objProducto.EliminarProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                MessageBox.Show("Se elimino correctamente");
                ListarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
