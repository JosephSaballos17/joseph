//Trabajo realizado por Joseph Saballos 1m2-S


using System;
using joseph;


namespace joseph
{
    class Program
    {
        public static void Main(string[] args)
        {

            // Creacion del objeto inventario
            Inventario inventario = new Inventario();

            Console.WriteLine("Bienvenido al sistema de inventario");
            Console.WriteLine("Porfavor ingrese:");
            int cantidad;


            //Validacion
            do
            {
                Console.WriteLine("¿De cuanta es la cantidad del producto que desea ingresar?");
                cantidad = int.Parse(Console.ReadLine());
                if (cantidad < 0)
                {
                    Console.WriteLine("Por favor digite un numero positivo.");
                }

            } while (cantidad < 0);




            // Creacion de un ciclo para que el usuario ingrese los produtos

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Producto {i + 1}");
                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();

                decimal precio;
                do
                {
                    Console.WriteLine("Precio:");
                    precio = decimal.Parse(Console.ReadLine());
                    if (precio < 0)
                    {
                        Console.WriteLine("Ingrese un numero Positivo");
                    }

                } while (precio < 0);


                //Creacion del objeto producto 

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            int opc;




            // Ciclo repetitivo para la seleccion de cada una de las opciones 

            do
            {
                // Menu de opciones
                Console.WriteLine(" Por favor seleccione una opción:");
                Console.WriteLine("1 - Actualizacion del precio de un producto");
                Console.WriteLine("2 - Eliminar un producto");
                Console.WriteLine("3 - Filtrar y mostrar los diferentes productos");
                Console.WriteLine("4 - Agrupar productos por precio");
                Console.WriteLine("5 - Salir del programa");
                opc = int.Parse(Console.ReadLine());





                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del producto cuyo precio desea actualizar:");
                        string nombreProducto = Console.ReadLine();

                        decimal nuevoPrecio = 0;


                        do
                        {
                            Console.WriteLine("Ingrese el nuevo precio:");
                            if (nuevoPrecio < 0)
                            {
                                Console.WriteLine("Ingrese un numero Positivo");
                            }

                        } while (nuevoPrecio < 0);

                        if (decimal.TryParse(Console.ReadLine(), out nuevoPrecio))
                        {
                            inventario.ActualizarPrecioProducto(nombreProducto, nuevoPrecio);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido.");
                        }
                        break;





                    case 2:
                        Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
                        string nombreProducto1 = Console.ReadLine();
                        inventario.EliminarProducto(nombreProducto1);
                        break;





                    case 3:
                        Console.WriteLine("Ingrese el precio mínimo para filtrar los productos:");
                        decimal precioMinimo = decimal.Parse(Console.ReadLine());

                        var productoFiltrados = inventario.FiltrarYOrdenarProducto(precioMinimo);

                        Console.WriteLine("\nProductos filtrados y ordenados:");
                        foreach (var producto in productoFiltrados)
                        {
                            Console.WriteLine($"- {producto.Nombre}: {producto.Precio:C}");
                        }
                        break;




                    case 4:

                        decimal precioAgrupar;
                        do
                        {
                            Console.WriteLine("Digite  el precio que desea agrupar los productos:");
                            precioAgrupar = decimal.Parse(Console.ReadLine());
                            if (precioAgrupar < 0)
                            {
                                Console.WriteLine("Digite  un numero Positivo");
                            }
                        } while (precioAgrupar < 0);

                        inventario.AgruparProducto(precioAgrupar);
                        break;






                    case 5:
                        Console.WriteLine("Saliendo del sistema");
                        break;





                    default:
                        Console.WriteLine("la opccion seleccionada es incorrecta");
                        break;
                }

            } while (opc != 5);






            Console.WriteLine("Reporte del inventario:");

            inventario.Resumen();
            Console.WriteLine();
            inventario.ProductoMostrar();


        }
    }
}