using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaOptica.DATOS
{
    internal class ClsProductos
    {
        private ConexionDB Conexion = new ConexionDB();//Instanciamos a la clase conexion
        private SqlCommand Comando = new SqlCommand();//llamamos a SqlCommand para ejecutar instrucciones SQL
        private SqlDataReader LeerFila;//Ejecuta las sentencias y lee las filas

        public DataTable ListarCategorias()//Metodo llamado DataTable para listar tabla categorias
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion(); //Se abre la conexion con SqlCommandConection
            Comando.CommandText = "ListarCategorias";//con procedimiento almacenado es mejor el tiempo de respuesta
            Comando.CommandType = CommandType.StoredProcedure;//Si se hace con sentencia TransSQL esta fila se omite
            LeerFila = Comando.ExecuteReader();
            Tabla.Load(LeerFila);//Aqui se carga la tabla con los datos que obtuvo "SqlDataReader LeerFila"
            LeerFila.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarOrden()//Metodo llamado DataTable para listar tabla categorias
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion(); //Se abre la conexion con SqlCommandConection
            Comando.CommandText = "ListarOrden";//con procedimiento almacenado es mejor el tiempo de respuesta
            Comando.CommandType = CommandType.StoredProcedure;//Si se hace con sentencia TransSQL esta fila se omite
            LeerFila = Comando.ExecuteReader();
            Tabla.Load(LeerFila);//Aqui se carga la tabla con los datos que obtuvo "SqlDataReader LeerFila"
            LeerFila.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarProductos(int idCategoria, int idOrden, string descripcion, double precio)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idcategoria", idCategoria); //Agregamos valores a los parametros del procedimiento
            Comando.Parameters.AddWithValue("@idorden", idOrden);
            Comando.Parameters.AddWithValue("@descripcion", descripcion);
            Comando.Parameters.AddWithValue("@prec", precio);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public DataTable ListarProductos()//Metodo llamado DataTable para listar tabla categorias
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion(); //Se abre la conexion con SqlCommandConection
            Comando.CommandText = "ListarProductos";//con procedimiento almacenado es mejor el tiempo de respuesta
            Comando.CommandType = CommandType.StoredProcedure;//Si se hace con sentencia TransSQL esta fila se omite
            LeerFila = Comando.ExecuteReader();
            Tabla.Load(LeerFila);//Aqui se carga la tabla con los datos que obtuvo "SqlDataReader LeerFila"
            LeerFila.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EditarProductos(int idCategoria, int idOrden, string descripcion, double precio, int idprod)//Declaramos parametros para todos los campos de la tabla productos
        {
            //Abrimos la coneccion 
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update PRODUCTOS set IDCATEGORIA="+idCategoria+",IDORDEN=" + idOrden + "DESCRIPCION='" + descripcion + "',PRECIO=" + precio + "where IDPROD=" + idprod;
            Comando.CommandType = CommandType.Text;//Especificamos que el comando es de tipo texto
            Comando.ExecuteNonQuery();//Ejecutamos la instruccion con "ExecuteNonQuery"
            Conexion.CerrarConexion();
        }

        public void EliminarProducto(int idprod)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete PRODUCTOS where IDPROD=" + idprod;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
