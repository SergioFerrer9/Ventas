using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data;



namespace Ejercicio1.Canexion
{
    public class ConexionBD
    {
        ///String de Cadena de Conexion.
        private string stringConexion = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
   
        /// <summary>
        /// Metodo para Obtener el String de Conexion.
        /// </summary>
        /// <returns> Retorna un String con la Conexion.</returns>
        public String CrearConexion() 
        {                    

            return stringConexion;

        }

        /// <summary>
        /// Obtener la Tabla de Categorias
        /// </summary>
        /// <param name="ObtenerConsulta"></param>
        /// <returns>Retorna un DataTable con la tabla Categorias.</returns>
        public DataTable ObtenerTabla(string ObtenerConsulta) 
        { 
            using(SqlConnection conexionBD = new SqlConnection(stringConexion))
            {
                try
                {
                    conexionBD.Open();
                    DataTable resultado = new DataTable();
                    SqlCommand comando = new SqlCommand(ObtenerConsulta, conexionBD);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(resultado);
                    return resultado; 
                }
                catch(SqlException s)
                {
                    throw s;
                }                        
            
            }     
      
        }    
 

    }

}