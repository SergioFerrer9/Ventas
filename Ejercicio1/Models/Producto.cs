using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio1.Models
{
    public class Producto
    {

        public int productID { get; set; }
        public string productName { get; set; }
        public int supplierID { get; set; }
        public int categoryID { get; set; }
        public string quantityPerUnit { get; set; }
        public decimal unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder { get; set; }
        public int reorderLevel { get; set; }
        public string picture { get; set; }



    }
}