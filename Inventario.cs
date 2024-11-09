using joseph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joseph
{
    // Clase Inventario 
    public class Inventario
    {
        private List<Producto> productos;





        // Creacion de la lista de productos 
        public Inventario()
        {
            productos = new List<Producto>();
        }




        // Metodo para agregar productos 
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }




        public IEnumerable<Producto> FiltrarYOrdenarProducto(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);
        }





        public void ActualizarPrecioProducto(string nombre, decimal nuevoPrecio)
        {
            // Buscar el producto por su nombre 
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (producto != null)
            {

                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto '{nombre}' ha sido actualizado a {nuevoPrecio:C}.");
            }
            else
            {

                Console.WriteLine($"No se encontro un producto con el nombre '{nombre}'.");
            }
        }




        //Metodo para eliminar productos 
        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));


            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"El Producto {nombre} ha sido Eliminado del Inventario");

            }
            else
            {
                Console.WriteLine($"Nose encuentra un producto con el nombre: {nombre}");
            }

        }




        //Metodo para agrupar los productos 
        public void AgruparProducto(decimal precio)
        {
            var grupos = productos
                .Where(p => p.Precio > precio)
                .GroupBy(p => p.Precio);

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"Productos con precio: {grupo.Key:C}");

                foreach (var producto in grupo)
                {
                    Console.WriteLine($"  - {producto.Nombre}: {producto.Precio:C}");
                }

                Console.WriteLine();
            }
        }





        //Metodo para elaborar el resumen 
        public void Resumen()
        {
            var productoConPrecioAlto = productos
                .OrderByDescending(p => p.Precio)
                .FirstOrDefault();
            if (productoConPrecioAlto != null)
            {
                Console.WriteLine($"Producto con el precio mas alto: {productoConPrecioAlto.Nombre} - {productoConPrecioAlto.Precio:C}");
            }


            var productoConPrecioBajo = productos
                .OrderBy(p => p.Precio)
                .FirstOrDefault();
            if (productoConPrecioBajo != null)
            {
                Console.WriteLine($"Producto con el precio mas bajo: {productoConPrecioBajo.Nombre} - {productoConPrecioBajo.Precio:C}");
            }


            var precioPromedio = productos.Average(p => p.Precio);
            Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}");
        }





        //Metodo que muestra el nombre y el precio del producto 


        public void ProductoMostrar()
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.Nombre}: {producto.Precio:C}");
            }
        }

        internal void AgregarProducto()
        {
            throw new NotImplementedException();
        }
    }
}
