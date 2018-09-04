using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejercicio1.Canexion;
using System.Data;
using Ejercicio1.Models;
using System.Data.SqlClient;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {

            ConexionBD conexion = new ConexionBD();
            string ss = conexion.CrearConexion();
            return Json(ss, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// listado de las Categorias.
        /// </summary>
        /// <returns> Retorna una lista de tipo categorias.</returns>
     /*   public ActionResult Index(int miCategoria=0, int ProductoSelecionado=0)
        {
            ///Obtener las Categorias.
            ConexionBD conexion = new ConexionBD();
            DataTable resultado = new DataTable();
            string consutaCategorias = "SELECT * FROM Categories";
            resultado = conexion.ObtenerTabla(consutaCategorias);
            List<Categoria> listaCategorias = new List<Categoria>();
            foreach (DataRow fila in resultado.Rows)
            {
                Categoria categoria = new Categoria();
                categoria.categoriaID = Convert.ToInt32(fila["CategoryID"]);
                categoria.categoriaNombre = Convert.ToString(fila["CategoryName"]);
                categoria.descripcionCategoria = Convert.ToString(fila["Description"]);
                categoria.imagenCategoria = Convert.ToString(fila["Imagen"]);
                listaCategorias.Add(categoria);
            }

            ///Obtener los Productos.
            if(miCategoria==0){
                miCategoria = 1;
            }
        
            DataTable resultadoProducto = new DataTable();
            string consultaProductos = "SELECT * FROM Products WHERE CategoryID="+miCategoria;
            resultadoProducto = conexion.ObtenerTabla(consultaProductos);
            List<Producto> listaProductos = new List<Producto>();
            foreach(DataRow fila in resultadoProducto.Rows)
            {
                Producto producto = new Producto();
                producto.productID = Convert.ToInt32(fila["ProductID"]);
                producto.productName = Convert.ToString(fila["ProductName"]);
                producto.categoryID = Convert.ToInt32(fila["CategoryID"]);
                producto.unitPrice = Convert.ToDecimal(fila["UnitPrice"]);
                producto.picture=Convert.ToString(fila["Picture"]);
                listaProductos.Add(producto);
            }

            ///Obtener la Descripcion del Producto.
            ///

            int productoMostrar;
            if (ProductoSelecionado == 0)
            {
                productoMostrar = listaProductos[0].productID;
            }
            else {
                productoMostrar = ProductoSelecionado;
            }

            Producto miProducto = listaProductos.Where(prod => prod.productID == productoMostrar).FirstOrDefault();

            Categoria detalleCategoria = listaCategorias.Where(prode => prode.categoriaID == miCategoria).FirstOrDefault();
            ViewData["Producto"]= listaProductos;
            ViewData["Detalle"] = miProducto;
            ViewData["DetalleCategoria"] = detalleCategoria;

            
            return View(listaCategorias);                     

        }
      */

        /// <summary>
        /// Agregar una nueva orden a la Tabla Orden a la Base de datos.
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <param name="producto"></param>
        /// <param name="categoria"></param>
        /// <param name="descripcion"></param>
        /// <returns>retorna a la vista Index </returns>
        public ActionResult AregarOrden(int categoriaId = 0, string producto = null, string categoria = null, string descripcion = null, int productoId = 0, double precioUnitario = 0, int cantidad=0, int total=0) 
        {
            if(categoriaId>0)
            {
                ConexionBD stringDeConexion = new ConexionBD();
                try
                {
                    SqlConnection conexion = new SqlConnection(stringDeConexion.CrearConexion());

                    conexion.Open();
                    SqlCommand query = new SqlCommand("EXEC spr_agregarOrden @categoriaId, @producto, @categoria, @descripcion", conexion);
                    query.Parameters.AddWithValue("@categoriaId", categoriaId);
                    query.Parameters.AddWithValue("@producto", producto);
                    query.Parameters.AddWithValue("@categoria", categoria);
                    query.Parameters.AddWithValue("@descripcion", descripcion);
                    query.ExecuteNonQuery();

                    SqlCommand query2 = new SqlCommand("EXEC spr_agregarOrdenDetalle @productoId, @precioUnitario, @cantidad, @total", conexion);
                    query2.Parameters.AddWithValue("@productoId", productoId);
                    query2.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                    query2.Parameters.AddWithValue("@cantidad", cantidad);
                    query2.Parameters.AddWithValue("@total", total);
                    query2.ExecuteNonQuery();
                    conexion.Close();

                }
                catch (InvalidOperationException)
                {

                    return RedirectToAction("Index", "Home");
                }

            }

            return RedirectToAction("Index", "Home");
            
        }

  
        
       
    }
}
