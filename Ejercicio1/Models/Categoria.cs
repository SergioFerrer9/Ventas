using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Ejercicio1.Models
{
    public class Categoria
    {
        public int categoriaID { get; set; }
        public string categoriaNombre { get; set; }
        public string descripcionCategoria { get; set; }
        public string imagenCategoria { get; set; }
        
    }
}