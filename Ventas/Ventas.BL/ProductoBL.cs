using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.BL
{
    public class ProductoBL
    {
        public  List<Producto>  ListadeProductos { get; set; }

        public ProductoBL()
        {
            ListadeProductos = new List<Producto>();
            Producto producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "iphone";
            Producto producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "Huawei P30";

            

            ListadeProductos.Add(producto1);
            ListadeProductos.Add(producto2);
            

        }

        public  void    agregar(int id, string descripcion)
        {
            var producto = new Producto();
            producto.Id = id;
            producto.Descripcion = descripcion;

            ListadeProductos.Add(producto);

            
        }
    }
}
