using System;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //ruta de los archivos csv
        string rutaCadetes = "csv/cadetes.csv";
        string rutaCadeteria = "csv/cadeteria.csv";

        // Crear cadetería
        Cadeteria cadeteria = CargarDesdeCSV.CargarCadeteria(rutaCadeteria);

        //Crear lista de cadetes
        List<Cadete> cadetes = CargarDesdeCSV.CargarCadetes(rutaCadetes);
        foreach (Cadete cadete in cadetes)
        {
            cadeteria.AgregarCadete(cadete);
        }

        // Mostrar información de los cadetes
        Console.WriteLine("Lista de Cadetes:");
        cadeteria.MostrarTodosLosCadetes();
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