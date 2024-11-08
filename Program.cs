using System;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

class Program
{
    static void Main()
    {
        AccesoADatos accesoADatos;
        string rutaCadetes, rutaCadeteria;

        Console.WriteLine("Seleccione el tipo de acceso a datos:");
        Console.WriteLine("1 - CSV");
        Console.WriteLine("2 - JSON");
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2))
        {
            Console.WriteLine("Opción no válida. Por favor ingrese 1 para CSV o 2 para JSON.");
        }

        if (opcion == 1)
        {
            rutaCadetes = "csv/cadetes.csv";
            rutaCadeteria = "csv/cadeteria.csv";
            accesoADatos = new CargarDesdeCSV();
            
        }else
        {
            rutaCadetes = "json/cadetes.json";
            rutaCadeteria = "json/cadeteria.json";
            accesoADatos = new CargarDesdeJSON();
        }
        
        // Crear cadetería
        Cadeteria cadeteria = accesoADatos.CargarCadeteria(rutaCadeteria);

        //Crear lista de cadetes
        List<Cadete> cadetes = accesoADatos.CargarCadetes(rutaCadetes);
        foreach (Cadete cadete in cadetes)
        {
            cadeteria.AgregarCadete(cadete);
        }

        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            int opcionMenu = ObtenerOpcion();

            switch (opcionMenu)
            {
                case 1:
                    Console.WriteLine("Alta de Pedido");
                    AltaPedidos(cadeteria);
                    break;
                case 2:
                    Console.WriteLine("Asignar Pedido");
                    AsignarPedido(cadeteria);
                    break;
                case 3:
                    Console.WriteLine("Reasignar Pedido");
                    ReasignarPedido(cadeteria);
                    break;
                case 4:
                    Console.WriteLine("Cambiar Estado de un Pedido");
                    CambiarEstado(cadeteria);
                    break;
                case 5:
                    continuar = false;
                    cadeteria.Informe();
                    Console.WriteLine("Saliendo...");
                    break;
                    
            }    
        }
    }
    static void MostrarMenu()
    {   
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       Sistema de Gestión de Pedidos");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("* 1. Alta de Pedido");
        Console.WriteLine("* 2. Asignar Pedido a un Cadete");
        Console.WriteLine("* 3. Reasignar Pedido a Otro Cadete");
        Console.WriteLine("* 4. Cambiar el Estado de un Pedido");
        Console.WriteLine("* 5. Salir");
        Console.WriteLine();

    }
    static int ObtenerOpcion()
    {
        int opcion;
        while (true) //hasta que se ingrese una opcion valida
        {
            Console.WriteLine("Seleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 5) 
            {                                               
                return opcion;
            }
            Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 5.");
        }
    }

    static void AltaPedidos(Cadeteria cadeteria)
    {
        //Creacion del Cliente
        Console.WriteLine("Ingrese los Datos del cliente: ");

        Console.Write("Nombre: ");
        string nombreCliente = Console.ReadLine();

        Console.Write("Direccion: ");
        string direccionCliente = Console.ReadLine();

        Console.Write("Telefono: ");
        string telefonoCliente = Console.ReadLine();

        Console.Write("Datos de Referencia de la Dirección: ");
        string refereciaCliente = Console.ReadLine();

        Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, refereciaCliente);

        //Creacion del Pedido
        Console.WriteLine("Ingrese los Datos del Pedido: ");

        Console.WriteLine("Nro del Pedido: ");
        int nroPedido;

        while (!int.TryParse(Console.ReadLine(), out nroPedido))
        {
            Console.WriteLine("Por favor, ingrese un numero.");
        }

        Console.WriteLine("Observacion del Pedido: ");
        string obs = Console.ReadLine();

        Pedido pedido = new Pedido(nroPedido, obs, cliente.Nombre, cliente.Direccion, cliente.Telefono, cliente.DatosReferenciaDireccion);
        cadeteria.AgregarPedido(pedido);
        Console.WriteLine("Pedido Guardado con Exito");
        Console.WriteLine();
    }
    
    static void AsignarPedido(Cadeteria cadeteria)
    {
        Console.Write("Ingrese el Nro del Pedido: ");
        int nroPedido;

        while (!int.TryParse(Console.ReadLine(), out nroPedido))
        {
            Console.WriteLine("Por favor, ingrese un numero.");
        }

        cadeteria.MostrarTodosLosCadetes();

        Console.Write("Ingrese el Id del Cadete al que desea asignar el pedido: ");
        int idCadete;

        while (!int.TryParse(Console.ReadLine(), out idCadete))
        {
            Console.WriteLine("Por favor, ingrese un numero.");
        }

        cadeteria.AsignarCadeteAPedido(idCadete, nroPedido);

    }
    
    static int ObtenerIdCadete()
    {
        Console.Write("Ingrese el ID del cadete para asignarle el pedido: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }
            Console.WriteLine("Por favor, ingrese un ID válido.");
        }
    }

    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Ingrese el nro del pedido que desea asignar: ");
        int nro;
        while (!int.TryParse(Console.ReadLine(), out nro))
        {
            Console.WriteLine("Por favor, ingrese un numero");
        }
        
        Pedido pedido = cadeteria.BuscarPedido(nro);

        if (pedido != null)
        {
            Console.WriteLine("Pedido Encontrado");
            int idCadete = ObtenerIdCadete();
            
            Cadete nuevoCadete = cadeteria.BuscarCadetePorId(idCadete);
            if (nuevoCadete != null)
            {
                cadeteria.AsignarCadeteAPedido(idCadete, nro);
            }else
            {
                Console.WriteLine("El ID del cadete ingresado no existe. Por favor, intente nuevamente.");
            }

        }else
        {
            Console.WriteLine("El número de pedido ingresado no existe. Por favor, intente nuevamente.");
        }

    }

    static void CambiarEstado(Cadeteria cadeteria)
    {
        Console.WriteLine("Ingrese el nro del pedido al que desea cambiar el estado: ");
        int nro;
        while (!int.TryParse(Console.ReadLine(), out nro))
        {
            Console.WriteLine("Por favor, ingrese un número válido.");
        }

        Pedido pedido = cadeteria.BuscarPedido(nro);
        if (pedido != null)
        {
            EstadoPedido estado;
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine("Ingrese el nuevo estado del pedido (Entregado, Cancelado, EnProceso): ");
                string ingresado = Console.ReadLine();
            
                if (Enum.TryParse(ingresado, true, out estado))
                {
                    cadeteria.CambiarEstadoPedido(pedido, estado);
                    Console.WriteLine($"Estado del pedido {nro} cambiado a {estado}.");
                    valido = true; 
                }else
                {
                    Console.WriteLine("Estado no valido. Intente nuevamente ");
                }
            }
            
        }else
        {
            Console.WriteLine("El pedido no existe.");
        }
    }
}
