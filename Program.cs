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
            cadeteria.AgregarCadete(cadete.Id, cadete.Nombre, cadete.Direccion, cadete.Telefono);
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
                    List<string> informe = cadeteria.Informe();
                    foreach (string linea in informe)
                    {
                        Console.WriteLine(linea);
                    }
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

    static int ObtenerNumero(string mensaje)
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                return numero;
            }
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
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
        int nroPedido;
        do
        {

            nroPedido = ObtenerNumero("Ingrese el num del Pedido: ");

            if (cadeteria.YaExiste(nroPedido))
            {
                Console.WriteLine("El número de pedido ya existe. Ingrese un número diferente.");
            }

        }while (cadeteria.YaExiste(nroPedido));
        

        Console.WriteLine("Observacion del Pedido: ");
        string obs = Console.ReadLine();

        cadeteria.AgregarPedido(nroPedido, obs, cliente.Nombre, cliente.Direccion, cliente.Telefono, cliente.DatosReferenciaDireccion);
        
        Console.WriteLine("Pedido Guardado con Exito");
        Console.WriteLine();
    }
    
    static void AsignarPedido(Cadeteria cadeteria)
    {

        int nroPedido = ObtenerNumero("Ingrese el Nro del Pedido: ");

        if (!cadeteria.YaExiste(nroPedido))
        {
            Console.WriteLine("El número de pedido ingresado no existe. Por favor, intente nuevamente.");
            return;
        }

        cadeteria.MostrarTodosLosCadetes();

        int idCadete = ObtenerNumero("Ingrese el ID del Cadete para Asignarle el Pedido: ");
        
        Console.WriteLine(cadeteria.AsignarCadeteAPedido(idCadete, nroPedido)); //ahora es tipo string, falta mostrarla adecuadamente

    }
    
    static void ReasignarPedido(Cadeteria cadeteria)
    {

        int nro = ObtenerNumero("Ingrese el Nro del Pedido que Desea Asignar: ");
        
        Pedido pedido = cadeteria.BuscarPedido(nro);

        if (pedido != null)
        {
            Console.WriteLine("Pedido Encontrado");
            int idCadete = ObtenerNumero("Ingrese el ID del Cadete para Asignarle el Pedido: ");
            
            Cadete nuevoCadete = cadeteria.BuscarCadetePorId(idCadete);
            if (nuevoCadete != null)
            {
                Console.WriteLine(cadeteria.AsignarCadeteAPedido(idCadete, nro)); 
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
        int nroPedido;
        while (!int.TryParse(Console.ReadLine(), out nroPedido))
        {
            Console.WriteLine("Por favor, ingrese un número válido.");
        }

        Console.WriteLine("Ingrese el nuevo estado del pedido (1: Entregado, 2: Cancelado, 3: EnProceso): ");
        int nroEstado;
        while (!(int.TryParse(Console.ReadLine(), out nroEstado) && nroEstado >= 1 && nroEstado <= 3) ) 
        {
            Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 3."); 
        }

        Console.WriteLine(cadeteria.CambiarEstadoPedido(nroPedido, nroEstado));     
        
    }
}
