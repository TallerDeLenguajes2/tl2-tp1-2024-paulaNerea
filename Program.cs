using System;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear clientes
        Cliente cliente1 = new Cliente("Juan Pérez", "Av. Siempre Viva 742", "555-1234", "Frente a la plaza");
        Cliente cliente2 = new Cliente("Ana Gómez", "Calle Falsa 123", "555-5678", "Junto al parque");

        // Crear pedidos
        Pedido pedido1 = new Pedido(1, "Entrega urgente", cliente1.Nombre, cliente1.Direccion, cliente1.Telefono, cliente1.DatosReferenciaDireccion);
        Pedido pedido2 = new Pedido(2, "Pedido estándar", cliente2.Nombre, cliente2.Direccion, cliente2.Telefono, cliente2.DatosReferenciaDireccion);

        // Crear cadetes
        Cadete cadete1 = new Cadete(1, "Carlos Díaz", "Calle Mayor 45", "555-9012");
        Cadete cadete2 = new Cadete(2, "Laura Sánchez", "Calle Secundaria 67", "555-3456");

        // Crear cadetería
        Cadeteria cadeteria = new Cadeteria("Cadetería Central", "555-7890");

        // Agregar cadetes a la cadetería
        cadeteria.AgregarCadete(cadete1);
        cadeteria.AgregarCadete(cadete2);

        // Asignar pedidos a cadetes
        cadeteria.AsignarPedido(cadete1, pedido1);
        cadeteria.AsignarPedido(cadete2, pedido2);

        // Mostrar información de los cadetes
        Console.WriteLine("Lista de Cadetes:");
        cadeteria.MostrarTodosLosCadetes();

        // Mostrar información de los pedidos
        Console.WriteLine("\nDetalles del Pedido 1:");
        pedido1.VerDatosCliente();
        Console.WriteLine($"Estado del Pedido 1: {pedido1.Estado}");

        Console.WriteLine("\nDetalles del Pedido 2:");
        pedido2.VerDatosCliente();
        Console.WriteLine($"Estado del Pedido 2: {pedido2.Estado}");

        // Cambiar el estado del pedido 1
        cadeteria.CambiarEstadoPedido(pedido1, EstadoPedido.Entregado);

        // Mostrar el estado actualizado del pedido 1
        Console.WriteLine("\nEstado actualizado del Pedido 1:");
        Console.WriteLine($"Estado del Pedido 1: {pedido1.Estado}");

        // Mostrar la cantidad de pedidos de cada cadete y su jornal
        Console.WriteLine("\nJornal a Cobrar de los Cadetes:");
        Console.WriteLine($"Jornal de {cadete1.Nombre}: {cadete1.JornalACobrar()}");
        Console.WriteLine($"Jornal de {cadete2.Nombre}: {cadete2.JornalACobrar()}");

        // Eliminar un pedido
        cadeteria.QuitarPedido(cadete1, pedido1);

        // Mostrar información después de eliminar el pedido
        Console.WriteLine("\nDespués de eliminar el Pedido 1:");
        Console.WriteLine($"Total de pedidos de {cadete1.Nombre}: {cadete1.TotalPedidos()}");
    }
}


//Cadeteria cadeteria = new Cadeteria("Mi Cadeteria", "12345");



/*
while (true)
{
    Console.WriteLine("\n---Sistema de Gestión de Pedidos");
    Console.WriteLine("1. Dar de Alta un Pedido");
    Console.WriteLine("2. Asignar un Pedido a un Cadete");
    Console.WriteLine("3. Cambiar el Estado de un Pedido");
    Console.WriteLine("4. Reasignar Pedido a Otro Cadete");
    Console.WriteLine("5. Salir");
    
    int opcion = ObtenerOpcion();

    switch (opcion)
    {
        
        default:
    }
}

static int ObtenerOpcion()
        {
            int opcion;
            while (true) //hasta que se ingrese una opcion valida
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 5) //int.TryParse convierte la entrada del usuario (cadena de texto) a un número entero (int).
                {                                                                               //Devuelve true si la conversión es exitosa, y almacena el resultado en la variable opcion. Si falla, opcion no se actualiza.
                    return opcion;
                }
                Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 5.");
            }
        }
*/