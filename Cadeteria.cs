public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    private List<Cadete> listadoCadetes { get; set; }
    
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }

    public void QuitarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public void AsignarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.AgregarPedido(pedido);
        
    }

    public void QuitarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.QuitarPedido(pedido);
    }

    public Pedido BuscarPedido(int num)
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            Pedido encontrado = cadete.BuscarPedidoPorNum(num);
            if (encontrado != null)
            {
                return encontrado;
            }
        }
        return null; 
    }

    public void CambiarEstadoPedido(Pedido pedido, EstadoPedido nuevo)
    {
        if (pedido != null)
        {
            pedido.CambiarEstado(nuevo);
            Console.WriteLine("Se cambio el estado del pedido");
        }else
        {
            Console.WriteLine("El pedido no es valido");
        }
    }

    public Cadete BuscarCadetePorId(int id)
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            if (cadete.Id == id)
            {
                return cadete;
            }
        }
        return null;
    }

    public Cadete BuscarCadetePorPedido(Pedido pedido)
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            if (cadete.TienePedido(pedido.NroPedido)) 
            {
                return cadete; 
            }
        }
        return null; 
    }

    public void MostrarTodosLosCadetes()
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            cadete.ImprimirInformacion();
        }
    }

    public void Informe()
    { 
        Console.WriteLine("--- Informe Final ---");
        int totalEnvios = listadoCadetes.Sum(cadete => cadete.TotalPedidos());
        int montoTotal = listadoCadetes.Sum(cadete => cadete.JornalACobrar());

        foreach (Cadete cadete in listadoCadetes)
        {
            int cantEnvios = cadete.TotalPedidos();
            int montoCobrar = cadete.JornalACobrar();
            
            Console.WriteLine($"{cadete.Nombre} - Envios: {cantEnvios} - Monto Ganado: {montoCobrar}");
        }

        double promedio = totalEnvios > 0 ? (double)totalEnvios / listadoCadetes.Count : 0; 
        Console.WriteLine($"Envios Promedio Por Cadete: {promedio} - Total Ganado: {montoTotal}");
    }
}